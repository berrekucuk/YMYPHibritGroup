namespace YMYPHibrit3GroupEFCore.API.Model.Repositories.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product>? Products { get; set; }
    }
}
