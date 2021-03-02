using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace DemoApp.Commons.Converters
{
    public class TextToInitialConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
            {
                var extractInitials = new Regex(@"\s*([^\s])[^\s]*\s*");
                
                var initials = extractInitials
                    .Replace(text, "$1")
                    .ToUpper()
                    .Take(2)
                    .ToArray();
                
                return new string(initials);
            }
            
            Debug.WriteLine($"Cannot convert given {value}! Use empty string as result of conversion.");
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}