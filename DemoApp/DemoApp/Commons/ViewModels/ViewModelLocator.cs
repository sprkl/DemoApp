using Autofac;
using DemoApp.Features.Posts.Details;
using DemoApp.Features.Posts.Lists;
using DemoApp.Features.Account.Login;

namespace DemoApp.Commons.ViewModels
{
    public class ViewModelLocator
    {
        public PostListViewModel PostListViewModel => App.Container.Resolve<PostListViewModel>();
        public PostDetailsViewModel PostDetailsViewModel => App.Container.Resolve<PostDetailsViewModel>();
        public LoginViewModel LoginViewModel => App.Container.Resolve<LoginViewModel>();
    }
}