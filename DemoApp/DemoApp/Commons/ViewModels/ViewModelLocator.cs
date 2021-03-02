using Autofac;
using DemoApp.Features.Posts.Details;
using DemoApp.Features.Posts.Lists;
using DemoApp.Features.Settings.AppSettings;

namespace DemoApp.Commons.ViewModels
{
    public class ViewModelLocator
    {
        public AppSettingsViewModel AppSettingsViewModel => App.Container.Resolve<AppSettingsViewModel>();
        public PostListViewModel PostListViewModel => App.Container.Resolve<PostListViewModel>();
        public PostDetailsViewModel PostDetailsViewModel => App.Container.Resolve<PostDetailsViewModel>();
    }
}