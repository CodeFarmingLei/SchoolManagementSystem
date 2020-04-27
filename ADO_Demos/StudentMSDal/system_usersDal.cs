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
    public class system_usersDal
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="dt">临时数据表</param>
        /// <returns>包含数据的临时数据表</returns>
        public DataTable GetDB(DataTable dt)
        {
            string strSql = @" SELECT * FROM system_users ";
            dt = ADOTools.ExcuteDataTable(strSql);
            return dt;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="su">模型类</param>
        /// <returns>受影响的行数</returns>
        public int Add(system_users su)
        {
            string sql = "INSERT INTO system_users(ucode,upwd) VALUES(@ucode,@upwd);";
            SqlParameter[] param =
            {
                new SqlParameter("@ucode",SqlDbType.VarChar,10){ Value =  su.ucode },
                new SqlParameter("@upwd",SqlDbType.VarChar,10){ Value =  su.upwd }
            };
            return ADOTools.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="su">模型类</param>
        /// <returns>受影响的行数</returns>
        public int Update(system_users su)
        {
            string sql = "UPDATE system_users SET ucode = @ucode,upwd = @upwd WHERE uid = @uid;";
            SqlParameter[] param =
            {
                new SqlParameter("@uid",SqlDbType.Int){ Value =  su.uid },
                new SqlParameter("@ucode",SqlDbType.VarChar,10){ Value =  su.ucode },
                new SqlParameter("@upwd",SqlDbType.VarChar,10){ Value =  su.upwd }
            };
            return ADOTools.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 按ID删除数据
        /// </summary>
        /// <param name="uid">要删除的ID值</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int uid)
        {
            string sql = "DELETE FROM system_users WHERE uid=@uid;";
            SqlParameter[] param =
            {
                new SqlParameter("@uid",SqlDbType.Int){ Value =  uid }
            };
            return ADOTools.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 查询数据总行数
        /// </summary>
        /// <returns></returns>
        public int GetDBRows()
        {
            string sql = " SELECT COUNT(*) FROM system_users ";
            object ob = ADOTools.ExecuteScalar(sql, null);
            if (ob != null)
                return int.Parse(ob.ToString());
            return 0;
        }

    }
}
