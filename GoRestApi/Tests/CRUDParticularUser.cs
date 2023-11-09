using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class BasicTestCases
    {
        public static HttpClient httpClient = new HttpClient();
        

        [Fact]
        public async Task VerifyCRUDUser()
        {   //creating new user with all needed data
            User createdUser = GenerateUser.ParticularUser();
            var response = await ResponseMethods.PostUserResponse(createdUser);
            string content = await response.Content.ReadAsStringAsync();
            User deserializedCreatedUser = JsonConvert.DeserializeObject<User>(content);

            //asserting status code and if values of user in response are the same that are specified in request
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(createdUser.name, deserializedCreatedUser.name);
            Assert.Equal(createdUser.email, deserializedCreatedUser.email);
            Assert.Equal(createdUser.gender, deserializedCreatedUser.gender);
            Assert.Equal(createdUser.status, deserializedCreatedUser.status);

            //geting added user 
            (User getUser, HttpResponseMessage responseGet) = await CombinedMethods.GetUser(deserializedCreatedUser);

            //Asserting Status Code and if values of user in get response are the same that were in response for user that is created
            Assert.Equal(HttpStatusCode.OK, responseGet.StatusCode);
            Assert.Equal(deserializedCreatedUser.id, getUser.id);
            Assert.Equal(deserializedCreatedUser.name, getUser.name);
            Assert.Equal(deserializedCreatedUser.email, getUser.email);
            Assert.Equal(deserializedCreatedUser.gender, getUser.gender);
            Assert.Equal(deserializedCreatedUser.status, getUser.status);
            
            //Update user by changing its name and email using patch method
            (User patchedUser, HttpResponseMessage responsePatch) = await CombinedMethods.PatchUsersNameAndEmail(getUser);

            //Asserting status code of executed update with Patch method
            Assert.Equal(HttpStatusCode.OK, responsePatch.StatusCode);

            //Asserting that name and email are changed, and that id, gender and status remain the same
            Assert.NotEqual(getUser.name, patchedUser.name);
            Assert.NotEqual(getUser.email, patchedUser.email);
            Assert.Equal(getUser.id, patchedUser.id);
            Assert.Equal(getUser.gender, patchedUser.gender);
            Assert.Equal(getUser.status, patchedUser.status);

            //Deleting our User from the list of users
            (User deletedUser, HttpResponseMessage responseDeleted) = await CombinedMethods.DeleteUser(patchedUser);

            //Asserting Status Code of exucuted deleting
            Assert.Equal(HttpStatusCode.NoContent, responseDeleted.StatusCode);


   

            httpClient.Dispose();

        }
        

            
        }
    }
