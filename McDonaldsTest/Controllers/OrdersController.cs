using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace McDonaldsTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostOrder()
        {
            return StatusCode((int)HttpStatusCode.OK, new { message = "Order posted" });
        }
    }
}
