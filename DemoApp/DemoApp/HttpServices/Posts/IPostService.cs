using System.Collections.Generic;
using System.Threading.Tasks;
using DemoApp.Models;
using Refit;

namespace DemoApp.HttpServices.Posts
{
    public interface IPostService
    {
        [Get("/posts")]
        Task<List<Post>> ListPostAsync();
        
        [Get("/posts/{postId}")]
        Task<Post> GetPostAsync([AliasAs("postId")] long postId);
    }
}
