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
    public partial class frmPayment : Form
    {
        Projset CLS = new Projset();
        int bankId;
        Boolean IsEditItem;
        int ItemIdx = 0;
        public frmPayment()
        {
            InitializeComponent();
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text == string.Empty)
            {
                MessageBox.Show("Enter Description!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescription.Focus();
                return;
            }
            if (txtRemark.Text == string.Empty)
            {
                MessageBox.Show("Enter Remark!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRemark.Focus();
                return;
            }
            if (rdoBank.Checked == true)
            {
                if (txtBank.Text == string.Empty)
                {
                    MessageBox.Show("Enter Bank!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBank.Focus();
                    return;
                }
                if (txtCheq.Text == string.Empty)
                {
                    MessageBox.Show("Enter Cheque No !", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCheq.Focus();
                    return;
                }
            }
            if (txtAmt.Text == string.Empty)
            {
                MessageBox.Show("Enter Amount!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmt.Focus();
                return;
            }

            if (IsEditItem == false)
            {
                ListViewItem liv = new ListViewItem();
                liv.Text = (listView1.Items.Count + 1).ToString();
                liv.SubItems.Add(txtDescription.Text.ToString());
                liv.SubItems.Add(txtRemark.Text);
                liv.SubItems.Add(Convert.ToString(bankId));
                liv.SubItems.Add(txtBank.Text);
                liv.SubItems.Add(txtCheq.Text);
                liv.SubItems.Add(Convert.ToDecimal(txtAmt.Text).ToString());
                listView1.Items.Add(liv);

            }
            else
            {
                listView1.Items[ItemIdx].Text = txtSrNo.Text;
                listView1.Items[ItemIdx].SubItems[1].Text = txtDescription.Text;
                listView1.Items[ItemIdx].SubItems[2].Text = txtRemark.Text;
                listView1.Items[ItemIdx].SubItems[3].Text = Convert.ToString(bankId);
                listView1.Items[ItemIdx].SubItems[4].Text = txtBank.Text;
                listView1.Items[ItemIdx].SubItems[5].Text = txtCheq.Text;
                listView1.Items[ItemIdx].SubItems[6].Text = txtAmt.Text;
            }
            txtSrNo.Text = (listView1.Items.Count + 1).ToString();
            ClearData();
        }
        public void ClearData()
        {
            txtAmt.Text = string.Empty;
            txtBank.Text = string.Empty;
            txtCheq.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtRemark.Text = string.Empty;

        }

        private void rdoCash_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCash.Checked == true)
            {
                txtBank.Enabled = false;
                txtCheq.Enabled = false;
            }
        }

        private void rdoBank_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBank.Checked == true)
            {
                txtBank.Enabled = true;
                txtCheq.Enabled = true;
            }
        }

        private void txtBank_Validated(object sender, EventArgs e)
        {
            bankId = Convert.ToInt32(CLS.GetValue("select * from bankMaster where bankName='" + txtBank.Text + "' and companyId= " + Module.CompanyId + ""));
        }

        private void btnRemove_Click(object sender, EventArgs e)
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

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void frmPayment_Shown(object sender, EventArgs e)
        {
            CLS.FillText("Select BankName from bankMaster where companyId=" + Module.CompanyId + "", txtBank);
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            txtSrNo.Text = "1";
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                txtSrNo.Text = listView1.SelectedItems[0].Text;
                txtDescription.Text = listView1.SelectedItems[0].SubItems[1].Text;
                txtRemark.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txtBank.Text = listView1.SelectedItems[0].SubItems[4].Text;
                txtCheq.Text = listView1.SelectedItems[0].SubItems[5].Text;
                txtAmt.Text = listView1.SelectedItems[0].SubItems[6].Text;
                IsEditItem = true;
                ItemIdx = listView1.SelectedItems[0].Index;
            }
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            e.Graphics.DrawRectangle(Pens.Red, e.Bounds);
        }
    }
}
