using Autofac;
using DemoApp.Features.Posts.Details;
using DemoApp.Features.Posts.Lists;

namespace DemoApp.Commons.ViewModels
{
    public class ViewModelLocator
    {
        public PostListViewModel PostListViewModel => App.Container.Resolve<PostListViewModel>();
        public PostDetailsViewModel PostDetailsViewModel => App.Container.Resolve<PostDetailsViewModel>();
    }
}