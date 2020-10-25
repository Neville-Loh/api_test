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

        public static void ShowProduct(Post post)
        {
            Console.WriteLine($"ID:{post.id} \nTitle: {post.title}\nBody: " +
                $"{post.body}\nUserID: {post.userId}");
        }

        public static async Task<HttpResponseMessage> CreatePostAsync(Post post)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "posts", post);
            return response;
        }

        public static async Task<Post> GetProductAsync(int id)
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
    }
}
