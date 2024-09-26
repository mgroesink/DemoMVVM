using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVVMWithToolkit.Converters
{
    public class ValidImageConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var imageUrl = value as string;

            // Controleer of de URL leeg is of niet bestaat, retourneer dan een fallback-afbeelding.
            if (!imageUrl!.ToLower().StartsWith("pokemon") || !imageUrl.ToLower().EndsWith("jpg"))
            {
                return "no-image-icon"; // Geef hier je alternatieve afbeelding op.
            }

            // Probeer de originele afbeelding te laden
            return imageUrl;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
