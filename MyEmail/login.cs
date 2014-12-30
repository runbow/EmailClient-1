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

namespace MyEmail
{
    public partial class login : Form
    {
        public static string User;
        public static string Password;
        public static string Smtp;
        public static string Pop;
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private StreamReader streamReader;
        private StreamWriter streamWriter;
        public login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User = txtUser.Text;
            Password = txtPwd.Text;
           


            if ((txtUser.Text == "") | (txtUser.Text.IndexOf("@") == -1) | (txtUser.Text.IndexOf(".com") == -1))
            {
                errorProName.SetError(txtUser, "用户名为空或格式不正确！");
            }
            else if (txtPwd.Text == "")
            {
                errorProName.SetError(txtPwd, "密码不能为空！");
            }
            else
            {
                errorProName.Clear();
                string[] i = txtUser.Text.Split('@');
                string smtpsever = "smtp." + i[1];
                string popsever;                             
                popsever = "pop." + i[1];                             
                Smtp = smtpsever;
                Pop = popsever;



                // 与POP3服务器建立TCP连接
                // 建立连接后把服务器上的邮件下载到本地
                // 设置当前界面的光标为等待光标（就是我们看到的一个动的圆形）
                Cursor.Current = Cursors.WaitCursor;


                try
                {
                    // POP3服务器通过监听TCP110端口来提供POP3服务的
                    // 向POP3服务器发出tcp请求
                    tcpClient = new TcpClient(popsever , 110);

                }
                catch
                {
                    MessageBox.Show("连接失败", "错误", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    return;
                }

                // 连接成功的情况
                networkStream = tcpClient.GetStream();
                streamReader = new StreamReader(networkStream, Encoding.Default);
                streamWriter = new StreamWriter(networkStream, Encoding.Default);
                streamWriter.AutoFlush = true;
                string str;
                // 读取服务器返回的响应连接信息
                str = GetResponse();
                if (CheckResponse(str) == false)
                {

                    return;
                }
                // 如果服务器接收请求
                // 向服务器发送凭证——用户名和密码

                // 向服务器发送用户名，请求确认

                SendToServer("USER " + txtUser.Text);
                str = GetResponse();
                if (CheckResponse(str) == false)
                {
                    MessageBox.Show("用户名错误.");
                    return;
                }

                // 用户名审核通过后再发送密码等待确认
                // 向服务器发送密码，请求确认
                SendToServer("PASS " + txtPwd.Text);
                str = GetResponse();
                if (CheckResponse(str) == false)
                {
                    MessageBox.Show("密码错误.");
                    return;
                }
                //sendmail Sendmail = new sendmail();
                frmMain frm = new frmMain();
                this.Hide();
                frm.Show();
                //Sendmail .Show();

            }
        }
        private string GetResponse()
        {
            string str = null;
            try
            {
                str = streamReader.ReadLine();
                if (str == null)
                {
                    
                }
                else
                {
                  
                    if (str.StartsWith("-ERR"))
                    {
                        str = null;
                    }
                }
            }
            catch //(Exception err)
            {
                
            }

            return str;
            }

        // 检查响应信息
        private bool CheckResponse(string responseString)
        {
            if (responseString == null)
            {
                return false;
            }
            else
            {
                if (responseString.StartsWith("+OK"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // 向服务器发送命令
        private bool SendToServer(string str)
        {
            try
            {
                // 这里必须使用WriteLine方法的，因为POP3协议中定义的命令是以回车换行结束的
                // 如果客户端发送的命令没有以回车换行结束，POP3服务器就不能识别，也就不能响应客户端的请求了
                // 如果想用Write方法，则str输入的参数字符中必须包含“\r\n”,也就是回车换行字符串。
                streamWriter.WriteLine(str);
                streamWriter.Flush();
                
                return true;
            }
            catch 
            {
                
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}

