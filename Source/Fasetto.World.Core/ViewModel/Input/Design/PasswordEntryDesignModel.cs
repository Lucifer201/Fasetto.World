
namespace Fasetto.World.Core
{
    /// <summary>
    /// The design time data for a <see cref="PasswordEntryViewModel"/>
    /// </summary>
    public class PasswordEntryDesignModel: PasswordEntryViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of design model
        /// </summary>
        public static PasswordEntryDesignModel Instance => new PasswordEntryDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PasswordEntryDesignModel()
        {
            Label = "Password";
            FakePassword = "fake-design";
        }

        #endregion
    }
}
