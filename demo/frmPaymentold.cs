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
    public partial class frmPaymentold : Form
    {
        Projset CLS = new Projset();
        string str;
        int partyId = 0;
        DataTable dt = new DataTable();
        public frmPaymentold()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtPartyName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter PartyName!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPartyName.Focus();
                return;
            }
            else
            {
                FillData(partyId);
            }
        }

        public void FillData(int party)

        {
            if(rdoPayment.Checked == false && rdoReceipt.Checked == false)
            {
                MessageBox.Show("Please Select Any Mode", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (rdoPayment.Checked == true)
            {
                str = "select PurchaseMaster.id, partyMaster.partyName as [Party Name], PurchaseMaster.BillNo as [Bill No], PurchaseMaster.BillDate as [Bill Date], PurchaseMaster.TotalAmount as [Net Amount], isnull(PurchaseMaster.PaymentAmount,0) AS[Paid Amount], isnull(PurchaseMaster.TotalAmount - isnull(PurchaseMaster.PaymentAmount,0),0) AS[Due Amount] " +
                      " from purchaseMaster inner join partyMaster on partyMaster.id = purchaseMaster.partyId " +
                      " where purchaseMaster.entryDate between '" + dtpFromDate.Value.ToString("yyyy/MM/dd") + "' and '" + dtpToDate.Value.ToString("yyyy/MM/dd") + "' " +
                      " and((purchaseMaster.TotalAmount - isnull(purchaseMaster.paymentAmount,0)) <> 0) " +
                      " and purchaseMaster.partyId = " + party + " and purchaseMaster.companyId = " + Module.CompanyId + "";
                
            }
            else
            {
                str = "select salesMaster.id,partyMaster.partyName as [Party Name], salesMaster.BillNo as [Bill No], salesMaster.BillDate as [Bill Date], salesMaster.TotalAmount as [Net Amount], isnull(salesMaster.receiptAmount, 0) AS[Received Amount], isnull(salesMaster.TotalAmount - isnull(salesMaster.receiptAmount, 0), 0) AS[Due Amount] " +
                      " from salesMaster inner join partyMaster on partyMaster.id = salesMaster.partyId " +
                      " where salesMaster.entryDate between '" + dtpFromDate.Value.ToString("yyyy/MM/dd") + "' and '" + dtpToDate.Value.ToString("yyyy/MM/dd") +"' " +
                      " and((salesMaster.TotalAmount - isnull(salesMaster.receiptAmount, 0)) <> 0) " +
                      " and salesMaster.partyId = " + partyId +" and salesMaster.companyId = "+ Module.CompanyId +"";
            }
            dt = CLS.FillDataTable(str);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns();
            dataGridView1.Columns[0].Visible = false;

        }

        private void frmPayment_Shown(object sender, EventArgs e)
        {
            CLS.FillText("Select PartyName from partyMaster where companyId= " + Module.CompanyId + "", txtPartyName);
        }

        private void txtPartyName_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblPartyName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTotalAmount.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPaymemtAmount.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDueAmount.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            lblPurchaseid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void txtPartyName_Validated(object sender, EventArgs e)
        {
                partyId = Convert.ToInt32(CLS.GetValue("Select * from PartyMaster where partyName= '" + txtPartyName.Text +"' and companyId= " + Module.CompanyId + ""));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rdoCash.Checked == false && rdoChaque.Checked == false && rdoBank.Checked == false)
            {
                MessageBox.Show("Please Select Any Payment Mode", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (rdoPayment.Checked == true)
            {
                str = String.Format("insert into paymentDetails (partyid,totalAmount, paidAmount, dueAmount, paymentDate, IsCash, IsBank, IsCheque, purchaseId, companyId) values ({0},{1},{2},{3},'{4}',{5},{6},{7},{8},{9})",
                        partyId,
                        Convert.ToDecimal(txtTotalAmount.Text),
                        Convert.ToDecimal(txtPayAmount.Text),
                        Convert.ToDecimal(txtDueAmount.Text),
                        DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"),
                        Convert.ToByte(rdoCash.Checked),
                        Convert.ToByte(rdoBank.Checked),
                        Convert.ToByte(rdoChaque.Checked),
                        lblPurchaseid.Text,
                        Module.CompanyId
                    );
                CLS.addrecord(str);

                str = String.Format("update purchaseMaster set paymentAmount = {0}, paymentDate= '{1}' ,IsPayment = {2}  where id={3} and companyId={4}",
                       Convert.ToDecimal(txtPayAmount.Text) + Convert.ToDecimal(txtPaymemtAmount.Text),
                        DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"),
                        1,
                        lblPurchaseid.Text,
                        Module.CompanyId
                    );
                CLS.addrecord(str);

                MessageBox.Show("Payment Completed", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnCancel_Click(null, null);
                txtDueAmount.Text = string.Empty;
            }
            else
            {
                str = String.Format("insert into receiptDetails (partyid,totalAmount, receivedAmount, dueAmount, receiptDate, IsCash, IsBank, IsCheque, salesId, companyId) values ({0},{1},{2},{3},'{4}',{5},{6},{7},{8},{9})",
                        partyId,
                        Convert.ToDecimal(txtTotalAmount.Text),
                        Convert.ToDecimal(txtPayAmount.Text),
                        Convert.ToDecimal(txtDueAmount.Text),
                        DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"),
                        Convert.ToByte(rdoCash.Checked),
                        Convert.ToByte(rdoBank.Checked),
                        Convert.ToByte(rdoChaque.Checked),
                        lblPurchaseid.Text,
                        Module.CompanyId
                    );
                CLS.addrecord(str);

                str = String.Format("update salesMaster set receiptAmount = {0}, receiptDate= '{1}' ,IsReceipt = {2}  where id={3} and companyId={4}",
                       Convert.ToDecimal(txtPayAmount.Text) + Convert.ToDecimal(txtPaymemtAmount.Text),
                        DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"),
                        1,
                        lblPurchaseid.Text,
                        Module.CompanyId
                    );
                CLS.addrecord(str);

                MessageBox.Show("Payment Completed", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnCancel_Click(null, null);
                txtDueAmount.Text = string.Empty;
            }

        }

        public void clearData()
        {
            txtDueAmount.Text = string.Empty;
            txtPartyName.Text = string.Empty;
            txtPayAmount.Text = string.Empty;
            txtPaymemtAmount.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
            dataGridView1.Columns.Clear();
            lblPartyName.Text = string.Empty;
            lblPurchaseid.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = dtpToDate.Value.AddDays(-30);
            dtpToDate.Value = dtpFromDate.Value.AddDays(31);
        }

        private void txtPayAmount_Validated(object sender, EventArgs e)
        {
            decimal totalAmount = string.IsNullOrEmpty(txtTotalAmount.Text) ? 0 : Convert.ToDecimal(txtTotalAmount.Text);
            decimal payment = string.IsNullOrEmpty(txtPaymemtAmount.Text) ? 0 : Convert.ToDecimal(txtPaymemtAmount.Text);
            decimal paid = string.IsNullOrEmpty(txtPayAmount.Text) ? 0 : Convert.ToDecimal(txtPayAmount.Text);
            decimal Amt = (totalAmount - (payment + paid));
            //txtDueAmount.Text = Amt.ToString();

            if (Convert.ToDecimal(txtPayAmount.Text) > Convert.ToDecimal(txtDueAmount.Text))
            {
                MessageBox.Show("Payment Amount more than Due Amount " + txtDueAmount.Text, Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtPaymemtAmount.Focus();
                btnSave.Enabled = false;
                return;
            }
            else
            {
                btnSave.Enabled = true;
            }
            }
    }
}
