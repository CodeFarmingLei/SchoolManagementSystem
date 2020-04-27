using StudentMSDal;
using StudentMSModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMSBll
{
    public class courseService
    {
        courseDal cdal = new courseDal();

        //读取数据
        public DataTable GetDB(DataTable dt)
        {
            return cdal.GetDB(dt);
        }

        //插入数据
        public int Add(course c)
        {
            return cdal.Add(c);
        }

        //更新数据
        public int Update(course c)
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
