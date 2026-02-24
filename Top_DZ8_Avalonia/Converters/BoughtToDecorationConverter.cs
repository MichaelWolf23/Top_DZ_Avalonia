using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace Top_DZ8_Avalonia.Converters;

public class BoughtToDecorationConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return (value is bool isBought && isBought) ? TextDecorations.Strikethrough : null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotImplementedException();
}