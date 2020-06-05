
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.World
{
    /// <summary>
    /// The MonitorPassword attached property for a <see cref="PasswordBox"/>
    /// </summary>
    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //Get the caller
            var password = sender as PasswordBox;

            //Make sure it is a password box
            if (password == null)
                return;

            //password.PasswordChanged-=

            //If the caller set MonitorPassword to true...
            if ((bool)e.NewValue)
            {
                //Set default value
                HasTextProperty.SetValue(password);

                //Start listening out for password changes
                password.PasswordChanged += Password_PasswordChanged;
            }
        }

        /// <summary>
        /// Fired when the password box password value changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //Sets the attached HasText value
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }

    /// <summary>
    /// The HasText attached property for a <see cref="PasswordBox"/>
    /// </summary>
    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        /// <summary>
        /// Sets the HasText property based on if the caller <see cref="PasswordBox"/> has any text
        /// </summary>
        /// <param name="sender"></param>
        public static void SetValue(DependencyObject sender)
        {
            SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }
}
