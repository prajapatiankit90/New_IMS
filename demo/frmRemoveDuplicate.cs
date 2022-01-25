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
    public partial class frmRemoveDuplicate : Form
    {
        String str;
        Projset CLS = new Projset();
     
        public frmRemoveDuplicate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillData(txtbillNo.Text);
        }

        public void FillData(string bill)
        {
            DataTable DT = new DataTable();
            str = string.Empty;
            str = "select salesMaster.billNo,salesMaster.billDate, partyMaster.partyName, salesMaster.TotalAmount from salesMaster " +
                  "inner join partyMaster on salesMaster.partyId = partyMaster.id " +
                  "where salesMaster.billNo = '" + txtbillNo.Text + "' and salesMaster.companyId=" + Module.CompanyId + "";
            DT = CLS.FillDataTable(str);

            if (DT.Rows.Count > 0)
            {
                lblPartyName.Text = DT.Rows[0]["partyName"].ToString();
                lblBillDate.Text = DT.Rows[0]["billDate"].ToString();
                //lblPartyName.Text = DT.Rows[0]["terms"].ToString();
                lblTotalAmount.Text = DT.Rows[0]["TotalAmount"].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtbillNo.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Bill No", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtbillNo.Focus();
                return;
            }
            else
            {
                str = "UPDate salesMaster set isPrint = 0 where billNo='" + txtbillNo.Text + "' and companyId= " + Module.CompanyId + " ";
                CLS.addrecord(str);

                MessageBox.Show("Sucessfully Save..", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                button3_Click(null, null);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblBillDate.Text = String.Empty;
            lblPartyName.Text = String.Empty;
            lblTotalAmount.Text = string.Empty;
            txtbillNo.Text = String.Empty;

        }
    }
}
