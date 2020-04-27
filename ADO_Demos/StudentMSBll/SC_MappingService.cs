using StudentMSAdo;
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
    public class SC_MappingService
    {
        SC_MappingDal scdal = new SC_MappingDal();

        //读取数据
        public DataTable GetDB(DataTable dt)
        {
            return scdal.GetDB(dt);
        }

        //插入数据
        public int Add(SC_Mapping sc)
        {
            return scdal.Add(sc);
        }

        //更新数据
        public int Update(SC_Mapping sc)
        {
            return scdal.Update(sc);
        }

        //删除数据
        public int Delete(int scid)
        {
            return scdal.Delete(scid);
        }

        // 查询数据总行数
        public int GetDBRows()
        {
            return scdal.GetDBRows();
        }

        // 分页查询数据
        public DataTable GetDataByPage(int pageSize, int pageIndex)
        {
            return scdal.GetDataByPage(pageSize, pageIndex);
        }

    }
}
