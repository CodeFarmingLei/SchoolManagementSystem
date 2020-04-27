using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO_Demos.entity;
using StudentMSAdo;
using StudentMSDal;

namespace StudentMSBll
{
    public class classInfoService
    {
        classInfoDal cdal = new classInfoDal();

        //读取数据
        public DataTable GetDB(DataTable dt)
        {
            return cdal.GetDB(dt);
        }

        //插入数据
        public int Add(classInfo c)
        {
            return cdal.Add(c);
        }

        //更新数据
        public int Update(classInfo c)
        {
            return cdal.Update(c);
        }

        //删除数据
        public int Delete(int cid)
        {
            return cdal.Delete(cid);
        }

        // 查询数据总行数
        public int GetDBRows()
        {
            return cdal.GetDBRows();
        }

        // 分页查询数据
        public DataTable GetDataByPage(int pageSize, int pageIndex)
        {
            return cdal.GetDataByPage(pageSize, pageIndex);
        }

    }
}
