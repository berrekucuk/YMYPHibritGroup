namespace YMYPHibrit3GroupEFCore.API.Model.Services.Dtos
{
    public record AddCategoryWithProductsRequest(string CategoryName, string ProductName, decimal ProductPrice, int ProductStock);
}
