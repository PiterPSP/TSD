using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookBookAPI.Models;

namespace CookBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly CookBookAPIContext _context;

        public RecipesController(CookBookAPIContext context)
        {
            _context = context;
        }

        private static RecipeDTO RecipeToDTO(Recipe recipe) =>
            new RecipeDTO
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Time = recipe.Time,
                Difficulty = recipe.Difficulty,
                Ingredients = recipe.Ingredients,
                NumberOfLikes = recipe.NumberOfLikes,
                Process = recipe.Process,
                Tips = recipe.Tips
            };

        // GET: api/Recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDTO>>> GetRecipe()
        {
            return await _context.Recipes
                .Select(x => RecipeToDTO(x))
                .ToListAsync();
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDTO>> GetRecipe(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return RecipeToDTO(recipe);
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(int id, RecipeDTO recipeDTO)
        {
            if (id != recipeDTO.Id)
            {
                return BadRequest();
            }

            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            recipe.Id = recipeDTO.Id;
            recipe.Name = recipeDTO.Name;
            recipe.Time = recipeDTO.Time;
            recipe.Difficulty = recipeDTO.Difficulty;
            recipe.Ingredients = recipeDTO.Ingredients;
            recipe.NumberOfLikes = recipeDTO.NumberOfLikes;
            recipe.Process = recipeDTO.Process;
            recipe.Tips = recipeDTO.Tips;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Recipes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(RecipeDTO recipeDTO)
        {
            var recipe = new Recipe
            {
                Id = recipeDTO.Id,
                Name = recipeDTO.Name,
                Time = recipeDTO.Time,
                Difficulty = recipeDTO.Difficulty,
                Ingredients = recipeDTO.Ingredients,
                NumberOfLikes = recipeDTO.NumberOfLikes,
                Process = recipeDTO.Process,
                Tips = recipeDTO.Tips
            };

            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, RecipeToDTO(recipe));
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recipe>> DeleteRecipe(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return recipe;
        }
    }
}
