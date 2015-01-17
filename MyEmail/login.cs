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
using System.Data.OleDb;
namespace MyEmail
{
    public partial class login : Form
    {
        public static string User;//定义全局变量User作为用户名，记录当前用户
        public static string Password;//定义全局变量Password作为用户密码，记录当前用户密码
        public static string Smtp;//定义全局变量Smtp用于记录当前用户发送邮件使用的SMTP服务器
        public static string Pop;//定义全局变量Pop用于记录当前用户接收邮件使用的Pop服务器
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private StreamReader streamReader;
        private StreamWriter streamWriter;//以上是登陆过程中与Pop服务器的连接及数据流读写的定义

        string strCon;
        OleDbConnection sqlCon;
        private void DBConnect()
        {
            strCon = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source = MyEmail.mdb";
            sqlCon = new OleDbConnection(strCon);
        }
        public login()
        {
            InitializeComponent();
            try
            {
                DBConnect();
                OleDbDataAdapter da = new OleDbDataAdapter("select 用户名 from users", sqlCon);
                DataSet ds=new DataSet ();
                da.Fill (ds,"tablename");
                Username.DisplayMember = "用户名";
                Username.ValueMember = "用户名";
                Username.DataSource = ds.Tables[0].DefaultView;
                
            }
            catch
            {
 
            }
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            User = Username.Text;
            Password = txtPwd.Text;
            if ((Username.Text == "") | (Username.Text.IndexOf("@") == -1) | (Username.Text.IndexOf(".com") == -1))//当用户名为空或不含@及.com字段时提示用户名格式有误
            {
                errorProName.SetError(Username, "用户名为空或格式不正确！");
            }
            else if (txtPwd.Text == "")
            {
                errorProName.SetError(txtPwd, "密码不能为空！");
            }
            else
            {
                errorProName.Clear();
                string[] i = Username.Text.Split('@');
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

                SendToServer("USER " + Username.Text);
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
                string pass;
                if (checkBox1.Checked == true)
                {
                    pass = txtPwd.Text;//当选中记住密码时记录密码
                }
                else
                {
                    pass = "";//当没选中记住密码时记住一个空值
                }             
                try
                {
                    DBConnect();
                    sqlCon.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("select 用户名 from users where 用户名='" + Username.Text + "'", sqlCon);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tablename");
                    if (ds.Tables["tablename"].Rows.Count == 0)
                    {
                        OleDbCommand cmd = new OleDbCommand("insert into users(用户名,密码) values('" + Username.Text + "','" + pass + "')", sqlCon);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        OleDbCommand cmd = new OleDbCommand("update users set 密码='" + pass + "' where 用户名='" + Username.Text + "'", sqlCon);
                        cmd.ExecuteNonQuery();
                    }
                    sqlCon.Close();
                }
                catch
                {
 
                }
            }
        }
        private string GetResponse()
        {
            string str = null;
            try
            {
                str = streamReader.ReadLine();//读取数据流信息
                if (str == null)
                {
                    
                }
                else
                {
                  
                    if (str.StartsWith("-ERR"))
                    {
                        str = null;//如果收到的响应为"-ERR"则令str=null
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
                if (responseString.StartsWith("+OK"))//检查到响应含有"+OK"返回true
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

        private void Username_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter da2 = new OleDbDataAdapter("select * from users where 用户名='" + Username.Text + "'", sqlCon);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "tablename1");
            txtPwd.Text = ds2.Tables["tablename1"].Rows[0]["密码"].ToString();
            if (txtPwd.Text != "")
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
        }
    }
}

