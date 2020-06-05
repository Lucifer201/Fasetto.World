using Fasetto.World.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace Fasetto.World
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public static class ApplicationPageHelpers
    {
        /// <summary>
        /// Takes an <see cref="ApplicationPage"/> and view model, if any, create the desired page
        /// </summary>
        /// <typeparam name="VM"></typeparam>
        /// <param name="page"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static BasePage ToBasePage(this ApplicationPage page,object viewModel=null)
        {
            switch (page)
            {
                case ApplicationPage.Login:
                    return new LoginPage(viewModel as LoginViewModel);  

                case ApplicationPage.Register:
                    return new RegisterPage(viewModel as RegisterViewModel);

                case ApplicationPage.Chat:
                    return new ChatPage(viewModel as ChatMessageListViewModel);

                default:
                    Debugger.Break();
                    return null;
            }
        }

        /// <summary>
        /// Converts a <see cref="BasePage"/> to the specific <see cref="ApplicationPage"/> that is for that type of page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static ApplicationPage ToApplicationPage(this BasePage page)
        {
            //Find application page matches the base page
            if (page is ChatPage)
                return ApplicationPage.Chat;
            if (page is LoginPage)
                return ApplicationPage.Login;
            if (page is RegisterPage)
                return ApplicationPage.Register;

            //Alert the developers this issue
            Debugger.Break();
            return default(ApplicationPage);
        }

    }
}
