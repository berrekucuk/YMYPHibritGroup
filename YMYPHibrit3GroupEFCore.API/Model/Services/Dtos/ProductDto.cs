namespace YMYPHibrit3GroupEFCore.API.Model.Services.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string? CategoryName { get; set; }
    }
}
