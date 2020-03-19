namespace AdminApp
{
    partial class Distribute
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
            this.btnSend = new System.Windows.Forms.Button();
            this.selectedListView = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.failList = new System.Windows.Forms.ListView();
            this.succesList = new System.Windows.Forms.ListView();
            this.hostList = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRetry = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(672, 92);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 28);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send To All";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.OnSendClick);
            // 
            // selectedListView
            // 
            this.selectedListView.BackColor = System.Drawing.SystemColors.Menu;
            this.selectedListView.FullRowSelect = true;
            this.selectedListView.GridLines = true;
            this.selectedListView.HideSelection = false;
            this.selectedListView.Location = new System.Drawing.Point(13, 12);
            this.selectedListView.Margin = new System.Windows.Forms.Padding(4);
            this.selectedListView.Name = "selectedListView";
            this.selectedListView.Size = new System.Drawing.Size(651, 307);
            this.selectedListView.TabIndex = 6;
            this.selectedListView.UseCompatibleStateImageBehavior = false;
            this.selectedListView.View = System.Windows.Forms.View.List;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(672, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Select files";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnSelectClick);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 489);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(651, 23);
            this.progressBar.TabIndex = 31;
            // 
            // failList
            // 
            this.failList.HideSelection = false;
            this.failList.Location = new System.Drawing.Point(140, 416);
            this.failList.Name = "failList";
            this.failList.Size = new System.Drawing.Size(523, 25);
            this.failList.TabIndex = 30;
            this.failList.UseCompatibleStateImageBehavior = false;
            this.failList.View = System.Windows.Forms.View.List;
            // 
            // succesList
            // 
            this.succesList.HideSelection = false;
            this.succesList.Location = new System.Drawing.Point(140, 372);
            this.succesList.Name = "succesList";
            this.succesList.Size = new System.Drawing.Size(523, 25);
            this.succesList.TabIndex = 29;
            this.succesList.UseCompatibleStateImageBehavior = false;
            this.succesList.View = System.Windows.Forms.View.List;
            // 
            // hostList
            // 
            this.hostList.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.hostList.GridLines = true;
            this.hostList.HideSelection = false;
            this.hostList.Location = new System.Drawing.Point(140, 323);
            this.hostList.Name = "hostList";
            this.hostList.Size = new System.Drawing.Size(523, 25);
            this.hostList.TabIndex = 28;
            this.hostList.UseCompatibleStateImageBehavior = false;
            this.hostList.View = System.Windows.Forms.View.List;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 416);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Fail:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "Succes:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Active Computers:";
            // 
            // btnRetry
            // 
            this.btnRetry.Location = new System.Drawing.Point(672, 150);
            this.btnRetry.Margin = new System.Windows.Forms.Padding(4);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(100, 28);
            this.btnRetry.TabIndex = 33;
            this.btnRetry.Text = "Retry";
            this.btnRetry.UseVisualStyleBackColor = true;
            this.btnRetry.Click += new System.EventHandler(this.BtnRetry_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(672, 205);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 28);
            this.btnReset.TabIndex = 32;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // Distribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(915, 539);
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.failList);
            this.Controls.Add(this.succesList);
            this.Controls.Add(this.hostList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.selectedListView);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Distribute";
            this.Click += new System.EventHandler(this.OnSelectClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListView selectedListView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListView failList;
        private System.Windows.Forms.ListView succesList;
        private System.Windows.Forms.ListView hostList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRetry;
        private System.Windows.Forms.Button btnReset;
    }
}