using McDonaldsTest.DTOs;
using McDonaldsTest.Models;
using McDonaldsTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace McDonaldsTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost("PostOrder")]
        public IActionResult PostOrder([FromBody] OrderDTO orderDTO, string token)
        {
            if (token != "7e5706d9-c662-4032-92a2-d6a787a3f95b")
                return StatusCode((int)HttpStatusCode.Unauthorized);
            var order = new Order()
            {
                GUID = Guid.NewGuid().ToString(),
                Received = DateTime.Now,
                ClientIdentifier = orderDTO.ClientIdentifier,
                OrderDetail = orderDTO.OrderDetails,
                KitechenArea = Enums.KitchenArea.Drink
            };
            RabbitMqService.SendOrderToQueue(order);
            return StatusCode((int)HttpStatusCode.OK, new { message = "Order posted" });
        }
    }
}
