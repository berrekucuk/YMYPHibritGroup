using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace YMYPHibritGroup.API.Filters
{
    //Amacımız Request ne kadar sürede Response döndüğünü görmek.
    public class PerformanceResourceFilter : Attribute, IResourceFilter
    {
        private Stopwatch _stopwatch; //Özel bir sınıftır. sürelei ölçmek için kullanılır.

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew(); //Hem nesne örneği oluşturuyoruz hemde süryi başlatıyoruz.
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var elapsedMiliseconds = _stopwatch.ElapsedMilliseconds; // Geçen süreyi ms olarak aldık.

            var descriptor = context?.ActionDescriptor as ControllerActionDescriptor;

            if (descriptor != null)
            {
                var actionName = descriptor.ActionName;
                var ctrlName = descriptor.ControllerName;

                Console.WriteLine($"Request çalışma süresi({actionName}-{ctrlName}) : {elapsedMiliseconds} ms");
            }           
            
        }

        
    }
}
