namespace AdminApp
{
    partial class App
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDistribute = new System.Windows.Forms.Button();
            this.btnHost = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.content = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnDistribute);
            this.panel1.Controls.Add(this.btnHost);
            this.panel1.Controls.Add(this.btnInstall);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1147, 123);
            this.panel1.TabIndex = 0;
            // 
            // btnDistribute
            // 
            this.btnDistribute.Location = new System.Drawing.Point(866, 44);
            this.btnDistribute.Margin = new System.Windows.Forms.Padding(4);
            this.btnDistribute.Name = "btnDistribute";
            this.btnDistribute.Size = new System.Drawing.Size(165, 28);
            this.btnDistribute.TabIndex = 2;
            this.btnDistribute.Text = "Distribute File";
            this.btnDistribute.UseVisualStyleBackColor = true;
            this.btnDistribute.Click += new System.EventHandler(this.OnPressDistribute);
            // 
            // btnHost
            // 
            this.btnHost.Location = new System.Drawing.Point(508, 44);
            this.btnHost.Margin = new System.Windows.Forms.Padding(4);
            this.btnHost.Name = "btnHost";
            this.btnHost.Size = new System.Drawing.Size(149, 28);
            this.btnHost.TabIndex = 1;
            this.btnHost.Text = "Host List";
            this.btnHost.UseVisualStyleBackColor = true;
            this.btnHost.Click += new System.EventHandler(this.OnHostClick);
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(181, 44);
            this.btnInstall.Margin = new System.Windows.Forms.Padding(4);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(124, 28);
            this.btnInstall.TabIndex = 0;
            this.btnInstall.Text = "Install Apps";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.OnInstallClick);
            // 
            // content
            // 
            this.content.Location = new System.Drawing.Point(0, 123);
            this.content.Margin = new System.Windows.Forms.Padding(4);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(1147, 652);
            this.content.TabIndex = 1;
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1147, 775);
            this.Controls.Add(this.content);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "App";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDistribute;
        private System.Windows.Forms.Button btnHost;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Panel content;
    }
}

