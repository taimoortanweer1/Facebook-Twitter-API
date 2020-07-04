namespace api_usage
{
    partial class DlgAuthorization
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
        private System.Windows.Forms.WebBrowser wbAuth;
        private void InitializeComponent()
        {
            this.wbAuth = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbAuth
            // 
            this.wbAuth.Dock = System.Windows.Forms.DockStyle.Top;
            this.wbAuth.Location = new System.Drawing.Point(0, 0);
            this.wbAuth.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbAuth.Name = "wbAuth";
            this.wbAuth.ScriptErrorsSuppressed = true;
            this.wbAuth.ScrollBarsEnabled = false;
            this.wbAuth.Size = new System.Drawing.Size(380, 392);
            this.wbAuth.TabIndex = 0;
            this.wbAuth.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.wbAuth_Navigated);
            // 
            // DlgAuthorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(397, 386);
            this.Controls.Add(this.wbAuth);
            this.KeyPreview = true;
            this.Name = "DlgAuthorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DlgAuthorization";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DlgAuthorization_KeyDown);
            this.ResumeLayout(false);

        }
    }
}