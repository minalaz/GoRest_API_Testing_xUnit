using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GoRest.GoRestApi.Methods;
using GoRest.GoRestApi.Models;
using Xunit;

namespace GoRest.GoRestApi.Tests
{
    public class AssertingCombinedMethods
    {    public static HttpClient httpClient = new HttpClient();    
        
        [Fact]
        public async Task AssertPostUser()
        {
           
            
            (User createdUser, HttpResponseMessage response) = await CombinedMethods.PostUser();
            Assert.NotNull(createdUser);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            
            httpClient.Dispose();
        }
        [Fact]
        public async Task AssertGetUserFromTheList()
        {
            (User userFromList, HttpResponseMessage response) = await CombinedMethods.GetUserFromTheListOfUsers();

            Assert.NotNull(userFromList);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            httpClient.Dispose();

        }
        [Fact]
        public async Task AssertGetUserFromTheListThenPatchItsNameAndEmail()
        {
            (User singleUser, HttpResponseMessage responseGet) = await CombinedMethods.GetUserFromTheListOfUsers();
            Assert.NotNull(singleUser);
            (User patchedUser, HttpResponseMessage response) = await CombinedMethods.PatchUsersNameAndEmail(singleUser);
            Assert.NotNull(patchedUser);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(singleUser.name, patchedUser.name);
            Assert.NotEqual(singleUser.email, patchedUser.email);
            Assert.Equal(singleUser.id, patchedUser.id);
            Assert.Equal(singleUser.gender, patchedUser.gender);
            Assert.Equal(singleUser.status, patchedUser.status);

            httpClient.Dispose();
        }
        [Fact]
        public async Task VerifygetUserFromTheListAndUpdateItWithPutMethod()
        {   //get user from the list of users
            (User singleUser, HttpResponseMessage responseGet) = await CombinedMethods.GetUserFromTheListOfUsers();
            Assert.NotNull(singleUser);
            //update-ing user using Put method
            (User updatedUser, HttpResponseMessage response) = await CombinedMethods.PutUserUpdate(singleUser);
            Assert.NotNull(updatedUser);
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(singleUser.id, updatedUser.id);
            Assert.NotEqual(singleUser, updatedUser);
           
            httpClient.Dispose();

        }
        [Fact]
        public async Task CreateAndDeleteUser()
        {
            (User createdUser, HttpResponseMessage response) = await CombinedMethods.PostUser();
            Assert.NotNull(createdUser);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            (User deletedUser, HttpResponseMessage responseDel) = await CombinedMethods.DeleteUser(createdUser);
            Assert.Null(deletedUser);
            Assert.Equal(HttpStatusCode.NoContent, responseDel.StatusCode);

            httpClient.Dispose();
        }
        }
    }

