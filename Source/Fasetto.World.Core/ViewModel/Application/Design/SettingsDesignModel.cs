using System.Collections.Generic;

namespace Fasetto.World.Core
{
    /// <summary>
    /// The design-time data for a <see cref="SettingsViewModel"/> 
    /// </summary>
    public class SettingsDesignModel: SettingsViewModel
    {

        #region Public Properties

        /// <summary>
        /// A single instance of design model
        /// </summary>
        public static SettingsDesignModel Instance =>new SettingsDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Defualt constructor
        /// </summary>
        public SettingsDesignModel()
        {
            Name = new TextEntryViewModel { Label = "Name", OriginalText = "Luke Maiquee" };
            UserName = new TextEntryViewModel { Label = "UserName", OriginalText = "luck" };
            Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "fake-design" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "Luke@gmail.com" };
        }

        #endregion

    }
}
