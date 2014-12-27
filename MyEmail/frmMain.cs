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
                                mailMessage.Charset = "GB2312";
                                mailMessage.Encoding = "Base64";
                                mailMessage.ISOEncodeHeaders = false;
                                string priority = mailMessage.Priority.ToString();
                                dgvEmailInfo.Rows[i - 1].Cells[0].Value = mailMessage.From ;                               
                                dgvEmailInfo.Rows[i - 1].Cells[1].Value = mailMessage.Subject;
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
        
    }
}
