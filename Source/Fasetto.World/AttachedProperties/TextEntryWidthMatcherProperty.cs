using System;
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.World
{
    /// <summary>
    /// Match the label width of all text entry controls inside this panel
    /// </summary>
    public class TextEntryWidthMatcherProperty : BaseAttachedProperty<TextEntryWidthMatcherProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //Get the panel (grid typically)
            var panel = (sender as Panel);

            //Call SetWidths initially (this is alse helpful for design time work)
            SetWidth(panel);

            //Wait for panel to load
            RoutedEventHandler onLoaded = null;
            onLoaded=(ss, ee) =>
            {
                //Unhook
                panel.Loaded -= onLoaded;

                //Set width
                SetWidth(panel);

                //Loop each child
                foreach (var child in panel.Children)
                {
                    //Ignore any non-text entry control
                    if (!(child is TextEntryControl &&!(child is PasswordEntryControl)))
                        continue;

                    //Get the label from the text entry or password entry
                    var label = child is TextEntryControl ? (child as TextEntryControl).Label : (child as PasswordEntryControl).Label;

                    //Set it's value to the given value
                    label.SizeChanged += (sss, eee) =>
                    {
                        //Update width
                        SetWidth(panel);
                    };


                }
            };

            //Hook into the loaded event
            panel.Loaded += onLoaded;




        }

        /// <summary>
        /// Update all child text entry controls so their widths match the largest width of the group
        /// <paramref name="panel">The panel containing the text entry controls</paramref>
        /// </summary>
        private void SetWidth(Panel panel)
        {
            //Keep track of the Maximum width
            var maxSize = 0d;

            //For each child ...
            foreach (var child in panel.Children)
            {
                //Ignore any non-text entry control
                if (!(child is TextEntryControl)&&!(child is PasswordEntryControl))
                    continue;

                //Get the label from the text entry or password entry
                var label = child is TextEntryControl ? (child as TextEntryControl).Label : (child as PasswordEntryControl).Label;


                //Find if this value is larger than the other controls
                maxSize = Math.Max(maxSize, label.RenderSize.Width + label.Margin.Left + label.Margin.Right);

            }

            //Transform the maxSize to GridLength
            var gridlength = (GridLength)new GridLengthConverter().ConvertFromString(maxSize.ToString());

            //For each child ...
            foreach (var child in panel.Children)
            {
                if (child is TextEntryControl text)
                    //Set each controls labelWidth value to the max size
                    text.LabelWidth = gridlength;
                else if (child is PasswordEntryControl pass)
                    //Set each controls labelWidth value to the max size
                    pass.LabelWidth = gridlength;
            }

        }
    }
}
