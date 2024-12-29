using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YMYPHibrit3GroupEFCore.API.Model.Services;
using YMYPHibrit3GroupEFCore.API.Model.Services.Dtos;

namespace YMYPHibrit3GroupEFCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : CustomControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return CreateObjectResult(await productService.GetAllList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return CreateObjectResult(await productService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProductRequest request)
        {
            return CreateObjectResult(await productService.AddAsync(request));  
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductRequest request)
        {
            return CreateObjectResult(await productService.UpdateAsync(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateObjectResult(await productService.DeleteAsync(id));
        }
        
    }
}
