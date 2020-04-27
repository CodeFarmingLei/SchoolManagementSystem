using StudentMSAdo;
using StudentMSModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMSDal
{
    public class teacherDal
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="dt">临时数据表</param>
        /// <returns>包含数据的临时数据表</returns>
        public DataTable GetDB(DataTable dt)
        {
            string strSql = @" SELECT * FROM teacher ";
            dt = ADOTools.ExcuteDataTable(strSql);
            return dt;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="t">模型类</param>
        /// <returns>受影响的行数</returns>
        public int Add(teacher t)
        {
            string sql = "INSERT INTO teacher(tcid,tname,tProfession,tpassword) VALUES(@tcid,@tname,@tProfession,@tpassword);";
            SqlParameter[] param =
            {
                new SqlParameter("@tcid",SqlDbType.Int){ Value =  t.tcid },
                new SqlParameter("@tname",SqlDbType.VarChar,20){ Value =  t.tname },
                new SqlParameter("@tProfession",SqlDbType.Char,1){ Value =  t.tProfession },
                new SqlParameter("@tpassword",SqlDbType.Char,6){ Value =  t.tpassword }
            };
            return ADOTools.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="t">模型类</param>
        /// <returns>受影响的行数</returns>
        public int Update(teacher t)
        {
            string sql = "UPDATE teacher SET tcid = @tcid,tname = @tname,tProfession = @tProfession,tpassword = @tpassword WHERE tid = @tid;";
            SqlParameter[] param =
            {
                new SqlParameter("@tid",SqlDbType.Int){ Value =  t.tid },
                new SqlParameter("@tcid",SqlDbType.Int){ Value =  t.tcid },
                new SqlParameter("@tname",SqlDbType.VarChar,20){ Value =  t.tname },
                new SqlParameter("@tProfession",SqlDbType.Char,1){ Value =  t.tProfession },
                new SqlParameter("@tpassword",SqlDbType.Char,6){ Value =  t.tpassword }
            };
            return ADOTools.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 按ID删除数据
        /// </summary>
        /// <param name="tid">要删除的ID值</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int tid)
        {
            string sql = "DELETE FROM teacher WHERE tid=@tid;";
            SqlParameter[] param =
            {
                new SqlParameter("@tid",SqlDbType.Int){ Value =  tid }
            };
            return ADOTools.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 查询数据总行数
        /// </summary>
        /// <returns></returns>
        public int GetDBRows()
        {
            string sql = " SELECT COUNT(*) FROM teacher ";
            object ob = ADOTools.ExecuteScalar(sql, null);
            if (ob != null)
                return int.Parse(ob.ToString());
            return 0;
        }

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="pageSize">每页展示数据的条数</param>
        /// <param name="pageIndex">当前的页码数</param>
        /// <returns></returns>
        public DataTable GetDataByPage(int pageSize, int pageIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT TOP " + pageSize + " * FROM teacher ");
            strSql.Append(" WHERE tid NOT IN( ");
            strSql.Append("   SELECT TOP (" + pageSize + "*(" + pageIndex + "-1)) tid FROM teacher ORDER BY tid ASC ");
            strSql.Append(" ) ORDER BY tid ASC ");
            return ADOTools.Query(strSql.ToString(), null);
        }

    }
}
