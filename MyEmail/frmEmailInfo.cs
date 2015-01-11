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
            /*mshtml.IHTMLDocument2 doc = this.webBrowser.Document.DomDocument as mshtml.IHTMLDocument2;
            if (doc != null)
            {
                doc.designMode = "on";
            }*/

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

        private void button1_Click(object sender, EventArgs e)
        {
            sendmail remail = new sendmail();
            remail.Text = "Re:" + txtSubject.Text + " - 写邮件";
            remail.txtTo.Text  = txtFrom.Text;
            remail.txtSubject.Text  = "Re:"+txtSubject.Text;
            if (frmMain.mailMessage.HTMLBody == null)
            {
                remail.webbody.Document.Write("<br><br><br>---------原始邮件---------<br>发件人：" + txtFrom.Text + "<br>发送时间：" + txtDate.Text + "<br>收件人：" + login.User + "<br>主题：" + txtSubject.Text + "<br>--------------------------" + "<br>" + frmMain.mailMessage.Body);
            }
            else
            {
                remail.webbody.Document.Write("<br><br><br>---------原始邮件---------<br>发件人：" + txtFrom.Text + "<br>发送时间：" + txtDate.Text + "<br>收件人：" + login.User + "<br>主题：" + txtSubject.Text + "<br>--------------------------" + frmMain.mailMessage.HTMLBody);
            }
            remail.Show();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sendmail resend = new sendmail();
            resend.Text = "Fw:" + txtSubject.Text + " - 写邮件";
            resend.txtSubject.Text = "Fw:" + txtSubject.Text;
            if (frmMain.mailMessage.HTMLBody == null)
            {
                resend.webbody.Document.Write("<br><br><br>---------原始邮件---------<br>发件人：" + txtFrom.Text + "<br>发送时间：" + txtDate.Text + "<br>收件人：" + login.User + "<br>主题：" + txtSubject.Text + "<br>--------------------------" + "<br>" + frmMain.mailMessage.Body);
            }
            else
            {
                resend.webbody.Document.Write("<br><br><br>---------原始邮件---------<br>发件人：" + txtFrom.Text + "<br>发送时间：" + txtDate.Text + "<br>收件人：" + login.User + "<br>主题：" + txtSubject.Text + "<br>--------------------------" + frmMain.mailMessage.HTMLBody);
            }
            /*string[] attname=frmMain .strAttachment .Split (';');            
            resend.listBox1.Items.AddRange(attname );*/
            resend.Show();            
        }
    }
}
