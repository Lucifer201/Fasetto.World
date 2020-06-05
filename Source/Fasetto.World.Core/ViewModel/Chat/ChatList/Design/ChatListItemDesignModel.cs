

namespace Fasetto.World.Core
{
    /// <summary>
    /// The design-time data for a <see cref="ChatListItemViewModel"/> 
    /// </summary>
    public class ChatListItemDesignModel : ChatListItemViewModel
    {

        #region Public Properties

        /// <summary>
        /// A single instance of design model
        /// </summary>
        public static ChatListItemDesignModel Instance =>new ChatListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Defualt constructor
        /// </summary>
        public ChatListItemDesignModel()
        {
            Initials = "LM";
            Name = "Luke";
            Message = "This new app is awesome. I bet it is fast too.";
            ProfilePictureRGB = "3099c5";

        }

        #endregion
    }
}
