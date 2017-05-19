using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP
{
    public interface IAccountService
    {
        Account Authenticate(string userName, string password);
    }
}
