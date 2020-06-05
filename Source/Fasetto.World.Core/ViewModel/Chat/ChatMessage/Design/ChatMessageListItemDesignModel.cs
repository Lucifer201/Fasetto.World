

using System;

namespace Fasetto.World.Core
{
    /// <summary>
    /// The design-time data for a <see cref="ChatMessageListItemDesignModel"/> 
    /// </summary>
    public class ChatMessageListItemDesignModel : ChatMessageListItemViewModel
    {

        #region Public Properties

        /// <summary>
        /// A single instance of design model
        /// </summary>
        public static ChatMessageListItemDesignModel Instance =>new ChatMessageListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Defualt constructor
        /// </summary>
        public ChatMessageListItemDesignModel()
        {
            Initials = "LM";
            SenderName = "Luke";
            Message = "Some design time visual text.";
            ProfilePictureRGB = "3099c5";
            SentByMe = true;
            MessageSentTime = DateTimeOffset.UtcNow;
            MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3));
        }

        #endregion
    }
}
