using DemoApp.Commons.Views;
using Xamarin.Forms.Xaml;

namespace DemoApp.Features.Settings.AppSettings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppSettingsPage : IView
    {
        public ViewType ViewType => ViewType.NavigationModal;

        public AppSettingsPage()
        {
            InitializeComponent();
        }
    }
}