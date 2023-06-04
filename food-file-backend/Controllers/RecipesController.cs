using food_file_backend.Models;
using food_file_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace food_file_backend.Controllers
{
    [Route("[controller]")]
    public class RecipesController : ControllerBase
    {
        private IRecipesService _recipesService;
        public RecipesController(IRecipesService recipesService)
        {
            _recipesService = recipesService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeModel>>> GetRecipesAsync()
        {
            try
            {
                return Ok(_recipesService.GetRecipes());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<RecipeModel>>> PostRecipeAsync([FromBody] RecipeModel recipe)
        {
            try
            {
                var recipeC = _recipesService.CreateRecipe(recipe);
                var recipes = await GetRecipesAsync();

                return recipes;

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }

        }
        [HttpDelete]
        public async Task<ActionResult> DeleteLastRecipe()
        {
            try
            {
                _recipesService.DeleteLast();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }

    }
}