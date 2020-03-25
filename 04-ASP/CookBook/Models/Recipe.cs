using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //minutes
        public int Time { get; set; }
        public string Difficulty { get; set; }
        public int NumberOfLikes{ get; set; }
        public string Ingredients { get; set; }
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
