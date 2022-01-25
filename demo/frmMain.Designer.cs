namespace demo
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companyInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partyMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseReturnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesReturnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseSalesReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentReceiptReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partyPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receiptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeCompanyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeDuplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.uName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCompanyName = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.stockToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.paymentToolStripMenuItem,
            this.utilityToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companyInformationToolStripMenuItem,
            this.partyMasterToolStripMenuItem,
            this.itemMasterToolStripMenuItem,
            this.bankMasterToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.fileToolStripMenuItem.Text = "Master";
            // 
            // companyInformationToolStripMenuItem
            // 
            this.companyInformationToolStripMenuItem.Name = "companyInformationToolStripMenuItem";
            this.companyInformationToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.companyInformationToolStripMenuItem.Text = "Company Master";
            this.companyInformationToolStripMenuItem.Click += new System.EventHandler(this.companyInformationToolStripMenuItem_Click);
            // 
            // partyMasterToolStripMenuItem
            // 
            this.partyMasterToolStripMenuItem.Name = "partyMasterToolStripMenuItem";
            this.partyMasterToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.partyMasterToolStripMenuItem.Text = "Party Master";
            this.partyMasterToolStripMenuItem.Click += new System.EventHandler(this.partyMasterToolStripMenuItem_Click);
            // 
            // itemMasterToolStripMenuItem
            // 
            this.itemMasterToolStripMenuItem.Name = "itemMasterToolStripMenuItem";
            this.itemMasterToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.itemMasterToolStripMenuItem.Text = "Item Master";
            this.itemMasterToolStripMenuItem.Click += new System.EventHandler(this.itemMasterToolStripMenuItem_Click);
            // 
            // bankMasterToolStripMenuItem
            // 
            this.bankMasterToolStripMenuItem.Name = "bankMasterToolStripMenuItem";
            this.bankMasterToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.bankMasterToolStripMenuItem.Text = "Bank Master";
            this.bankMasterToolStripMenuItem.Click += new System.EventHandler(this.bankMasterToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseBillToolStripMenuItem,
            this.salesBillToolStripMenuItem,
            this.purchaseReturnToolStripMenuItem,
            this.salesReturnToolStripMenuItem});
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.editToolStripMenuItem.Text = "Bill";
            // 
            // purchaseBillToolStripMenuItem
            // 
            this.purchaseBillToolStripMenuItem.Name = "purchaseBillToolStripMenuItem";
            this.purchaseBillToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.purchaseBillToolStripMenuItem.Text = "Purchase Bill";
            this.purchaseBillToolStripMenuItem.Click += new System.EventHandler(this.purchaseBillToolStripMenuItem_Click);
            // 
            // salesBillToolStripMenuItem
            // 
            this.salesBillToolStripMenuItem.Name = "salesBillToolStripMenuItem";
            this.salesBillToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.salesBillToolStripMenuItem.Text = "Sales Bill";
            this.salesBillToolStripMenuItem.Click += new System.EventHandler(this.salesBillToolStripMenuItem_Click);
            // 
            // purchaseReturnToolStripMenuItem
            // 
            this.purchaseReturnToolStripMenuItem.Name = "purchaseReturnToolStripMenuItem";
            this.purchaseReturnToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.purchaseReturnToolStripMenuItem.Text = "Purchase Return";
            this.purchaseReturnToolStripMenuItem.Click += new System.EventHandler(this.purchaseReturnToolStripMenuItem_Click);
            // 
            // salesReturnToolStripMenuItem
            // 
            this.salesReturnToolStripMenuItem.Name = "salesReturnToolStripMenuItem";
            this.salesReturnToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.salesReturnToolStripMenuItem.Text = "Sales Return";
            this.salesReturnToolStripMenuItem.Click += new System.EventHandler(this.salesReturnToolStripMenuItem_Click);
            // 
            // stockToolStripMenuItem
            // 
            this.stockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockMasterToolStripMenuItem});
            this.stockToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            this.stockToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.stockToolStripMenuItem.Text = "Stock";
            // 
            // stockMasterToolStripMenuItem
            // 
            this.stockMasterToolStripMenuItem.Name = "stockMasterToolStripMenuItem";
            this.stockMasterToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.stockMasterToolStripMenuItem.Text = "Stock Master";
            this.stockMasterToolStripMenuItem.Click += new System.EventHandler(this.stockMasterToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseSalesReportToolStripMenuItem,
            this.paymentReceiptReportToolStripMenuItem});
            this.reportToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // purchaseSalesReportToolStripMenuItem
            // 
            this.purchaseSalesReportToolStripMenuItem.Name = "purchaseSalesReportToolStripMenuItem";
            this.purchaseSalesReportToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.purchaseSalesReportToolStripMenuItem.Text = "Purchase && Sales Report";
            this.purchaseSalesReportToolStripMenuItem.Click += new System.EventHandler(this.purchaseSalesReportToolStripMenuItem_Click);
            // 
            // paymentReceiptReportToolStripMenuItem
            // 
            this.paymentReceiptReportToolStripMenuItem.Name = "paymentReceiptReportToolStripMenuItem";
            this.paymentReceiptReportToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.paymentReceiptReportToolStripMenuItem.Text = "Payment && Receipt Report";
            this.paymentReceiptReportToolStripMenuItem.Click += new System.EventHandler(this.paymentReceiptReportToolStripMenuItem_Click);
            // 
            // paymentToolStripMenuItem
            // 
            this.paymentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.partyPaymentToolStripMenuItem,
            this.receiptToolStripMenuItem});
            this.paymentToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentToolStripMenuItem.Name = "paymentToolStripMenuItem";
            this.paymentToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.paymentToolStripMenuItem.Text = "Account";
            // 
            // partyPaymentToolStripMenuItem
            // 
            this.partyPaymentToolStripMenuItem.Name = "partyPaymentToolStripMenuItem";
            this.partyPaymentToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.partyPaymentToolStripMenuItem.Text = "Payment";
            this.partyPaymentToolStripMenuItem.Click += new System.EventHandler(this.partyPaymentToolStripMenuItem_Click);
            // 
            // receiptToolStripMenuItem
            // 
            this.receiptToolStripMenuItem.Name = "receiptToolStripMenuItem";
            this.receiptToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.receiptToolStripMenuItem.Text = "Receipt";
            this.receiptToolStripMenuItem.Click += new System.EventHandler(this.receiptToolStripMenuItem_Click);
            // 
            // utilityToolStripMenuItem
            // 
            this.utilityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.changeCompanyToolStripMenuItem,
            this.removeDuplicateToolStripMenuItem});
            this.utilityToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.utilityToolStripMenuItem.Name = "utilityToolStripMenuItem";
            this.utilityToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.utilityToolStripMenuItem.Text = "Utility";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // changeCompanyToolStripMenuItem
            // 
            this.changeCompanyToolStripMenuItem.Name = "changeCompanyToolStripMenuItem";
            this.changeCompanyToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.changeCompanyToolStripMenuItem.Text = "Change Company ";
            this.changeCompanyToolStripMenuItem.Click += new System.EventHandler(this.changeCompanyToolStripMenuItem_Click);
            // 
            // removeDuplicateToolStripMenuItem
            // 
            this.removeDuplicateToolStripMenuItem.Name = "removeDuplicateToolStripMenuItem";
            this.removeDuplicateToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.removeDuplicateToolStripMenuItem.Text = "Remove Duplicate";
            this.removeDuplicateToolStripMenuItem.Click += new System.EventHandler(this.removeDuplicateToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.uName,
            this.toolStripStatusLabel2,
            this.lblCompanyName,
            this.timer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 726);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1264, 23);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(90, 18);
            this.toolStripStatusLabel1.Text = "USER NAME:";
            // 
            // uName
            // 
            this.uName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.uName.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.uName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uName.ForeColor = System.Drawing.Color.Red;
            this.uName.Name = "uName";
            this.uName.Size = new System.Drawing.Size(49, 18);
            this.uName.Text = "Name";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Navy;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(119, 18);
            this.toolStripStatusLabel2.Text = "Company Name :";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblCompanyName.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.lblCompanyName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.Navy;
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(49, 18);
            this.lblCompanyName.Text = "Name";
            // 
            // timer
            // 
            this.timer.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.timer.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.timer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timer.ForeColor = System.Drawing.Color.Blue;
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(49, 18);
            this.timer.Text = "Timer";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 749);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companyInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partyMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemMasterToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem salesBillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseBillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseReturnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesReturnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel timer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel uName;
        private System.Windows.Forms.ToolStripMenuItem changeCompanyToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        public System.Windows.Forms.ToolStripStatusLabel lblCompanyName;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseSalesReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeDuplicateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partyPaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentReceiptReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiptToolStripMenuItem;
    }
}