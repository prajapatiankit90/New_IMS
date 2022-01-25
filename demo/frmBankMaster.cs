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
    public partial class frmBankMaster : Form
    {
        Projset CLS = new Projset();
        String str;
        Boolean IsEdit = false;
        public frmBankMaster()
        {
            InitializeComponent();
        }

        private void frmBankMaster_Load(object sender, EventArgs e)
        {
            showData();
            btnNew_Click(null, null);
        }

        public void ClearData()
        {
            txtBankName.Text = string.Empty;
            txtBranchName.Text = string.Empty;
            txtIFSCCode.Text = string.Empty;
            txtid.Text = string.Empty;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtBankName.Text == String.Empty)
            {
                MessageBox.Show("Please Enter Bank Name?", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBankName.Focus();
                return;
            }
            if(txtBranchName.Text == String.Empty)
            {
                MessageBox.Show("Please Enter Branch Name!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBranchName.Focus();
                return;
            }
            if(txtIFSCCode.Text == String.Empty)
            {
                MessageBox.Show("Please Enter IFSC Code!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIFSCCode.Focus();
                return;
            }
            if(IsEdit == false)
            {
                str = String.Format("Insert into bankMaster (bankName, IFSCCode, branchName, companyId) values ('{0}','{1}','{2}',{3})",
                    txtBankName.Text.ToString(),
                    txtIFSCCode.Text.ToString(),
                    txtBranchName.Text.ToString(),
                    Module.CompanyId                    
                    );
                CLS.addrecord(str);
            }
            else
            {
                str = String.Format("UPDATE bankMaster set bankName='{0}', IFSCCode='{1}', branchName='{2}' where id={3} and companyId={4}",
                    txtBankName.Text.ToString(),
                    txtIFSCCode.Text.ToString(),
                    txtBranchName.Text.ToString(),
                    txtid.Text,
                    Module.CompanyId);
                CLS.addrecord(str);
            }
            ClearData();
            frmBankMaster_Load(null, null);
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtBankName.Focus();
            ClearData();
            IsEdit = false;
            btnSave.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            IsEdit = true;
            txtid.Focus();
            btnSave.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Are you sure Delete Bank?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(msg == DialogResult.Yes)
            {
                     str = "Update bankMaster set isActive = 1 where id=" + txtid.Text + " and companyId = " + Module.CompanyId;
                     CLS.addrecord(str);
                     frmBankMaster_Load(null, null);
            }
            
        }

        public void showData()
        {
            str = "Select * from BankMaster where isActive = 0 and companyId = " + Module.CompanyId;
            dataGridView1.DataSource = CLS.FillDataTable(str);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
        }

        

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtBankName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtBranchName.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtIFSCCode.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            btnSave.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
