using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace TestAPI
{
    public class TestDeleteProduct
    {
        /*Testing delete with good data*/
        [Fact]
        public async Task TestDeleteProductGood()
        {
            bool result;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44365/api/product/" + 20))
                {

                    result = response.IsSuccessStatusCode;
                }
            }

            Assert.True(result);
        }

        /*Testing delete with invalid data*/
        [Fact]
        public async Task TestDeleteProductBad()
        {
            bool result;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44365/api/product/" + 'd'))
                {

                    result = response.IsSuccessStatusCode;
                }
            }

            Assert.False(result);
        }
    }
}
