using McDonaldsTest.DTOs;
using McDonaldsTest.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.Tests
{
    public class OrdersTest
    {
        [Fact]
        public static async Task Test1Async()
        {
            //Arrange
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("token", "7e5706d9-c662-4032-92a2-d6a787a3f95b");
            var order = new OrderDTO()
            {
                KitchenArea = Enums.KitchenArea.Fries,
                ClientIdentifier = "Someone",
                OrderDetails = "Cheddar McMelt and Fries"
            };
            JObject document = JObject.FromObject(order);
            StringContent content = new(JsonConvert.SerializeObject(document),
                                        Encoding.UTF8, "application/json");

            //Act
            var response = await httpClient.PostAsync("api/Orders/PostOrder", content);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
