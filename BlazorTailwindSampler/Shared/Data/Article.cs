using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorTailwindSampler.Shared.Data
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";

        public string Description { get; set; } = "";

        [Required]
        public string Category { get; set; } = "";

        public string URL { get; set; } = "";
        public string Source { get; set; } = "";
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }

        public List<string> Validate()
        {
            List<string> errors = new List<string>();
            if (string.IsNullOrEmpty(Title))
            {
                errors.Add("Title is required");
            }
            if (string.IsNullOrEmpty(Description))
            {
                errors.Add("Description is required");
            }
            if (string.IsNullOrEmpty(Category))
            {
                errors.Add("Category is required");
            }

            return errors;
        }
    }
}
