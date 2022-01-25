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
    public partial class frmPurchaseReturn : Form
    {

        
        bool IsEditItem ;
        int ItemId = 0;
        int ItemIdx = 0;
        bool IsEdit ;
        Projset CLS = new Projset();
        int ShopId = 0;
        string str;
        int PReturnId;
        public frmPurchaseReturn()
        {
            InitializeComponent();
        }        

        public void clearData()
        {
            txtPartyName.Text = String.Empty;
            txtBillNo.Text = String.Empty;
            dtpBillDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            listView1.Items.Clear();
            lblCGST.Text = "0.00";
            lblIGST.Text = "0.00";
            lblNetAmount.Text = "0.00";
            lblSGST.Text = "0.00";
            lblTotalAmount.Text = "0.00";
        }
        public void clearItem()
        {
            txtItemName.Text = String.Empty;
            txtHSNCode.Text = String.Empty;
            txtQty.Text = String.Empty;
            txtRate.Text = String.Empty;
            txtSGSTPer.Text = "0.00";
            txtSGSTAmt.Text = "0.00";
            txtCGSTPer.Text = "0.00";
            txtCGSTAmt.Text = "0.00";
            txtIGSTPer.Text = "0.00";
            txtIGSTAmt.Text = "0.00";
            txtAmt.Text = "0.00";
            txtTotalAmount.Text = "0.00";
        }
        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            if (txtItemName.Text == String.Empty)
            {
                MessageBox.Show("Please Enter Item Name", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtItemName.Focus();
                return;
            }
            if (txtHSNCode.Text == String.Empty)
            {
                MessageBox.Show("Please Enter HSN Code", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtHSNCode.Focus();
                return;
            }
            if (txtQty.Text == String.Empty)
            {
                MessageBox.Show("Please Enter Qty", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtQty.Focus();
                return;
            }
            if (txtRate.Text == String.Empty)
            {
                MessageBox.Show("Please Enter Amount", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtRate.Focus();
                return;
            }
            if (IsEditItem == false)
            {
                ListViewItem liv = new ListViewItem();
                liv.Text = (listView1.Items.Count + 1).ToString();
                liv.SubItems.Add(Convert.ToString(ItemId));
                liv.SubItems.Add(txtItemName.Text.ToString());
                liv.SubItems.Add(txtHSNCode.Text);
                liv.SubItems.Add(txtQty.Text);
                liv.SubItems.Add(Convert.ToDecimal(txtRate.Text).ToString());
                liv.SubItems.Add(Convert.ToDecimal(txtAmt.Text).ToString());
                liv.SubItems.Add(Convert.ToDecimal(txtCGSTPer.Text).ToString());
                liv.SubItems.Add(Convert.ToDecimal(txtCGSTAmt.Text).ToString());
                liv.SubItems.Add(Convert.ToDecimal(txtSGSTPer.Text).ToString());
                liv.SubItems.Add(Convert.ToDecimal(txtSGSTAmt.Text).ToString());
                liv.SubItems.Add(Convert.ToDecimal(txtIGSTPer.Text).ToString());
                liv.SubItems.Add(Convert.ToDecimal(txtIGSTAmt.Text).ToString());
                liv.SubItems.Add(Convert.ToDecimal(txtTotalAmount.Text).ToString());
                listView1.Items.Add(liv);

            }
            else
            {
                listView1.Items[ItemIdx].Text = txtSrNo.Text;
                listView1.Items[ItemIdx].SubItems[1].Text = Convert.ToString(ItemId);
                listView1.Items[ItemIdx].SubItems[2].Text = txtItemName.Text;
                listView1.Items[ItemIdx].SubItems[3].Text = txtHSNCode.Text;
                listView1.Items[ItemIdx].SubItems[4].Text = txtQty.Text;
                listView1.Items[ItemIdx].SubItems[5].Text = txtRate.Text;
                listView1.Items[ItemIdx].SubItems[6].Text = txtAmt.Text;
                listView1.Items[ItemIdx].SubItems[7].Text = txtCGSTPer.Text;
                listView1.Items[ItemIdx].SubItems[8].Text = txtCGSTAmt.Text;
                listView1.Items[ItemIdx].SubItems[9].Text = txtSGSTPer.Text;
                listView1.Items[ItemIdx].SubItems[10].Text = txtSGSTAmt.Text;
                listView1.Items[ItemIdx].SubItems[11].Text = txtIGSTPer.Text;
                listView1.Items[ItemIdx].SubItems[12].Text = txtIGSTAmt.Text;
                listView1.Items[ItemIdx].SubItems[13].Text = txtTotalAmount.Text;
            }
            txtSrNo.Text = (listView1.Items.Count + 1).ToString();
            txtItemName.Focus();
            TotalCalculation();

            IsEditItem = false;
            ItemIdx = 0;
            clearItem();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            decimal Qty = string.IsNullOrEmpty(txtQty.Text) ? 0 : Convert.ToDecimal(txtQty.Text);
            decimal Rate = string.IsNullOrEmpty(txtRate.Text) ? 0 : Convert.ToDecimal(txtRate.Text);
            decimal Amt = (Qty * Rate);
            txtAmt.Text = Amt.ToString("#0.00");

            decimal CGST = string.IsNullOrEmpty(txtCGSTPer.Text) ? 0 : Convert.ToDecimal(txtCGSTPer.Text);
            decimal SGST = string.IsNullOrEmpty(txtSGSTPer.Text) ? 0 : Convert.ToDecimal(txtSGSTPer.Text);
            decimal IGST = string.IsNullOrEmpty(txtIGSTPer.Text) ? 0 : Convert.ToDecimal(txtIGSTPer.Text);


            txtCGSTAmt.Text = ((Amt * CGST) / 100).ToString("#0.00");
            txtSGSTAmt.Text = ((Amt * SGST) / 100).ToString("#0.00");
            txtIGSTAmt.Text = ((Amt * IGST) / 100).ToString("#0.00");


            txtTotalAmount.Text = (Amt + Convert.ToDecimal(txtCGSTAmt.Text) + Convert.ToDecimal(txtSGSTAmt.Text) + Convert.ToDecimal(txtIGSTAmt.Text)).ToString("#0.00");
        }

        

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtSrNo.Text = "1";           
            IsEdit = false;
            txtPartyName.Focus();
            clearData();
            clearItem();
        }

        public void TotalCalculation()
        {
            lblTotalAmount.Text = "0.00";
            lblCGST.Text = "0.00";
            lblSGST.Text = "0.00";
            lblIGST.Text = "0.00";
            lblNetAmount.Text = "0.00";

            foreach (ListViewItem Liv in listView1.Items)
            {

                decimal TotalAmt = string.IsNullOrEmpty(lblTotalAmount.Text) ? 0 : Convert.ToDecimal(lblTotalAmount.Text);
                decimal CGST = string.IsNullOrEmpty(lblCGST.Text) ? 0 : Convert.ToDecimal(lblCGST.Text);
                decimal SGST = string.IsNullOrEmpty(lblSGST.Text) ? 0 : Convert.ToDecimal(lblSGST.Text);
                decimal IGST = string.IsNullOrEmpty(lblIGST.Text) ? 0 : Convert.ToDecimal(lblIGST.Text);
                decimal MyNetAmount = string.IsNullOrEmpty(lblNetAmount.Text) ? 0 : Convert.ToDecimal(lblNetAmount.Text);

                decimal MyAmt = string.IsNullOrEmpty(Liv.SubItems[6].Text) ? 0 : Convert.ToDecimal(Liv.SubItems[6].Text);
                decimal MyCGST = string.IsNullOrEmpty(Liv.SubItems[8].Text) ? 0 : Convert.ToDecimal(Liv.SubItems[8].Text);
                decimal MySGST = string.IsNullOrEmpty(Liv.SubItems[10].Text) ? 0 : Convert.ToDecimal(Liv.SubItems[10].Text);
                decimal MyIGST = string.IsNullOrEmpty(Liv.SubItems[12].Text) ? 0 : Convert.ToDecimal(Liv.SubItems[12].Text);
                decimal MyTotal = string.IsNullOrEmpty(Liv.SubItems[13].Text) ? 0 : Convert.ToDecimal(Liv.SubItems[13].Text);

                lblTotalAmount.Text = (MyAmt + TotalAmt).ToString("#0.00");
                lblCGST.Text = (MyCGST + CGST).ToString("#0.00");
                lblSGST.Text = (MySGST + SGST).ToString("#0.00");
                lblIGST.Text = (MyIGST + IGST).ToString("#0.00");
                lblNetAmount.Text = (MyTotal + MyNetAmount).ToString("#0.00");

            }
        }
        
        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                return;
            }
            DialogResult Dr = MessageBox.Show("Are you sure Delete", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Dr == DialogResult.Yes)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
                foreach (ListViewItem liv in listView1.Items)
                {
                    liv.Text = (liv.Text + 1).ToString();
                }
                txtSrNo.Text = (listView1.Items.Count + 1).ToString();
                TotalCalculation();
            }
        }


        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          
            if (listView1.SelectedItems.Count > 0)
            {
                txtSrNo.Text = listView1.SelectedItems[0].Text;
                txtItemName.Tag = listView1.SelectedItems[0].SubItems[2].Text;
                txtItemName.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txtHSNCode.Text = listView1.SelectedItems[0].SubItems[3].Text;
                txtQty.Text = listView1.SelectedItems[0].SubItems[4].Text;
                txtRate.Text = listView1.SelectedItems[0].SubItems[5].Text;
                txtAmt.Text = listView1.SelectedItems[0].SubItems[6].Text;
                txtCGSTPer.Text = listView1.SelectedItems[0].SubItems[7].Text;
                txtCGSTAmt.Text = listView1.SelectedItems[0].SubItems[8].Text;
                txtSGSTPer.Text = listView1.SelectedItems[0].SubItems[9].Text;
                txtSGSTAmt.Text = listView1.SelectedItems[0].SubItems[10].Text;
                txtIGSTPer.Text = listView1.SelectedItems[0].SubItems[11].Text;
                txtIGSTAmt.Text = listView1.SelectedItems[0].SubItems[12].Text;
                txtTotalAmount.Text = listView1.SelectedItems[0].SubItems[13].Text;
                txtItemName.Focus();
                IsEditItem = true;
                ItemIdx = listView1.SelectedItems[0].Index;
            }
        
    }

        private void frmPurchaseMaster_Load(object sender, EventArgs e)
        {
            btnNew_Click(null, null);
            txtPartyName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPartyName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Party Name", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                txtPartyName.Focus();
                return;
            }
            if (txtBillNo.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Bill No", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                txtBillNo.Focus();
                return;
            }
            if(IsEdit == false)
            {
                str = String.Format("insert into purchaseReturnMaster (purchaseBillNo, purchaseReturnBillNo, BillDate, TotalAmt, companyId) values ('{0}','{1}','{2}',{3},{4})",
                    txtBillNo.Text.ToString(),
                    txtPRNo.Text.ToString(),
                    dtpBillDate.Value.ToString("yyyy/MM/dd"),
                    lblNetAmount.Text,
                    Module.CompanyId
                    );
                CLS.addrecord(str);
                PReturnId = Convert.ToInt32(CLS.GetValue("select Max(id) from purchaseReturnMaster where companyId = " + Module.CompanyId));
            }
            else
            {
                PReturnId = Convert.ToInt32(CLS.GetValue("select Max(id) from purchaseReturnMaster where companyId = " + Module.CompanyId));
                str = String.Format("update purchaseReturnMaster set purchaseBillNo = '{0}', purchaseReturnBillNo = '{1}', BillDate = '{2}', TotalAmount = {3} where id = {4} and companyId = {5}",
                        txtBillNo.Text.ToString(),
                        txtPRNo.Text.ToString(),
                        dtpBillDate.Value.ToString("yyyy/MM/dd"),
                        lblNetAmount.Text,
                        PReturnId,
                        Module.CompanyId
                        );
                CLS.addrecord(str);
                CLS.addrecord("DELETE from purchaseReturnDetails where PurchaseReturnId = " + PReturnId);
                CLS.addrecord("DELETE from stockMaster where pReturnId = " + PReturnId + " and companyId= "+ Module.CompanyId );
            }
            foreach (ListViewItem liv in listView1.Items)
            {
                str = String.Format("insert into purchaseReturnDetails (purchaseReturnid, itemId, qty, rate, amount, cgstper, cgstAmt, sgstper, sgstAmt, igstper, igstAmt,totalAmount) values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}) ",
                    PReturnId,
                    liv.SubItems[1].Text,
                    liv.SubItems[4].Text,
                    liv.SubItems[5].Text,
                    liv.SubItems[6].Text,
                    liv.SubItems[7].Text,
                    liv.SubItems[8].Text,
                    liv.SubItems[9].Text,
                    liv.SubItems[10].Text,
                    liv.SubItems[11].Text,
                    liv.SubItems[12].Text,
                    liv.SubItems[13].Text
                    );
                CLS.addrecord(str);
                str = String.Format("Insert into stockMaster (partyId, ItemId, qty, purchaseReturnId, entryDate, companyId) values ({0},{1},{2},{3},'{4}',{5}) ",
                     ShopId,
                     liv.SubItems[1].Text,
                     Convert.ToInt32(liv.SubItems[4].Text) * -1,
                     PReturnId,
                     DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"),
                     Module.CompanyId
                    );
                CLS.addrecord(str);
            }
            btnNew_Click(null, null);

        }

        private void txtPartyName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtItemName_Validating(object sender, CancelEventArgs e)
        {
            ItemId = Convert.ToInt32(CLS.GetValue("Select ID from itemMaster where itemName = '" + txtItemName.Text + "' and companyId = "+ Module.CompanyId +""));
            DataTable dt = new DataTable();
            dt = CLS.FillDataTable("Select * from itemMaster Where itemName = '" + txtItemName.Text + "' and companyId = "+ Module.CompanyId +"");
            if (dt.Rows.Count > 0)
            {
                ItemId = Convert.ToInt32(dt.Rows[0]["id"]);
                txtHSNCode.Text = (dt.Rows[0]["itemHSNCode"].ToString());
                decimal CGSTPer = string.IsNullOrEmpty(dt.Rows[0]["itemCGST"].ToString()) ? 0 : Convert.ToDecimal(dt.Rows[0]["itemCGST"].ToString());
                decimal SGSTPer = string.IsNullOrEmpty(dt.Rows[0]["itemSGST"].ToString()) ? 0 : Convert.ToDecimal(dt.Rows[0]["itemSGST"].ToString());
                decimal IGSTPer = string.IsNullOrEmpty(dt.Rows[0]["itemIGST"].ToString()) ? 0 : Convert.ToDecimal(dt.Rows[0]["itemIGST"].ToString());

                txtCGSTPer.Text = CGSTPer.ToString();
                txtIGSTPer.Text = IGSTPer.ToString();
                txtSGSTPer.Text = SGSTPer.ToString();
            }
        }

        private void txtPartyName_Validating(object sender, CancelEventArgs e)
        {
            ShopId = Convert.ToInt32(CLS.GetValue("Select * from PartyMaster where partyName = '" + txtPartyName.Text + "' and companyId = " + Module.CompanyId + ""));            
        }

        private void frmPurchaseReturn_Shown(object sender, EventArgs e)
        {
            CLS.FillText("Select partyName from partyMaster where companyId = " + Module.CompanyId +"", txtPartyName);
            CLS.FillText("Select itemName from itemMaster where companyId = " + Module.CompanyId + "", txtItemName);
        }

        public void FillData(string Bill)
        {
            DataTable dt = new DataTable();
            str = string.Empty;
            str = "select purchaseMaster.billNo,purchaseMaster.billDate,partyMaster.partyName from (purchaseMaster " +
                  "inner join partyMaster on purchaseMaster.partyId = partyMaster.id )" +
                  "where purchaseMaster.billNo = '" + Bill + "'and purchaseMaster.companyId = " + Module.CompanyId + "";
            dt = CLS.FillDataTable(str);

            if (dt.Rows.Count > 0)
            {
                txtPartyName.Text = dt.Rows[0]["partyName"].ToString();
                dtpBillDate.Value = Convert.ToDateTime(dt.Rows[0]["billDate"].ToString());
            }
            dt = null;
            dt = new DataTable();
            str = string.Empty;

            str = "select itemMaster.itemName, itemMaster.itemHSNCode, purchaseDetails.* from (purchaseMaster " +
                  "inner join purchaseDetails on purchaseMaster.id = purchaseDetails.purchaseId) " +
                  "inner join itemMaster on itemMaster.id = purchaseDetails.itemId " +
                  "where purchaseMaster.billNo = '" + Bill + "' and purchaseMaster.companyId= " + Module.CompanyId;

            dt = CLS.FillDataTable(str);
            listView1.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                listView1.Items.Add(Convert.ToString(listView1.Items.Count + 1));
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(dr["ItemId"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(dr["itemName"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(dr["itemHSNCode"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(dr["qty"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(dr["rate"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(dr["amount"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(dr["cgstper"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(dr["cgstAmt"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(dr["sgstper"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(dr["sgstAmt"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(dr["igstper"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(dr["igstAmt"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(dr["totalAmount"].ToString());
            }
            txtSrNo.Text = (listView1.Items.Count + 1).ToString();
            txtPartyName.Focus();
            TotalCalculation();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtBillNo.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Bill No", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                txtBillNo.Focus();
                return;
            }
            else
            {
                FillData(txtBillNo.Text.ToString());
                btnSave.Enabled = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            IsEdit = true;
            txtPartyName.Focus();
            btnSave.Enabled = true;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void lblCGST_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }
    }
}