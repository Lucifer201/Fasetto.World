
namespace Fasetto.World.Core
{
    /// <summary>
    /// The design time data for a <see cref="TextEntryViewModel"/>
    /// </summary>
    public class TextEntryDesignModel: TextEntryViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of design model
        /// </summary>
        public static TextEntryDesignModel Instance => new TextEntryDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TextEntryDesignModel()
        {
            Label = "Name";
            OriginalText = "Luck Malpass";
            EditedText = "Editing :)";
        }

        #endregion
    }
}
