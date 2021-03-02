using System;
using System.Net.Http;
using DemoApp.Application.HttpServices.Comments;
using DemoApp.Application.HttpServices.Posts;
using Refit;

namespace DemoApp.Application.HttpServices
{
    public class ServiceLocator
    {
        private const string PlaceholderAbsoluteUrl = "https://jsonplaceholder.typicode.com";
        
        public IPostService PostService => RestService.For<IPostService>(CreatePlaceholderHttpClient());
        public ICommentService CommentService => RestService.For<ICommentService>(CreatePlaceholderHttpClient());

        private HttpClient CreatePlaceholderHttpClient()
        {
            return new HttpClient
            {
                BaseAddress = new Uri(PlaceholderAbsoluteUrl)
            };
        }
    }
}