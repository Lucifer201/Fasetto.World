
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.World
{
    /// <summary>
    /// The NoFrameHistory attached property for Creating a <see cref="Frame"/> that never shows the navigation
    /// </summary>
    public class NoFrameHistory : BaseAttachedProperty<NoFrameHistory, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //Get the frame
            var frame = (sender as Frame);

            //Hide navigation bar
            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            //Clear history on naviagate
            frame.Navigated += (ss, ee) => ((Frame)ss).NavigationService.RemoveBackEntry();

        }
    }
}
