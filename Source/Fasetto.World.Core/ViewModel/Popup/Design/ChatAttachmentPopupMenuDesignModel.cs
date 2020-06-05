using System.Collections.Generic;

namespace Fasetto.World.Core
{
    /// <summary>
    /// A design model for any popup menus
    /// </summary>
    public class ChatAttachmentPopupMenuDesignModel : ChatAttachmentPopupMenuViewModel
    {
        #region Public Properties

        /// <summary>
        /// A single instance of design model
        /// </summary>
        public static ChatAttachmentPopupMenuDesignModel Instance => new ChatAttachmentPopupMenuDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Defualt constructor
        /// </summary>
        public ChatAttachmentPopupMenuDesignModel()
        {

        }

        #endregion
    }
}
