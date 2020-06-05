

using System.Collections.Generic;

namespace Fasetto.World.Core
{
    /// <summary>
    /// The design-time data for a <see cref="ChatListDesignModel"/> 
    /// </summary>
    public class ChatListDesignModel: ChatListViewModel
    {

        #region Public Properties

        /// <summary>
        /// A single instance of design model
        /// </summary>
        public static ChatListDesignModel Instance =>new ChatListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Defualt constructor
        /// </summary>
        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Initials = "LM",
                    Name = "Luke",
                    Message = "This new app is awesome. I bet it is fast too.",
                    ProfilePictureRGB = "3099c5",
                    NewContentAvailable=true,
                },
                new ChatListItemViewModel
                {
                    Initials = "JA",
                    Name = "Jasse",
                    Message = "Hey dude, here are the icons.",
                    ProfilePictureRGB = "fe4503"

                },
                new ChatListItemViewModel
                {
                    Initials = "PL",
                    Name = "Parnell",
                    Message = "The new server is up, got 198.168.1.1",
                    ProfilePictureRGB = "00d405",
                    IsSelected=true,
                },
                new ChatListItemViewModel
                {
                    Initials = "LM",
                    Name = "Luke",
                    Message = "This new app is awesome. I bet it is fast too.",
                    ProfilePictureRGB = "3099c5"
                },
                new ChatListItemViewModel
                {
                    Initials = "JA",
                    Name = "Jasse",
                    Message = "Hey dude, here are the icons.",
                    ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Initials = "PL",
                    Name = "Parnell",
                    Message = "The new server is up, got 198.168.1.1",
                    ProfilePictureRGB = "00d405"
                },
                new ChatListItemViewModel
                {
                    Initials = "LM",
                    Name = "Luke",
                    Message = "This new app is awesome. I bet it is fast too.",
                    ProfilePictureRGB = "3099c5"
                },
                new ChatListItemViewModel
                {
                    Initials = "JA",
                    Name = "Jasse",
                    Message = "Hey dude, here are the icons.",
                    ProfilePictureRGB = "fe4503"
                },
                new ChatListItemViewModel
                {
                    Initials = "PL",
                    Name = "Parnell",
                    Message = "The new server is up, got 198.168.1.1",
                    ProfilePictureRGB = "00d405"
                },
            };

        }

        #endregion
    }
}
