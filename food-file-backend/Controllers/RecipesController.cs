using food_file_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace food_file_backend.Controllers
{
    [Route("[controller]")]
    public class RecipesController : ControllerBase
    {
        private List<RecipeModel> _recipes;
        public RecipesController()
        {
            _recipes = new List<RecipeModel>();
            _recipes.Add(new RecipeModel() { Id=1, Name="Pique Macho", Country="Bolivia", Description="El mejor plato de Bolivia" });
            _recipes.Add(new RecipeModel() { Id=2, Name="Silpancho", Country="Bolivia", Description="El mejor plato de Bolivia" });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeModel>>> GetRecipesAsync()
        {
            try
            {
                return Ok(_recipes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
    }
}