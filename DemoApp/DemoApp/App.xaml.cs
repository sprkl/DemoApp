using Autofac;
using DemoApp.Features.Posts.Lists;
using DemoApp.Features.Account.Login;
using DemoApp.Resources.Lang;
using DemoApp.Services.Navigations;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DemoApp
{
    public partial class App
    {
        public static IContainer Container { get; private set; }
        
        public App()
        {
            InitializeComponent();
            
            LocalizationResourceManager.Current.Init(AppResources.ResourceManager);

            DependencyInjection.Initialize();
            Container = DependencyInjection.GetContainer();

            var navigationService = Container.Resolve<INavigationService>();
            navigationService.NavigateAsync<LoginPage>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            
        }

        protected override void OnResume()
        {
            
        }
    }
}