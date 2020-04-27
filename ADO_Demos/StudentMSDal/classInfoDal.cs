using ADO_Demos.entity;
using StudentMSAdo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMSDal
{
    public class classInfoDal
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="dt">临时数据表</param>
        /// <returns>包含数据的临时数据表</returns>
        public DataTable GetDB(DataTable dt)
        {
            string strSql = @" SELECT * FROM classInfo ";
            dt = ADOTools.ExcuteDataTable(strSql);
            return dt;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="c">模型类</param>
        /// <returns>受影响的行数</returns>
        public int Add(classInfo c)
        {
            string sql = "INSERT INTO classInfo(cid,cname) VALUES(@cid,@cname);";
            SqlParameter[] param =
            {
                new SqlParameter("@cid",SqlDbType.Int){ Value =  c.cid },
                new SqlParameter("@cname",SqlDbType.NVarChar,20){ Value =  c.cname }
            };
            return ADOTools.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="c">模型类</param>
        /// <returns>受影响的行数</returns>
        public int Update(classInfo c)
        {
            string sql = "UPDATE classInfo SET cname = @cname WHERE cid=@cid;";
            SqlParameter[] param =
            {
                new SqlParameter("@cid",SqlDbType.Int){ Value =  c.cid },
                new SqlParameter("@cname",SqlDbType.NVarChar,20){ Value =  c.cname }
            };
            return ADOTools.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 按ID删除数据
        /// </summary>
        /// <param name="cid">要删除的ID值</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int cid)
        {
            string sql = "DELETE FROM classInfo WHERE cid=@cid;";
            SqlParameter[] param =
            {
                new SqlParameter("@id",SqlDbType.Int){ Value =  cid }
            };
            return ADOTools.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 查询数据总行数
        /// </summary>
        /// <returns></returns>
        public int GetDBRows()
        {
            string sql = " SELECT COUNT(*) FROM classInfo ";
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
            strSql.Append(" SELECT TOP " + pageSize + " * FROM classInfo ");
            strSql.Append(" WHERE cid NOT IN( ");
            strSql.Append("   SELECT TOP (" + pageSize + "*(" + pageIndex + "-1)) cid FROM classInfo ORDER BY cid ASC ");
            strSql.Append(" ) ORDER BY cid ASC ");
            return ADOTools.Query(strSql.ToString(), null);
        }

    }
}
