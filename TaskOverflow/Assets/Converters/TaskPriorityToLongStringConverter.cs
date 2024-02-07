using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOverflow.Assets.Converters
{
    public class TaskPriorityToLongStringConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            if (value is not int)
                return null;

            return value switch
            {
                0 => "Bassa",
                1 => "Media",
                2 => "Alta",
                _ => "NA",
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
