using System.Net;
using YMYPHibrit3GroupEFCore.API.Model.Repositories;
using YMYPHibrit3GroupEFCore.API.Model.Repositories.Entities;
using YMYPHibrit3GroupEFCore.API.Model.Services.Dtos;

namespace YMYPHibrit3GroupEFCore.API.Model.Services
{
    public class CategoryService(IGenericRepository<Category> categoryRepository, IGenericRepository<Product> productRepository, IUnitOfWork unitOfWork) : ICategoryService
    {
        public async Task<ServiceResult<List<CategoryDto>>> Get()
        {
            var categories = await categoryRepository.GetAsync();

            if (categories == null)
            {
                return ServiceResult<List<CategoryDto>>.Success(Enumerable.Empty<CategoryDto>().ToList());
            }

            //List<CategoryDto> categoryDtos = new();

            //foreach (var item in product)
            //{
            //    categoryDtos.Add(new CategoryDto(item.Id, item.Name));
            //}

            var categoriesDtos = categories.Select(p => new CategoryDto(p.Id, p.Name)).ToList();

            return ServiceResult<List<CategoryDto>>.Success(categoriesDtos);

        }

        public async Task<ServiceResult<CategoryDto>> Get(int id)
        {
            var category = await categoryRepository.GetAsync(id);

            if (category == null)
            {
                return ServiceResult<CategoryDto>.Failure("Categorynot found", System.Net.HttpStatusCode.NotFound);
            }

            var categoryDtos = new CategoryDto(category.Id, category.Name);

            return ServiceResult<CategoryDto>.Success(categoryDtos);
        }

        public async Task<ServiceResult<CategoryDto>> AddAsync(AddCategoryRequest request)
        {
            var category = new Category()
            {
                Name = request.Name
            };

            categoryRepository.AddAsync(category);

            return ServiceResult<CategoryDto>.Success(new CategoryDto(category.Id, category.Name), HttpStatusCode.Created);

        }

        public async Task<ServiceResult<int>> AddCategoryWithProduct(AddCategoryWithProductsRequest request)
        {

            #region 1.way
            //using (var transaction = await unitOfWork.BeginTransactionAsync())
            //{
            //    var category = new Category()
            //    {
            //        Name = request.CategoryName
            //    };

            //    categoryRepository.AddAsync(category);

            //    await unitOfWork.SaveChangesAsync();

            //    var product = new Product()
            //    {
            //        Name = request.ProductName,
            //        Price = request.ProductPrice,
            //        Barcode = Guid.NewGuid().ToString(),
            //        Stock = request.ProductStock,
            //        CategoryId = category.Id
            //    };

            //    productRepository.AddAsync(product);

            //    await unitOfWork.SaveChangesAsync();

            //    //await unitOfWork.CommitAsync();
            //    await transaction.CommitAsync();


            //    return ServiceResult<int>.Success(category.Id,HttpStatusCode.Created);
            //} 
            #endregion

            var category = new Category()
            {
                Name = request.CategoryName
            };

            category.Products = new();
            category.Products.Add(new Product()
            {
                Name = request.ProductName,
                Price = request.ProductPrice,
                Barcode = Guid.NewGuid().ToString(),
                Stock = request.ProductStock
            });

            categoryRepository.AddAsync(category);

            await unitOfWork.SaveChangesAsync();

            return ServiceResult<int>.Success(category.Id, HttpStatusCode.Created);

        }
    }
}
