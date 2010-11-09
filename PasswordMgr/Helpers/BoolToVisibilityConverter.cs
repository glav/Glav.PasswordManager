using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace PasswordMgr.Helpers
{
    [ValueConversion(typeof(Object), typeof(Visibility), ParameterType = typeof(string))]
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility result;

            try
            {
                bool isVisible = false;
                if (value != null)
                    isVisible = (bool)value;
                else
                    isVisible = false;

                if (parameter != null)
                {
                    string parm = parameter as string;
                    if (parm.ToLowerInvariant() == "negateresult")
                        isVisible = !isVisible;
                }

                result = isVisible ? Visibility.Visible : Visibility.Hidden;

            }
            catch (Exception)
            {
                result = Visibility.Hidden;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
