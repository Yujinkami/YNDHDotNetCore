using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNDHDotNetCore.ConsoleApp
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-V9J631O\\YENANDAHTET",
            InitialCatalog = "YNDHDotNetCore",
            UserID = "sa",
            Password = "sa@123"
        };
    }
}
