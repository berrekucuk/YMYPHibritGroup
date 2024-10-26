using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using YMYPHibritGroup.API.Model.Repositories.Entities;
using YMYPHibritGroup.API.Model.Services;
using YMYPHibritGroup.API.Model.Services.DTO;

namespace YMYPHibritGroup.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomControllerBase
    {
        //readonly => Tekrar newlenmesini yani nesne örneğinin alınmasını engeller.

        private readonly ProductService _productService = new(); // Constructor ile aynı işlemi yapar.

        

        //Endpoint
        [HttpGet]
        public IActionResult GetProducts()
        {
            var result = _productService.GetProducts();

            return CreateObjectResult(result);
        }


        [HttpGet("{productId:int}")]
        public IActionResult GetProductById(int productId)
        {
            var result = _productService.GetProductById(productId);

            return CreateObjectResult(result);

        }

        [HttpGet("{pageSize:int}/{pageCount:int}")]
        public IActionResult GetPagedProduct(int pageSize, int pageCount)
        {
            return Ok();
        }


        [HttpPost]
        public IActionResult AddProduct(AddProductRequest request)
        {
            var result = _productService.AddProduct(request);

            return CreateObjectResult(result);
            
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductRequest request)
        {
            var result = _productService.UpdateProduct(request);

            return CreateObjectResult(result);
        }

        [HttpPatch("stock/{stock:int}")]
        public IActionResult UpdateProductStock(int stock )
        {            

            return NoContent();
        }

        [HttpPatch("price/{price:int}")]
        public IActionResult UpdateProductPrice(int price)
        {

            return NoContent();
        }

        [HttpDelete("{productId:int}")]
        public IActionResult DeleteProduct(int productId)
        {
            var result = _productService.DeleteProduct(productId);

            return CreateObjectResult(result);
        }
        
    }
}
