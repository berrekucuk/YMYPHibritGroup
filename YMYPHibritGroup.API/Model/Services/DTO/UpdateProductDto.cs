namespace YMYPHibritGroup.API.Model.Services.DTO
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
