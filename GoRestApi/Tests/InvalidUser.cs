using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GoRest.GoRestApi.Methods;
using GoRest.GoRestApi.Models;
using Newtonsoft.Json;
using Xunit;

namespace GoRest.GoRestApi.Tests
{
    public class InvalidUser
    {
       private static HttpClient httpClient = new HttpClient();

        [Fact]
        public async Task VerifyHttpMethodsWithInvalidUser()
        {   //creating user with null values for name and gender
            User invalidUser = GenerateUser.InvalidUser();
            var response = await ResponseMethods.PostUserResponse(invalidUser);
            //assert that response has 422 status code which stands for Unprocessable entity
            Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);
            //deserialize user for viewing messages in response body
            string content = await response.Content.ReadAsStringAsync();
            
            //assert error messages
            Assert.Contains("can't be blank", content);

            httpClient.Dispose();
        }
    }
}
