
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Fasetto.World
{
    /// <summary>
    /// Focuses (keyboard focus) this element on load
    /// </summary>
    public class IsFocusedProperty : BaseAttachedProperty<IsFocusedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //If we don't have a control, return
            if (!(sender is Control control))
                return;

            //Focus this control once loaded
            control.Loaded += (s, se) => control.Focus();
        }
    }

    /// <summary>
    /// Focuses (keyboard focus) and select all the text in this element if true
    /// </summary>
    public class FocusedAndSelectProperty : BaseAttachedProperty<FocusedAndSelectProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //If we don't have a control, return
            if (sender is TextBoxBase control)
            {
                if ((bool)e.NewValue)
                {
                    //Focus this control
                    control.Focus();

                    //Select all text
                    control.SelectAll();
                }
            }

            if (sender is PasswordBox passwordBox)
            {
                if ((bool)e.NewValue)
                {
                    //Focus this control
                    passwordBox.Focus();

                    //Select all text
                    passwordBox.SelectAll();
                }
            }
        }
    }
}
