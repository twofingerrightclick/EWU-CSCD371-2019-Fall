using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace ShoppingList
{
    class DateAddedConverter : IValueConverter
    {
        public object Convert(object value, Type? targetType=null, object? parameter=null, CultureInfo? culture=null)
        {
            if (value is ShoppingItem)
            {

                var timeAdded = DateTime.Today.ToShortDateString();
                return timeAdded;
            }
            else
            {
                return "hello world!";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
