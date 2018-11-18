using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Common.Utilities
{
    public class ApplicationInfo
    {
        static string _currency;
        static ApplicationInfo()
        {
            _currency = ConfigurationManager.AppSettings["currency"];
        }
        public static string Currency
        {
            get
            {
                return _currency;
            }

        }

    }
}
