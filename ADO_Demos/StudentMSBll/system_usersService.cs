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
    public class system_usersService
    {
        system_usersDal sudal = new system_usersDal();

        //读取数据
        public DataTable GetDB(DataTable dt)
        {
            return sudal.GetDB(dt);
        }

        //插入数据
        public int Add(system_users su)
        {
            return sudal.Add(su);
        }

        //更新数据
        public int Update(system_users su)
        {
            return sudal.Update(su);
        }

        //删除数据
        public int Delete(int uid)
        {
            return sudal.Delete(uid);
        }

    }
}
