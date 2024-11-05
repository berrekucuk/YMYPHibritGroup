using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using YMYPHibritGroup.API.Filters;
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

        private readonly IProductService _productService; // Constructor ile aynı işlemi yapar.        
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //Endpoint
        [MyActionFilter]
        //[PerformanceResourceFilter]
        [MyResourceFilter]
        [HttpGet]
        public IActionResult GetProducts()
        {
            var result = _productService.GetAll();
            Thread.Sleep(2500);

            return CreateObjectResult(result);
        }


        [HttpGet("{productId:int}")]
        public IActionResult GetProductById(int productId)
        {
            var result = _productService.GetById(productId);

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
            var result = _productService.Add(request);

            return CreateObjectResult(result);
            
        }

        [ServiceFilter<NotFoundProductFilter>] //Constructor kullandığımız için böyle yapıyoruz.
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductRequest request)
        {
            var result = _productService.Update(request);

            return CreateObjectResult(result);
        }

        [HttpPatch("stock")]
        public IActionResult UpdateProductStock(UpdateProductStockRequest request)
        {
            var result = _productService.UpdateStock(request.ProductId, request.Stock);

            return CreateObjectResult(result);
        }

        [HttpPatch("price")]
        public IActionResult UpdateProductPrice(UpdateProductPriceRequest request)
        {
            var result = _productService.UpdatePrice(request.ProductId, request.Price);

            return CreateObjectResult(result);
        }

        [HttpDelete("{productId:int}")]
        public IActionResult DeleteProduct(int productId)
        {
            var result = _productService.Delete(productId);

            return CreateObjectResult(result);
        }
        
    }
}
