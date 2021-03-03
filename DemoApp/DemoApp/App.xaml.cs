using Autofac;
using DemoApp.Features.Posts.Lists;
using DemoApp.Resources.Lang;
using DemoApp.Services.Hello;
using DemoApp.Services.Navigations;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;
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
            navigationService.NavigateAsync<PostListPage>();
            
            var helloService = DependencyService.Get<IHelloService>();
            var helloString = helloService.GetHelloString();
            App.Current.MainPage.DisplayAlert("Hello", helloString, "OK");
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