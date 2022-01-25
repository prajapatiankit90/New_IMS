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
    public partial class frmCompanyMaster : Form
    {
        Boolean IsEdit = false;
        String str;
        Projset CLS = new Projset();
        public frmCompanyMaster()
        {
            InitializeComponent();
        }

        private void frmCompanyMaster_Load(object sender, EventArgs e)
        {
            ShowData();
            btnNew_Click(null, null);
            clearData();
            btnSave.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            IsEdit = true;
            txtid.Focus();
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtCompanyName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Company Name!", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtCompanyName.Focus();
                return;
            }
            if(txtCompanyAddress.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Company Address!", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtCompanyAddress.Focus();
                return;
            }
            if(txtPhoneNo.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Phone no!", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtPhoneNo.Focus();
                return;
            }
            if (txtPanNo.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Pan no!", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtPanNo.Focus();
                return;
            }
            if (txtGSTNo.Text == string.Empty)
            {
                MessageBox.Show("Please Enter GST No!", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtGSTNo.Focus();
                return;
            }
            if (txtBankName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Bank Name!", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtBankName.Focus();
                return;
            }
            if (txtAccountNo.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Account No!", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtAccountNo.Focus();
                return;
            }
            if (txtIFSCCode.Text == string.Empty)
            {
                MessageBox.Show("Please Enter IFSC Code!", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtIFSCCode.Focus();
                return;
            }
            if (txtBankBranch.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Bank Branch!", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtBankBranch.Focus();
                return;
            }
            
            if (IsEdit == false)
            {
                object CompanyName = CLS.GetValue("Select companyName From companyMaster WHERE companyName = '" + txtCompanyName.Text.Trim().ToString() + "'");
                if (Convert.ToString(CompanyName) != "")
                {
                    MessageBox.Show("Company Name Already Exists.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCompanyName.Focus();
                    return;

                }

                str = String.Format("INSERT INTO companyMaster (CompanyName, CompanyAddress, companyPhone, CompanyPanNo, CompanyGSTNo, companyBankName, companyBankAccount, companyIFSCCode, companyBranch, addDate) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
                txtCompanyName.Text.ToString(),
                txtCompanyAddress.Text.ToString(),
                txtPhoneNo.Text.ToString(),
                txtPanNo.Text.ToString(),
                txtGSTNo.Text.ToString(),
                txtBankName.Text.ToString(),
                txtAccountNo.Text.ToString(),
                txtIFSCCode.Text.ToString(),
                txtBankBranch.Text.ToString(),
                DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
            }
            else
            {
                //object CoNameCnt = CLS.GetValue("Select Count(companyName) From companyMaster WHERE companyName = '" + txtCompanyName.Text.Trim().ToString() + "' Group By companyName");
                //if (Convert.ToInt32(CoNameCnt) >= 1)
                //{
                //    MessageBox.Show("Company Name Already Exists.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtCompanyName.Focus();
                //    return;
                //}

                str = String.Format("UPDATE companyMaster set CompanyName='{0}', CompanyAddress='{1}', companyPhone='{2}', CompanyPanNo='{3}', CompanyGSTNo='{4}', companyBankName='{5}', companyBankAccount='{6}', companyIFSCCode='{7}', companyBranch='{8}', editDate='{10}' where Id = {9}",
                txtCompanyName.Text.ToString(),
                txtCompanyAddress.Text.ToString(),
                txtPhoneNo.Text.ToString(),
                txtPanNo.Text.ToString(),
                txtGSTNo.Text.ToString(),
                txtBankName.Text.ToString(),
                txtAccountNo.Text.ToString(),
                txtIFSCCode.Text.ToString(),
                txtBankBranch.Text.ToString(),
                txtid.Text,
                DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
            }
            CLS.addrecord(str);
            clearData();
            ShowData();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtCompanyName.Focus();
            IsEdit = false;
            clearData();
            ShowData();
            btnSave.Enabled = true;
        }

        public void ShowData()
        {
            dataGridView1.DataSource = CLS.FillDataTable("Select * from companyMaster where InActive = 0");
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
        }

        public void clearData()
        {
            txtCompanyName.Text = string.Empty;
            txtCompanyAddress.Text = string.Empty;
            txtPanNo.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            txtGSTNo.Text = string.Empty;
            txtBankName.Text = string.Empty;
            txtAccountNo.Text = string.Empty;
            txtIFSCCode.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            txtBankBranch.Text = string.Empty;
            txtid.Text = string.Empty;
            btnSave.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtCompanyName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCompanyAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPhoneNo.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPanNo.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtGSTNo.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtBankName.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtAccountNo.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtIFSCCode.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtBankBranch.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            btnSave.Enabled = false;         
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Are you sure Delete Company?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(msg == DialogResult.Yes)
            {
                str = "update companyMaster set InActive=1 where id =" + txtid.Text;
                CLS.addrecord(str);
                btnNew_Click(null, null);
            }
        }

        private void txtCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
