using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb ;
namespace MyEmail
{
    public partial class addressbook : Form
    {
        public addressbook()
        {
            InitializeComponent();
        }
        string strCon;
        OleDbConnection  sqlCon;
        private void DBConnect()
        {
            strCon = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source = MyEmail.mdb";
            sqlCon = new OleDbConnection(strCon);
        }
        private void CommonDataView()
        {
            try
            {
                DBConnect();
                OleDbDataAdapter da = new OleDbDataAdapter("select 邮箱,电话,姓名 from addresslist where 用户='" + login.User + "'", sqlCon);
                DataSet ds = new DataSet();
                da.Fill(ds, "tablename");
                dataGridView1.DataSource = ds.Tables[0];
                OleDbDataAdapter da2 = new OleDbDataAdapter("select distinct 邮箱 from addresslist where 用户='" + login.User + "'", sqlCon);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2, "tablename2");
                cbUsername.DisplayMember = "邮箱";
                cbUsername.ValueMember = "邮箱";               
                cbUsername.DataSource = ds2.Tables[0].DefaultView;
            }
            catch (SystemException ex)
            {
                MessageBox.Show("错误:" + ex.Message, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }
        }
        private void addressbook_Load(object sender, EventArgs e)
        {
            CommonDataView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnect();
                sqlCon.Open();
                OleDbCommand cmd = new OleDbCommand("insert into addresslist(邮箱,电话,姓名,用户) values('" + cbUsername.Text + "','" + tbPwd.Text + "','" + tbRealname.Text + "','" + login.User + "')", sqlCon);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                CommonDataView();
            }
            catch
            {
                MessageBox.Show("操作失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                                               
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnect();
                sqlCon.Open();
                OleDbCommand cmd = new OleDbCommand("delete from addresslist where 邮箱='" + cbUsername.Text + "'and 用户='" + login.User + "'", sqlCon);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                CommonDataView();
            }
            catch
            {
                MessageBox.Show("操作失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnect();
                sqlCon.Open();
                OleDbCommand cmd = new OleDbCommand("update addresslist set 电话='" + tbPwd.Text + "',姓名='" + tbRealname.Text + "'where 邮箱='" + cbUsername.Text + "'and 用户='" + login.User + "'", sqlCon);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                CommonDataView();
            }
            catch
            {
                MessageBox.Show("操作失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                                           
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnect();
                sqlCon.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("select 邮箱,电话,姓名 from addresslist where 邮箱 like '%" + cbUsername.Text + "%'and 用户='" + login.User + "'", sqlCon);
                DataSet ds = new DataSet();
                da.Fill(ds, "tablename");
                dataGridView1.DataSource = ds.Tables[0];
                sqlCon.Close();
            }
            catch
            {
                MessageBox.Show("操作失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                sendmail sendab = new sendmail();
                sendab.txtTo.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                sendab.Show();
            }
            catch
            {
                MessageBox.Show("操作失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbPwd.Text = "";
            tbRealname.Text = "";
        }

    }
}
