using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.Commons.ViewModels;
using DemoApp.Features.Posts.Details;
using DemoApp.Features.Settings.AppSettings;
using DemoApp.HttpServices.Posts;
using DemoApp.Models;
using DemoApp.Services.Navigations;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.CommunityToolkit.UI.Views;

namespace DemoApp.Features.Posts.Lists
{
    public class PostListViewModel : ObservableObject, IViewModel
    {
        private readonly IPostService _postService;
        private readonly INavigationService _navigationService;
        
        public LayoutState _postListState;
        public LayoutState PostListState
        {
            get => _postListState;
            set => SetProperty(ref _postListState, value);
        }

        public ObservableRangeCollection<Post> Posts { get; }

        public AsyncCommand RefreshPostsAsyncCommand { get; }
        public AsyncCommand<Post> SelectedPostAsyncCommand { get; }
        public AsyncCommand ShowSettingsCommand { get; }

        public PostListViewModel(IPostService postService, INavigationService navigationService)
        {
            _postService = postService;
            _navigationService = navigationService;

            Posts = new ObservableRangeCollection<Post>();
            RefreshPostsAsyncCommand = new AsyncCommand(ListPostAsync, allowsMultipleExecutions: false);
            SelectedPostAsyncCommand = new AsyncCommand<Post>(ShowPostDetailsAsync, allowsMultipleExecutions: false);
            ShowSettingsCommand = new AsyncCommand(ShowSettingsAsync, allowsMultipleExecutions: false);
        }

        public Task InitializeAsync()
        {
            return ListPostAsync();
        }

        private async Task ListPostAsync()
        {
            PostListState = LayoutState.Loading;
            Posts.Clear();

            var postTask = GetPostsAsync();
            await Task.WhenAll(postTask, Task.Delay(1500));
            
            var posts = await postTask;
            Posts.AddRange(posts);
            
            PostListState = Posts.Any() ? LayoutState.Success : LayoutState.Empty;
        }

        private Task ShowPostDetailsAsync(Post post)
        {
            var viewModelParams = new PostDetailsViewModelParams(post.Id);
            return _navigationService.NavigateAsync<PostDetailsPage, PostDetailsViewModelParams>(viewModelParams);
        }

        private Task ShowSettingsAsync()
        {
            return _navigationService.NavigateAsync<AppSettingsPage>();
        }

        private async Task<List<Post>> GetPostsAsync()
        {
            try
            {
                var posts = await _postService.ListPostAsync();
                posts = posts.Take(10).ToList(); // fake pagination
                
                return posts;
            }
            catch(Exception exception)
            {
                return new List<Post>();
            }
        }
    }
}