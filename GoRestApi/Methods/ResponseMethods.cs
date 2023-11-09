using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoRest.GoRestApi.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace GoRest.GoRestApi.Methods
{
    public static class ResponseMethods
    {
        private static HttpClient httpClient = new HttpClient();
        private static string URI = "https://gorest.co.in/public/v2/users/";
        private static string _token = "Bearer 3c7607055a1bf7d429b0b9ed454c9f98c7687002e4a0e4ff91251cc6555ec5ea";


        public static async Task<HttpResponseMessage> GetUserResponse(int userId)
        {

            httpClient.DefaultRequestHeaders.Add("Authorization", _token);
            var request = new HttpRequestMessage(HttpMethod.Get, URI + userId);
            HttpResponseMessage response = await httpClient.SendAsync(request);
            return response;
        }

        public static async Task<HttpResponseMessage> PostUserResponse(User user)
        {

            httpClient.DefaultRequestHeaders.Add("Authorization", _token);
            httpClient.DefaultRequestHeaders.Add("Accept", "aplication/json");
            string userSerialized = JsonConvert.SerializeObject(user);
            var message = new HttpRequestMessage(HttpMethod.Post, URI);
            message.Content = new StringContent(userSerialized);
            message.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await httpClient.SendAsync(message);
            return response;

        }
    }
}