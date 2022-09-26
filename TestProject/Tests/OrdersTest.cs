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
        private readonly HttpClient _httpClient;
        public OrdersTest()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateClient();
            _httpClient.DefaultRequestHeaders.Add("token", "7e5706d9-c662-4032-92a2-d6a787a3f95b");
        }

        [Fact]
        public async Task Test1Async()
        {
            //Arrange
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
            var response = await _httpClient.PostAsync("api/Orders/PostOrder", content);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Test2Async()
        {
            //Arrange
            var order = new OrderDTO()
            {
                KitchenArea = Enums.KitchenArea.Fries,
                ClientIdentifier = "",
                OrderDetails = "Cheddar McMelt and Fries"
            };
            JObject document = JObject.FromObject(order);
            StringContent content = new(JsonConvert.SerializeObject(document),
                                        Encoding.UTF8, "application/json");

            //Act
            var response = await _httpClient.PostAsync("api/Orders/PostOrder", content);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Test3Async()
        {
            //Arrange
            var order = new OrderDTO()
            {
                KitchenArea = Enums.KitchenArea.Fries,
                ClientIdentifier = "",
                OrderDetails = null
            };
            JObject document = JObject.FromObject(order);
            StringContent content = new(JsonConvert.SerializeObject(document),
                                        Encoding.UTF8, "application/json");

            //Act
            var response = await _httpClient.PostAsync("api/Orders/PostOrder", content);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
