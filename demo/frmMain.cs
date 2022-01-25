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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        Projset CLS = new Projset();

        private void ShowNewForm(Form _Frm)
        {
            frmMain objMain = new demo.frmMain();
            _Frm.Icon = objMain.Icon;
            _Frm.MdiParent = this;
            _Frm.Show();
            objMain = null;
        }

        private void companyInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompanyMaster CmpMaster = new frmCompanyMaster();
            ShowNewForm(CmpMaster);
        }

        private void partyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPartyMaster PartyMaster = new frmPartyMaster();
            ShowNewForm(PartyMaster);
        }

        private void itemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemMaster ItemMaster = new frmItemMaster();
            ShowNewForm(ItemMaster);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmLogin main = new frmLogin();
            string str = "Select userName from login";
            object userName = CLS.GetValue(str);
            uName.Text = Convert.ToString(userName);

            frmCompanySelection cmpSelect = new frmCompanySelection();
            //cmpSelect.FormBorderStyle = FormBorderStyle.None;
            ShowNewForm(cmpSelect);
        }

        private void salesBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesMaster salesMaster = new frmSalesMaster();
            ShowNewForm(salesMaster);
        }

        private void purchaseBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseMaster purchaseMaster = new frmPurchaseMaster();
            ShowNewForm(purchaseMaster);
            
        }

        private void purchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseReturn purchaseReturn = new frmPurchaseReturn();
            ShowNewForm(purchaseReturn);
        }

        private void salesReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesReturn salesReturn = new frmSalesReturn();
            ShowNewForm(salesReturn);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword();
            ShowNewForm(changePassword);
        }

        private void stockMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockMaster StockMaster = new frmStockMaster();
            ShowNewForm(StockMaster);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult message = MessageBox.Show("Are you sure Close ?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(message == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void changeCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompanySelection companySelection = new frmCompanySelection();
            ShowNewForm(companySelection);
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void purchaseSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rpt_purchaseReport Report = new rpt_purchaseReport();
            ShowNewForm(Report);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void removeDuplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRemoveDuplicate removeDuplicate = new frmRemoveDuplicate();
            ShowNewForm(removeDuplicate);
        }

        private void partyPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPayment paymentMaster = new frmPayment();
            ShowNewForm(paymentMaster);
        }

        private void paymentReceiptReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void bankMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBankMaster bankMaster = new frmBankMaster();
            ShowNewForm(bankMaster);
        }

        private void receiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmreceipt receipt = new frmreceipt();
            ShowNewForm(receipt);
        }
    }
}
