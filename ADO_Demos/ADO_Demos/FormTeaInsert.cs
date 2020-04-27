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
    public partial class FormTeaInsert : CCSkinMain
    {
        public FormTeaInsert()
        {
            InitializeComponent();
        }

        private void FormTeaInsert_Load(object sender, EventArgs e)
        {
            comboBoxAdpter();
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

        private void ButtonInsert_Click(object sender, EventArgs e)
        {
            if (CheckInput()==true)
            {
                string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                try
                {
                    conn = new SqlConnection(connStr);
                    conn.Open();
                    string strSql = "INSERT INTO teacher VALUES('" + (this.comboBoxSbanji.SelectedIndex + 1) + "'," + textBoxTname.Text + "," + (this.comboBoxTprofession.SelectedIndex + 1) + ",'" + textBoxTpwd.Text + "'); ";
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
        }

        //输入内容验证
        public bool CheckInput()
        {
            if (comboBoxSbanji.Text == "")
            {
                MessageBox.Show("请选择班级","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            else if (textBoxTname.Text == "")
            {
                MessageBox.Show("请输入教师姓名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (comboBoxTprofession.Text == "")
            {
                MessageBox.Show("请选择课程专业", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (textBoxTpwd.Text == "")
            {
                MessageBox.Show("请输入教师登录密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void FormTeaInsert_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否关闭当前窗口？？\n警告:关闭后您当前输入的内容将会丢失", "确认关闭", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                this.FormClosing -= new FormClosingEventHandler(this.FormTeaInsert_FormClosing);
                e.Cancel = false;
            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
