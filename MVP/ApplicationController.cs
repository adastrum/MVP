using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVP
{
    public class ApplicationController : IApplicationController
    {
        private UnityContainer _container;

        public ApplicationController(UnityContainer container)
        {
            _container = container;

            _container.RegisterInstance<IApplicationController>(this);
        }

        public IApplicationController Register<TFrom, TTo>() where TTo : class, TFrom
        {
            _container.RegisterType<TFrom, TTo>();

            return this;
        }

        public IApplicationController RegisterInstance<TInterface>(TInterface instance)
        {
            _container.RegisterInstance(instance);

            return this;
        }

        public void Run<TPresenter>() where TPresenter : class, IPresenter
        {
            if (!_container.IsRegistered<TPresenter>())
            {
                _container.RegisterType(typeof(TPresenter));
            }

            var presenter = _container.Resolve<TPresenter>();
            presenter.Run();
        }


        public void Run<TPresenter, TArgument>(TArgument argument) where TPresenter : class, IPresenter<TArgument>
        {
            if (!_container.IsRegistered<TPresenter>())
            {
                _container.RegisterType(typeof(TPresenter));
            }

            var presenter = _container.Resolve<TPresenter>();
            presenter.Run(argument);
        }
    }
}
