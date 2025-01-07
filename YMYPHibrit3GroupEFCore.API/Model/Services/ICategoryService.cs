using YMYPHibrit3GroupEFCore.API.Model.Services.Dtos;

namespace YMYPHibrit3GroupEFCore.API.Model.Services
{
    public interface ICategoryService
    {
        Task<ServiceResult<CategoryDto>> AddAsync(AddCategoryRequest request);
        Task<ServiceResult<int>> AddCategoryWithProduct(AddCategoryWithProductsRequest request);
        Task<ServiceResult<List<CategoryDto>>> Get();
        Task<ServiceResult<CategoryDto>> Get(int id);
    }
}