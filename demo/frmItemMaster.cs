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
    public partial class frmItemMaster : Form
    {
        Boolean IsEdit = false;
        Projset CLS = new Projset();
        String str;
        public frmItemMaster()
        {
            InitializeComponent();
        }

        private void frmItemMaster_Load(object sender, EventArgs e)
        {
            btnNew_Click(null, null);
            ShowData();
        }

        public void clearData()
        {
            txtItemName.Text = string.Empty;
            txtHSNCode.Text = string.Empty;
            txtSGST.Text = string.Empty;
            txtCGST.Text = string.Empty;
            txtIGST.Text = string.Empty;
            txtid.Text = string.Empty;            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtItemName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Item Name", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtItemName.Focus();
                return;
            }
            if(txtHSNCode.Text == string.Empty)
            {
                MessageBox.Show("Please Enter HSN Code", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtHSNCode.Focus();
                return;
            }
            if(txtCGST.Text == string.Empty)
            {
                MessageBox.Show("Please Enter CGST Per", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtCGST.Focus();
                return;
            }
            if(txtSGST.Text == string.Empty)
            {
                MessageBox.Show("Please Enter SGST Per", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtSGST.Focus();
                return;
            }
            if(txtIGST.Text == string.Empty)
            {
                MessageBox.Show("Please Enter IGST Per", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtIGST.Focus();
                return;
            }

            if(IsEdit == false)
            {
                object ItemName = CLS.GetValue("Select itemName From itemMaster WHERE itemName = '" + txtItemName.Text.Trim().ToString() + "' And companyId = " + Module.CompanyId +"");
                if (Convert.ToString(ItemName) != "")
                {
                    MessageBox.Show("Item Name Already Exists.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtItemName.Focus();
                    return;

                }
                str = String.Format("INSERT INTO itemMaster (itemName, itemHSNCode, itemCGST, itemSGST, itemIGST, companyId) values ('{0}','{1}',{2},{3},{4},{5}) ",
                    txtItemName.Text,
                    txtHSNCode.Text,
                    txtCGST.Text,
                    txtSGST.Text,
                    txtIGST.Text,
                    Module.CompanyId);
            }
            else
            {
                //object ShNameCnt = CLS.GetValue("Select Count(itemName) From itemMaster WHERE itemName = '" + txtItemName.Text.Trim().ToString() + "' And companyId = "+ Module.CompanyId +" Group By itemName");
                //if (Convert.ToInt32(ShNameCnt) >= 1)
                //{
                //    MessageBox.Show("Item Name Already Exists.", Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
                //    txtItemName.Focus();
                //    return;
                //}
                str = String.Format("UPDATE itemMaster SET itemName='{0}', itemHSNCode='{1}', itemCGST = {2}, itemSGST = {3}, itemIGST = {4} where id = {5} and companyId = {6}",
                     txtItemName.Text,
                    txtHSNCode.Text,
                    txtCGST.Text,
                    txtSGST.Text,
                    txtIGST.Text,
                    txtid.Text,
                    Module.CompanyId
                    );
            }
            CLS.addrecord(str);
            ShowData();
            btnNew_Click(null, null);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            IsEdit = false;
            txtItemName.Focus();
            clearData();
            btnSave.Enabled = true;
        }

        public void ShowData()
        {
            dataGridView1.DataSource = CLS.FillDataTable("SELECT * FROM ItemMaster WHERE isInActive = 0 AND companyId = "+ Module.CompanyId +"");
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtItemName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtHSNCode.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtCGST.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSGST.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtIGST.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            btnSave.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            IsEdit = true;
            txtid.Focus();
            btnSave.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Are You Sure Delete Item ??", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(msg == DialogResult.Yes)
            {
            str = "UPDATE itemMaster SET isActive = 1 WHERE id = "+ txtid.Text +" AND companyId = "+ Module.CompanyId +"";
            CLS.addrecord(str);
            frmItemMaster_Load(null, null);
            }
            
            
        }

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
