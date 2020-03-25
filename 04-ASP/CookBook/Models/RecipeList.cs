using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.Models
{
    public static class RecipeList
    {
        private static readonly List<Recipe> RecipesList = new List<Recipe>();
        private static int _generatedCount = 0;

        public static List<Recipe> GetRecipeList()
        {
            return RecipesList;
        }

        public static void Initialize()
        {
            RecipesList.Add(new Recipe(RecipesList.Count, "Some recipe " + _generatedCount++, 15, "easy", 5, "water, melon, watermelon", "Just eat and drink", "Don't get fat!"));
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
    }
}
