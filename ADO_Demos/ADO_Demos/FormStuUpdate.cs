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
    public partial class FormStuUpdate : CCSkinMain
    {
        //存储id值
        public string id = null;

        static string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        public FormStuUpdate()
        {
            InitializeComponent();
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            //验证序号ID是否存在
            conn.Open();
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            if (textBoxID.Text != "")
            {
                try
                {
                    string strSql = " SELECT S.sid,S.sname,S.ssex,S.sage,S.sbirthday,S.sphone,S.saddress,C.cname,S.spassword FROM student AS S LEFT JOIN classInfo AS C ON C.cid = S.scid WHERE sid=" + Convert.ToInt32(textBoxID.Text);
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
                string strSql = " SELECT S.sid,S.sname,S.ssex,S.sage,S.sbirthday,S.sphone,S.saddress,C.cname,S.spassword FROM student AS S LEFT JOIN classInfo AS C ON C.cid = S.scid WHERE sid=" + Convert.ToInt32(textBoxID.Text);
                cmdGet = new SqlCommand(strSql, conn);
                readerGet = cmdGet.ExecuteReader();
                while (readerGet.Read())
                {
                    textBoxSname.Text = readerGet["sname"].ToString();
                    //判断性别数值并选中相应控件
                    if (Convert.ToInt32(readerGet["ssex"].ToString()) == 0)
                    {
                        radioButtonNan.Checked = false;
                        radioButtonNv.Checked = true;
                    }
                    else if (Convert.ToInt32(readerGet["ssex"].ToString()) == 1)
                    {
                        radioButtonNan.Checked = true;
                        radioButtonNv.Checked = false;
                    }
                    textBoxSage.Text = readerGet["sage"].ToString();
                    dateTimePickerSbirthday.Text = readerGet["sbirthday"].ToString();
                    textBoxSphone.Text = readerGet["sphone"].ToString();
                    textBoxSaddress.Text = readerGet["saddress"].ToString();
                    comboBoxSbanji.Text = readerGet["cname"].ToString();
                    textBoxPwd.Text = readerGet["spassword"].ToString();
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

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            //进行数据更新操作
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                //判断选中的性别radioButton进行性别变量赋值
                int sex = 0;        //存储性别值
                if (radioButtonNan.Checked == true & radioButtonNv.Checked == false) { sex = 1; }   //男
                else if (radioButtonNv.Checked == true & radioButtonNan.Checked == false) { sex = 0; }    //女
                string strSql = " UPDATE student set sname='" + textBoxSname.Text + "',ssex=" + sex + ",sage=" + textBoxSage.Text + ",sbirthday='" + dateTimePickerSbirthday.Text + "',sphone='" + textBoxSphone.Text + "',saddress='" + textBoxSaddress.Text + "',scid='" + (this.comboBoxSbanji.SelectedIndex+1) + "',spassword='"+textBoxPwd.Text+"' WHERE sid=" + Convert.ToInt32(textBoxID.Text);
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

        private void FormUpdate_Load(object sender, EventArgs e)
        {
            //初始化填充数据
            if (id != null)
            {
                textBoxID.Text = id;
            }

            //填充comboBox数据
            AddcomboBoxValues();
        }

        //填充comboBox控件数据
        public void AddcomboBoxValues()
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
    }
}
