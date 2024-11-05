using YMYPHibritGroup.API.Model.Services.DTO;

namespace YMYPHibritGroup.API.Model.Services
{
    public interface IProductService
    {
        ServiceResult<List<ProductDto>> GetAll();
        ServiceResult<ProductDto> GetById(int productId);
        ServiceResult<ProductDto> Add(AddProductRequest addProductDto);
        ServiceResult Update(UpdateProductRequest updateProductDto);
        ServiceResult UpdateStock(int productId, int stock);
        ServiceResult UpdatePrice(int productId, decimal price);
        ServiceResult Delete(int productId);
    }
}
