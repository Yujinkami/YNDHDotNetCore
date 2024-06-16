// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using YNDHDotNetCore.ConsoleApp.AdoDotNetExamples;
using YNDHDotNetCore.ConsoleApp.DapperExamples;
using YNDHDotNetCore.ConsoleApp.EFCoreExamples;
using YNDHDotNetCore.ConsoleApp.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Hello, World!");

//nutget,org htae mar package install lo ya tal
// Ctrl + . => suggestion
// one sentences si so yin F10
// detail lite mal so yin F11
// F9 => breakpoint

// => C# => Db

// SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
// stringBuilder.DataSource = "DESKTOP-V9J631O\\YENANDAHTET"; //server name
// stringBuilder.InitialCatalog = "YNDHDotNetCore"; // database name
// stringBuilder.UserID = "sa";
// stringBuilder.Password = "sa@123";
// SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);

//SqlConnection connection = new SqlConnection("Data Source = DESKTOP-V9J631O\\YENANDAHTET;Initial Catalog = YNDHDotNetCore;User ID = sa;Password = sa@123");
// connection.Open();
// Console.WriteLine("Connection open.");

// string query = "select * from tbl_blog";
// SqlCommand cmd = new SqlCommand(query, connection);
// SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
// DataTable dt = new DataTable();
// sqlDataAdapter.Fill(dt);

// connection.Close();
// Console.WriteLine("Connection close.");

// dataset => datatable
// datatable => datarow
// datarow => datacolumn

// foreach (DataRow dr in dt.Rows)
// {
//     Console.WriteLine("Blog Id => " + dr["BlogId"]);
//     Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
//     Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
//     Console.WriteLine("Blog Content => " + dr["BlogContent"]);
//     Console.WriteLine("----------------------------------------");
// }

// Ado.Net Read
// CRUD
//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("title", "author", "content");
//adoDotNetExample.Update(11, "test title", "test author", "test content");
//adoDotNetExample.Delete(11);
//adoDotNetExample.Edit(11);  
//adoDotNetExample.Edit(1);
//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Run();

var connectionString = ConnectionStrings.SqlConnectionStringBuilder.ConnectionString;
var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

var serviceProvider = new ServiceCollection()
    .AddScoped(n => new AdoDotNetExample(sqlConnectionStringBuilder))
    .AddScoped(n => new DapperExample(sqlConnectionStringBuilder))
    .AddDbContext<AppDbContext>(opt => 
 {
    opt.UseSqlServer(connectionString);
})
    .AddScoped<EFCoreExample>()
    .BuildServiceProvider();

//AppDbContext db = serviceProvider.GetRequiredService<AppDbContext>();

var adoDotNetExample = serviceProvider.GetRequiredService<AdoDotNetExample>();
adoDotNetExample.Read();

//var dapperExample = serviceProvider.GetRequiredService<DapperExample>();
//dapperExample.Run();

Console.ReadLine();  