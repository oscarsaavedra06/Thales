using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThalesTestApplicationCore.SettingHelper
{
    public class AppSettings
    {
        public static AppSettings Instance
        {
            get
            {
                lock (Padlock)
                {
                    return _instance ?? (_instance = new AppSettings());
                }
            }
        }

        private static AppSettings _instance;
        private static readonly object Padlock = new object();

        public string EmployesApiUrl { get; set; }
        public string GetEmployeeApiUrl { get; set; }

    }
}


