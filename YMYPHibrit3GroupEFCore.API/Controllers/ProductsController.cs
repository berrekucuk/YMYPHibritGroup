using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YMYPHibrit3GroupEFCore.API.Model.Services;
using YMYPHibrit3GroupEFCore.API.Model.Services.Dtos;

namespace YMYPHibrit3GroupEFCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ProductService productService) : CustomControllerBase
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
    }
}
