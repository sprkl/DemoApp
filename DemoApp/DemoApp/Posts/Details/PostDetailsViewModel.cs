using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.Application.HttpServices.Comments;
using DemoApp.Application.HttpServices.Posts;
using DemoApp.Commons.ViewModels;
using DemoApp.Domain.Entities;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.CommunityToolkit.UI.Views;

namespace DemoApp.Posts.Details
{
    public class PostDetailsViewModelParams : IViewModelParams
    {
        public long PostId { get; }

        public PostDetailsViewModelParams(long postId)
        {
            PostId = postId;
        }
    }
    
    public class PostDetailsViewModel : ObservableObject, IViewModel<PostDetailsViewModelParams>
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;

        private PostDetailsViewModelParams _params;
        
        public LayoutState _commentListState;
        public LayoutState CommentListState
        {
            get => _commentListState;
            set => SetProperty(ref _commentListState, value);
        }
        
        private Post _post;
        public Post Post
        {
            get => _post;
            set => SetProperty(ref _post, value);
        }

        public ObservableRangeCollection<Comment> Comments { get; }

        public AsyncCommand RefreshPageAsyncCommand { get; }

        public PostDetailsViewModel(IPostService postService, ICommentService commentService)
        {
            _postService = postService;
            _commentService = commentService;

            Comments = new ObservableRangeCollection<Comment>();
            RefreshPageAsyncCommand = new AsyncCommand(() => OnRefreshPageAsync(_params.PostId), allowsMultipleExecutions: false);
        }

        public Task InitializeAsync(PostDetailsViewModelParams @params)
        {
            _params = @params;
            return OnRefreshPageAsync(_params.PostId);
        }
        
        private async Task OnRefreshPageAsync(long postId)
        {
            CommentListState = LayoutState.Loading;
            Post = null;
            Comments.Clear();
            
            var postTask = GetPostAsync(postId);
            var commentsTask = GetCommentsAsync(postId);
            await Task.WhenAll(postTask, commentsTask, Task.Delay(1500));
            
            Post = await postTask;
            
            var comments = await commentsTask;
            Comments.AddRange(comments);
            
            CommentListState = Comments.Any() ? LayoutState.Success : LayoutState.Empty;
        }

        private async Task<Post> GetPostAsync(long postId)
        {
            try
            {
                var post = await _postService.GetPostAsync(postId);
                return post;
            }
            catch(Exception exception)
            {
                return new Post();
            }
        }
        
        private async Task<List<Comment>> GetCommentsAsync(long postId)
        {
            try
            {
                var queryParams = new ListCommentQueryParams
                {
                    PostId = postId
                };
                
                var comments = await _commentService.ListCommentsAsync(queryParams);
                comments = comments.Take(20).ToList(); // fake pagination
                
                return comments;
            }
            catch(Exception exception)
            {
                return new List<Comment>();
            }
        }
    }
}