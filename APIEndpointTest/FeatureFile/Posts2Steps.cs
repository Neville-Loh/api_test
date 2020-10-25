using System;
using System.Net.Http;
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
        public async void ThenTheSystemShouldReturn(int p0)
        {
            response = await ClientHandler.CreatePostAsync(post);
            Assert.Equals(response.StatusCode, p0);
        }

        /// <summary>
        /// asdfffffffffffffffffffffffffffffffffffffffffffffff
        /// 
        /// </summary>
        /// <param name="p0"></param>
        [When(@"I request to view post with id (.*)")]
        public async System.Threading.Tasks.Task WhenIRequestToViewPostWithIdAsync(int p0)
        {
            post = await ClientHandler.GetProductAsync(p0);

            //Assert.NotNull(post);
            ClientHandler.ShowProduct(post);
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
            Assert.AreEqual(post.title, title);
            Assert.AreEqual(post.body, body);
            Assert.AreEqual(post.id, p3);
        }


    }
}
