
namespace Fasetto.World.Core
{
    /// <summary>
    /// Details for a messagebox dialog
    /// </summary>
    public class MessageBoxDialogDesignModel:MessageBoxDialogViewModel
    {
        #region Public Properties

        /// <summary>
        /// A single instance of design model
        /// </summary>
        public static MessageBoxDialogDesignModel Instance => new MessageBoxDialogDesignModel();

        #endregion

        #region Constructor

        public MessageBoxDialogDesignModel()
        {
            Message = "Design time messages are fun:)";
            OkText = "OK";
        }

        #endregion
    }
}
