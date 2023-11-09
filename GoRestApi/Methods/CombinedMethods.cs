using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GoRest.GoRestApi.Models;
using Newtonsoft.Json;

namespace GoRest.GoRestApi.Methods
{
    public class CombinedMethods
    {
        private static HttpClient httpClient = new HttpClient();
        private static string URI = "https://gorest.co.in/public/v2/users/";
        private static string _token = "Bearer 3c7607055a1bf7d429b0b9ed454c9f98c7687002e4a0e4ff91251cc6555ec5ea";
        private static RandomizingData randomizingData = new RandomizingData();
        private static Random random = new Random();
           
        //method that returns object called HttpRequest headers. This alows headers to be recycled in request methods multiple times.
        private static HttpRequestHeaders SetRequestHeaders(HttpRequestHeaders headers)
        {
            headers.Add("Accept", "application/json");
            headers.Add("Authorization", _token);
            return headers;
        }

        public static async Task<(User createdUser, HttpResponseMessage response)> PostUser()
        {
            User userPost = GenerateUser.InstantiateUSer();
            string userSerialized = JsonConvert.SerializeObject(userPost);
            var message = new HttpRequestMessage(HttpMethod.Post, URI);
            message.Content = new StringContent(userSerialized);
            message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            message.Headers.AddHeaders(SetRequestHeaders);
            var response = await httpClient.SendAsync(message);
            string content = await response.Content.ReadAsStringAsync();
            User createdUser = JsonConvert.DeserializeObject<User>(content);
            return (createdUser, response);
        }

        public static async Task<(User user, HttpResponseMessage response)> GetUser(User user)
        {
            string getUri = URI + user.id;
            var messageGet = new HttpRequestMessage(HttpMethod.Get, getUri);
            messageGet.Headers.AddHeaders(SetRequestHeaders);
            var responseGet = await httpClient.SendAsync(messageGet);
            var contentGet = await responseGet.Content.ReadAsStringAsync();
            User deserializeUser = JsonConvert.DeserializeObject<User>(contentGet);
            return (deserializeUser, responseGet);
        }

        public static async Task<(User patchedUser, HttpResponseMessage response)> PatchUsersName(User user)
        {
            
            var updatedUserData = new { name = randomizingData.GenerateRandomName() };
            var jsonContent = JsonConvert.SerializeObject(updatedUserData);
            int userId = user.id;
            var messagePatch = new HttpRequestMessage(HttpMethod.Patch, URI + userId);
            messagePatch.Content = new StringContent(jsonContent);
            messagePatch.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            messagePatch.Headers.AddHeaders(SetRequestHeaders);
            var response = await httpClient.SendAsync(messagePatch);
            string contentPatch = await response.Content.ReadAsStringAsync();
            User patchedUser = JsonConvert.DeserializeObject<User>(contentPatch);
            return (patchedUser, response);
        }

        public static async Task<(User singleUser, HttpResponseMessage response)> GetUserFromTheListOfUsers()
        {
            var messageGet = new HttpRequestMessage(HttpMethod.Get, URI);
            messageGet.Headers.AddHeaders(SetRequestHeaders);
            var responseGet = await httpClient.SendAsync(messageGet);
            var contentGet = await responseGet.Content.ReadAsStringAsync();
            List<User> allUsers = JsonConvert.DeserializeObject<List<User>>(contentGet);
            var orderedList = allUsers.OrderBy(user => random.Next());
            User singleUser = orderedList.First();
            //User singleUser = allUsers?.FirstOrDefault(x => x.id == 5676928);
            return (singleUser, responseGet);
        }

        public static async Task<(User patchedUser, HttpResponseMessage response)> PatchUsersNameAndEmail(User user)
        {
           
            var updatedUserData = new
            {
                name = randomizingData.GenerateRandomName(),
                email = randomizingData.GenerateRandomEmail("example.com")
            };
            var jsonContent = JsonConvert.SerializeObject(updatedUserData);
            int userId = user.id;
            var messagePatch = new HttpRequestMessage(HttpMethod.Patch, URI + userId);
            messagePatch.Content = new StringContent(jsonContent);
            messagePatch.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            messagePatch.Headers.AddHeaders(SetRequestHeaders);
            var response = await httpClient.SendAsync(messagePatch);
            string contentPatch = await response.Content.ReadAsStringAsync();
            User patchedUser = JsonConvert.DeserializeObject<User>(contentPatch);
            return (patchedUser, response);
        }
        public static async Task<(User updatedUser, HttpResponseMessage response)> PutUserUpdate(User user)
        {

            var updatedUserData = new User()
            {
                name = randomizingData.GenerateRandomName(),
                email = randomizingData.GenerateRandomEmail("example.com"),
                gender = randomizingData.GenerateRandomGender(),
                status = randomizingData.GenerateRandomStatus()
            };
            var jsonContent = JsonConvert.SerializeObject(updatedUserData);
            int userId = user.id;
            var messagePut = new HttpRequestMessage(HttpMethod.Put, URI + userId);
            messagePut.Content = new StringContent(jsonContent);
            messagePut.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            messagePut.Headers.AddHeaders(SetRequestHeaders);
            var response = await httpClient.SendAsync(messagePut);
            string contentPut = await response.Content.ReadAsStringAsync();
            User updatedUser = JsonConvert.DeserializeObject<User>(contentPut);
            return (updatedUser, response);
        }
        public static async Task<(User user, HttpResponseMessage response)> DeleteUser(User user)
        {
            string deleteUri = URI + user.id;
            var messageDelete = new HttpRequestMessage(HttpMethod.Delete, deleteUri);
            messageDelete.Headers.AddHeaders(SetRequestHeaders);
            var responseDelete = await httpClient.SendAsync(messageDelete);
            var contentDelete = await responseDelete.Content.ReadAsStringAsync();
            User deserializeUser = JsonConvert.DeserializeObject<User>(contentDelete);
            return (deserializeUser, responseDelete);
        }
    }
    //This class alows to add custom headers to an 'HttpRequestHeaders' Object
    public static class HttpRequestHeadersExtensions
    { 
        
        public static void AddHeaders(this HttpRequestHeaders headers, Func<HttpRequestHeaders, HttpRequestHeaders> headersFunc)
        {
            headersFunc(headers);
        }
    }
}
