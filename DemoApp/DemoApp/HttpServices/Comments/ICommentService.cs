using System.Collections.Generic;
using System.Threading.Tasks;
using DemoApp.Entities;
using Refit;

namespace DemoApp.HttpServices.Comments
{
    public interface ICommentService
    {
        [Get("/comments")]
        Task<List<Comment>> ListCommentsAsync(ListCommentQueryParams queryParams);
    }

    public class ListCommentQueryParams
    {
        public long PostId { get; set; }
    }
}
