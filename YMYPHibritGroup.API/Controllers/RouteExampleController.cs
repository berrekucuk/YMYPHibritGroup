using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace YMYPHibritGroup.API.Controllers
{

    public class TcDto
    {
        public string Tc { get; set; } = default!;
    }


    [Route("api/[controller]")]
    [ApiController]
    public class RouteExampleController : ControllerBase
    {
        // URL Rotalamasında önemli olan,
        //1. Parametreler sayısı
        //2. Statik ifade ile ayırmak gerek

        //[HttpGet("id/{id}/name/{name}")]
        //public IActionResult Get(int id, string name)
        //{
        //    return Ok(id);
        //}

        //[HttpGet("{id}/{name}")]
        //public IActionResult Get(double id, string name)
        //{
        //    return Ok(id);
        //}

        //[HttpGet("s/{id}/{name}")]
        //public IActionResult Get2(int id, string name)
        //{
        //    return Ok(id);
        //}
        //------------------------------------

        // 2 adet parametrem mevcut id ve name
        //Bu parametrelerden id'yi route data da name ise query stringde almak istiyoum. [HttpGet("{id}")] yazarak Route da gösteririz name queryden gelir.veya ikinci yöntem [FromRoute] ve [ForumQuery] ile belirterek gelir.

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id,[FromQuery] string name)
        {
            return Ok(id);
        }

        //Güvenli data taşımak için requestin ya headerını ya da bodysini kullanmalıyız.

        //[FromQuery] => query string
        //[FromBody] => request body
        //[FromRoute] => route parameter
        //[FromHeader] => header parameter

        [HttpGet] // Bu doğru bir yazım değildir sadece örnk için yapılmıştır.
        public IActionResult Create([FromHeader] int x)
        {
            return Ok(x);
        }

        //[HttpPost]
        //public IActionResult Create2([FromBody] int x)
        //{
        //    return Ok(x);
        //}


        [HttpPost]
        public IActionResult GetPersonalDate(TcDto tc)
        {
            return Ok();
        }
    }
}
