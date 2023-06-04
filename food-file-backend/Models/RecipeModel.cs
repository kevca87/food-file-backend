namespace food_file_backend.Models
{
    public class RecipeModel
    {
        public int Id { get; set; }
        public string? RecipeName { get; set; }
        public string? Instructions { get; set; }
        public string? Country { get; set; }
        public string? Difficulty { get; set; }
        public string? Category { get; set; }
        public string? AdditionalNotes { get; set; }
        public string? Description { get; set; }
    }
}
