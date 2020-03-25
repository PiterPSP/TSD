using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CookBook.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CookBook.Controllers
{
    public class CookBookController : Controller
    {
        // GET: /CookBook/
        public IActionResult Index()
        {
            return View(RecipeList.GetRecipeList());
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id >= RecipeList.GetRecipeList().Count)
            {
                return NotFound();
            }

            return View(RecipeList.GetRecipeList()[id.Value]);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
