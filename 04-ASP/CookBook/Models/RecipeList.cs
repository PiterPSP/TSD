using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.Models
{
    public static class RecipeList
    {
        private static readonly List<Recipe> RecipesList = new List<Recipe>();

        public static List<Recipe> GetRecipeList()
        {
            return RecipesList;
        }

        public static void Initialize()
        {
            RecipesList.Add(new Recipe(RecipesList.Count, "Some recipe", 15, "easy", 5, "water, melon, watermelon", "Just eat and drink", "Don't get fat!"));
            RecipesList.Add(new Recipe(RecipesList.Count, "Awsome recipe", 25, "medium", 15, "more water, banana", "Grill it.", "no tips"));
            RecipesList.Add(new Recipe(RecipesList.Count, "Another recipe", 8, "hard", 7, "less water, watermelon, melon", "Bake it. Somehow", "really no tips"));
            RecipesList.Add(new Recipe(RecipesList.Count, "Yummy", 60, "hard", 19877, "less water, onion, watermelon, melon", "Bake it and grill. Really", "Don't rush it."));
        }

        public static void Remove(int id)
        {
            RecipesList.RemoveAt(id);
            int idd = 0;
            foreach (var recipe in RecipesList)
            {
                recipe.Id = idd++;
            }
        }

        public static void Add(Recipe recipe)
        {
            recipe.Id = RecipesList.Count;
            RecipesList.Add(recipe);
        }

        public static List<Recipe> GetFilteredRecipeList(string searchPattern)
        {
            return RecipesList.FindAll(recipe => recipe.Name.ToLower().Contains(searchPattern.ToLower().Trim()));
        }
    }
}
