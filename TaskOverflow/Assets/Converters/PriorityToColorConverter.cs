using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace TaskOverflow.Assets.Converters
{
    public class PriorityToColorConverter : IValueConverter
    {
        //TODO spostare queste variabili in un file visibile globalmente, visto che gli stessi valori vengono usati altrove.
        private SolidColorBrush lowSelectedColor = new SolidColorBrush(Color.FromArgb(255, 118, 227, 108));
        private SolidColorBrush mediumSelectedColor = new SolidColorBrush(Color.FromArgb(255, 239, 226, 111));
        private SolidColorBrush highSelectedColor = new SolidColorBrush(Color.FromArgb(255, 235, 94, 94));


        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            if (value is not int)
                return null;

            return value switch
            {
                0 => lowSelectedColor,
                1 => mediumSelectedColor,
                2 => highSelectedColor,
                _ => null,
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
