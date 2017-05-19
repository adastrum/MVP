using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MVP
{
    public partial class LoginForm : Form, ILoginView
    {
        private ApplicationContext _context;

        public LoginForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();

            btnLogin.Click += (sender, e) => Login();
        }

        public string UserName
        {
            get { return txtUserName.Text; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
        }

        public event Action Login;

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public new void Show()
        {
            _context.MainForm = this;
            Application.Run(_context);
        }
    }
}
