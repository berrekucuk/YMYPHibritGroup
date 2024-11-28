namespace YMYPHibrit3GroupEFCore.API.Model.Repositories.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string? CategoryName { get; set; }
        public int Stock { get; set; }
    }
}
