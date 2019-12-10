using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;

namespace ShoppingList
{
    public class ShoppingItemInvisibleConverter : BaseConverter, IValueConverter

    {

        public object Convert(object value, Type? targetType =null , object? parameter = null, CultureInfo? culture = null)
        {
            if (value is ShoppingItem && value!=null)
            {
                return "Visible";
            }
            else
            {
                return "Hidden";
            }
        }

        public object ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException();
        }





    }
}
