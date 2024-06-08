using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNDHDotNetCore.WinFormsApp;

internal static class ConnectionStrings
{
    public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = "DESKTOP-V9J631O\\YENANDAHTET",
        InitialCatalog = "YNDHDotNetCore",
        UserID = "sa",
        Password = "sa@123",
        TrustServerCertificate = true,
    };
}
