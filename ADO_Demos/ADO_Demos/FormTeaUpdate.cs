using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_Demos
{
    public partial class FormTeaUpdate : CCSkinMain
    {
        //存储id值
        public string id = null;

        static string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        public FormTeaUpdate()
        {
            InitializeComponent();
        }

        private void TextBoxID_TextChanged(object sender, EventArgs e)
        {
            //验证序号ID是否存在
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            if (textBoxID.Text != "")
            {
                try
                {
                    conn.Open();
                    string strSql = " SELECT C.cname,T.tname,T.tProfession,T.tpassword FROM teacher AS T LEFT JOIN classInfo AS C ON T.tcid = C.cid WHERE tid =" + Convert.ToInt32(textBoxID.Text);
                    cmd = new SqlCommand(strSql, conn);
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        labelidTip.ForeColor = Color.Green;
                        labelidTip.Text = "包含该ID的用户存在，请继续完成下面的操作。";
                        labelLock.Visible = false;
                        reader.Close();
                        //填充读取到的用户数据到各个控件
                        GetRead();
                    }
                    else
                    {
                        labelidTip.ForeColor = Color.Red;
                        labelidTip.Text = "包含该ID的用户不存在，请重新输入...";
                        labelLock.Visible = true;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    cmd.Dispose();
                    reader.Close();
                    conn.Close();
                }
            }
            else
            {
                labelidTip.ForeColor = Color.Black;
                labelidTip.Text = "请优先输入序号ID";
                labelLock.Visible = true;
            }
        }

        //填充读取到的用户数据到各个控件
        public void GetRead()
        {
            SqlCommand cmdGet = null;
            SqlDataReader readerGet = null;
            try
            {
                string strSql = " SELECT C.cname,T.tname,T.tProfession,T.tpassword FROM teacher AS T LEFT JOIN classInfo AS C ON T.tcid = C.cid WHERE tid =" + Convert.ToInt32(textBoxID.Text);
                cmdGet = new SqlCommand(strSql, conn);
                readerGet = cmdGet.ExecuteReader();
                while (readerGet.Read())
                {
                    comboBoxSbanji.Text = readerGet["cname"].ToString();
                    textBoxTname.Text = readerGet["tname"].ToString();
                    if (readerGet["tProfession"].ToString()=="1")
                    {
                        comboBoxTprofession.Text = "体育";
                    }
                    else if (readerGet["tProfession"].ToString() == "2")
                    {
                        comboBoxTprofession.Text = "计算机";
                    }
                    else if (readerGet["tProfession"].ToString() == "3")
                    {
                        comboBoxTprofession.Text = "数学";
                    }
                    else if (readerGet["tProfession"].ToString() == "4")
                    {
                        comboBoxTprofession.Text = "化学";
                    }
                    textBoxTpwd.Text = readerGet["tpassword"].ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                readerGet.Close();
                cmdGet.Dispose();
            }

        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            //进行数据更新操作
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                string strSql = " UPDATE teacher set tcid='" + (this.comboBoxSbanji.SelectedIndex + 1) + "',tname=" + textBoxTname.Text + ",tProfession=" + (this.comboBoxTprofession.SelectedIndex + 1) + ",tpassword='" + textBoxTpwd.Text + "' WHERE tid=" + Convert.ToInt32(textBoxID.Text);
                cmd = new SqlCommand(strSql, conn);
                int flag = cmd.ExecuteNonQuery();
                if (flag > 0)
                {
                    MessageBox.Show("数据更新成功!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cmd.Dispose();
                conn.Dispose();
            }
        }

        //初始化填充下拉框数据
        public void comboBoxAdpter()
        {
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string strSql = "SELECT * FROM classInfo";
            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxSbanji.Items.Add(reader["cname"].ToString());
            }
        }

        private void FormTeaUpdate_Load(object sender, EventArgs e)
        {
            if (id != null)
            {
                textBoxID.Text = id;
            }

            comboBoxAdpter();
        }

        private void FormTeaUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否关闭当前窗口？？\n警告:关闭后您当前输入的内容将会丢失", "确认关闭", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                this.FormClosing -= new FormClosingEventHandler(this.FormTeaUpdate_FormClosing);
                e.Cancel = false;
            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
