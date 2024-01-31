using Avalonia.Data.Converters;
using System;
using System.Globalization;


namespace TaskOverflow.Assets.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            if (value is not DateTime)
                return null;

            return ((DateTime)value).ToShortDateString();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
