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
    public partial class FormClassInfoInsert : CCSkinMain
    {
        static string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        public FormClassInfoInsert()
        {
            InitializeComponent();
        }

        private void TextBoxCname_TextChanged(object sender, EventArgs e)
        {
            //验证序号ID是否存在
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            if (textBoxCname.Text != "")
            {
                try
                {
                    conn.Open();
                    string strSql = " SELECT * FROM classInfo WHERE cname ='" + textBoxCname.Text+ "'; ";
                    cmd = new SqlCommand(strSql, conn);
                    reader = cmd.ExecuteReader();
                    if (textBoxCname.Text.Length == 4)
                    {
                        if (reader.HasRows)
                        {
                            labelHelp.ForeColor = Color.Red;
                            labelHelp.Text = "此班级编号已存在，请重新输入新的班级编号...";
                            buttonInsert.Enabled = false;
                            reader.Close();
                        }
                        else
                        {
                            labelHelp.ForeColor = Color.Green;
                            labelHelp.Text = "此班级编号不存在，可以进行添加操作。";
                            buttonInsert.Enabled = true;
                        }
                    }
                    else
                    {
                        labelHelp.ForeColor = Color.Red;
                        labelHelp.Text = "请输入4位字符长度的班级编号";
                        buttonInsert.Enabled = false;
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
                labelHelp.ForeColor = Color.Black;
                labelHelp.Text = "请优先输入序号ID";
                buttonInsert.Enabled = false;
            }
        }

        private void ButtonInsert_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                string strSql = " INSERT INTO classInfo VALUES('" + textBoxCname.Text + "'); ";
                cmd = new SqlCommand(strSql, conn);
                int flag = cmd.ExecuteNonQuery();
                if (flag > 0)
                {
                    MessageBox.Show("数据添加成功!!", "执行完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void FormClassInfoInsert_Load(object sender, EventArgs e)
        {

        }

        private void FormClassInfoInsert_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否关闭当前窗口？？\n警告:关闭后您当前输入的内容将会丢失", "确认关闭", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                this.FormClosing -= new FormClosingEventHandler(this.FormClassInfoInsert_FormClosing);
                e.Cancel = false;
            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
