using System.ComponentModel.DataAnnotations;

namespace CookBookAPI.Models
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, 600)]
        public int Time { get; set; }
        [StringLength(30)]
        public string Difficulty { get; set; }
        [Range(0, int.MaxValue)]
        public int NumberOfLikes { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required]
        public string Process { get; set; }
        public string Tips { get; set; }

    }
}
