﻿
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Fasetto.World.Core
{
    /// <summary>
    /// A view model for each chat list item in the overview chat list 
    /// </summary>
    public class ChatListItemViewModel:BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The display name of this chat list
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The latest message from this chat
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The initials to show for the profile picture background
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// The RGB values (in hex) for the background color of the profile picture
        /// For example FF00FF for Red and Blu mixed
        /// </summary>
        public string ProfilePictureRGB { get; set; }

        /// <summary>
        /// True if there are unread messages in this chat
        /// </summary>
        public bool NewContentAvailable { get; set; }

        /// <summary>
        /// True if this item is selected
        /// </summary>
        public bool IsSelected { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// Open the current message thread
        /// </summary>
        public ICommand OpenMessageCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatListItemViewModel()
        {
            OpenMessageCommand = new RelayCommand(OpenMessage);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Open Message page on the right
        /// </summary>
        private void OpenMessage()
        {
            if (Name=="Jasse")
            {
                IoC.Application.GoToPage(ApplicationPage.Login, new LoginViewModel
                {
                    Email = "esfre@109n.com"
                });


                return;
            }

            IoC.Application.GoToPage(ApplicationPage.Chat, new ChatMessageListViewModel
            {
                DisplayTitle = "Parnell, Me",

                Items = new ObservableCollection<ChatMessageListItemViewModel>
                {
                    new ChatMessageListItemViewModel
                    {
                        Message=Message,
                        Initials=Initials,
                        MessageSentTime=DateTime.UtcNow,
                        ProfilePictureRGB="FF00FF",
                        SenderName="Luke",
                        SentByMe =true
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message="A recive message",
                        Initials=Initials,
                        MessageSentTime=DateTime.UtcNow,
                        ProfilePictureRGB="FF0000",
                        SenderName="Parnell",
                        SentByMe =true
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message=Message,
                        Initials=Initials,
                        MessageSentTime=DateTime.UtcNow,
                        ProfilePictureRGB="FF00FF",
                        SenderName="Luke",
                        SentByMe =true
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message=Message,
                        Initials=Initials,
                        MessageSentTime=DateTime.UtcNow,
                        ProfilePictureRGB="FF00FF",
                        SenderName="Luke",
                        SentByMe =true
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message="A recive message",
                        Initials=Initials,
                        MessageSentTime=DateTime.UtcNow,
                        ProfilePictureRGB="FF0000",
                        SenderName="Parnell",
                        SentByMe =false
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message=Message,
                        Initials=Initials,
                        ImageAttachment=new ChatMessageListItemImageAttachmentViewModel
                        {
                            ThumbnailUrl="http://anywhere"
                        },
                        MessageSentTime=DateTime.UtcNow,
                        ProfilePictureRGB="FF00FF",
                        SenderName="Luke",
                        SentByMe =true
                    }
                }

            });
        }

        #endregion
    }
}