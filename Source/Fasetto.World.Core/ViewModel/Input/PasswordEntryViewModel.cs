using System.Security;
using System.Windows.Input;

namespace Fasetto.World.Core
{
    /// <summary>
    /// The view model for a password entry edit a string value
    /// </summary>
    public class PasswordEntryViewModel:BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The label to identify what this value is for
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The fake password display
        /// </summary>
        public string FakePassword { get; set; }

        /// <summary>
        /// The current password hint text
        /// </summary>
        public string CurrentPasswordHintText { get; set; }

        /// <summary>
        /// The new password hint text
        /// </summary>
        public string NewPasswordHintText { get; set; }

        /// <summary>
        /// The Confirm password hint text
        /// </summary>
        public string ConfirmPasswordHintText { get; set; }

        /// <summary>
        /// The current saved password
        /// </summary>
        public SecureString CurrentPassword { get; set; }

        /// <summary>
        /// The new password
        /// </summary>
        public SecureString NewPassword { get; set; }

        /// <summary>
        /// The current confirm password
        /// </summary>
        public SecureString ConfirmPassword { get; set; }

        /// <summary>
        /// Indicates if the current text is in edit mode
        /// </summary>
        public bool Editing { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// Puts the control into edit mode
        /// </summary>
        public ICommand EditCommand { get; set; }

        /// <summary>
        /// Cancels out of edit mode
        /// </summary>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// Commits the edits and save the value
        /// as well as goes back to non-edit mode
        /// </summary>
        public ICommand SaveCommand { get; set; }
         
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PasswordEntryViewModel()
        {
            //Create commands
            EditCommand = new RelayCommand(Edit);
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);

            //Set the default hints
            //TODO: Repalace with localization text
            CurrentPasswordHintText = "Current Password";
            NewPasswordHintText = "new Password";
            ConfirmPasswordHintText = "Confirm Password";
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Puts the control into edit mode
        /// </summary>
        public void Edit()
        {
            //Clear all password
            CurrentPassword = new SecureString();
            NewPassword = new SecureString();

            //Go into edit mode
            Editing = true;
        }

        /// <summary>
        /// Cancels out of edit mode
        /// </summary>
        public void Cancel()
        {
            Editing = false;
        }

        /// <summary>
        /// Commit the content and exits out of edit mode
        /// </summary>
        public void Save()
        {
            //Make sure the current password is correct
            //TODO: This will come from the real back-end store of this user password
            //      or via the web server to confirm it
            var storePassword = "Testing";

            //Confirm current password is match
            //NOTE: Typically this isn't done here, it's done on the server
            if (storePassword != CurrentPassword.Unsecure())
            {
                //Let us know
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Wrong password",
                    Message = "The current password is invalid",
                });

                return;
            }

            //Now check the new and confirm password match
            //NOTE: Typically this isn't done here, it's done on the server
            if (NewPassword.Unsecure() != ConfirmPassword.Unsecure())
            {
                //Let us know
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Password mismatch",
                    Message = "The new and confirm password do not match",
                });

                return;
            }

            //Check we actually have a password
            if (NewPassword.Unsecure().Length==0)
            {
                //Let us know
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Password too short",
                    Message = "You must enter a password!",
                });

                return;
            }

            //Set the edited password to the current value
            CurrentPassword = new SecureString();
            foreach (var c in NewPassword.Unsecure().ToCharArray())
                CurrentPassword.AppendChar(c);


            Editing = false;
        }

        #endregion

    }
}
