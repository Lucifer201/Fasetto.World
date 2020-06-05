
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.World
{
    /// <summary>
    /// The PanelChildMarginProperty attached property for Creating a <see cref="Panel"/> which has children
    /// </summary>
    public class PanelChildMarginProperty : BaseAttachedProperty<PanelChildMarginProperty, string>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //Get the panel (grid typically)
            var panel = (sender as Panel);

            //Wait for panel to load
            panel.Loaded += (ss, ee) =>
            {
                //Load each child
                foreach (var child in panel.Children)
                    //Set it's value to the given value
                    (child as FrameworkElement).Margin = (Thickness)(new ThicknessConverter().ConvertFromString(e.NewValue as string));
            };

        }
    }
}
