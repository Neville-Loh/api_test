﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using APIEndpointTest.Helper;
using APIEndpointTest.Model;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace APIEndpointTest.FeatureFile
{
    [Binding]
    public class PostsSteps
    {
        private static HttpResponseMessage response;
        private static Post post;


        /* CREATE post test 
         * test the basical functionality of GET operation within CRUD
         * and the happy path
         */
        [Given(@"I create a new post with \((.*),'(.*)','(.*)',(.*)\)")]
        public void GivenICreateANewPostWith(int id, string title, string body, int userId)
        {
            post = new Post()
            {
                id = id,
                title = title,
                body = body,
                userId = userId
            };

        }

        [Then(@"the system should return (.*)")]
        public async void ThenTheSystemShouldReturn(int statusCode)
        {
            response = await ClientHandler.CreatePostAsync(post);
            Assert.Equals(response.StatusCode, statusCode);
        }


        /* GET post test 
         * test the basical functionality of GET operation within CRUD
         * and the happy path
         */

        [When(@"I request to view post with id (.*)")]
        public async Task WhenIRequestToViewPostWithIdAsync(int id)
        {
            post = await ClientHandler.GetPostAsync(id);
        }

        [Then(@"system should return (.*)")]
        public void ThenSystemShouldReturn(int p0)
        {
            Assert.NotNull(post);
        }

        [Then(@"system should reutrn post header \((.*),'(.*)','(.*)',(.*)\)")]
        public void ThenSystemShouldReutrnPostHeader(int p0, string title, string body, int p3)
        {
            Assert.AreEqual(post.id, p0);
            Assert.AreEqual(post.id, p3);
        }

        /* DELETE post test 
        *  test the basical functionality of DELETE operation within CRUD
        *  and the happy path
        */

        [Given(@"There exists a post with id (.*)")]
        public async Task GivenThereExistsAPostWithIdAsync(int id)
        {
            post = await ClientHandler.GetPostAsync(id);
            Assert.NotNull(post);
        }

        [When(@"I delete a post")]
        public async Task WhenIDeleteAProperty()
        {
            response = await ClientHandler.DeletePostAsync(1);
            Assert.NotNull(response);
        }

        [Then(@"the system should return success code")]
        public void ThenTheSystemShouldNotReturnAnyResults()
        {
            Assert.True(response.IsSuccessStatusCode);
        }


        /* UPDATE post test 
        *  test the basical functionality of UPDATE operation within CRUD
        *  and the happy path
        */

        [Given(@"There exists a post with (.*)")]
        public async Task GivenThereExistsAPostWith(int id)
        {
            post = await ClientHandler.GetPostAsync(id);
        }

        [When(@"I update an existing property \('(.*)','(.*)'\)")]
        public async Task WhenIUpdateAnExistingProperty(string newTitle, string newBody)
        {
            post.title = newTitle;
            post.body = newBody;
            response = await ClientHandler.UpdateProductAsync(post);
        }

        [Then(@"the response post should have value \((.*),'(.*)','(.*)',(.*)\);")]
        public async Task ThenTheResponsePostShouldHaveValue(int userId, string newtitle, string newbody, int id)
        {

            post = await response.Content.ReadAsAsync<Post>();
            Assert.AreEqual(post.userId, userId);
            Assert.AreEqual(post.title, newtitle);
            Assert.AreEqual(post.body, newbody);
            Assert.AreEqual(post.id, id);
        }

        /* Negative Test
         * test the senario where Quetry Does not Exist 
         * 
         */

        [When(@"I request a post that does not exists")]
        public async Task WhenIRequestAPostThatDoesNotExists()
        {
            response = await ClientHandler.client.GetAsync($"posts/idontexist");
        }

        [Then(@"the response should not be successful")]
        public void ThenTheResponseShouldHaevAErrorCode()
        {
            Assert.NotNull(response);
            Assert.False(response.IsSuccessStatusCode);
        }

    }
}
