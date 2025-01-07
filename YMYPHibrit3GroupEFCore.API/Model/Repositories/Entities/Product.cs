namespace YMYPHibrit3GroupEFCore.API.Model.Repositories.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public string? Barcode { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }

        //Navigation Property
        public Category Category { get; set; } = default!;
    }
}





