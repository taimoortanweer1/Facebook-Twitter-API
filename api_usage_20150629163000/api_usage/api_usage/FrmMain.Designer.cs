namespace api_usage
{
    partial class FrmMain
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
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewFBSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewTWSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ultraTabbedMdiManager1 = new Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(811, 24);
            this.msMain.TabIndex = 1;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewFBSearch,
            this.tsmiNewTWSearch,
            this.tsmiExit,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fileToolStripMenuItem.Text = "Search";
            // 
            // tsmiNewFBSearch
            // 
            this.tsmiNewFBSearch.Name = "tsmiNewFBSearch";
            this.tsmiNewFBSearch.Size = new System.Drawing.Size(155, 22);
            this.tsmiNewFBSearch.Text = "New Facebook ";
            this.tsmiNewFBSearch.Click += new System.EventHandler(this.tsmiNewSearch_Click);
            // 
            // tsmiNewTWSearch
            // 
            this.tsmiNewTWSearch.Name = "tsmiNewTWSearch";
            this.tsmiNewTWSearch.Size = new System.Drawing.Size(155, 22);
            this.tsmiNewTWSearch.Text = "New Twitter";
            this.tsmiNewTWSearch.Click += new System.EventHandler(this.tsmiNewTWSearch_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(155, 22);
            this.tsmiExit.Text = "New LinkedIn";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // ultraTabbedMdiManager1
            // 
            this.ultraTabbedMdiManager1.MdiParent = this;
            this.ultraTabbedMdiManager1.TabSettings.AllowClose = Infragistics.Win.DefaultableBoolean.True;
            this.ultraTabbedMdiManager1.TabSettings.CloseButtonAlignment = Infragistics.Win.UltraWinTabs.TabCloseButtonAlignment.AfterContent;
            this.ultraTabbedMdiManager1.TabSettings.CloseButtonVisibility = Infragistics.Win.UltraWinTabs.TabCloseButtonVisibility.WhenSelected;
            this.ultraTabbedMdiManager1.TabSettings.DisplayFormIcon = Infragistics.Win.DefaultableBoolean.False;
            this.ultraTabbedMdiManager1.ViewStyle = Infragistics.Win.UltraWinTabbedMdi.ViewStyle.Office2007;
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 406);
            this.Controls.Add(this.msMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMain;
            this.Name = "FrmMain";
            this.Text = "CARE OSINT";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewFBSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewTWSearch;
        private Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager ultraTabbedMdiManager1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}