using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            System.Diagnostics.Debug.WriteLine($"\nvalue {value}\n");

            switch (value)
            {
                case 0:
                    return "B";
                case 1:
                    return "M";
                case 2:
                    return "A";
                default:
                    return "NA";
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
