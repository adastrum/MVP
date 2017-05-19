using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MVP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var controller = new ApplicationController(new UnityContainer())
                .Register<ILoginView, LoginForm>()
                .Register<IAccountView, AccountForm>()
                .Register<IAccountService, AccountService>()
                .RegisterInstance(new ApplicationContext());
            controller.Run<LoginPresenter>();
        }
    }
}
