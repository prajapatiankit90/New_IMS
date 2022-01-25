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
    public partial class frmSearch : Form
    {
        int SearchType = 0;
        string Query;
        DataTable DT = new DataTable();
        public frmSearch(int MySearch)
        {
            InitializeComponent();
            SearchType = MySearch;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(SearchType == 1)
            {
                Query = "select PurchaseMaster.id, purchaseMaster.billNo as [Bill No],purchaseMaster.billDate as [Bill Date],partyMaster.partyName as [Party Name], purchaseMaster.TotalAmount from purchaseMaster " +
                      "inner join partyMaster on purchaseMaster.partyId = partyMaster.id " +
                      "where ((PurchaseMaster.billDate) >= #" + dtpFromDate.Value.ToString("yyyy/MM/dd") + "# And (PurchaseMaster.billDate) <= #" + dtpToDate.Value.ToString("yyyy/MM/dd") + "#)  and purchaseMaster.companyId=" + Module.CompanyId +" " +
                       "Order by PurchaseMaster.billDate DESC";
            }
            if(SearchType == 2)
            {
                Query = "select salesMaster.id, salesMaster.billNo, partyMaster.partyName, salesMaster.totalAmount " +
                        " from salesMaster  inner join partyMaster on partyMaster.id = salesMaster.partyId " +
                        " where ((salesMaster.billDate) >= #" + dtpFromDate.Value.ToString("yyyy/MM/dd") + "# And (salesMaster.billDate) <= #" + dtpToDate.Value.ToString("yyyy/MM/dd") + "#)" + 
                        " Order by SalesMaster.Billdate DESC";  
            }
            if (!string.IsNullOrEmpty(Query))
            {
                Projset RasClass = new Projset();
                DT = RasClass.FillDataTable(Query);
                dataGridView1.DataSource = DT;
                dataGridView1.AutoResizeColumns();
                dataGridView1.ClearSelection();
                cmbSearch.Items.Clear();
                foreach (DataColumn dc in DT.Columns)
                {
                    if ((dc.ColumnName.ToLower() == "entrydate" || dc.ColumnName.ToLower() == "billdate"))
                    { continue; }

                    cmbSearch.Items.Add(dc.ColumnName.ToString());
                }
            }
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = dtpToDate.Value.AddDays(-30);
            btnSearch_Click(null, null);

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please Select any Row.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SearchType == 1)
            {
                // Purchase Search
                Module.FindId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
            else if (SearchType == 2)
            {
                Module.FindId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
            Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please Select any Row.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SearchType == 1)
            {
                // Purchase Search
                Module.FindId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
            else if (SearchType == 2)
            {
                Module.FindId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
            Close();
        }
    }
}
