

//local
using BlazorTailwindSampler.Shared.Data;

namespace BlazorTailwindSampler.Client.Services
{
    public class CacheService
    {
        private List<Article> articles = new List<Article>();

        public List<Article> Articles
        {
            get { return articles; }
            set { articles = value; }
        }

        public CacheService()
        {

        }


    }
}
