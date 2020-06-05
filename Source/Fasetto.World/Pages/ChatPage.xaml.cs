using Fasetto.World.Core;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Fasetto.World
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class ChatPage : BasePage<ChatMessageListViewModel>
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatPage():base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific view model used for this page</param>
        public ChatPage(ChatMessageListViewModel specificViewModel):base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Fired when the view model changes
        /// </summary>
        protected override void OnViewModelChanged()
        {
            //Make sure the UI exist
            if (ChatMessageList == null)
                return;

            //Fade in chat messge list
            var storyboard = new Storyboard();
            storyboard.AddFadeIn(1);
            storyboard.Begin(ChatMessageList);

            //Make the messagebox focused
            MessageText.Focus();
        }

        #endregion

        /// <summary>
        /// Preview the input into the message box and respond as required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageText_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //Get the text box
            var textbox = sender as TextBox;

            //Check if we have pressed Ctrl+Enter, if, new line
            if (e.Key == Key.Enter)
            {
                if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
                {
                    //Add a new line at the point where the cursor is 
                    var index = textbox.CaretIndex;

                    //Insert the new line
                    textbox.Text = textbox.Text.Insert(index, Environment.NewLine);

                    //Shift the caret forward to the new line
                    textbox.CaretIndex = index + Environment.NewLine.Length;

                    //Mark this key as handled by us
                    e.Handled = true;

                }
                else
                    ViewModel.Send();

                //Mark this key as handled by us
                e.Handled = true;

            }

        }
    }
}
