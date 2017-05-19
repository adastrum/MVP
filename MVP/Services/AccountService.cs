using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP
{
    public class AccountService : IAccountService
    {
        public Account Authenticate(string userName, string password)
        {
            if (userName == "sa" && password == "1")
            {
                return new Account() { Balance = 1000, UserName = userName };
            }
            return null;
        }
    }
}
