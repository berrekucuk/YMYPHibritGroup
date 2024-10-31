using YMYPHibritGroup.API.Model.Services.DTO;

namespace YMYPHibritGroup.API.Model.Services
{
    public interface IProductService
    {
        ServiceResult<List<ProductDto>> GetProducts();
        ServiceResult<ProductDto> GetProductById(int productId);
        ServiceResult<ProductDto> AddProduct(AddProductRequest addProductDto);
        ServiceResult UpdateProduct(UpdateProductRequest updateProductDto);
        ServiceResult DeleteProduct(int productId);
    }
}
