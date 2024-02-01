using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace TaskOverflow.Assets.Converters
{
    public class TaskPriorityToString : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            if (value is not int)
                return null;

            return value switch
            {
                0 => "B",
                1 => "M",
                2 => "A",
                _ => "NA",
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
