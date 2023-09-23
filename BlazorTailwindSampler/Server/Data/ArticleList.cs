
using System.Text.Json;

//locals
using BlazorTailwindSampler.Shared.Data;

namespace BlazorTailwindSampler.Server.Data
{
    public class ArticleList
    {
        private List<Article> articles = new List<Article>();
        private string filePath = "";

        public List<Article> Articles
        {
            get { return articles; }
            set { articles = value; }
        }

        public ArticleList(string FilePath)
        {
            filePath = FilePath;
            //check to see it file exists
            if (!File.Exists(filePath))
            {
                //create file
                var tempFile = File.Create(filePath);
                tempFile.Close();
            }
            //load articles from file
            string json = File.ReadAllText(filePath);
            var data = DeserializeJson<List<Article>>(json);
            if (data != null)
            {
                articles = data;
            }
        }

        public int AddArticle(Article article)
        {
            int result = 0;

            //add new id if 0
            if (article.Id == 0)
            {
                article.Id = articles.Count + 1;
            }
            //set created date
            article.CreateDate = DateTime.Now;
            //set active
            article.Active = true;

            articles.Add(article);
            try
            {
                SerializeAndSaveToJsonFile(articles);
                result = article.Id;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

        private void SerializeAndSaveToJsonFile<T>(T obj)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(obj);
                File.WriteAllText(filePath, jsonString);
                Console.WriteLine("Object serialized and saved to articles.json");
            }
            catch (Exception ex)
            {
                // Handle serialization or file-writing errors here
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        private static T? DeserializeJson<T>(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(json);
            }
            catch (JsonException ex)
            {
                // Handle deserialization errors here
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                return default(T); // or throw an exception if you prefer
            }
        }
    }
}
