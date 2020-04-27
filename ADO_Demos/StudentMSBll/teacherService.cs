using StudentMSAdo;
using StudentMSDal;
using StudentMSModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMSBll
{
    public class teacherService
    {
        teacherDal tdal = new teacherDal();

        //读取数据
        public DataTable GetDB(DataTable dt)
        {
            return tdal.GetDB(dt);
        }

        //插入数据
        public int Add(teacher t)
        {
            return tdal.Add(t);
        }

        //更新数据
        public int Update(teacher t)
        {
            return tdal.Update(t);
        }

        //删除数据
        public int Delete(int tid)
        {
            return tdal.Delete(tid);
        }

        // 查询数据总行数
        public int GetDBRows()
        {
            return tdal.GetDBRows();
        }

        // 分页查询数据
        public DataTable GetDataByPage(int pageSize, int pageIndex)
        {
            return tdal.GetDataByPage(pageSize, pageIndex);
        }

    }
}
