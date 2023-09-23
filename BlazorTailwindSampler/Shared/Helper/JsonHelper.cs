
using System.Text.Json;


namespace BlazorTailwindSampler.Shared
{
    public static class JsonHelper
    {
        public static string Serialize<T>(T obj)
        {
            string result = "";
            try
            {
                result = JsonSerializer.Serialize(obj);
            }
            catch (Exception ex)
            {
                // Handle serialization or file-writing errors here
                Console.WriteLine($"Error: {ex.Message}");
            }
            return result;
        }


        public static T? DeserializeJson<T>(string json)
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
