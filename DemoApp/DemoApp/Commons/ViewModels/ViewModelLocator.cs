using Autofac;
using DemoApp.Posts.Details;
using DemoApp.Posts.Lists;

namespace DemoApp.Commons.ViewModels
{
    public class ViewModelLocator
    {
        public PostListViewModel PostListViewModel => App.Container.Resolve<PostListViewModel>();
        public PostDetailsViewModel PostDetailsViewModel => App.Container.Resolve<PostDetailsViewModel>();
    }
}