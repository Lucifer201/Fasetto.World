using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasetto.World.Core
{
    /// <summary>
    /// The View Model for a login screen
    /// </summary>
    public class LoginViewModel:BaseViewModel
    {

        #region Command

        /// <summary>
        /// The command to login 
        /// </summary>

        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// The command to Register for a new command 
        /// </summary>

        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool LoginIsRunning { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window"></param>
        public LoginViewModel()
        {
            //Create commands
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));
            RegisterCommand = new RelayCommand(async () =>await RegisterAsync());
            
        }


        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">The<see cref="SecureString"/>passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task LoginAsync(object parameter)
        {

            await RunCommandAsync(() => LoginIsRunning, async () =>

            {

                // TODO: Fake a login...
                await Task.Delay(1000);
                // OK successfully logged in... now get users data

                // TODO: Ask server for users info
                // TODO: Remove this with real information pulled from our database in future
                IoC.Settings.Name = new TextEntryViewModel { Label = "Name", OriginalText = $"Luke Malpass {DateTime.Now.ToLocalTime()}" };
                IoC.Settings.UserName = new TextEntryViewModel { Label = "Username", OriginalText = "luke" };
                IoC.Settings.Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
                IoC.Settings.Email = new TextEntryViewModel { Label = "Email", OriginalText = "contact@angelsix.com" };
                
                // Go to chat page
                IoC.Application.GoToPage(ApplicationPage.Chat);

                //var email = Email;
                //// IMPORTANT: Never store unsecure password in variable like this

                //var pass = (parameter as IHavePassword).SecurePassword.Unsecure();

            });

        }

        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <returns></returns>
        public async Task RegisterAsync()
        {
            //TODO:Go to register page?
            //((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Register;
            IoC.Application.GoToPage(ApplicationPage.Register);

            await Task.Delay(1);


        }

    }
}
