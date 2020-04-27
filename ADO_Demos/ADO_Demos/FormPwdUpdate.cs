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
    public partial class FormPwdUpdate : CCSkinMain
    {
        //保存传递的ID信息
        public int id = 0;
        //获取主窗体用户选择的登录用户身份(0:开发者，1:学生，2:教师，3:管理员)
        public int userflag = 0;

        static string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        public FormPwdUpdate()
        {
            InitializeComponent();
        }

        private void ButtonUpdateOK_Click(object sender, EventArgs e)
        {
            if (CheckInput() == true)
            {
                string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    conn = new SqlConnection(connStr);
                    conn.Open();
                    string strSql = "";
                    if (userflag == 1)
                    {
                        strSql = " UPDATE student set spassword='" + textBoxNewPwd2.Text + "' WHERE sid=" + id;
                    }
                    else if (userflag == 2)
                    {
                        strSql = " UPDATE teacher set tpassword='" + textBoxNewPwd2.Text + "' WHERE tid=" + id;
                    }
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
        }

        //输入验证方法
        public bool CheckInput()
        {
            if (textBoxThisPwd.Text == "")
            {
                MessageBox.Show("输入原始密码框不能为空", "输入提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            else if (textBoxNewPwd1.Text == "")
            {
                MessageBox.Show("输入新密码框不能为空", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (textBoxNewPwd2.Text == "")
            {
                MessageBox.Show("输入确认新密码框不能为空", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (textBoxNewPwd2.Text != textBoxNewPwd1.Text)
            {
                MessageBox.Show("两次输入的新密码不一致!! 请重新输入", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void FormStuPwdUpdate_Load(object sender, EventArgs e)
        {
            //填充ID信息到下方文本
            labelThisIdTip.Text += id.ToString();
        }

        private void TextBoxThisPwd_TextChanged(object sender, EventArgs e)
        {
            //验证序号ID是否存在
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            if (textBoxThisPwd.Text != "")
            {
                try
                {
                    conn.Open();
                    string strSql = null;
                    if (userflag == 1)
                    {
                        strSql = " SELECT sid,spassword FROM student WHERE sid=" + id + " AND spassword='" + Convert.ToInt32(textBoxThisPwd.Text) + "'";
                    }
                    else if (userflag == 2)
                    {
                        strSql = " SELECT sid,spassword FROM teacher WHERE tid=" + id + " AND tpassword='" + Convert.ToInt32(textBoxThisPwd.Text) + "'";
                    }
                    cmd = new SqlCommand(strSql, conn);
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        labelidTip.ForeColor = Color.Green;
                        labelidTip.Text = "密码输入正确，请继续完成下面的操作。";
                        textBoxNewPwd1.Enabled = true;
                        textBoxNewPwd2.Enabled = true;
                        buttonUpdateOK.Enabled = true;
                    }
                    else
                    {
                        labelidTip.ForeColor = Color.Red;
                        labelidTip.Text = "密码输入错误，请重新输入...";
                        textBoxNewPwd1.Enabled = false;
                        textBoxNewPwd2.Enabled = false;
                        buttonUpdateOK.Enabled = false;
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
        }

        private void FormPwdUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否关闭当前窗口？？\n警告:关闭后您当前输入的内容将会丢失", "确认关闭", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                this.FormClosing -= new FormClosingEventHandler(this.FormPwdUpdate_FormClosing);
                e.Cancel = false;
            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
