namespace MyEmail
{
    partial class sent
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
            this.sentdataGridView = new System.Windows.Forms.DataGridView();
            this.sentcontextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deletesent = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.sentdataGridView)).BeginInit();
            this.sentcontextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // sentdataGridView
            // 
            this.sentdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sentdataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sentdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sentdataGridView.ContextMenuStrip = this.sentcontextMenuStrip;
            this.sentdataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sentdataGridView.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sentdataGridView.Location = new System.Drawing.Point(0, 0);
            this.sentdataGridView.Name = "sentdataGridView";
            this.sentdataGridView.ReadOnly = true;
            this.sentdataGridView.RowTemplate.Height = 23;
            this.sentdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sentdataGridView.Size = new System.Drawing.Size(583, 348);
            this.sentdataGridView.TabIndex = 0;
            this.sentdataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sentdataGridView_CellDoubleClick);
            this.sentdataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.sentdataGridView_CellMouseClick);
            // 
            // sentcontextMenuStrip
            // 
            this.sentcontextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deletesent});
            this.sentcontextMenuStrip.Name = "sentcontextMenuStrip";
            this.sentcontextMenuStrip.Size = new System.Drawing.Size(99, 26);
            // 
            // deletesent
            // 
            this.deletesent.Name = "deletesent";
            this.deletesent.Size = new System.Drawing.Size(152, 22);
            this.deletesent.Text = "删除";
            this.deletesent.Click += new System.EventHandler(this.deletesent_Click);
            // 
            // sent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 348);
            this.Controls.Add(this.sentdataGridView);
            this.Name = "sent";
            this.Text = "发件箱";
            this.Load += new System.EventHandler(this.sent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sentdataGridView)).EndInit();
            this.sentcontextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView sentdataGridView;
        private System.Windows.Forms.ContextMenuStrip sentcontextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deletesent;

    }
}