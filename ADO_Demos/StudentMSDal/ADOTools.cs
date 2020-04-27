using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;

namespace StudentMSAdo
{
    public class ADOTools
    {
        //操作数据库的API

        ///<remarks>数据库连接字符串(两种方法)
        /// Configuration方式：
        /// public static readonly string CONNECTION_STR = ConfigurationManager.ConnectionStrings["connStr"].ToString();
        ///
        /// 普通字符串方式
        /// public static string CONNECTION_STR = "server=.;database=student;uid=sa;pwd=123456";
        /// </remarks>

        //已使用的数据库连接字符串
        public static string connstr = ConfigurationManager.ConnectionStrings["connStr"].ToString();

        /// <summary>
        /// 数据增删改方法
        /// </summary>
        /// <param name="sql">T-SQL语句</param>
        /// <param name="param">参数数组</param>
        /// <returns>返回受影响行数</returns>
        public static int ExecuteNonQuery(string sql, SqlParameter[] param)
        {
            //创建连接
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (param != null) //当我们传递的参数不为空,进行赋值
                    {
                        cmd.Parameters.AddRange(param);
                    }

                    try
                    {
                        conn.Open(); //打开连接
                        return cmd.ExecuteNonQuery(); //执行命令,返回受影响行数
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }

        }


        /// <summary>
        /// SqlDataAdapter 数据填充查询方法
        /// </summary>
        /// <param name="sql">T-SQL语句</param>
        /// <param name="param">参数数组</param>
        /// <returns>返回系统临时内存表</returns>
        public static DataTable Query(string sql, SqlParameter[] param)
        {
            using (SqlDataAdapter sda = new SqlDataAdapter(sql, connstr))
            {
                if (param != null)
                {
                    sda.SelectCommand.Parameters.AddRange(param);
                }
                DataTable dt = new DataTable(); //创建系统虚表
                sda.Fill(dt); // 把查询出来的数据填充到系统虚表当中
                return dt; //返回系统虚表
            }

        }

        /// <summary>
        /// 查询数据个数
        /// </summary>
        /// <param name="sql">T-SQL语句</param>
        /// <param name="param">参数数组</param>
        /// <returns>数量</returns>
        public static object ExecuteScalar(string sql, SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }

                    try
                    {
                        conn.Open();
                        return cmd.ExecuteScalar();//执行之后得到我们查询的值
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }


        /// <summary>
        /// 执行SQL操作,ExcuteNoQuery
        /// </summary>
        /// <param name="connstr">数据库链接字符串</param>
        /// <param name="strSql">执行的SQL语句</param>
        /// <returns>影响行数</returns>
        public static int SqlDataReader(string strSql)
        {
            int flag = 0;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection(connstr);
                conn.Open();
                cmd = new SqlCommand(strSql, conn);
                flag = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                conn.Dispose();
            }
            return flag;
        }


        /// <summary>
        /// 执行SQL操作,ExecuteScalar
        /// </summary>
        /// <param name="connstr">数据库链接字符串</param>
        /// <param name="strSql">执行的SQL语句</param>
        /// <returns>返回唯一值</returns>
        public static object ExecuteScalar(string strSql)
        {
            object flag = 0;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection(connstr);
                conn.Open();
                cmd = new SqlCommand(strSql, conn);
                flag = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                conn.Dispose();
            }
            return flag;
        }


        /// <summary>
        /// Reader查询
        /// </summary>
        /// <param name="connstr">数据库链接字符串</param>
        /// <param name="strSql">执行的SQL语句</param>
        /// <returns>影响行数</returns>
        public static SqlDataReader ExcuteReader(string strSql)
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        /// <summary>
        /// DataTable查询
        /// </summary>
        /// <param name="connstr">数据库链接字符串</param>
        /// <param name="strSql">执行的SQL语句</param>
        /// <returns>返回DataTable数据源</returns>
        public static DataTable ExcuteDataTable(string strSql)
        {
            DataTable dt = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataAdapter adapter = null;
            try
            {
                conn = new SqlConnection(connstr);
                cmd = new SqlCommand(strSql, conn);
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = null;
                throw ex;
            }
            finally
            {
                adapter.Dispose();
                cmd.Dispose();
                conn.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// DataTable参数化查询
        /// </summary>
        /// <param name="connstr">数据库链接字符串</param>
        /// <param name="strSql">执行的SQL语句</param>
        /// <param name="CommandType">存储过程或者SQL</param>
        /// <returns>返回DataTable数据源</returns>
        public static DataTable ExcuteDataTable(string strSql, CommandType cd, SqlParameter[] sp)
        {
            DataTable dt = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataAdapter adapter = null;
            try
            {
                conn = new SqlConnection(connstr);
                cmd = new SqlCommand(strSql, conn);
                cmd.CommandType = cd;
                cmd.Parameters.AddRange(sp);
                adapter = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = null;
                throw ex;
            }
            finally
            {
                adapter.Dispose();
                cmd.Dispose();
                conn.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// 参数化执行SQL
        /// </summary>
        /// <param name="connstr">连接字符串</param>
        /// <param name="strSql">执行的SQL语句</param>
        /// <param name="cd">存储过程或者SQL</param>
        /// <param name="sp">参数数组</param>
        /// <returns>影响的行数</returns>
        public static int ExcuteNoQuery(string strSql, CommandType cd, SqlParameter[] sp)
        {
            int flag = 0;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection(connstr);
                conn.Open();
                cmd = new SqlCommand(strSql, conn);
                cmd.CommandType = cd;
                cmd.Parameters.AddRange(sp);
                flag = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                conn.Dispose();
            }
            return flag;
        }

        public static int ExcuteNoQuerys(string strSql)
        {
            int flag = 0;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection(connstr);
                conn.Open();
                cmd = new SqlCommand(strSql, conn);
                flag = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                conn.Dispose();
            }
            return flag;
        }

        /// <summary>
        /// 参数化执行SQL,返回插入后自增ID
        /// </summary>
        /// <param name="connstr">连接字符串</param>
        /// <param name="strSql">执行的SQL语句</param>
        /// <param name="cd">存储过程或者SQL</param>
        /// <param name="sp">参数数组</param>
        /// <returns>影响的行数</returns>
        public static int ExcuteNoQueryByReturnID(string strSql, CommandType cd, SqlParameter[] sp)
        {
            int flag = 0;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection(connstr);
                conn.Open();
                cmd = new SqlCommand(strSql, conn);
                cmd.CommandType = cd;
                cmd.Parameters.AddRange(sp);
                cmd.ExecuteNonQuery();
                flag = Convert.ToInt32(sp[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                conn.Dispose();
            }
            return flag;
        }

        /// <summary>
        /// 执行SQL事务,ExcuteNoQuery
        /// </summary>
        /// <param name="transaction">事务对象</param>
        /// <param name="strSql">执行脚本</param>
        /// <returns>受影响行数</returns>
        public static int ExcuteNoQuery(SqlTransaction transaction, string strSql)
        {
            int flag = 0;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand(strSql, transaction.Connection, transaction);
                flag = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
            return flag;
        }

        /// <summary>
        /// 执行SQL事务,ExecuteScalar
        /// </summary>
        /// <param name="transaction">事务对象</param>
        /// <param name="strSql">执行脚本</param>
        /// <returns></returns>
        public static object ExecuteScalar(SqlTransaction transaction, string strSql)
        {
            object flag = 0;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand(strSql, transaction.Connection, transaction);
                flag = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
            return flag;
        }


        /// <summary>
        /// 读取Excel形成DataTable结果集
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        /// <param name="strSql">查询页签sql</param>
        /// <returns>DataTable结果集</returns>
        public static DataTable ExcuteDataTableByExcel(string filePath,string strSql) 
        {
            string connetionStr = "Provider=Microsoft.Ace.OleDb.12.0;" + "Data Source=" + filePath + ";" + "Extended Properties='Excel 12.0;HDR=Yes;IMEX=0';";
            DataTable dtExcel = new DataTable();
            OleDbConnection odbConn = new OleDbConnection(connetionStr);
            OleDbDataAdapter odbAdapter = new OleDbDataAdapter(strSql, odbConn);
            odbAdapter.Fill(dtExcel);
            return dtExcel;
        }

        /// <summary>
        /// 批量导入数据到数据库
        /// </summary>
        /// <param name="dt">源数据</param>
        /// <param name="conn">连接的数据库</param>
        /// <param name="transaction">事务</param>
        /// <param name="colums">导入的数据列</param>
        public static void BulkCopyToDBFormExel(DataTable dt,SqlBulkCopyOptions option, string tableName)
        {
            //SqlBulkCopy blkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.KeepIdentity, transaction);//生成自增的列表
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlBulkCopy blkCopy = null;

            try
            {
                conn = new SqlConnection(connstr);
                conn.Open();
                transaction = conn.BeginTransaction();
                blkCopy = new SqlBulkCopy(conn,option, transaction);
                blkCopy.BatchSize = dt.Rows.Count;
                blkCopy.DestinationTableName = tableName;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    blkCopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                }
                blkCopy.WriteToServer(dt);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                blkCopy.Close();
                transaction.Dispose();
                conn.Dispose();
            }
        }


    }
}
