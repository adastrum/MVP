using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVP
{
    public interface IApplicationController
    {
        IApplicationController Register<TFrom, TTo>()
            where TTo : class, TFrom;

        IApplicationController RegisterInstance<TInterface>(TInterface instance);

        void Run<TPresenter>()
            where TPresenter : class, IPresenter;

        void Run<TPresenter, TArgument>(TArgument argument)
            where TPresenter : class, IPresenter<TArgument>;
    }
}
