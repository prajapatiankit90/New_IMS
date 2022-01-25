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
    public partial class frmStockMaster : Form
    {
        Projset CLS = new Projset();
        
        
        public frmStockMaster()
        {
            InitializeComponent();
        }

        private void frmStockMaster_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CLS.FillDataTable("select itemMaster.itemName as [Item Name], sum(stockMaster.qty) As [Total Qty]  from (stockMaster inner join itemMaster on itemMaster.id = stockMaster.itemId) inner join partyMaster on partyMaster.id = stockMaster.partyId where stockMaster.companyId = "+ Module.CompanyId +" group by itemMaster.itemName HAVING(((Sum(StockMaster.Qty)) <> 0))");
            dtpFromDate.Value = dtpToDate.Value.AddDays(-30);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(rdoItemWise.Checked == true)
            {
            dataGridView1.DataSource = CLS.FillDataTable("select itemMaster.itemName as [Item Name], sum(stockMaster.qty) as [Total Qty] from (stockMaster inner join itemMaster on itemMaster.id = stockMaster.itemId) inner join partyMaster on partyMaster.id = stockMaster.partyId where stockMaster.entryDate between '" + dtpFromDate.Value.ToString("yyyy/MM/dd") + "' and '" + dtpToDate.Value.ToString("yyyy/MM/dd") + "'  and stockMaster.companyId = " + Module.CompanyId + " group by itemMaster.itemName HAVING(((Sum(StockMaster.Qty)) <> 0)) ");

            }
            else
            {
               dataGridView1.DataSource= CLS.FillDataTable("select partyMaster.partyName as [Party Name], itemMaster.itemName as [Item Name], sum(stockMaster.qty) as [Total Qty] from (stockMaster inner join itemMaster on itemMaster.id = stockMaster.itemId) inner join partyMaster on partyMaster.id = stockMaster.partyId where ((StockMaster.EntryDate) >= #" + dtpFromDate.Value.ToString("yyyy/MM/dd") + "# And (StockMaster.EntryDate) <= #" + dtpToDate.Value.ToString("yyyy/MM/dd") + "#)  and stockMaster.companyId = " + Module.CompanyId + " group by itemMaster.itemName, partyMaster.partyName HAVING(((Sum(StockMaster.Qty)) <> 0)) ");
            }
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CLS.FillDataTable("select itemMaster.itemName as [Item Name], sum(stockMaster.qty) as [Total Qty] from (stockMaster inner join itemMaster on itemMaster.id = stockMaster.itemId) inner join partyMaster on partyMaster.id = stockMaster.partyId where itemMaster.itemName like '%" + txtItemName.Text + "%' and stockMaster.companyId = " + Module.CompanyId + " group by itemMaster.itemName HAVING(((Sum(StockMaster.Qty)) <> 0)) ");
        }

        private void txtPartyName_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CLS.FillDataTable("select partyMaster.partyName as [Party Name], itemMaster.itemName as [Item Name], sum(stockMaster.qty) as [Total Qty] from (stockMaster inner join itemMaster on itemMaster.id = stockMaster.itemId) inner join partyMaster on partyMaster.id = stockMaster.partyId where  partyMaster.partyName like '%" + txtPartyName.Text + "%' and stockMaster.companyId = " + Module.CompanyId + " and stockMaster.qty >=0 group by itemMaster.itemName, partyMaster.partyName HAVING(((Sum(StockMaster.Qty)) <> 0)) ");
        }

        private void frmStockMaster_Shown(object sender, EventArgs e)
        {
            CLS.FillText("Select partyName from partyMaster where companyId = " + Module.CompanyId + "", txtPartyName);
            CLS.FillText("Select itemName from itemMaster where companyId = " + Module.CompanyId + "", txtItemName);
        }

        private void rdoPartyWise_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CLS.FillDataTable("select partyMaster.partyName as [Party Name], itemMaster.itemName as [Item Name], sum(stockMaster.qty) as [Total Qty] from (stockMaster inner join itemMaster on itemMaster.id = stockMaster.itemId) inner join partyMaster on partyMaster.id = stockMaster.partyId where stockMaster.companyId = " + Module.CompanyId + " group by itemMaster.itemName, partyMaster.partyName HAVING(((Sum(StockMaster.Qty)) <> 0)) ");
        }

        private void rdoItemWise_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CLS.FillDataTable("select itemMaster.itemName as [Item Name], sum(stockMaster.qty) As [Total Qty]  from (stockMaster inner join itemMaster on itemMaster.id = stockMaster.itemId) inner join partyMaster on partyMaster.id = stockMaster.partyId where stockMaster.companyId = " + Module.CompanyId + " group by itemMaster.itemName HAVING(((Sum(StockMaster.Qty)) <> 0))");
        }
    }
}
