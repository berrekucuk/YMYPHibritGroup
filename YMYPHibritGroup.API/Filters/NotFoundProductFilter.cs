using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using YMYPHibritGroup.API.Model.Repositories;
using YMYPHibritGroup.API.Model.Repositories.Entities;
using YMYPHibritGroup.API.Model.Services;
using YMYPHibritGroup.API.Model.Services.DTO;

namespace YMYPHibritGroup.API.Filters
{
    public class NotFoundProductFilter : Attribute, IActionFilter
    {
        private IProductRepository _productRepository;

        public NotFoundProductFilter(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var methodType = context.HttpContext.Request.Method;

            int? id = null;
            
            var message = string.Empty;

            if (methodType == "PUT")
            {
                var updateProductRequest = context.ActionArguments.Values.First() as UpdateProductRequest;

                if (updateProductRequest != null)
                {
                    id = updateProductRequest.Id;

                    message = "Güncellemeye çalıştığınız ürün bulunamadı";
                }
            }
            
            if(methodType == "DELETE")
            {
                var idAsObject = context.ActionArguments.Values.FirstOrDefault();

                if(idAsObject is not null)
                {
                    if(int.TryParse(idAsObject.ToString(),out int idValue) == true) 
                    {
                        id = idValue;

                        message = "Silmeye çalıştığınız ürün bulunamadı";

                    }
                }
                
            }

            if (id.HasValue)
            {
                var hasProduct = _productRepository.Get(id.Value);

                if (hasProduct == null)
                {

                    var serviceResult = ServiceResult.Failure("Ürün bulunamadı");

                    context.Result = new NotFoundObjectResult(serviceResult);
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {            
        }

        
    }
}
