using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YMYPHibritGroup.API.Model.Services;
using YMYPHibritGroup.API.Model.Services.DTO;

namespace YMYPHibritGroup.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //readonly => Tekrar newlenmesini yani nesne örneğinin alınmasını engeller.

        private readonly ProductService _productService = new(); // Constructor ile aynı işlemi yapar.



        //Endpoint
        [HttpGet]
        public IActionResult GetProduct() => Ok(_productService.GetProducts());


        [HttpGet("{productId:int}")]
        public IActionResult GetProductById(int productId)
        {
            return Ok(_productService.GetProductById(productId));
        }

        [HttpGet("{pageSize:int}/{pageCount:int}")]
        public IActionResult GetPagedProduct(int pageSize, int pageCount)
        {
            return Ok();
        }


        [HttpPost]
        public IActionResult AddProduct(AddProductRequest request)
        {
            var product = _productService.AddProduct(request);
            return Created($"api/products/{product.Id}",product);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductRequest request)
        {
            _productService.UpdateProduct(request);

            return NoContent();
        }

        [HttpPatch("stock/{stock:int}")]
        public IActionResult UpdateProductStock(int stock )
        {
            //ProductService.UpdateProduct(request);

            return NoContent();
        }

        [HttpPatch("price/{price:nt}")]
        public IActionResult UpdateProductPrice(int price)
        {
            //ProductService.UpdateProduct(request);

            return NoContent();
        }

        [HttpDelete("{productId:int}")]
        public IActionResult DeleteProduct(int productId)
        {
            _productService.DeleteProduct(productId);

            return NoContent();
        }
    }
}
