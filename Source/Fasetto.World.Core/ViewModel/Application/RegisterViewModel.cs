using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasetto.World.Core
{
    /// <summary>
    /// The View Model for a login screen
    /// </summary>
    public class RegisterViewModel:BaseViewModel
    {

        #region Command

        /// <summary>
        /// The command to go to login page 
        /// </summary>

        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// The command to Register for user 
        /// </summary>

        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag indicating if the Register command is running
        /// </summary>
        public bool RegisterIsRunning { get; set; }

        #endregion



        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window"></param>
        public RegisterViewModel()
        {
            //Create commands
            RegisterCommand = new RelayParameterizedCommand(async (parameter) =>await RegisterAsync(parameter));
            LoginCommand = new RelayCommand(async () =>await LoginAsync());
            
        }


        #endregion

        /// <summary>
        /// Attempts to register a new account
        /// </summary>
        /// <param name="parameter">The<see cref="SecureString"/>passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task RegisterAsync(object parameter)
        {

            await RunCommandAsync(() => this.RegisterIsRunning,async()=>
            {
                await Task.Delay(1000);

                //var email = this.Email;

                ////IMPRORTANT:Never store unsecure password in variable like this
                //var pass = (parameter as IHavePassword).SecurePassword.Unsecure();


            });
            
        }

        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <returns></returns>
        public async Task LoginAsync()
        {
            //TODO:Go to register page?
            //((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Register;
            IoC.Application.GoToPage(ApplicationPage.Login);

            await Task.Delay(1);


        }

    }
}
