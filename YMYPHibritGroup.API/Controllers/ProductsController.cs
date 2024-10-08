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
        //complex type => class => request body(json)

        //simple type => int,double,string,datetime => request url query string

        private ProductService ProductService;

        public ProductsController()
        {
            ProductService = new ProductService();
        }

        //Endpoint
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(ProductService.GetProducts());
        }

        [HttpGet("{productId}")]
        public IActionResult GetProductById(int productId)
        {
            return Ok(ProductService.GetProductById(productId));
        }

        [HttpGet("{pageSize}/{pageCount}")]
        public IActionResult GetPagedProduct(int pageSize, int pageCount)
        {
            return Ok();
        }


        [HttpPost]
        public IActionResult AddProduct(AddProductDto request)
        {
            var product = ProductService.AddProduct(request);
            return Created($"api/products/{product.Id}",product);
        }

        [HttpPost("/api/Category")]
        public IActionResult AddCategory(AddCategoryDto request)
        {            
            return Created(string.Empty,null);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto request)
        {
            ProductService.UpdateProduct(request);

            return NoContent();
        }

        [HttpPatch("stock/{stock}")]
        public IActionResult UpdateProductStock(int stock )
        {
            //ProductService.UpdateProduct(request);

            return NoContent();
        }

        [HttpPatch("price/{price}")]
        public IActionResult UpdateProductPrice(int price)
        {
            //ProductService.UpdateProduct(request);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int productId)
        {
            ProductService.DeleteProduct(productId);

            return NoContent();
        }
    }
}
