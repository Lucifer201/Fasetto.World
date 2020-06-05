﻿using Fasetto.World.Core;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.World
{
    /// <summary>
    /// Interaction logic for PasswordEntryControl.xaml
    /// </summary>
    public partial class PasswordEntryControl : UserControl
    {
        #region Dependency Properties

        public GridLength LabelWidth
        {
            get { return (GridLength)GetValue(LabelWidthProperty); }
            set { SetValue(LabelWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(PasswordEntryControl), new PropertyMetadata(GridLength.Auto,LabelWidthChangedCallback));

        #endregion

        #region Constructor

        /// <summary>
        /// Default constuctor
        /// </summary>
        public PasswordEntryControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Dependency Properties Callbacks

        public static void LabelWidthChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                //Set the colum width to new value
                (d as PasswordEntryControl).LabelColumDefinition.Width = (GridLength)e.NewValue;

            }
            catch
            {
                //Make developer aware of potential issue
                Debugger.Break();

                (d as PasswordEntryControl).LabelColumDefinition.Width = GridLength.Auto;
            }
        }

        #endregion

        /// <summary>
        /// Update the view model value with the new password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //Update view model
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.CurrentPassword = CurrentPassword.SecurePassword;
        }

        /// <summary>
        /// Update the view model value with the new password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //Update view model
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.NewPassword = NewPassword.SecurePassword;
        }

        /// <summary>
        /// Update the view model value with the new password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //Update view model
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.ConfirmPassword = ConfirmPassword.SecurePassword;
        }


    }
}