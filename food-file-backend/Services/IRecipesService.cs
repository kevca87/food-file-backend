using food_file_backend.Models;

namespace food_file_backend.Services
{
    public interface IRecipesService
    {
        Task<RecipeModel> CreateRecipe(RecipeModel model);
        IEnumerable<RecipeModel> GetRecipes();
    }
}
