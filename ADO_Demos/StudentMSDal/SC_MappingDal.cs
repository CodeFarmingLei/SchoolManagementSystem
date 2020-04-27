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
    public class SC_MappingDal
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="dt">临时数据表</param>
        /// <returns>包含数据的临时数据表</returns>
        public DataTable GetDB(DataTable dt)
        {
            string strSql = @" SELECT * FROM SC_Mapping ";
            dt = ADOTools.ExcuteDataTable(strSql);
            return dt;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="sc">模型类</param>
        /// <returns>受影响的行数</returns>
        public int Add(SC_Mapping sc)
        {
            string sql = "INSERT INTO SC_Mapping(sid,cid,score) VALUES(@sid,@cid,@score);";
            SqlParameter[] param =
            {
                new SqlParameter("@sid",SqlDbType.Int){ Value =  sc.sid },
                new SqlParameter("@cid",SqlDbType.Int){ Value =  sc.cid },
                new SqlParameter("@score",SqlDbType.Int){ Value =  sc.score }
            };
            return ADOTools.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sc">模型类</param>
        /// <returns>受影响的行数</returns>
        public int Update(SC_Mapping sc)
        {
            string sql = "UPDATE SC_Mapping SET sid = @sid,cid = @cid,score = @score WHERE scid = @scid;";
            SqlParameter[] param =
            {
                new SqlParameter("@scid",SqlDbType.Int){ Value =  sc.scid },
                new SqlParameter("@sid",SqlDbType.Int){ Value =  sc.sid },
                new SqlParameter("@cid",SqlDbType.Int){ Value =  sc.cid },
                new SqlParameter("@score",SqlDbType.Int){ Value =  sc.score }
            };
            return ADOTools.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 按ID删除数据
        /// </summary>
        /// <param name="scid">要删除的ID值</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int scid)
        {
            string sql = "DELETE FROM SC_Mapping WHERE scid=@scid;";
            SqlParameter[] param =
            {
                new SqlParameter("@scid",SqlDbType.Int){ Value =  scid }
            };
            return ADOTools.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 查询数据总行数
        /// </summary>
        /// <returns></returns>
        public int GetDBRows()
        {
            string sql = " SELECT COUNT(*) FROM SC_Mapping ";
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
            strSql.Append(" SELECT TOP " + pageSize + " * FROM SC_Mapping ");
            strSql.Append(" WHERE scid NOT IN( ");
            strSql.Append("   SELECT TOP (" + pageSize + "*(" + pageIndex + "-1)) scid FROM SC_Mapping ORDER BY scid ASC ");
            strSql.Append(" ) ORDER BY scid ASC ");
            return ADOTools.Query(strSql.ToString(), null);
        }

    }
}
