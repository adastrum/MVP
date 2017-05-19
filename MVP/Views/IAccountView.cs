using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP
{
    public interface IAccountView : IView
    {
        decimal Amount { get; }
        event Action Deposit;
        event Action Widthraw;
        void UpdateAccountInfo(Account account);
    }
}
