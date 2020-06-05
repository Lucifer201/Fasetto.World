
using Fasetto.World.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace Fasetto.World
{
    /// <summary>
    /// Converts a string name to service pulled from IoC container
    /// </summary>
    public class IoCConverter : BaseValueConverter<IoCConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((string)value)
            {
                case nameof(ApplicationViewModel):
                    return IoC.Application;

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
