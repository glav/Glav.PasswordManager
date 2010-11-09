using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace PasswordMgr.Helpers
{
    [ValueConversion(typeof(Object), typeof(Brush))]
    public class FindEntryStatusMessageColourConverter : IValueConverter
    {
        static readonly Color successColor = Color.FromArgb(byte.Parse("FF", System.Globalization.NumberStyles.HexNumber),
                byte.Parse("25", System.Globalization.NumberStyles.HexNumber),
                byte.Parse("5F", System.Globalization.NumberStyles.HexNumber),
                byte.Parse("0D", System.Globalization.NumberStyles.HexNumber));
        static readonly Color failureColor = Color.FromArgb(byte.Parse("FF", System.Globalization.NumberStyles.HexNumber),
                byte.Parse("6C", System.Globalization.NumberStyles.HexNumber),
                byte.Parse("20", System.Globalization.NumberStyles.HexNumber),
                byte.Parse("20", System.Globalization.NumberStyles.HexNumber));

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Brush result;
            try
            {
                
                bool foundEntry = false;
                if (value != null)
                    foundEntry = (bool)value;
                else
                    foundEntry = false;

                if (foundEntry)
                    result = new SolidColorBrush(successColor);
                else
                    result = new SolidColorBrush(failureColor);

            }
            catch (Exception)
            {
                result = new SolidColorBrush(failureColor);
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
