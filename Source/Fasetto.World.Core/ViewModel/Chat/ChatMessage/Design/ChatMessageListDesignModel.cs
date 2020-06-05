
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Fasetto.World.Core
{
    /// <summary>
    /// The design-time data for a <see cref="ChatMessageListViewModel"/> 
    /// </summary>
    public class ChatMessageListDesignModel: ChatMessageListViewModel
    {

        #region Public Properties

        /// <summary>
        /// A single instance of design model
        /// </summary>
        public static ChatMessageListDesignModel Instance =>new ChatMessageListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Defualt constructor
        /// </summary>
        public ChatMessageListDesignModel()
        {
            DisplayTitle = "Parnell";

            Items = new ObservableCollection<ChatMessageListItemViewModel>
            {
                new ChatMessageListItemViewModel
                {
                    SenderName = "Parnell",
                    Initials = "PL",
                    Message = "This new app is awesome. I bet it is fast too.",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime=DateTimeOffset.UtcNow,
                    SentByMe=false
                },
                new ChatMessageListItemViewModel
                {
                    SenderName = "Parnell",
                    Initials = "PL",
                    Message = "This new app is awesome. I bet it is fast too.",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime=DateTimeOffset.UtcNow,
                    MessageReadTime=DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3)),
                    SentByMe=true
                },
                new ChatMessageListItemViewModel
                {
                    SenderName = "Parnell",
                    Initials = "PL",
                    Message = "This new app is awesome.\r\n I bet it is fast too.",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime=DateTimeOffset.UtcNow,
                    SentByMe=false
                },
            };

        }

        #endregion
    }
}
