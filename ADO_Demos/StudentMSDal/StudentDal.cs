using ADO_Demos;
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
    public class StudentDal
    {
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="dt">临时数据表</param>
        /// <returns>包含数据的临时数据表</returns>
        public DataTable GetDB(DataTable dt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ");
            strSql.Append("   S.sid AS '学生ID', ");
            strSql.Append("   S.sname AS '学生姓名', ");
            strSql.Append("   ( CASE S.ssex ");
            strSql.Append("   WHEN'1' THEN'男' ");
            strSql.Append("   WHEN'0' THEN'女' ");
            strSql.Append("   ELSE '双性人' ");
            strSql.Append("   END) AS '学生性别', ");
            strSql.Append("   S.sage AS '学生年龄', ");
            strSql.Append("   (CAST(YEAR(S.sbirthday) AS CHAR(4)) + '年' + ");
            strSql.Append("   CAST(MONTH(S.sbirthday) AS VARCHAR(2)) + '月' + ");
            strSql.Append("   CAST(DAY(S.sbirthday) AS VARCHAR(2)) + '日' ) AS '学生生日', ");
            strSql.Append("   S.sphone AS '学生电话', ");
            strSql.Append("   S.saddress AS '学生地址', ");
            strSql.Append("   C.cname AS '学生班级', ");
            strSql.Append("   S.spassword AS '学生登录密码' ");
            strSql.Append("   FROM student AS S ");
            strSql.Append(" LEFT JOIN classInfo AS C ON C.cid = S.scid ");
            dt = ADOTools.ExcuteDataTable(strSql.ToString());
            return dt;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="s">模型类</param>
        /// <returns>受影响的行数</returns>
        public int Add(Student s)
        {
            string sql = "INSERT INTO student(sid,sname,ssex,sage,sbirthday,sphone,saddress,scid,spassword) VALUES(@sid,@sname,@ssex,@sage,@sbirthday,@sphone,@saddress,@scid,@spassword);";
            SqlParameter[] param =
            {
                new SqlParameter("@sid",SqlDbType.Int){ Value =  s.sid },
                new SqlParameter("@sname",SqlDbType.VarChar,20){ Value =  s.sname },
                new SqlParameter("@ssex",SqlDbType.Int){ Value =  s.ssex },
                new SqlParameter("@sage",SqlDbType.Int){ Value =  s.sage },
                new SqlParameter("@sbirthday",SqlDbType.Date){ Value =  s.sbirthday },
                new SqlParameter("@sphone",SqlDbType.VarChar,20){ Value =  s.sphone },
                new SqlParameter("@saddress",SqlDbType.VarChar,50){ Value =  s.saddress },
                new SqlParameter("@scid",SqlDbType.Int){ Value =  s.scid },
                new SqlParameter("@spassword",SqlDbType.VarChar,6){ Value =  s.spassword },
            };
            return ADOTools.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="s">模型类</param>
        /// <returns>受影响的行数</returns>
        public int Update(Student s)
        {
            string sql = "UPDATE student SET sname = @sname,ssex = @ssex,sage = @sage,sbirthday = @sbirthday,sphone = @sphone,saddress = @saddress,scid = @scid,spassword = @spassword WHERE sid=@sid;";
            SqlParameter[] param =
            {
                new SqlParameter("@sid",SqlDbType.Int){ Value =  s.sid },
                new SqlParameter("@sname",SqlDbType.VarChar,20){ Value =  s.sname },
                new SqlParameter("@ssex",SqlDbType.Int){ Value =  s.ssex },
                new SqlParameter("@sage",SqlDbType.Int){ Value =  s.sage },
                new SqlParameter("@sbirthday",SqlDbType.Date){ Value =  s.sbirthday },
                new SqlParameter("@sphone",SqlDbType.VarChar,20){ Value =  s.sphone },
                new SqlParameter("@saddress",SqlDbType.VarChar,50){ Value =  s.saddress },
                new SqlParameter("@scid",SqlDbType.Int){ Value =  s.scid },
                new SqlParameter("@spassword",SqlDbType.VarChar,6){ Value =  s.spassword },
            };
            return ADOTools.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 按ID删除数据
        /// </summary>
        /// <param name="sid">要删除的ID值</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int sid)
        {
            string sql = "DELETE FROM student WHERE sid=@sid;";
            SqlParameter[] param =
            {
                new SqlParameter("@sid",SqlDbType.Int){ Value =  sid }
            };
            return ADOTools.ExecuteNonQuery(sql, param);
        }

        /// <summary>
        /// 查询数据总行数
        /// </summary>
        /// <returns></returns>
        public int GetDBRows()
        {
            string sql = " SELECT COUNT(*) FROM student ";
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
            strSql.Append(" SELECT TOP " + pageSize + " ");
            strSql.Append("   S.sid AS '学生ID', ");
            strSql.Append("   S.sname AS '学生姓名', ");
            strSql.Append("   ( CASE S.ssex ");
            strSql.Append("   WHEN'1' THEN'男' ");
            strSql.Append("   WHEN'0' THEN'女' ");
            strSql.Append("   ELSE '双性人' ");
            strSql.Append("   END) AS '学生性别', ");
            strSql.Append("   S.sage AS '学生年龄', ");
            strSql.Append("   (CAST(YEAR(S.sbirthday) AS CHAR(4)) + '年' + ");
            strSql.Append("   CAST(MONTH(S.sbirthday) AS VARCHAR(2)) + '月' + ");
            strSql.Append("   CAST(DAY(S.sbirthday) AS VARCHAR(2)) + '日' ) AS '学生生日', ");
            strSql.Append("   S.sphone AS '学生电话', ");
            strSql.Append("   S.saddress AS '学生地址', ");
            strSql.Append("   C.cname AS '学生班级', ");
            strSql.Append("   S.spassword AS '学生登录密码' ");
            strSql.Append("   FROM student AS S ");
            strSql.Append(" LEFT JOIN classInfo AS C ON C.cid = S.scid ");
            strSql.Append(" WHERE sid NOT IN( ");
            strSql.Append("   SELECT TOP (" + pageSize + "*(" + pageIndex + "-1)) sid FROM student ORDER BY sid ASC ");
            strSql.Append(" ) ORDER BY sid ASC ");
            return ADOTools.Query(strSql.ToString(), null);

        }

    }
}
