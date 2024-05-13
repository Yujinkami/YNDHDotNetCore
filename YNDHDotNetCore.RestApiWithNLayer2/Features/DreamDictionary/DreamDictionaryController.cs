using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace YNDHDotNetCore.RestApiWithNLayer2.Features.DreamDictionary
{
    [Route("api/[controller]")]
    [ApiController]
    public class DreamDictionaryController : ControllerBase
    {
        private async Task<DreamDictionary> GetDreamDictionaryAsync()
        {
            string jsonStr1 = await System.IO.File.ReadAllTextAsync("dreamdictionary.json");
            var model1 = JsonConvert.DeserializeObject<DreamDictionary>(jsonStr1);
            return model1;
        }
        [HttpGet("BlogHeader")]
        public async Task<IActionResult> Header()
        {
            var model1 = await GetDreamDictionaryAsync();
            return Ok(model1.BlogHeader);
        }

        [HttpGet("blogid")]
        public async Task<IActionResult> LetterList(int blogid)
        {
            var model1 = await GetDreamDictionaryAsync();
            
            return Ok(model1.BlogDetail.TakeWhile(x => x.BlogId == blogid));
        }

        [HttpGet("{BlogId}/{BlogDetailId}")]
        public async Task<IActionResult> Result(int BlogId, int BlogDetailId)
        {
            var model = await GetDreamDictionaryAsync();
            return Ok(model.BlogDetail.FirstOrDefault(x => x.BlogId == BlogId && x.BlogDetailId == BlogDetailId));
        }

    }

    public class DreamDictionary
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

}
