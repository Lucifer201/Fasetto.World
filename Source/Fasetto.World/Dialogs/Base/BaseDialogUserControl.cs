using Fasetto.World.Core;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;
using System.Windows.Input;

namespace Fasetto.World
{
    /// <summary>
    /// The base class for any content that is being used inside of <see cref="DialogWindow"/>
    /// </summary>
    public class BaseDialogUserControl:UserControl
    {
        #region Private Members

        /// <summary>
        /// The dialog window we will be contained within
        /// </summary>
        private DialogWindow mDialogWindow;

        #endregion

        #region Public Commands

        /// <summary>
        /// Command to close this dialog
        /// </summary>
        public ICommand CloseCommand { get; private set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// The minimum width of this dialog
        /// </summary>
        public int WindowMinimumWidth { get; set; } = 250;
        
        /// <summary>
        /// The minimum height of this dialog
        /// </summary>
        public int WindowMinimumHeight { get; set; } = 100;


        /// <summary>
        /// The minimum height title bar
        /// </summary>
        public int TitleHeight { get; set; } = 30;

        /// <summary>
        /// The title of this dialog
        /// </summary>
        public string Title { get; set; }

        #endregion

        #region Public Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseDialogUserControl()
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                //Create a new dialog
                mDialogWindow = new DialogWindow();
                mDialogWindow.ViewModel = new DialogWindowViewModel(mDialogWindow);

                //Create command
                CloseCommand = new RelayCommand(() => mDialogWindow.Close());
            }
        }

        #endregion

        #region Public Show Dialog Method

        /// <summary>
        /// Disaplays a single message box to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <param name="T">The view model type for this control</param>
        /// <returns></returns>
        public Task ShowDialog<T>(T viewModel)
            where T : BaseDialogViewModel
        {
            //Create a task to await the dialog closing
            var tcs = new TaskCompletionSource<bool>();

            //Run on a UI thread
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    //Match controls expected sizes to the dialog windows view model
                    mDialogWindow.ViewModel.WindowMinimumHeight = WindowMinimumHeight;
                    mDialogWindow.ViewModel.WindowMinimumWidth = WindowMinimumWidth;
                    mDialogWindow.ViewModel.TitleHeight = TitleHeight;
                    mDialogWindow.ViewModel.Title = string.IsNullOrEmpty(viewModel.Title) ? Title : viewModel.Title;

                    //Set this control to the dialog window content
                    mDialogWindow.ViewModel.Content = this;

                    //Set this controls data context binding to the view model
                    DataContext = viewModel;

                    //Show in the center of the parent
                    mDialogWindow.Owner = Application.Current.MainWindow;
                    mDialogWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                    //Show dialog
                    mDialogWindow.ShowDialog();
                }
                finally
                {
                    //Let caller know we finished
                    tcs.TrySetResult(true);
                }
            });

            return tcs.Task;
        }

        #endregion

    }
}
