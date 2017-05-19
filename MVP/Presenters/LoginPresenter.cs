using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVP
{
    public class LoginPresenter : BasePresenter<ILoginView>
    {
        private IAccountService _accountService;

        public LoginPresenter(IApplicationController controller, ILoginView view, IAccountService accountService) : base(controller, view)
        {
            _accountService = accountService;

            _view.Login += Login;
        }

        void Login()
        {
            if (string.IsNullOrWhiteSpace(_view.UserName) || string.IsNullOrWhiteSpace(_view.Password))
            {
                _view.ShowMessage("incorrect login data");
            }
            else
            {
                var account = _accountService.Authenticate(_view.UserName, _view.Password);

                _controller.Run<AccountPresenter, Account>(account);
                _view.Close();
            }
        }
    }
}
