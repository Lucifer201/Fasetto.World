using System;
using System.Globalization;
using System.Windows;
using Fasetto.World.Core;

namespace Fasetto.World
{
    /// <summary>
    /// A converter that takes in a <see cref="BaseViewModel"/> and returns a spercific UI control
    /// that should bind to that type of ViewModel
    /// </summary>
    public class PopupContentConverter : BaseValueConverter<PopupContentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is MenuViewModel)
                return new VerticalMenu { DataContext = value };

            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
