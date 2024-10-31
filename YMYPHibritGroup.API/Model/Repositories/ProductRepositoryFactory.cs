namespace YMYPHibritGroup.API.Model.Repositories
{
    public class ProductRepositoryFactory
    {
        public static IProductRepository CreateProductRepository()
        {
            return new ProductRepository();
        }
    }
}
