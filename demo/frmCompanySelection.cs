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
    public partial class frmCompanySelection : Form
    {
        Projset CLS = new Projset();
        public frmCompanySelection()
        {
            InitializeComponent();
        }

        private void frmCompanySelection_Load(object sender, EventArgs e)
        {
            dataGride.DataSource = CLS.FillDataTable("Select * From CompanyMaster where InActive = 0");
            dataGride.Columns[0].Visible = false;
            dataGride.Columns[4].Visible = false;
            dataGride.Columns[5].Visible = false;
            dataGride.Columns[6].Visible = false;
            dataGride.Columns[7].Visible = false;
            dataGride.Columns[8].Visible = false;
            dataGride.Columns[9].Visible = false;
            dataGride.Columns[10].Visible = false;
            

        }

        private void dataGride_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            frmMain main = new frmMain();
            Module.CompanyId = Convert.ToInt32(dataGride.Rows[e.RowIndex].Cells[0].Value.ToString());
            ((frmMain)MdiParent).lblCompanyName.Text = dataGride.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGride_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
    }
}
