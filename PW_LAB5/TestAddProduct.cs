using Assignment4.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestAPI
{
    public class TestAddProduct
    {
        /*Testing add product with good parameters */ 
        [Fact]
        public async Task TestAddProductGood()
        {
            Product product = new Product() { ProductId = 20, ProductName = "testProduct", Price = 11.11, CategoryId = 2 };

            bool result;

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(product),
                                                                                        Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44365/api/product", content))
                {
                    result = response.IsSuccessStatusCode ;
                   
                }

            }
            Assert.True(result);
        }

        [Fact]
        /*Testing add product with bad parameters */
        public async Task TestAddProductBad()
        {
            Product product = new Product();

            bool result;

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(product),
                                                                                        Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44365/api/product", content))
                {
                    result = response.IsSuccessStatusCode;

                }

            }
            Assert.False(result);
        }
    }
}
