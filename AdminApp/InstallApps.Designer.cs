namespace AdminApp
{
    partial class InstallApps
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SelectedListView = new System.Windows.Forms.ListView();
            this.btnInstall = new System.Windows.Forms.Button();
            this.failList = new System.Windows.Forms.ListView();
            this.succesList = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.hostList = new System.Windows.Forms.ListView();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnRetry = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(504, 331);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 0;
            this.label1.Click += new System.EventHandler(this.OnInstallClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(752, 33);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnSelectClick);
            // 
            // SelectedListView
            // 
            this.SelectedListView.BackColor = System.Drawing.SystemColors.Menu;
            this.SelectedListView.FullRowSelect = true;
            this.SelectedListView.GridLines = true;
            this.SelectedListView.HideSelection = false;
            this.SelectedListView.Location = new System.Drawing.Point(45, 33);
            this.SelectedListView.Margin = new System.Windows.Forms.Padding(4);
            this.SelectedListView.Name = "SelectedListView";
            this.SelectedListView.Size = new System.Drawing.Size(651, 307);
            this.SelectedListView.TabIndex = 2;
            this.SelectedListView.UseCompatibleStateImageBehavior = false;
            this.SelectedListView.View = System.Windows.Forms.View.List;
            this.SelectedListView.Click += new System.EventHandler(this.OnInstallClick);
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(752, 92);
            this.btnInstall.Margin = new System.Windows.Forms.Padding(4);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(100, 28);
            this.btnInstall.TabIndex = 3;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.OnInstallClick);
            // 
            // failList
            // 
            this.failList.HideSelection = false;
            this.failList.Location = new System.Drawing.Point(170, 460);
            this.failList.Name = "failList";
            this.failList.Size = new System.Drawing.Size(523, 25);
            this.failList.TabIndex = 21;
            this.failList.UseCompatibleStateImageBehavior = false;
            this.failList.View = System.Windows.Forms.View.List;
            // 
            // succesList
            // 
            this.succesList.HideSelection = false;
            this.succesList.Location = new System.Drawing.Point(170, 416);
            this.succesList.Name = "succesList";
            this.succesList.Size = new System.Drawing.Size(523, 25);
            this.succesList.TabIndex = 20;
            this.succesList.UseCompatibleStateImageBehavior = false;
            this.succesList.View = System.Windows.Forms.View.List;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 460);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Fail:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 416);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Succes:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Active Computers:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(485, 332);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 25);
            this.label5.TabIndex = 15;
            // 
            // hostList
            // 
            this.hostList.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.hostList.GridLines = true;
            this.hostList.HideSelection = false;
            this.hostList.Location = new System.Drawing.Point(170, 367);
            this.hostList.Name = "hostList";
            this.hostList.Size = new System.Drawing.Size(523, 25);
            this.hostList.TabIndex = 19;
            this.hostList.UseCompatibleStateImageBehavior = false;
            this.hostList.View = System.Windows.Forms.View.List;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(752, 220);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 28);
            this.btnReset.TabIndex = 22;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // btnRetry
            // 
            this.btnRetry.Location = new System.Drawing.Point(752, 165);
            this.btnRetry.Margin = new System.Windows.Forms.Padding(4);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(100, 28);
            this.btnRetry.TabIndex = 23;
            this.btnRetry.Text = "Retry";
            this.btnRetry.UseVisualStyleBackColor = true;
            this.btnRetry.Click += new System.EventHandler(this.BtnRetry_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(45, 533);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(651, 23);
            this.progressBar.TabIndex = 24;
            // 
            // InstallApps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1128, 763);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.failList);
            this.Controls.Add(this.succesList);
            this.Controls.Add(this.hostList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.SelectedListView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InstallApps";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView SelectedListView;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.ListView failList;
        private System.Windows.Forms.ListView succesList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView hostList;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnRetry;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}