namespace AdminApp
{
    partial class HostList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostList));
            this.refresh = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hostsList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(16, 7);
            this.refresh.Margin = new System.Windows.Forms.Padding(4);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(100, 28);
            this.refresh.TabIndex = 1;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.OnRefresh_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "images.png");
            // 
            // hostsList
            // 
            this.hostsList.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.hostsList.AllowColumnReorder = true;
            this.hostsList.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.hostsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IP});
            this.hostsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hostsList.FullRowSelect = true;
            this.hostsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.hostsList.HideSelection = false;
            this.hostsList.LabelWrap = false;
            this.hostsList.LargeImageList = this.imageList1;
            this.hostsList.Location = new System.Drawing.Point(0, 0);
            this.hostsList.Name = "hostsList";
            this.hostsList.ShowGroups = false;
            this.hostsList.Size = new System.Drawing.Size(1159, 795);
            this.hostsList.SmallImageList = this.imageList1;
            this.hostsList.TabIndex = 2;
            this.hostsList.UseCompatibleStateImageBehavior = false;
            this.hostsList.DoubleClick += new System.EventHandler(this.OnSelectItem);
            // 
            // HostList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1159, 795);
            this.Controls.Add(this.hostsList);
            this.Controls.Add(this.refresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HostList";
            this.Text = "MultipleControls";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ListView hostsList;
    }
}