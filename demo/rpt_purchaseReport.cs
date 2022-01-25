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
    public partial class rpt_purchaseReport : Form
    {
        Projset CLS = new Projset();
        int PartyId;
      
        

        public rpt_purchaseReport()
        {
            InitializeComponent();
        }

        private void rpt_purchaseReport_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = dtpToDate.Value.AddDays(-30);
        }

        private void rpt_purchaseReport_Shown(object sender, EventArgs e)
        {
            CLS.FillText("Select partyName From PartyMaster where companyid = " + Module.CompanyId, txtPartyName);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {


            if (rdoPurchase.Checked == true)
            {
                //ALTER PROCEDURE[dbo].[get_purchaseDetails]
                //@fromDate AS Date,
                //@toDate AS Date,
                //@partyId AS Int

                RptPurchaseBill report = new RptPurchaseBill();
                report.Load("RptPurchaseBill.rpt");
                report.SetParameterValue(0, dtpFromDate.Value.ToString("yyyy/MM/dd"));
                report.SetParameterValue(1, dtpToDate.Value.ToString("yyyy/MM/dd"));
                report.SetParameterValue(2, PartyId);
                report.SetDatabaseLogon("sa", "001", "grading11", "test");
                ;


                frmRptDisplay FrmRpt = new frmRptDisplay();
                FrmRpt.ReportViewer.ReportSource = report;
                FrmRpt.ReportViewer.Zoom(1);
                FrmRpt.ReportViewer.Refresh();
                FrmRpt.Show();
            }
            else
            {
                rptSalesBill report = new rptSalesBill();

                report.Load("rptSalesBill.rpt");
                report.SetParameterValue(0, dtpFromDate.Value.ToString("yyyy/MM/dd"));
                report.SetParameterValue(1, dtpToDate.Value.ToString("yyyy/MM/dd"));
                report.SetParameterValue(2, PartyId);
                report.SetDatabaseLogon("sa", "001", "grading11", "test");
                ;


                frmRptDisplay FrmRpt = new frmRptDisplay();
                FrmRpt.ReportViewer.ReportSource = report;
                FrmRpt.ReportViewer.Zoom(1);
                FrmRpt.ReportViewer.Refresh();
                FrmRpt.Show();

            }
        }

        private void txtPartyName_Validating(object sender, CancelEventArgs e)
        {
            PartyId = Convert.ToInt32(CLS.GetValue("Select * from PartyMaster where partyName like '%" + txtPartyName.Text + "%' and companyId = " + Module.CompanyId + ""));
            
        }

        private void rdoPurchase_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtPartyName_TextChanged(object sender, EventArgs e)
        {
            //PartyId = Convert.ToInt32(CLS.GetValue("Select * from PartyMaster where partyName like '%" + txtPartyName.Text + "%' and companyId = " + Module.CompanyId + ""));
        }
    }
}
