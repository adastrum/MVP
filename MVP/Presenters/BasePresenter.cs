using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP
{
    public class BasePresenter<TView> : IPresenter
        where TView : IView
    {
        protected IApplicationController _controller;
        protected TView _view;

        protected BasePresenter(IApplicationController controller, TView view)
        {
            _controller = controller;
            _view = view;
        }

        public virtual void Run()
        {
            _view.Show();
        }
    }

    public abstract class BasePresenter<TView, TArgument> : IPresenter<TArgument>
    {
        protected IApplicationController _controller;
        protected TView _view;

        protected BasePresenter(IApplicationController controller, TView view)
        {
            _controller = controller;
            _view = view;
        }

        public abstract void Run(TArgument argument);
    }
}
