using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YMYPHibrit3GroupEFCore.API.Model.Services;
using YMYPHibrit3GroupEFCore.API.Model.Services.Dtos;

namespace YMYPHibrit3GroupEFCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : CustomControllerBase
    {
        [HttpPost("WithProduct")]
        public async Task<IActionResult> AddCategoryWithProduct(AddCategoryWithProductsRequest request)
        {
            var result = await categoryService.AddCategoryWithProduct(request);

            return CreateObjectResult(result);
        }
    }
}
