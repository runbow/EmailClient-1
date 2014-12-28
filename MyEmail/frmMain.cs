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
using System.Net.Mime;
using System.Net.Sockets;
using System.IO;
using jmail;

namespace MyEmail
{
    public partial class frmMain : Form
    {
        public static string Base64Decode(string str)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(str));
        }
        public static jmail.POP3Class popMail;
        public static jmail.Message mailMessage;
        public static jmail.Attachments atts;
        public static jmail.Attachment att;
        public static string strsever;
        public static string user;
        public static string pwd;
        public static string strFrom;
        public static string strSubject;
        public static string strBody;
        public static string strDate;
        public static string strAttachment;
        public frmMain()
        {
            InitializeComponent();
            
        }
        
       

        private void frmMain_Load(object sender, EventArgs e)
        {
            string MailSubject="";
            for (int i = 0; i < dgvEmailInfo.Columns.Count; i++)
            {
                dgvEmailInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            strsever ="pop.163.com";//login.Pop;
            user ="dupeng1160058696@163.com";//login.User ;
            pwd ="HbMcSb2065141DP";//login .Password ;
            popMail = new jmail.POP3Class();
            try
            {
                popMail.Connect(user, pwd, strsever, 110);
                TLabUser.Text = user;
                TLabNum.Text = popMail.Count + "封";
                if (popMail.Count != 0)
                {
                    dgvEmailInfo.RowCount = popMail.Count;
                                      
                    if (popMail != null)
                    {
                        if (popMail.Count > 0)
                        {
                            for (int i = 1; i < popMail.Count+1; i++)
                            {
                                mailMessage = popMail.Messages[i];
                                transCode(ref MailSubject,  mailMessage);
                                mailMessage.Charset = "GB2312";
                                mailMessage.Encoding = "Base64";
                                mailMessage.ISOEncodeHeaders = false;
                                string priority = mailMessage.Priority.ToString();
                                dgvEmailInfo.Rows[i - 1].Cells[0].Value = mailMessage.From;                               
                                dgvEmailInfo.Rows[i - 1].Cells[1].Value = MailSubject ;
                                dgvEmailInfo.Rows[i - 1].Cells[2].Value = mailMessage.Body;
                                dgvEmailInfo.Rows[i - 1].Cells[4].Value = mailMessage.Date;
                                if ((popMail.Count >= 1) && (i <= popMail.Count))
                                {
                                    atts = mailMessage.Attachments;
                                    if (atts.Count > 0)
                                    {
                                        dgvEmailInfo.Rows[i - 1].Cells[3].Value = "附件下载";
                                    }
                                    else
                                    {
                                        dgvEmailInfo.Rows[i - 1].Cells[3].Value = "无附件";
                                    }

                                }
                            }
                        }
                    }
                }
                else
                {
                    dgvEmailInfo.Rows.Clear();
                }
            }
            catch
            {
                MessageBox.Show("该用户邮箱不存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        

        private void dgvEmailInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            strFrom = strSubject = strBody = strDate = strAttachment = string.Empty;
            strFrom = dgvEmailInfo.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (dgvEmailInfo.Rows[e.RowIndex].Cells[1].Value == null)
            {
                strSubject = null;
            }
            else
            {
                strSubject = dgvEmailInfo.Rows[e.RowIndex].Cells[1].Value.ToString();
            }         
            strBody = dgvEmailInfo.Rows[e.RowIndex].Cells[2].Value.ToString ();
            strDate = dgvEmailInfo.Rows[e.RowIndex].Cells[4].Value.ToString();
            mailMessage = popMail.Messages[e.RowIndex + 1];
            atts = mailMessage.Attachments;
            for (int k = 0; k < atts.Count; k++)
            {
                att = atts[k];
                if (strAttachment == string.Empty)
                {
                    strAttachment =(att.Name);
                }
                else
                {
                    strAttachment += ";" + (att.Name);
                }
            }
            frmEmailInfo frmemailinfo = new frmEmailInfo();
            frmemailinfo.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            sendmail send = new sendmail();
            send.Show();
        }

        private void dgvEmailInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    mailMessage = popMail.Messages[e.RowIndex + 1];
                    atts = mailMessage.Attachments;
                    if (atts.Count != 0)
                    {
                        for (int k = 0; k < atts.Count; k++)
                        {
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                att = atts[k];
                                string attname = att.Name;
                                //Directory.CreateDirectory("AttachFiles\\" + user);
                                //string mailPath = "AttachFiles\\" + user + "\\" +att.Name;                               
                                string mailPath = saveFileDialog.FileName.ToString();
                                att.SaveToFile(mailPath);
                                MessageBox.Show("下载成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }                        
                    }
                }
            }
            catch
            {
                MessageBox.Show("下载失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
        public static int index;
        private void dgvEmailInfo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            index = e.RowIndex;
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            frmMain_Load(sender, e);
        }

        private void logoff(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出该账户吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                popMail.Disconnect();
                this.Hide();
                login Login = new login();
                Login.Show();
            }                                       
        }

        private void deleteEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定删除邮件吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    popMail.DeleteSingleMessage(index + 1);
                    popMail.Disconnect();
                    MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmMain_Load(sender, e);
                }                
            }
            catch
            {
                MessageBox.Show("删除失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            currentTime.Text=DateTime.Now.ToString("HH:mm:ss");          
        }

        private void transCode(ref string MailSubject,jmail.Message mailmessage)
        {
            byte[] b;
            string transcode;
            try
            {

                /*if (mailMessage.From == useraddr.Trim().ToLower())
                {
                    MailFrom = "我";
                }
                else
                {
                    if (mailMessage.Text.IndexOf("From: =?UTF-8?B?") != -1)
                    {
                        if (mailMessage.FromName.IndexOf("<") != -1)
                        {
                            // b = System.Text.Encoding.Default.GetBytes(mailMessage.FromName.Substring(0, mailMessage.FromName.IndexOf("<")-1));
                            // b = System.Text.Encoding.Default.GetBytes(mailMessage.FromName.Substring(mailMessage.FromName.IndexOf("<")+1 , mailMessage.FromName.Length - mailMessage.FromName.IndexOf("<")));
                            //transcode = Encoding.GetEncoding("utf-8").GetString(b);
                            transcode = mailMessage.FromName.Substring(mailMessage.FromName.IndexOf("<") + 1);
                            MailFrom = transcode;
                        }
                        else
                            MailFrom = mailMessage.From;
                    }
                    else
                        MailFrom = mailMessage.From;
                }*/
                if (mailMessage.Text.IndexOf("Subject:=?UTF-8?B?") != -1 ||
                    mailMessage.Text.IndexOf("Subject: =?UTF-8?B?") != -1 ||
                     mailMessage.Text.IndexOf("Subject: =?utf-8?B?") != -1
                    )//解析邮件主题
                {
                    if (mailMessage.Subject.IndexOf("=?UTF-8?B?") != -1
                        )
                    {

                        transcode = mailMessage.Subject.Substring(mailMessage.Subject.IndexOf("=?UTF-8?B?") + 10);
                        transcode = transcode.Substring(0, transcode.IndexOf("?="));//修改
                        b = Convert.FromBase64String(transcode);
                        transcode = Encoding.GetEncoding("utf-8").GetString(b);
                        MailSubject = transcode;
                    }
                    else if (mailMessage.Subject.IndexOf("=?utf-8?B?") != -1)
                    {
                        transcode = mailMessage.Subject.Substring(mailMessage.Subject.IndexOf("=?utf-8?B?") + 10);
                        transcode = transcode.Substring(0, transcode.Length - 2);
                        b = Convert.FromBase64String(transcode);
                        transcode = Encoding.GetEncoding("utf-8").GetString(b);
                        MailSubject = transcode;
                    }
                    else
                    {
                        b = System.Text.Encoding.Default.GetBytes(mailMessage.Subject);
                        transcode = Encoding.GetEncoding("utf-8").GetString(b);
                        MailSubject = transcode;
                    }
                }
                else
                {
                    MailSubject = mailMessage.Subject;
                }
            }
            catch
            {
                MessageBox.Show("编码格式有问题");
            }
        }
    }
}
