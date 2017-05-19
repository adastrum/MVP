using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVP;
using NSubstitute;

namespace Tests
{
    [TestClass]
    public class LoginPresenterTests
    {
        private IApplicationController _controller;
        private ILoginView _view;

        [TestInitialize]
        public void Setup()
        {
            _controller = Substitute.For<IApplicationController>();
            _view = Substitute.For<ILoginView>();
            var service = Substitute.For<IAccountService>();
            service.Authenticate(Arg.Any<string>(), Arg.Any<string>()).Returns(new Account());
            var presenter = new LoginPresenter(_controller, _view, service);
            presenter.Run();
        }

        [TestMethod]
        public void IncorrectCredentials_ShowErrorMessage()
        {
            _view.Login += Raise.Event<Action>();
            _view.Received().ShowMessage("incorrect login data");
            _controller.DidNotReceive().Run<AccountPresenter, Account>(Arg.Any<Account>());
        }

        [TestMethod]
        public void CorrectCredentials_ShowAccountForm()
        {
            _view.UserName.Returns("sa");
            _view.Password.Returns("1");
            _view.Login += Raise.Event<Action>();
            _view.DidNotReceive().ShowMessage(Arg.Any<string>());
            _controller.Received().Run<AccountPresenter, Account>(Arg.Any<Account>());
        }
    }
}
