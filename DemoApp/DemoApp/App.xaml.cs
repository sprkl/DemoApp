using Autofac;
using DemoApp.Features.Posts.Lists;
using DemoApp.Features.Settings.AppSettings;
using DemoApp.Resources.Lang;
using DemoApp.Services.AppThemes;
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
            
            AppThemeSettings.Initialize();
            LocalizationResourceManager.Current.Init(AppResources.ResourceManager);

            DependencyInjection.Initialize();
            Container = DependencyInjection.GetContainer();

            var navigationService = Container.Resolve<INavigationService>();
            navigationService.NavigateAsync<PostListPage>();
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