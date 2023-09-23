
using Microsoft.AspNetCore.Mvc;

//locals
using BlazorTailwindSampler.Shared;
using BlazorTailwindSampler.Shared.Data;
using BlazorTailwindSampler.Server.Data;

namespace BlazorTailwindSampler.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly IWebHostEnvironment _environment;

        public ArticleController(ILogger<ArticleController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        [HttpGet(Name = "GetArticles")]
        public IEnumerable<Article> Get()
        {

            var filePath = Path.Combine(_environment.ContentRootPath, "articles.json");
            //APIResponse result = new(false, "", null);
            ArticleList articleList = new(filePath);
            //result = new APIResponse(true, "", articleList.Articles);
            return articleList.Articles;
        }

        [HttpPost(Name = "AddArticle")]
        public APIResponse SaveArticle(Article data)
        {
            APIResponse result = new(false, "Add Failed", null, 0);
            //validate article
            List<string> errors = data.Validate();
            if(errors.Count == 0)
            {
                var filePath = Path.Combine(_environment.ContentRootPath, "articles.json");
                ArticleList articleList = new(filePath);
                int newId =  articleList.AddArticle(data);
                if(newId > 0)
                {
                    result = new(true, "", null, newId);
                }
            }
            return result;
        }
    }
}