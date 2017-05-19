using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP
{
    public partial class AccountForm : Form, IAccountView
    {
        private ApplicationContext _context;

        public AccountForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
            btnDeposit.Click += (sender, e) => Deposit();
            btnWidthraw.Click += (sender, e) => Widthraw();
        }

        public decimal Amount
        {
            get
            {
                decimal result;
                decimal.TryParse(txtAmount.Text, out result);
                return result;
            }
        }

        public event Action Deposit;

        public event Action Widthraw;

        public void UpdateAccountInfo(Account account)
        {
            lblUserName.Text = account.UserName;
            lblBalance.Text = account.Balance.ToString(CultureInfo.InvariantCulture);
        }

        public new void Show()
        {
            _context.MainForm = this;
            base.Show();
        }
    }
}
