using McDonaldsTest.DTOs;
using McDonaldsTest.Interfaces;
using McDonaldsTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace McDonaldsTest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMessageSender _messageSender;
        private readonly IConfiguration _configuration;

        public OrdersController(IMessageSender messageSender, IConfiguration configuration)
        {
            _messageSender = messageSender;
            _configuration = configuration;
        }

        [HttpPost("PostOrder")]
        public IActionResult PostOrder([FromBody] OrderDTO orderDTO)
        {
            var token = Request.Headers["token"];
            if (!token.Equals(_configuration.GetValue<string>("Token")))
                return StatusCode((int)HttpStatusCode.Unauthorized);

            var order = new Order()
            {
                GUID = Guid.NewGuid().ToString(),
                Received = DateTime.Now,
                ClientIdentifier = orderDTO.ClientIdentifier,
                OrderDetail = orderDTO.OrderDetails,
                KitechenArea = orderDTO.KitchenArea
            };
            _messageSender.SendOrder(order);
            return StatusCode((int)HttpStatusCode.OK, new { message = "Order posted" });
        }
    }
}
