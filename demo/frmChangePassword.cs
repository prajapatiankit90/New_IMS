using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo
{
    public partial class frmChangePassword : Form
    {
        Projset CLS = new Projset();
        string str;
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtOldPwd.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Old Password");
                txtOldPwd.Focus();
                return;
            }
            if(txtNewPwd.Text == string.Empty)
            {
                MessageBox.Show("Please Enter New Password");
                txtNewPwd.Focus();
                return;
            }
            if(txtRePwd.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Re-Enter Password");
                txtRePwd.Focus();
                return;
            }
            if(txtRePwd.Text != txtNewPwd.Text)
            {
                MessageBox.Show("Password is not Match!!", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                txtRePwd.Focus();
                return;
            }
            object pwd = CLS.GetValue("Select pwd from login where pwd = '" + txtOldPwd.Text + "'");
            if (string.IsNullOrEmpty(Convert.ToString(pwd)))
            {
                MessageBox.Show("Old Password Not Match!!", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                txtOldPwd.Focus();
                return;
            }
            str = "UPDATE login set pwd = '" + txtRePwd.Text +"'";
            CLS.addrecord(str);
            MessageBox.Show("Password Successfully Changed!!",Text,MessageBoxButtons.OKCancel,MessageBoxIcon.None);
            clearData();


        }

        public void clearData()
        {
            txtOldPwd.Text = string.Empty;
            txtNewPwd.Text = string.Empty;
            txtRePwd.Text = string.Empty;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtOldPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
