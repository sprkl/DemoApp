using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DemoApp.Services.AppThemes
{
    public static class AppThemeSettings
    {
        public const string AppThemeSettingKey = "AppTheme";
        
        public static OSAppTheme AppTheme
        {
            get
            {
                var appTheme = Preferences.Get(AppThemeSettingKey, GetAppThemeName(OSAppTheme.Unspecified));
                return GetAppThemeEnum(appTheme);
            }
            set
            {
                var appTheme = GetAppThemeName(value);
                Preferences.Set(AppThemeSettingKey, appTheme);
            }
        }

        public static void Initialize()
        {
            Application.Current.UserAppTheme = AppTheme;
        }

        private static OSAppTheme GetAppThemeEnum(string appTheme)
        {
            return (OSAppTheme)Enum.Parse(typeof(OSAppTheme), appTheme);
        }

        private static string GetAppThemeName(OSAppTheme appTheme)
        {
            return Enum.GetName(typeof(OSAppTheme), appTheme);
        }
    }
}