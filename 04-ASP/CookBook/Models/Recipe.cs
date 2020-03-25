using System.ComponentModel.DataAnnotations;

namespace CookBook.Models
{
    public class Recipe
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
        [Range(0,int.MaxValue)]
        public int NumberOfLikes{ get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required]
        public string Process { get; set; }
        public string Tips { get; set; }

        public Recipe() { }

        public Recipe(int id, string name, int time, string difficulty, int numberOfLikes, string ingredients, string process, string tips)
        {
            Id = id;
            Name = name;
            Time = time;
            Difficulty = difficulty;
            NumberOfLikes = numberOfLikes;
            Ingredients = ingredients;
            Process = process;
            Tips = tips;
        }
    }
}
