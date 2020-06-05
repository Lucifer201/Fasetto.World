using System.Windows;

namespace Fasetto.World
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        #region Private Members

        /// <summary>
        /// The view model for this window
        /// </summary>
        private DialogWindowViewModel mViewModel;

        #endregion

        #region Public Properties

        /// <summary>
        /// The view model for this window
        /// </summary>
        public DialogWindowViewModel ViewModel
        {
            get => mViewModel;
            set
            {
                //Set new value
                mViewModel = value;

                DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public DialogWindow()
        {
            InitializeComponent();
        }

        #endregion
    }
}
