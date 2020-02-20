using System;
using System.Globalization;
using System.IO;
using System.Xml;
using Avalonia.Data.Converters;
using AvaloniaEdit.Highlighting;

namespace AvalonStalker.Converters
{
    public class HighlightingDefinitionConverter: IValueConverter
    {
        private static readonly HighlightingDefinitionTypeConverter Converter = new HighlightingDefinitionTypeConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var json = value as string;
            if (json.Equals("JSON"))
            {
               
                return Converter.ConvertFrom("JavaScript");
            }
            
            return Converter.ConvertFrom(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Converter.ConvertToString(value);
        }
    }
}