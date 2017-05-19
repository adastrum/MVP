using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVP
{
    public interface IPresenter
    {
        void Run();
    }

    public interface IPresenter<TArgument>
    {
        void Run(TArgument argument);
    }
}
