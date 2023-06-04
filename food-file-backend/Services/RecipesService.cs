using food_file_backend.Models;

namespace food_file_backend.Services
{
    public class RecipesService : IRecipesService
    {
        private List<RecipeModel> _recipes;
        public RecipesService()
        {
            _recipes = new List<RecipeModel>();
            _recipes.Add(new RecipeModel() { Id = 1, RecipeName = "Pique Macho", Country = "Bolivia", Description = "El mejor plato de Bolivia" });
            _recipes.Add(new RecipeModel() { Id = 2, RecipeName = "Silpancho", Country = "Bolivia", Description = "Carne delgada y apanada con papas retostadas" });
            _recipes.Add(new RecipeModel() { Id = 3, RecipeName = "Relleno de papa", Country = "Bolivia", Description = "Un clasico de Cochabamba." });
            _recipes.Add(new RecipeModel() { Id = 4, RecipeName = "Salchipapa", Country = "Bolivia", Description = "Plato rapido de elaborar, con pocos ingredientes." });
            _recipes.Add(new RecipeModel() { Id = 5, RecipeName = "Spaggetti", Country = "Italia", Description = "Plato de pasta" });

        }
        public async Task<RecipeModel> CreateRecipe(RecipeModel model)
        {
            var last = _recipes.OrderByDescending(r => r.Id).FirstOrDefault();
            int nextId = last!= null ? last.Id +1:1;
            model.Id= nextId;
            _recipes.Add(model);
            return model;
        }

        public IEnumerable<RecipeModel> GetRecipes()
        {
            return _recipes;
        }
    }
}
