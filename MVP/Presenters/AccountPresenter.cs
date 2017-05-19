using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP
{
    public class AccountPresenter : BasePresenter<IAccountView, Account>
    {
        private Account _account;

        public AccountPresenter(IApplicationController controller, IAccountView view) : base(controller, view)
        {
            _view.Deposit += Deposit;
            _view.Widthraw += Widthraw;
        }

        void Deposit()
        {
            _account.Balance += _view.Amount;
            _view.UpdateAccountInfo(_account);
        }

        void Widthraw()
        {
            _account.Balance -= _view.Amount;
            _view.UpdateAccountInfo(_account);
        }

        public override void Run(Account argument)
        {
            _account = argument;
            _view.UpdateAccountInfo(_account);
            _view.Show();
        }
    }
}
