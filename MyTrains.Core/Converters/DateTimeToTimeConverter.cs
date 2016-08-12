using System;
using MvvmCross.Platform.Converters;

namespace MyTrains.Core.Converters
{
    public class DateTimeToTimeConverter:
        MvxValueConverter<DateTime, string>
    {
        protected override string Convert(DateTime value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return value.ToString("hh:mm");
        }
    }
}