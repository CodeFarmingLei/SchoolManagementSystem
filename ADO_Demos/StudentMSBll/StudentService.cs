using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO_Demos;
using StudentMSDal;

namespace StudentMSBll
{
    public class StudentService
    {
        StudentDal sdal = new StudentDal();

        //读取数据
        public DataTable GetDB(DataTable dt)
        {
            return sdal.GetDB(dt);
        }

        //插入数据
        public int Add(Student s)
        {
            return sdal.Add(s);
        }

        //更新数据
        public int Update(Student s)
        {
            return sdal.Add(s);
        }

        //删除数据
        public int Delete(int sid)
        {
            return sdal.Delete(sid);
        }

        //查询数据总行数
        public int GetDBRows()
        {
            return sdal.GetDBRows();
        }

        //分页查询数据
        public DataTable GetDataByPage(int pageSize, int pageIndex)
        {
            return sdal.GetDataByPage(pageSize, pageIndex);
        }

    }
}
