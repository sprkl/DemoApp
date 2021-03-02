using Autofac;
using DemoApp.Application.HttpServices;
using DemoApp.Posts.Details;
using DemoApp.Posts.Lists;
using DemoApp.Services.Navigations;

namespace DemoApp
{
    public static class DependencyInjection
    {
        private static bool _isInitialized;
        
        private static IContainer _container;

        public static void Initialize()
        {
            if (_isInitialized) return;

            var builder = new ContainerBuilder();
            builder = RegisterServices(builder);
            builder = RegisterHttpServices(builder);
            builder = RegisterViewModels(builder);
            
            _container = builder.Build();
            _isInitialized = true;
        }

        public static IContainer GetContainer() => _container;

        private static ContainerBuilder RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<NavigationService>().As<INavigationService>();
            return builder;
        }
        
        private static ContainerBuilder RegisterHttpServices(ContainerBuilder builder)
        {
            var serviceLocator = new ServiceLocator();
            builder.Register(c => serviceLocator.PostService);
            builder.Register(c => serviceLocator.CommentService);

            return builder;
        }

        private static ContainerBuilder RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterType<PostListViewModel>().SingleInstance();
            builder.RegisterType<PostDetailsViewModel>().SingleInstance();
            return builder;
        }
    }
}