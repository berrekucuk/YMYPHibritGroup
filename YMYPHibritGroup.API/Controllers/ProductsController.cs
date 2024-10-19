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
    public class ProductsController : ControllerBase
    {
        //readonly => Tekrar newlenmesini yani nesne örneğinin alınmasını engeller.

        private readonly ProductService _productService = new(); // Constructor ile aynı işlemi yapar.



        //Endpoint
        [HttpGet]
        public IActionResult GetProducts()
        {
            var result = _productService.GetProducts();

            //ObjectResult = Hangi status kodunu verirsen onu döner.
            return new ObjectResult(result)
            {
                StatusCode = (int)result.Status
            };
        }


        [HttpGet("{productId:int}")]
        public IActionResult GetProductById(int productId)
        {
            var result = _productService.GetProductById(productId);

            if(result.Status == HttpStatusCode.NoContent)
            {
                return new ObjectResult(null)
                {
                    StatusCode = (int)result.Status
                };
            }

            return new ObjectResult(result)
            {
                StatusCode = (int)result.Status
            };

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

            return new ObjectResult(result)
            {
                StatusCode = (int)result.Status
            };
            
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductRequest request)
        {
            var result = _productService.UpdateProduct(request);

            return new ObjectResult(result)
            {
                StatusCode = (int)result.Status
            };
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

            if(result.Status == HttpStatusCode.NoContent)
            {
                return new ObjectResult(null)
                {
                    StatusCode = (int)result.Status
                };
            }

            return new ObjectResult(result)
            {
                StatusCode = (int)result.Status
            };
        }
        
    }
}
