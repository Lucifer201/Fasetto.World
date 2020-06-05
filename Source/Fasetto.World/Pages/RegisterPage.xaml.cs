using Fasetto.World.Core;
using System.Security;

namespace Fasetto.World
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class RegisterPage : BasePage<RegisterViewModel>,IHavePassword
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public RegisterPage() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific view model used for this page</param>
        public RegisterPage(RegisterViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion
        /// <summary>
        /// The secure password for this login page
        /// </summary>
        public SecureString SecurePassword => PasswordText.SecurePassword;

    }
}
