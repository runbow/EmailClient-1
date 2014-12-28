namespace MyEmail
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
            this.CMStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvEmailInfo = new System.Windows.Forms.DataGridView();
            this.发件人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.SStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TLabUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TLabNum = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.CMStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmailInfo)).BeginInit();
            this.MStrip.SuspendLayout();
            this.SStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // CMStrip
            // 
            this.CMStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteEmail});
            this.CMStrip.Name = "CMStrip";
            this.CMStrip.Size = new System.Drawing.Size(99, 26);
            // 
            // deleteEmail
            // 
            this.deleteEmail.Name = "deleteEmail";
            this.deleteEmail.Size = new System.Drawing.Size(98, 22);
            this.deleteEmail.Text = "删除";
            this.deleteEmail.Click += new System.EventHandler(this.deleteEmail_Click);
            // 
            // dgvEmailInfo
            // 
            this.dgvEmailInfo.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvEmailInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEmailInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmailInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.发件人,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvEmailInfo.ContextMenuStrip = this.CMStrip;
            this.dgvEmailInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmailInfo.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvEmailInfo.Location = new System.Drawing.Point(0, 24);
            this.dgvEmailInfo.Name = "dgvEmailInfo";
            this.dgvEmailInfo.ReadOnly = true;
            this.dgvEmailInfo.RowTemplate.Height = 23;
            this.dgvEmailInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmailInfo.Size = new System.Drawing.Size(765, 353);
            this.dgvEmailInfo.TabIndex = 1;
            this.dgvEmailInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmailInfo_CellClick);
            this.dgvEmailInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmailInfo_CellDoubleClick);
            this.dgvEmailInfo.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEmailInfo_CellMouseClick);
            // 
            // 发件人
            // 
            this.发件人.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.发件人.HeaderText = "发件人";
            this.发件人.Name = "发件人";
            this.发件人.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "主题";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "内容";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "附件";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "发件日期";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // MStrip
            // 
            this.MStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.refresh});
            this.MStrip.Location = new System.Drawing.Point(0, 0);
            this.MStrip.Name = "MStrip";
            this.MStrip.Size = new System.Drawing.Size(765, 24);
            this.MStrip.TabIndex = 2;
            this.MStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItem1.Size = new System.Drawing.Size(82, 20);
            this.toolStripMenuItem1.Text = "发送邮件(S)";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(67, 20);
            this.toolStripMenuItem2.Text = "用户管理";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(43, 20);
            this.toolStripMenuItem3.Text = "注销";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.logoff);
            // 
            // refresh
            // 
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(43, 20);
            this.refresh.Text = "刷新";
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // SStrip
            // 
            this.SStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.TLabUser,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.TLabNum,
            this.toolStripStatusLabel2,
            this.currentTime});
            this.SStrip.Location = new System.Drawing.Point(0, 355);
            this.SStrip.Name = "SStrip";
            this.SStrip.Size = new System.Drawing.Size(765, 22);
            this.SStrip.TabIndex = 3;
            this.SStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(58, 17);
            this.toolStripStatusLabel1.Text = "当前用户:";
            // 
            // TLabUser
            // 
            this.TLabUser.Name = "TLabUser";
            this.TLabUser.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabel3.Text = "||";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(58, 17);
            this.toolStripStatusLabel4.Text = "邮件总数:";
            // 
            // TLabNum
            // 
            this.TLabNum.Name = "TLabNum";
            this.TLabNum.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(351, 17);
            this.toolStripStatusLabel2.Text = "                                                                                时" +
    "间";
            // 
            // currentTime
            // 
            this.currentTime.Name = "currentTime";
            this.currentTime.Size = new System.Drawing.Size(0, 17);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 377);
            this.Controls.Add(this.SStrip);
            this.Controls.Add(this.dgvEmailInfo);
            this.Controls.Add(this.MStrip);
            this.MainMenuStrip = this.MStrip;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "邮件管理";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.CMStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmailInfo)).EndInit();
            this.MStrip.ResumeLayout(false);
            this.MStrip.PerformLayout();
            this.SStrip.ResumeLayout(false);
            this.SStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip CMStrip;
        private System.Windows.Forms.DataGridView dgvEmailInfo;
        private System.Windows.Forms.MenuStrip MStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteEmail;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem refresh;
        private System.Windows.Forms.StatusStrip SStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel TLabUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel TLabNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn 发件人;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel currentTime;
    }
}