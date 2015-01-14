using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Mail;
using System.Data.OleDb;
namespace MyEmail
{
    public partial class sendmail : Form
    {
        public sendmail()
        {
            InitializeComponent();
            txtSend.Text = login.User;//frmMain.user;// //  ;
            txtServer.Text = login.Smtp;// frmMain.smtpserver;// ; 
            webbody.Navigate("about:blank");
            mshtml.IHTMLDocument2 doc = this.webbody.Document.DomDocument as mshtml.IHTMLDocument2;
            if (doc != null)
            {
                doc.designMode = "on";
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage message = null;
                if (txtTo.Text.IndexOf(";") != -1)
                {
                    string[] strEmail = txtTo.Text.Split(';');
                    string sumEmail = "";
                    for (int i = 0; i < strEmail.Length; i++)
                    {
                        sumEmail = strEmail[i];
                        message = new MailMessage(new MailAddress(txtSend.Text), new MailAddress(sumEmail));
                        SendEmail(message);
                    }
                }
                else
                {
                    message = new MailMessage(new MailAddress(txtSend.Text), new MailAddress(txtTo.Text));
                    SendEmail(message);
                }
                MessageBox.Show("发送成功！");
                try
                {
                    DBConnect();
                    sqlCon.Open();
                    OleDbCommand cmd = new OleDbCommand("insert into send(发件人,收件人,主题,内容,时间) values ('" + txtSend.Text + "','" + txtTo.Text + "','" + txtSubject.Text + "','" + webbody.DocumentText + "','" + DateTime.Now.ToLocalTime().ToString() + "')", sqlCon);
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();         
                }
                catch
                {
                    MessageBox.Show("保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch 
            {
                MessageBox .Show ("发送失败！");
            }
        }
        private void SendEmail(MailMessage message)
        {
            message .Subject = txtSubject .Text ;
            message.Body = webbody.DocumentText; //txtContent .Text ;
            message.SubjectEncoding = System.Text.Encoding.GetEncoding("gb18030");//System.Text.Encoding.UTF8;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Priority = System.Net.Mail.MailPriority.High;
            message.IsBodyHtml = true;
            /*if(txtAttachment .Text !="")
            {
                if (txtAttachment .Text .IndexOf (";")!=-1)
                {
                    string []strAttachment=txtAttachment .Text .Split (';');
                    for (int i=0;i<strAttachment .Length ;i++)
                    {
                        AddFile(strAttachment [i],message );
                    }
                }
                else 
                {
                    AddFile(txtAttachment .Text ,message );
                }
            }*/
            if (listBox1.Items.Count > 0)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    AddFile(listBox1.Items[i].ToString(),message);
                }
            }
            SmtpClient client=new SmtpClient (txtServer .Text ,25);
            client .Credentials =new System.Net .NetworkCredential (txtSend .Text  ,login .Password  );
            client .Send (message );
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {        
            openFileDialog.Title = "添加附件";
            if (openFileDialog .ShowDialog ()==DialogResult .OK )//用户进行了选择，即点击了打开按钮
            {
                /*if (txtAttachment .Text =="")
                {
                    txtAttachment .Text =openFileDialog .FileName ;
                }
                else 
                {
                    txtAttachment .Text +=";"+openFileDialog .FileName ;
                }*/
                if (openFileDialog .FileNames !=null)//将选择的文件路径写入listbox中
                {
                    listBox1.Items.AddRange(openFileDialog .FileNames );
                }
            }
        }
        private void AddFile(string strFile,MailMessage message)
        {
            Attachment myAttachment=new Attachment (strFile ,System.Net.Mime .MediaTypeNames .Application .Octet );
            myAttachment .NameEncoding =System .Text .Encoding .GetEncoding ("gb18030");
            System .Net .Mime .ContentDisposition disposition=myAttachment .ContentDisposition ;
            disposition .CreationDate =System .IO .File .GetCreationTime (strFile );
            disposition .ModificationDate =System .IO.File.GetLastWriteTime (strFile );
            disposition .ReadDate =System .IO .File .GetLastAccessTime (strFile );
            message.Attachments .Add (myAttachment );
        }

        private void btnDeAtt_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.SelectedItems.Count - 1; i > -1; i--)
            {
                listBox1.Items.Remove(listBox1.SelectedItems[i]);
            }

        }

        string strCon;
        OleDbConnection sqlCon;
        private void DBConnect()
        {
            strCon = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source = MyEmail.mdb";
            sqlCon = new OleDbConnection(strCon);
        }
        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnect();
                sqlCon.Open();
                OleDbCommand cmd = new OleDbCommand("insert into draft(发件人,收件人,主题,内容,时间) values ('" + txtSend.Text + "','" + txtTo.Text + "','" + txtSubject.Text + "','" + webbody.DocumentText + "','" + DateTime.Now.ToLocalTime().ToString() + "')", sqlCon);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           /* SqlDataAdapter da = new SqlDataAdapter("select * from emailuser", sqlCon);//("select username as 用户名," + "password as 密码,realname as 真实姓名 from emailuser", sqlCon);
            DataSet ds = new DataSet();
            da.Fill(ds, "tablename");
            //dataGridView1.DataSource   = ds.Tables["tablename"];
            /*listBox1.Items.Add(ds.Tables["tablename"].Rows[1]["password"].ToString());
            dataGridView1.Rows[0 ].Cells[0].Value = ds.Tables["tablename"].Rows[0]["username"].ToString();
            dataGridView1.Rows[0].Cells[1].Value = ds.Tables["tablename"].Rows[0]["password"].ToString();
            dataGridView1.Rows[0].Cells[2].Value = ds.Tables["tablename"].Rows[0]["realname"].ToString();*/
        }       
    }
}
