
using System.Collections.Generic;
using System.Windows.Input;

namespace Fasetto.World.Core
{
    /// <summary>
    /// A view model for the overview chat list
    /// </summary>
    public class ChatListViewModel:BaseViewModel
    {
        #region Public Properties
        /// <summary>
        /// The chat list items for this list
        /// </summary>
        public List<ChatListItemViewModel> Items { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatListViewModel()
        {

        }

        #endregion

    }
}
