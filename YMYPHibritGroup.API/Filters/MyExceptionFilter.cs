using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using YMYPHibritGroup.API.Model.Services;

namespace YMYPHibritGroup.API.Filters
{
    public class MyExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine($"Ciddi bir hata var : {context.Exception.Message}");

            //Response modeli .Net yerine kendi yazdığımız response modeli dönmesi için yazılan kodlar aşağıdaki gibidir.
            context.ExceptionHandled = true; 

            var serviceResult = ServiceResult.Failure("İstenmeyen bir durum meydana geldi.Lütfen daha sonra tekrar deneyiniz.",HttpStatusCode.InternalServerError);

            context.Result = new ObjectResult(serviceResult)
            {
                StatusCode = (int)serviceResult.Status
            };

        }
    }
}
