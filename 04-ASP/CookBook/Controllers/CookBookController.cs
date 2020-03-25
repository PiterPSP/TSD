using System.Text.Encodings.Web;
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

        // GET: /CookBook/Welcome/ 
        // Requires using System.Text.Encodings.Web;

        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }

        public IActionResult Edit()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Details()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Delete(int Id)
        {
            RecipeList.Remove(Id);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Initialize()
        {
            RecipeList.Initialize();
            return RedirectToAction("Index");
        }
    }
}
