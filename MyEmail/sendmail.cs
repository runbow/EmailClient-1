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

namespace MyEmail
{
    public partial class sendmail : Form
    {
        public sendmail()
        {
            InitializeComponent();
            txtSend.Text = login.User;
            txtServer.Text = login.Smtp;
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
            }
            catch 
            {
                MessageBox .Show ("发送失败！");
            }
        }
        private void SendEmail(MailMessage message)
        {
            message .Subject = txtSubject .Text ;
            message .Body = txtContent .Text ;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Priority = System.Net.Mail.MailPriority.High;
            message.IsBodyHtml = false; 
            if(txtAttachment .Text !="")
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
                if (txtAttachment .Text =="")
                {
                    txtAttachment .Text =openFileDialog .FileName ;
                }
                else 
                {
                    txtAttachment .Text +=";"+openFileDialog .FileName ;
                }
            }
        }
        private void AddFile(string strFile,MailMessage message)
        {
            Attachment myAttachment=new Attachment (strFile ,System.Net.Mime .MediaTypeNames .Application .Octet );
            System .Net .Mime .ContentDisposition disposition=myAttachment .ContentDisposition ;
            disposition .CreationDate =System .IO .File .GetCreationTime (strFile );
            disposition .ModificationDate =System .IO.File.GetLastWriteTime (strFile );
            disposition .ReadDate =System .IO .File .GetLastAccessTime (strFile );
            message.Attachments .Add (myAttachment );
        }       
    }
}