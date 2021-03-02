using System.Collections.Generic;
using System.Threading.Tasks;
using DemoApp.Domain.Entities;
using Refit;

namespace DemoApp.Application.HttpServices.Comments
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
