﻿using System;
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
        public static string smtpserver;
        public static string user;
        public static string pwd;
        public static string strFrom;
        public static string strSubject;
        public static string strBody;
        public static string strDate;
        public static string strAttachment;
        public static string[] htmlbody;
        public static string strhtmlbody;
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
            //smtpserver = "smtp.qq.com";
            strsever = login.Pop; //"pop.qq.com";//
            user = login.User; //"dupeng1160058696@qq.com";//
            pwd = login.Password; //"hust2012--DP";//
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
                                transCode1(ref MailSubject,  mailMessage);
                                mailMessage.Charset = "GB2312";
                                mailMessage.Encoding = "Base64";
                                mailMessage.ISOEncodeHeaders = false;
                                string priority = mailMessage.Priority.ToString();
                                dgvEmailInfo.Rows[i - 1].Cells[0].Value = mailMessage.From;                               
                                dgvEmailInfo.Rows[i - 1].Cells[1].Value = MailSubject ;
                                //dgvEmailInfo.Rows[i - 1].Cells[2].Value = mailMessage.Body;
                                //htmlbody[i-1] = mailMessage.HTMLBody;
                                dgvEmailInfo.Rows[i - 1].Cells[3].Value = mailMessage.Date;
                                if ((popMail.Count >= 1) && (i <= popMail.Count))
                                {
                                    atts = mailMessage.Attachments;
                                    if (atts.Count > 0)
                                    {
                                        dgvEmailInfo.Rows[i - 1].Cells[2].Value = "附件下载";
                                    }
                                    else
                                    {
                                        dgvEmailInfo.Rows[i - 1].Cells[2].Value = "无附件";
                                    }

                                }
                                dgvEmailInfo.Rows[0].Selected = false;
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
        
        

        private void dgvEmailInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)//双击相应单元格得到详细邮件信息
        {
            //string[] MailAtts=new string[]{};
            strFrom = strSubject = strDate = strAttachment = string.Empty;
            strFrom = dgvEmailInfo.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (dgvEmailInfo.Rows[e.RowIndex].Cells[1].Value == null)
            {
                strSubject = null;
            }
            else
            {
                strSubject = dgvEmailInfo.Rows[e.RowIndex].Cells[1].Value.ToString();
            }

           /* if (dgvEmailInfo.Rows[e.RowIndex].Cells[2].Value == null)
            {
                strBody = null;
            }
            else
            {
                strBody = dgvEmailInfo.Rows[e.RowIndex].Cells[2].Value.ToString();
            }*/
            //strhtmlbody = htmlbody[e.RowIndex];
            strDate = dgvEmailInfo.Rows[e.RowIndex].Cells[3].Value.ToString();
            mailMessage = popMail.Messages[e.RowIndex + 1];
            atts = mailMessage.Attachments;
            //transCode2(ref MailAtts, mailMessage);
            for (int k = 0; k < atts.Count; k++)
            {
                att = atts[k];
                if (strAttachment == string.Empty)
                {
                    strAttachment =att.Name;
                }
                else
                {
                    strAttachment += ";" +att.Name;
                }
            }
            frmEmailInfo frmemailinfo = new frmEmailInfo();
            frmemailinfo.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)//发送邮件
        {
            sendmail send = new sendmail();
            send.Show();            
        }

        private void dgvEmailInfo_CellClick(object sender, DataGridViewCellEventArgs e)//下载附件
        {
            try
            {
                if (e.ColumnIndex ==2)
                {
                    mailMessage = popMail.Messages[e.RowIndex + 1];
                    atts = mailMessage.Attachments;
                    if (atts.Count != 0)
                    {
                        for (int k = 0; k < atts.Count; k++)
                        {
                            att = atts[k];
                            string attname = att.Name;
                            saveFileDialog.FileName = attname;
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
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
        private void dgvEmailInfo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)//得到当前鼠标双击选中的索引
        {
            index = e.RowIndex;
        }

        private void refresh_Click(object sender, EventArgs e)//刷新邮箱，重新接收邮件
        {
            frmMain_Load(sender, e);
        }

        private void logoff(object sender, EventArgs e)//注销账户，回到登陆界面
        {
            if (MessageBox.Show("确定退出该账户吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                popMail.Disconnect();
                this.Hide();
                login Login = new login();
                Login.Show();
            }                                       
        }

        private void deleteEmail_Click(object sender, EventArgs e)//删除邮件
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

        private void timer_Tick(object sender, EventArgs e)//添加显示当前时间工具
        {
            currentTime.Text=DateTime.Now.ToString("HH:mm:ss");          
        }

        private void transCode1(ref string MailSubject,jmail.Message mailmessage)//对邮件主题的解码
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


        private void transCode2(ref string[] MailAtts, jmail.Message mailmessage)
        {
            byte[] b;
            string transcode;
            jmail.Attachments attachments;
            jmail.Attachment attachment;
            attachments=mailmessage .Attachments;
            for(int i=0;i<attachments .Count ;i++)
            {   
                try
                {       
                    attachment =attachments [i];
                if (mailmessage.Text.IndexOf("name:=?UTF-8?B?") != -1 ||
                    mailmessage.Text.IndexOf("name: =?UTF-8?B?") != -1 ||
                     mailmessage.Text.IndexOf("name: =?utf-8?B?") != -1
                    )//解析邮件主题
                  {
                    if (attachment.Name .IndexOf("=?UTF-8?B?") != -1
                        )
                    {

                        transcode = attachment.Name .Substring(attachment.Name.IndexOf("=?UTF-8?B?") + 10);
                        transcode = transcode.Substring(0, transcode.IndexOf("?="));//修改
                        b = Convert.FromBase64String(transcode);
                        transcode = Encoding.GetEncoding("utf-8").GetString(b);
                        MailAtts[i] = transcode;
                    }
                    else if (attachment.Name.IndexOf("=?utf-8?B?") != -1)
                    {
                        transcode = attachment.Name.Substring(attachment.Name.IndexOf("=?utf-8?B?") + 10);
                        transcode = transcode.Substring(0, transcode.Length - 2);
                        b = Convert.FromBase64String(transcode);
                        transcode = Encoding.GetEncoding("utf-8").GetString(b);
                        MailAtts[i] = transcode;
                    }
                    else
                    {
                        b = System.Text.Encoding.Default.GetBytes(attachment.Name);
                        transcode = Encoding.GetEncoding("utf-8").GetString(b);
                        MailAtts[i] = transcode;
                    }
                }
                else
                {
                    MailAtts [i] = attachment.Name;
                }
            }
            catch
            {
                MessageBox.Show("编码格式有问题");
            }
            }
            
        }

        private void search_Click(object sender, EventArgs e)//解决输入为空仍可查询的问题？？？？？？？？？
        {
            int row = dgvEmailInfo.Rows.Count;//得到总行数 
            int cell = dgvEmailInfo.Rows[0].Cells.Count;//得到总列数
            int i, j;
            for (i = 0; i < row; i++)
            {
                dgvEmailInfo.Rows[i].Selected = false;
            }
            if (searchmail.Text !="")
            {
                for (i = 0; i < row; i++)//得到总行数并在之内循环 
                {
                    if (popMail.Messages[i + 1].Body != null)
                    {
                        if (popMail.Messages[i + 1].Body.IndexOf(searchmail.Text) != -1)
                        {
                            dgvEmailInfo.Rows[i].Selected = true;
                        }
                    }
                    for (j = 0; j < cell; j++)//得到总列数并在之内循环 
                    {
                        //精确查找定位
                        if (dgvEmailInfo.Rows[i].Cells[j].Value != null)
                        {
                            if (dgvEmailInfo.Rows[i].Cells[j].Value.ToString().IndexOf(searchmail.Text) != -1)
                            {
                                //对比TexBox中的值是否与dataGridView中的值相同（上面这句） 
                                //dgvEmailInfo.CurrentCell = dgvEmailInfo[j,i];//定位到相同的单元格 
                                dgvEmailInfo.Rows[i].Selected = true;//定位到行 
                                break;
                            }
                        }

                    }
                }
            }
           else
            {
                for (i = 0; i < row; i++)
                {
                    dgvEmailInfo.Rows[i].Selected = false;
                }
            }
        }
        public static bool bl;
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*DialogResult dr = MessageBox.Show("是否退出该应用？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)        //如果单击“是”按钮
            {

                Application .Exit() ;                 //关闭窗体

            }
            else                                           //如果单击“否”按钮
            {

                e.Cancel = true;                  //不执行操作

            }*/
            if (bl == false)
            {
                if (MessageBox.Show("确定退出应用吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    bl = true;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                Application.Exit();
            }
            
        }
    }
}
