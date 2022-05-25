using Assignment4.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace TestAPI
{
    public class TestGetProduct
    {
        /*Testing get product with good data*/
        [Fact]
        public async Task TestGetProductGood()
        {
            bool result;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44365/api/product/" + 3))
                {
                    result = response.IsSuccessStatusCode;

                }

            }

            Assert.True(result);
        }

        /*Testing get product with bad data*/
        [Fact]
        public async Task TestGetProductBad()
        {
            bool result;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44365/api/product/" + 'd'))
                {
                    result = response.IsSuccessStatusCode;

                }

            }

            Assert.False(result);
        }





    }
}
