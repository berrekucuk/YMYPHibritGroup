using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YMYPHibritGroup.API.Filters;

namespace YMYPHibritGroup.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterExampleController : ControllerBase
    {
        [MyExceptionFilter]
        [HttpGet]
        public IActionResult Get(string id)
        {
            throw new Exception("Db hatası");

            //!!! Kod yazarken mümkün olduğunca try ve exception dönülmemeli.

            //try
            //{
            //    var x = int.Parse(id);
            //}
            //catch(Exception e) 
            //{
            //    Console.WriteLine(e);
            //    return BadRequest(" ");
            //}



            return Ok("Get request");
        }

        [HttpPost]
        public IActionResult Post()
        {
            throw new Exception("Db hatası");

            return Ok("Post request");
        }

        [MyResultFilter]
        [HttpPut]
        public IActionResult Put()
        {
            return Ok("Put request");
        }
    }
}
