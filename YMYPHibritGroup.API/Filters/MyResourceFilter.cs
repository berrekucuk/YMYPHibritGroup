using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using YMYPHibritGroup.API.Model.Services;
using YMYPHibritGroup.API.Model.Services.DTO;

namespace YMYPHibritGroup.API.Filters
{
    public class MyResourceFilter :Attribute, IResourceFilter
    {
        //Sadece controllerde kullanılır.

        //Response olduğu zaman çalışır.
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("OnResourceExecuting çalıştı");
        }

        //Request geldiği zaman çalışır.
        public void OnResourceExecuted(ResourceExecutedContext context)
        {

            var objectResult = context.Result as ObjectResult;

            var products = objectResult.Value as ServiceResult<List<ProductDto>>;

            Console.WriteLine("OnResourceExecuted çalıştı");           

        }
        
    }

  
}
