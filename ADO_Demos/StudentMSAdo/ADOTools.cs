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
        //public static readonly string CONNECTION_STR = ConfigurationManager.ConnectionStrings["connStr"].ToString();

        public static string CONNECTION_STR = "server=.;database=student;uid=sa;pwd=123456";
        /// <summary>
        /// 执行SQL操作,ExcuteNoQuery
        /// </summary>
        /// <param name="CONNECTION_STR">数据库链接字符串</param>
        /// <param name="strSql">执行的SQL语句</param>
        /// <returns>影响行数</returns>
        public static int SqlDataReader(string strSql)
        {
            int flag = 0;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection(CONNECTION_STR);
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
        /// <param name="CONNECTION_STR">数据库链接字符串</param>
        /// <param name="strSql">执行的SQL语句</param>
        /// <returns>返回唯一值</returns>
        public static object ExecuteScalar(string strSql)
        {
            object flag = 0;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection(CONNECTION_STR);
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
        /// <param name="CONNECTION_STR">数据库链接字符串</param>
        /// <param name="strSql">执行的SQL语句</param>
        /// <returns>影响行数</returns>
        public static SqlDataReader ExcuteReader(string strSql)
        {
            SqlConnection conn = new SqlConnection(CONNECTION_STR);
            conn.Open();
            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        /// <summary>
        /// DataTable查询
        /// </summary>
        /// <param name="CONNECTION_STR">数据库链接字符串</param>
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
                conn = new SqlConnection(CONNECTION_STR);
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
        /// <param name="CONNECTION_STR">数据库链接字符串</param>
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
                conn = new SqlConnection(CONNECTION_STR);
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
        /// <param name="CONNECTION_STR">连接字符串</param>
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
                conn = new SqlConnection(CONNECTION_STR);
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
                conn = new SqlConnection(CONNECTION_STR);
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
        /// <param name="CONNECTION_STR">连接字符串</param>
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
                conn = new SqlConnection(CONNECTION_STR);
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
        /// <returns></returns>
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
                conn = new SqlConnection(CONNECTION_STR);
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
