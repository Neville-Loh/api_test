using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using APIEndpointTest.Model;
using NUnit.Framework;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace APIEndpointTest.Helper
{
    [Binding]
    class ClientHandler
    {
        public static HttpClient client { set; get; }

        
        [BeforeTestRun]
        public static void StartUpSteps()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Handle the CREATE request of the applciation 
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> CreatePostAsync(Post post)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "posts", post);
            return response;
        }

        /// <summary>
        /// Handle the GET request of the applcaiton 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<Post> GetPostAsync(int id)
        {
            Post post = null;
            Assert.IsNotNull(client);
            Assert.IsNotNull(id);
            HttpResponseMessage response = await client.GetAsync($"posts/{id}");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("jasdhfljaskdhfl");
                post = await response.Content.ReadAsAsync<Post>();
            }
            return post;
        }

        /// <summary>
        /// Handle the DELETE request of the applcaiton using async call
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> DeletePostAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"posts/{id}");
            return response;
        }

        /// <summary>
        /// Handle the PUT request of the application using asunc call
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> UpdateProductAsync(Post product)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"posts/{product.id}", product);
            response.EnsureSuccessStatusCode();
            return response;
        }

    }
}
