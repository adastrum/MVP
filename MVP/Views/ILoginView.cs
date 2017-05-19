using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVP
{
    public interface ILoginView : IView
    {
        string UserName { get; }
        string Password { get; }
        event Action Login;
        void ShowMessage(string message);
    }
}
