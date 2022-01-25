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
    public partial class frmPartyMaster : Form
    {
        Boolean IsEdit = false;
        String str;
        Projset CLS = new Projset();
        public frmPartyMaster()
        {
            InitializeComponent();
        }

        private void frmPartyMaster_Load(object sender, EventArgs e)
        {
            ShowData();
            btnNew_Click(null, null);            
        }

        public void clearData()
        {
            txtPName.Text = string.Empty;
            txtPAddress.Text = string.Empty;
            txtPPhone.Text = string.Empty;
            txtPPan.Text = string.Empty;
            txtPGst.Text = string.Empty;
            txtid.Text = string.Empty;
            txtPCode.Text = string.Empty;
            txtPStateName.Text = string.Empty;
            btnSave.Enabled = false;
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
            if(txtPName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Party Name", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtPName.Focus();
                return;
            }
            if(txtPAddress.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Party Address", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtPAddress.Focus();
                return;
            }
            if(txtPPhone.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Party Phone No", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtPPhone.Focus();
                return;
            }
            if(txtPGst.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Party GST No", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtPGst.Focus();
                return;
            }
            if(txtPPan.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Party Pan No", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtPPan.Focus();
                return;
            }
            if (txtPStateName.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Party State Name", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtPStateName.Focus();
                return;
            }
            if (txtPCode.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Party Code", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtPCode.Focus();
                return;
            }
            if (IsEdit == false)
            {
                object PartyName = CLS.GetValue("Select partyName From partyMaster WHERE partyName = '" + txtPName.Text.Trim().ToString() + "' and companyId= " + Module.CompanyId +"");
                if (Convert.ToString(PartyName) != "")
                {
                    MessageBox.Show("Party Name Already Exists.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPName.Focus();
                    return;

                }
                str = String.Format("INSERT INTO partyMaster (partyName, partyAddress, partyPhoneno, partyPanno, partyGSTNo, companyId,state,code) values ('{0}','{1}','{2}','{3}','{4}',{5},'{6}',{7})",
                    txtPName.Text.ToString(),
                    txtPAddress.Text.ToString(),
                    txtPPhone.Text.ToString(),
                    txtPPan.Text.ToString(),
                    txtPGst.Text.ToString(),
                    Module.CompanyId,
                    txtPStateName.Text.ToString(),
                    txtPCode.Text
                    );
            }
            else
            {
                //object ShNameCnt = CLS.GetValue("Select Count(partyName) From partyMaster WHERE partyName = '" + txtPName.Text.Trim().ToString() + "' and companyId= " + Module.CompanyId +" Group By partyName");
                //if (Convert.ToInt32(ShNameCnt) >= 1)
                //{
                //    MessageBox.Show("Party Name Already Exists.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtPName.Focus();
                //    return;
                //}
                str = String.Format("UPDATE partyMaster set partyName = '{0}', partyAddress = '{1}', partyPhoneno = '{2}', partyPanno = '{3}', partyGSTNo = '{4}', state='{7}', code={8} where id={5} and companyId = {6}",
                    txtPName.Text.ToString(),
                    txtPAddress.Text.ToString(),
                    txtPPhone.Text.ToString(),
                    txtPPan.Text.ToString(),
                    txtPGst.Text.ToString(),
                    txtid.Text,
                    Module.CompanyId,
                    txtPStateName.Text.ToString(),
                    txtPCode.Text
                    );
            }
            CLS.addrecord(str);
            ShowData();
            clearData();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            IsEdit = false;
            txtPName.Focus();
            clearData();
            btnSave.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            IsEdit = true;
            txtid.Focus();
            btnSave.Enabled = true;
        }

        public void ShowData()
        {
            dataGridView1.DataSource = CLS.FillDataTable("select * from partyMaster where isInActive = 0 and companyId= " + Module.CompanyId + "");
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
        }


        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtPName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPPan.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPGst.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtPStateName.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtPCode.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            btnSave.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)

        {
            DialogResult msg = MessageBox.Show("Are you sure Delete Party?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(msg == DialogResult.Yes)
            {
                str = "update partyMaster set isInactive = 1 where id = " + txtid.Text + " and companyId= " + Module.CompanyId;
                CLS.addrecord(str);
                frmPartyMaster_Load(null, null);
            }
        }

        private void txtPName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
