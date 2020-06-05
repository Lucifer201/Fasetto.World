using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.World
{
    /// <summary>
    /// Interaction logic for TextEntryControl.xaml
    /// </summary>
    public partial class TextEntryControl : UserControl
    {
        #region Dependency Properties

        public GridLength LabelWidth
        {
            get { return (GridLength)GetValue(LabelWidthProperty); }
            set { SetValue(LabelWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabelWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(TextEntryControl), new PropertyMetadata(GridLength.Auto,LabelWidthChangedCallback));

        #endregion

        #region Constructor

        /// <summary>
        /// Default constuctor
        /// </summary>
        public TextEntryControl()
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
                (d as TextEntryControl).LabelColumDefinition.Width = (GridLength)e.NewValue;

            }
            catch
            {
                //Make developer aware of potential issue
                Debugger.Break();

                (d as TextEntryControl).LabelColumDefinition.Width = GridLength.Auto;
            }
        }

        #endregion
    }
}
