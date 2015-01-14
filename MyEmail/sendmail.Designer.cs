namespace MyEmail
{
    partial class sendmail
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnDeAtt = new System.Windows.Forms.Button();
            this.webbody = new System.Windows.Forms.WebBrowser();
            this.save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(459, 231);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "添加附件";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSend.Location = new System.Drawing.Point(152, 290);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(80, 8);
            this.txtSend.Name = "txtSend";
            this.txtSend.ReadOnly = true;
            this.txtSend.Size = new System.Drawing.Size(159, 21);
            this.txtSend.TabIndex = 7;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(399, 48);
            this.txtServer.Name = "txtServer";
            this.txtServer.ReadOnly = true;
            this.txtServer.Size = new System.Drawing.Size(157, 21);
            this.txtServer.TabIndex = 8;
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(80, 48);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(137, 21);
            this.txtSubject.TabIndex = 9;
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(399, 8);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(157, 21);
            this.txtTo.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "发件人";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "收件人";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(351, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "服务器";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "主题";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "邮件内容";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "附件";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "添加附件";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(80, 231);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(344, 52);
            this.listBox1.TabIndex = 20;
            // 
            // btnDeAtt
            // 
            this.btnDeAtt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeAtt.Location = new System.Drawing.Point(459, 260);
            this.btnDeAtt.Name = "btnDeAtt";
            this.btnDeAtt.Size = new System.Drawing.Size(75, 23);
            this.btnDeAtt.TabIndex = 21;
            this.btnDeAtt.Text = "删除附件";
            this.btnDeAtt.UseVisualStyleBackColor = true;
            this.btnDeAtt.Click += new System.EventHandler(this.btnDeAtt_Click);
            // 
            // webbody
            // 
            this.webbody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webbody.Location = new System.Drawing.Point(80, 94);
            this.webbody.MinimumSize = new System.Drawing.Size(20, 20);
            this.webbody.Name = "webbody";
            this.webbody.Size = new System.Drawing.Size(344, 117);
            this.webbody.TabIndex = 22;
            // 
            // save
            // 
            this.save.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.save.Location = new System.Drawing.Point(280, 290);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 23;
            this.save.Text = "保存";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // sendmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 325);
            this.Controls.Add(this.save);
            this.Controls.Add(this.webbody);
            this.Controls.Add(this.btnDeAtt);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnSelect);
            this.Name = "sendmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "邮件发送";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnDeAtt;
        public System.Windows.Forms.TextBox txtSend;
        public System.Windows.Forms.TextBox txtServer;
        public System.Windows.Forms.TextBox txtTo;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.WebBrowser webbody;
        public System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Button save;
    }
}

