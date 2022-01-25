using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace demo
{
    public partial class frmLogin : Form
    {
        string str;
        Projset cls = new Projset();
        public frmLogin()
        {
            InitializeComponent();
            Module.ReadFile();

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            str = "Select * from login where userName='" + txtUserName.Text + "' and pwd='" + txtPassword.Text + "'";
            OleDbConnection sqlconn = new OleDbConnection(Module.ConnString);
            OleDbCommand cmd = new OleDbCommand(str, sqlconn);
            OleDbDataAdapter da = new OleDbDataAdapter(str, sqlconn);
            DataSet ds = new DataSet();
            da.Fill(ds, "login");
            if (txtUserName.Text == string.Empty)
            {
                MessageBox.Show("Invalid User Name..");
                txtUserName.Focus();
                return;
            }

            if (txtPassword.Text.Length <= 4)
            {
                MessageBox.Show("Password not more then 5 Character");
                txtPassword.Focus();
                return;
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                frmMain MainForm = new frmMain();
                MainForm.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Invalid Password..", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }
            

        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.FormBorderStyle = FormBorderStyle.None;
            
        }
    }
}
