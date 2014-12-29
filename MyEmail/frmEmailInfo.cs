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
            webBrowser.Navigate("about:blank");
            mshtml.IHTMLDocument2 doc = this.webBrowser.Document.DomDocument as mshtml.IHTMLDocument2;
            if (doc != null)
            {
                doc.designMode = "on";
            }

        }

        private void frmEmailInfo_Load(object sender, EventArgs e)
        {
            txtFrom.Text = frmMain.strFrom;
            txtSubject.Text = frmMain.strSubject;
            //txtContent.Text = frmMain.strBody;
            txtAttachment.Text = frmMain.strAttachment;
            txtDate.Text = frmMain.strDate;
            if (frmMain.mailMessage.HTMLBody == null)
            {
                webBrowser.Document.Write(frmMain.mailMessage.Body);
            }
            else
            {
                webBrowser.Document.Write(frmMain.mailMessage.HTMLBody);
            }
            
            //webBrowser.DocumentText = frmMain.mailMessage.HTMLBody;
        }
    }
}
