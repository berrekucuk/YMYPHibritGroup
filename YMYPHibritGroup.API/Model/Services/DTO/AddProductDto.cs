namespace YMYPHibritGroup.API.Model.Services.DTO
{
    public class AddProductDto
    {
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
