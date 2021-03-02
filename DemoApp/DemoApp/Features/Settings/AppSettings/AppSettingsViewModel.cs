using System.Threading.Tasks;
using DemoApp.Commons.ViewModels;
using DemoApp.Services.AppThemes;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace DemoApp.Features.Settings.AppSettings
{
    public class AppSettingsViewModel : ObservableObject, IViewModel
    {
        private bool _useDeviceThemeSettings;
        public bool UseDeviceThemeSettings
        {
            get => _useDeviceThemeSettings;
            set
            {
                if (SetProperty(ref _useDeviceThemeSettings, value))
                {
                    if(_useDeviceThemeSettings)
                        UpdateAppTheme(OSAppTheme.Unspecified);
                }
            }
        }

        private bool _useLightMode;
        public bool UseLightMode
        {
            get => _useLightMode;
            set
            {
                if (SetProperty(ref _useLightMode, value))
                {
                    if(_useLightMode)
                        UpdateAppTheme(OSAppTheme.Light);
                }
            }
        }

        private bool _useDarkMode;
        public bool UseDarkMode
        {
            get => _useDarkMode;
            set
            {
                if (SetProperty(ref _useDarkMode, value))
                {
                    if(_useDarkMode)
                        UpdateAppTheme(OSAppTheme.Dark);
                }
            }
        }

        public Task InitializeAsync()
        {
            var appTheme = AppThemeSettings.AppTheme;
            UseDeviceThemeSettings = appTheme == OSAppTheme.Unspecified;
            UseLightMode = appTheme == OSAppTheme.Light;
            UseDarkMode = appTheme == OSAppTheme.Dark;
            
            return Task.CompletedTask;
        }

        private void UpdateAppTheme(OSAppTheme appTheme)
        {
            Application.Current.UserAppTheme = appTheme;
            AppThemeSettings.AppTheme = appTheme;
        }
    }
}