using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Demos.common
{
    public static class PageConfig
    {
        /// <summary>
        /// 从配置文件App.config当中得到分页条数的值
        /// </summary>
        /// <returns></returns>
        public static int GetPageSize()
        {
            string str = ConfigurationManager.AppSettings["PageSize"];
            return int.Parse(str);
        }

    }
}
