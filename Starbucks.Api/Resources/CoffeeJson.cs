namespace Starbucks.Api.Resources
{
    public class CoffeeJson
    {
        public Guid CoffeeId { get; set; } = Guid.NewGuid();
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string [] Ingredients { get; set; } = [];
        public string? Image { get; set; }
        public int Category { get; set; }
    }

}
