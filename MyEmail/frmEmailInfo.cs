using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEmail
{
    public partial class frmEmailInfo : Form
    {
        public frmEmailInfo()
        {
            InitializeComponent();
        }

        private void frmEmailInfo_Load(object sender, EventArgs e)
        {
            txtFrom.Text = frmMain.strFrom;
            txtSubject.Text = frmMain.strSubject;
            txtContent.Text = frmMain.strBody;
            txtAttachment.Text = frmMain.strAttachment;
            txtDate.Text = frmMain.strDate;
        }
    }
}
