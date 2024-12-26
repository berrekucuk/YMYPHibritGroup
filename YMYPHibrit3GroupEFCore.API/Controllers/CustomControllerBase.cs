using Microsoft.AspNetCore.Mvc;
using System.Net;
using YMYPHibrit3GroupEFCore.API.Model.Services;


namespace YMYPHibrit3GroupEFCore.API.Controllers
{
    //!! ObjectResult sınıfı ProductController da fazlaca newlendiği için ve ObjectResult ve ControlBase'e bir kod yazamadığımız için arasına bir class oluşturarak kodlarımızı yazacağız.
    // ProductController - CustomControllerBase - ControllerBase
    public class CustomControllerBase : ControllerBase
    {
        [NonAction]
        public IActionResult CreateObjectResult<T>(ServiceResult<T> serviceResult)
        {
            if (serviceResult.Status == HttpStatusCode.NoContent)
            {
                return new ObjectResult(null)
                {
                    StatusCode = (int)serviceResult.Status
                };
            }

            return new ObjectResult(serviceResult)
            {
                StatusCode = (int)serviceResult.Status
            };
        }

        [NonAction]
        public IActionResult CreateObjectResult(ServiceResult serviceResult)
        {
            if (serviceResult.Status == HttpStatusCode.NoContent)
            {
                return new ObjectResult(null)
                {
                    StatusCode = (int)serviceResult.Status
                };
            }

            return new ObjectResult(serviceResult)
            {
                StatusCode = (int)serviceResult.Status
            };
        }
    }
}
