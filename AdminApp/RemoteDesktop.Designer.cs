namespace AdminApp
{
    partial class RemoteDesktop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteDesktop));
            this.axRDPViewer = new AxRDPCOMAPILib.AxRDPViewer();
            ((System.ComponentModel.ISupportInitialize)(this.axRDPViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // axRDPViewer
            // 
            this.axRDPViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axRDPViewer.Enabled = true;
            this.axRDPViewer.Location = new System.Drawing.Point(0, 0);
            this.axRDPViewer.Name = "axRDPViewer";
            this.axRDPViewer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axRDPViewer.OcxState")));
            this.axRDPViewer.Size = new System.Drawing.Size(1147, 617);
            this.axRDPViewer.TabIndex = 0;
            // 
            // RemoteDesktop
            // 
            this.ClientSize = new System.Drawing.Size(1147, 617);
            this.Controls.Add(this.axRDPViewer);
            this.Name = "RemoteDesktop";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.axRDPViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private AxRDPCOMAPILib.AxRDPViewer axRDPViewer;
    }
}