
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Fasetto.World.Core
{
    /// <summary>
    /// A view model for the chat message thread list
    /// </summary>
    public class ChatMessageListViewModel : BaseViewModel
    {
        #region Protected Members

        /// <summary>
        /// The last search text in this list
        /// </summary>
        protected string mLastSearchText;

        /// <summary>
        /// The text to search for in the search command
        /// </summary>
        protected string mSearchText;

        /// <summary>
        /// The chat thread items for the list
        /// </summary>
        protected ObservableCollection<ChatMessageListItemViewModel> mItems;

        /// <summary>
        /// A flag indicating if the search dialog is open
        /// </summary>
        protected bool mSearchIsOpen;

        #endregion

        #region Public Properties

        /// <summary>
        /// The chat list items for this list
        /// </summary>
        public ObservableCollection<ChatMessageListItemViewModel> Items
        {
            get => mItems;
            set
            {
                //Make sure list has changed
                if (mItems == value)
                    return;

                //Update value
                mItems = value;

                //Update filter list to match
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(mItems);
            }
        }

        /// <summary>
        /// The chat thread items for the list that include any serch filtering
        /// </summary>
        public ObservableCollection<ChatMessageListItemViewModel> FilteredItems { get; set; }

        /// <summary>
        /// The title of this chat list
        /// </summary>
        public string DisplayTitle { get; set; }

        /// <summary>
        /// True to show the attachment menu, false to hide it
        /// </summary>
        public bool AttachmentMenuVisible { get; set; }

        /// <summary>
        /// True if any popup menus are visible
        /// </summary>
        public bool AnyPopupVisible => AttachmentMenuVisible;

        /// <summary>
        /// The view model for the attachment menu
        /// </summary>
        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        /// <summary>
        /// The text for the current message being written
        /// </summary>
        public string PendingMessageText { get; set; }

        /// <summary>
        /// The text to search for when we do a search
        /// </summary>
        public string SearchText
        {
            get => mSearchText;
            set
            {
                //Check value is different
                if (mSearchText == value)
                    return;

                //Update value
                mSearchText = value;

                //If the search text is empty...
                if (string.IsNullOrEmpty(SearchText))
                    //Search to restore message
                    Search();
            }
        }

        /// <summary>
        /// A flag indicating if the search dialog is open
        /// </summary>
        public bool SearchIsOpen
        {
            get => mSearchIsOpen;
            set
            {
                //Check value has changed
                if (mSearchIsOpen == value)
                    return;

                //Update value
                mSearchIsOpen = value;

                //If dialog closes...
                if (!mSearchIsOpen)
                    //Clear search text
                    SearchText = string.Empty;
            }
        }

        #endregion

        #region Public Commands

        /// <summary>
        /// The command for when the attachment button is clicked
        /// </summary>
        public ICommand AttachmentButtonCommand { get; set; }

        /// <summary>
        /// The command for when the area outside of any popup is clicked
        /// </summary>
        public ICommand PopupClickAwayCommand { get; set; }

        /// <summary>
        /// The command for when the user click the send button
        /// </summary>
        public ICommand SendCommand { get; set; }

        /// <summary> 
        /// The command for when the user wants to search 
        /// </summary> 
        public ICommand SearchCommand { get; set; }

        /// <summary> 
        /// The command for when the user wants to open the search dialog 
        /// </summary> 
        public ICommand OpenSearchCommand { get; set; }

        /// <summary> 
        /// The command for when the user wants to close to search dialog 
        /// </summary> 
        public ICommand CloseSearchCommand { get; set; }

        /// <summary> 
        /// The command for when the user wants to clear the search text 
        /// </summary> 
        public ICommand ClearSearchCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatMessageListViewModel()
        {
            //Create commands
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            PopupClickAwayCommand = new RelayCommand(PopupClickAway);
            SendCommand = new RelayCommand(Send);
            SearchCommand = new RelayCommand(Search);
            OpenSearchCommand = new RelayCommand(OpenSearch);
            CloseSearchCommand = new RelayCommand(CloseSearch);
            ClearSearchCommand = new RelayCommand(ClearSearch);


            //Make a defult menu
            AttachmentMenu = new ChatAttachmentPopupMenuViewModel();

        }

        #endregion

        #region Command Methods

        /// <summary>
        /// When the attachment button is clicked show/hide the attachment popup
        /// </summary>
        public void AttachmentButton()
        {
            //Toggle menu visibility
            AttachmentMenuVisible ^= true;
        }
        /// <summary>
        /// When popup clicked away area is clicked hide any popups
        /// </summary>
        public void PopupClickAway()
        {
            //Hide attachment menu
            AttachmentMenuVisible = false;

        }
        /// <summary>
        /// When the user click the send button, send the message
        /// </summary>
        public void Send()
        {
            //Don't send a blank message
            if (string.IsNullOrEmpty(PendingMessageText))
                return;

            //Ensure lists are not null
            if (Items == null)
                Items = new ObservableCollection<ChatMessageListItemViewModel>();

            //Fake send a message
            var message = new ChatMessageListItemViewModel
            {
                Initials = "LM",
                Message = PendingMessageText,
                MessageSentTime = DateTime.UtcNow,
                SentByMe = true,
                SenderName = "Luke Malpass",
                NewItem = true
            };

            //Add message to both lists
            Items.Add(message);
            FilteredItems.Add(message);

            //Clear the pending message text
            PendingMessageText = string.Empty;

        }

        /// <summary>
        /// Searches the current message list and filters the view
        /// </summary>
        public void Search()
        {
            //Make sure we don't re-search the same text
            if ((string.IsNullOrEmpty(mLastSearchText) && string.IsNullOrEmpty(SearchText)) ||
                string.Equals(mLastSearchText, SearchText))
                return;

            //If we have no search text, or no items
            if (string.IsNullOrEmpty(SearchText) || Items == null||Items.Count<=0)
            {
                //Make filtered list the same
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(Items??Enumerable.Empty<ChatMessageListItemViewModel>());

                //Set last search text
                mLastSearchText = SearchText;

                return;
            }

            //Find all items that contain the given text
            //TODO: Make more efficient search
            FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(
                Items.Where(item => item.Message.ToLower().Contains(SearchText)));

            //Set lase search text
            mLastSearchText = SearchText;
        }

        /// <summary>
        /// Clears the search text
        /// </summary>
        public void ClearSearch()
        {
            //If there is some search tex...
            if (!string.IsNullOrEmpty(SearchText))
                //Clear the text
                SearchText = string.Empty;
            //Otherwise...
            else
                //Close search dialog
                SearchIsOpen = false;
        }

        /// <summary>
        /// Opens the search dialog
        /// </summary>
        public void OpenSearch() => SearchIsOpen = true;

        /// <summary>
        /// Closes the search dialog
        /// </summary>
        public void CloseSearch() => SearchIsOpen = false;

        #endregion

    }
}
