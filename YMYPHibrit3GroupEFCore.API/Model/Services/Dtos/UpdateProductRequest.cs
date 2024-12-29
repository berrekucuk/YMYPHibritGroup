namespace YMYPHibrit3GroupEFCore.API.Model.Services.Dtos
{
    public record UpdateProductRequest(int Id,string Name,decimal Price,int Stock);
}
