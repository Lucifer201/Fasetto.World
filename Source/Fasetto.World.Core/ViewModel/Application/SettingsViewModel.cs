using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasetto.World.Core
{
    /// <summary>
    /// The settings state as a view model
    /// </summary>
    public class SettingsViewModel:BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The current users name 
        /// </summary>
        public TextEntryViewModel Name { get; set; }

        /// <summary>
        /// The current users username 
        /// </summary>
        public TextEntryViewModel UserName { get; set; }
        
        /// <summary>
        /// The current users password 
        /// </summary>
        public PasswordEntryViewModel Password { get; set; }

        /// <summary>
        /// The current users email 
        /// </summary>
        public TextEntryViewModel Email { get; set; }

        /// <summary>
        /// The text for logout button
        /// </summary>
        public string LogoutButtonText { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// The command to open the setting menu
        /// </summary>
        public ICommand OpenCommand { get; set; }

        /// <summary>
        /// The command to close the setting menu
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to logout of the application
        /// </summary>
        public ICommand LogoutCommand { get; set; }

        /// <summary>
        /// The command to clear user's data from the view model
        /// </summary>
        public ICommand ClearUserDataCommand { get; set; }

        #endregion

        #region Constructor

        public SettingsViewModel()
        {
            //Create command
            CloseCommand = new RelayCommand(Close);
            OpenCommand = new RelayCommand(Open);
            LogoutCommand = new RelayCommand(Logout);
            ClearUserDataCommand = new RelayCommand(ClearUserData);

            //TODO：Get form localization
            LogoutButtonText = "Logout";

        }

        #endregion

        #region Command Methods
        
        /// <summary>
        /// Close the settings menu
        /// </summary>
        private void Close()
        {
            //Close settings menu
            IoC.Application.SettingMenuVisible = false;
        }

        /// <summary>
        /// Open the settings menu
        /// </summary>
        private void Open()
        {
            //Close settings menu
            IoC.Application.SettingMenuVisible = true;
        }

        /// <summary>
        /// Logout the user out
        /// </summary>
        private void Logout()
        {
            //TODO: Confirm user wants to logout

            //TODO: Clear user data/cache

            //TODO: Clean all application level view models that contain
            //      any information about the current user
            ClearUserData();

            //Go to the login page
            IoC.Application.GoToPage(ApplicationPage.Login);
        }

        /// <summary>
        /// Clears any data specific to the current user
        /// </summary>
        private void ClearUserData()
        {
            //Clear all view models containing the users info
            Name = null;
            UserName = null;
            Password = null;
            Email = null;
        }

        #endregion

    }
}
