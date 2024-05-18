// See https://aka.ms/new-console-template for more information
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using YNDHDotNetCore.ConsoleAppHttpClientExamples;

Console.WriteLine("Hello, World!");

// See https://aka.ms/new-console-template for more information
// Console App - Client (FrontEnd)
// ASP.NET Core Web API - Sever (BackEnd)

// HttpClient client = new HttpClient();
// var response = await client.GetAsync("https://localhost:7221/api/blog"); // One Job
// if (response.IsSuccessStatusCode)
// {
//     string jsonStr = await response.Content.ReadAsStringAsync();
//     Console.WriteLine(jsonStr);
//     List<BlogDto> lst = JsonConvert.DeserializeObject<List<BlogDto>>(jsonStr)!;
//     foreach (var blog in lst)
//     {
//         Console.WriteLine(JsonConvert.SerializeObject(blog));
//         Console.WriteLine($"Title => {blog.BlogTitle}");
//         Console.WriteLine($"Author => {blog.BlogAuthor}");
//         Console.WriteLine($"Content => {blog.BlogContent}");
//     }
// }

HttpClientExample httpClientExample =  new HttpClientExample();
await httpClientExample.RunAsync();

Console.ReadLine();