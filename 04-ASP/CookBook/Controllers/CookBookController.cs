using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CookBook.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CookBook.Controllers
{
    public class CookBookController : Controller
    {

        public IActionResult Index(string searchPattern)
        {
            if(searchPattern == null || searchPattern.Trim() == "")
                return View(RecipeList.GetRecipeList());
            return View(RecipeList.GetFilteredRecipeList(searchPattern));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id >= RecipeList.GetRecipeList().Count)
            {
                return NotFound();
            }

            return View(RecipeList.GetRecipeList()[id.Value]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Time,Difficulty,NumberOfLikes,Ingredients,Process,Tips")] Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                RecipeList.GetRecipeList()[id] = recipe;
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        public IActionResult Details(int Id)
        {
            if (Id >= RecipeList.GetRecipeList().Count || Id < 0)
                RedirectToAction(nameof(Index));
            return View(RecipeList.GetRecipeList()[Id]);
        }

        public IActionResult Delete(int Id)
        {
            if (Id < RecipeList.GetRecipeList().Count && Id >= 0)
                RecipeList.Remove(Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Initialize()
        {
            RecipeList.Initialize();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add(int id, [Bind("Id,Name,Time,Difficulty,NumberOfLikes,Ingredients,Process,Tips")] Recipe recipe)
        {
            RecipeList.Add(recipe);
            return RedirectToAction(nameof(Index));
        }
    }
}
