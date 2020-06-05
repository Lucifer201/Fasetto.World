using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.World.Core
{
    /// <summary>
    /// The application state as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Chat;

        /// <summary>
        /// The view model to use for the current page when <see cref="CurrentPage"/> changes
        /// NOTE: This is not a live up-to-date view model of the current page
        ///       it is simply used to set the view  model of the current page
        ///       at the time it changes
        /// </summary>
        public BaseViewModel CurrentPageViewModel { get; set; }

        /// <summary>
        /// True if the side menu is shown
        /// </summary>
        public bool SideMenuVisible { get; set; } = true;

        /// <summary>
        /// True if the Setting menu is shown
        /// </summary>
        public bool SettingMenuVisible { get; set; }

        /// <summary>
        /// Navigates to specified page
        /// </summary>
        /// <param name="page">The page we go to</param>
        /// <param name="viewModel">The view model, if any, to set explicity to the new page</param>
        public void GoToPage(ApplicationPage page, BaseViewModel viewModel=null)
        {
            //Always hide the setting page when change the current page
            SettingMenuVisible = false;

            //Set the view model
            CurrentPageViewModel = viewModel;

            //Set the current page
            CurrentPage = page;

            //Fire off a current page changed event
            OnPropertyChanged(nameof(CurrentPage));

            //Show side menu or not?
            SideMenuVisible = page == ApplicationPage.Chat;
        }
    }
}
