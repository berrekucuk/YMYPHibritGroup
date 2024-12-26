using YMYPHibrit3GroupEFCore.API.Model.Services.Dtos;

namespace YMYPHibrit3GroupEFCore.API.Model.Services
{
    public interface IProductService
    {
        Task<ServiceResult<AddProductResponse>> AddAsync(AddProductRequest request);
        Task<ServiceResult<ProductDto>> Get(int id);
        Task<ServiceResult<List<ProductDto>>> GetAllList();
    }
}