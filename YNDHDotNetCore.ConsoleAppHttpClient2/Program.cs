// See https://aka.ms/new-console-template for more information
using System.Text.Json.Serialization;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

string jsonStr1 = await File.ReadAllTextAsync("dreamdictionary.json");
var model1 = JsonConvert.DeserializeObject<MainDto1>(jsonStr1);

foreach(var BlogHeader in model1.BlogHeader)
{
    Console.WriteLine(BlogHeader.BlogId);
}

Console.ReadLine();

static string ToNumber(string num)
{
    num = num.Replace("၃", "3");
    return num;
}

//static int ToNumber(string Str)
//{
//    Str = Str.Replace("က", "1");
//    Str = Str.Replace("ခ", "2");
//    Str = Str.Replace("ဂ", "3");
//    Str = Str.Replace("င", "4");
//    Str = Str.Replace("စ", "5");
//    Str = Str.Replace("ဆ", "6");
//    Str = Str.Replace("ဇ", "7");
//    Str = Str.Replace("ဈ", "8");
//    Str = Str.Replace("ည", "9");
//    Str = Str.Replace("တ", "10");
//    Str = Str.Replace("ထ", "11");
//    Str = Str.Replace("ဒ", "12");
//    Str = Str.Replace("ဓ", "13");
//    Str = Str.Replace("န", "14");
//    Str = Str.Replace("ပ", "15");
//    Str = Str.Replace("ဖ", "16");
//    Str = Str.Replace("ဗ", "17");
//    Str = Str.Replace("ဘ", "18");
//    Str = Str.Replace("မ", "19");
//    Str = Str.Replace("ယ", "20");
//    Str = Str.Replace("ရ", "21");
//    Str = Str.Replace("လ", "22");
//    Str = Str.Replace("ဝ", "23");
//    Str = Str.Replace("သ", "24");
//    Str = Str.Replace("ဟ", "25");
//    Str = Str.Replace("အ", "26");
//    return Convert.ToInt32(Str);
//}

public class MainDto1
{
    public Blogheader[] BlogHeader { get; set; }
    public Blogdetail[] BlogDetail { get; set; }
}

public class Blogheader
{
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
}

public class Blogdetail
{
    public int BlogDetailId { get; set; }
    public int BlogId { get; set; }
    public string BlogContent { get; set; }
}

