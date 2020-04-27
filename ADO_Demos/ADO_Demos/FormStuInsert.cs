using CCWin;
using StudentMSAdo;
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
    public partial class FormStuInsert : CCSkinMain
    {
        public FormStuInsert()
        {
            InitializeComponent();
        }

        private void FormInsert_Load(object sender, EventArgs e)
        {
            //初始化填充数据

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

        //检查输入数据是否合法
        public bool CheckInput()
        {
            if (textBoxSname.Text == "")
            {
                MessageBox.Show("请输入姓名", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (textBoxSage.Text == "")
            {
                MessageBox.Show("请输入年龄", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (textBoxSphone.Text == "")
            {
                MessageBox.Show("请输入电话号码", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (textBoxSaddress.Text == "")
            {
                MessageBox.Show("请输入地址", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (comboBoxSbanji.Text == "")
            {
                MessageBox.Show("请选择班级编号", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (textBoxPwd.Text == "")
            {
                MessageBox.Show("请输入学生登录密码", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (CheckInput() == true)
            {
                string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
                SqlConnection conn = null;
                SqlCommand cmd = null;
                int sex = 0;       //存储性别值
                try
                {
                    conn = new SqlConnection(connStr);
                    conn.Open();
                    //判断选中的性别radioButton进行性别变量赋值
                    if (radioButtonNan.Checked == true & radioButtonNv.Checked == false) { sex = 1; }   //男
                    else if (radioButtonNv.Checked == true & radioButtonNan.Checked == false) { sex = 0; }    //女
                    string strSql = "INSERT INTO student VALUES('" + textBoxSname.Text + "'," + sex + "," + Convert.ToInt32(textBoxSage.Text) + ",'" + dateTimePickerSbirthday.Text + "','" + textBoxSphone.Text + "','" + textBoxSaddress.Text + "','" + (this.comboBoxSbanji.SelectedIndex+1) + "','"+ textBoxPwd.Text + "'); ";
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

        //拼接方法
        public int AddStudentPinJie(Student s)
        {
            //判断选中的性别radioButton进行性别变量赋值
            int sex = 0;       //存储性别值
            if (radioButtonNan.Checked == true & radioButtonNv.Checked == false) { sex = 1; }   //男
            else if (radioButtonNv.Checked == true & radioButtonNan.Checked == false) { sex = 0; }    //女
            string strSql = "INSERT INTO student VALUES('" + textBoxSname.Text + "'," + sex + "," + Convert.ToInt32(textBoxSage.Text) + ",'" + dateTimePickerSbirthday.Text + "','" + textBoxSphone.Text + "','" + textBoxSaddress.Text + "','" + this.comboBoxSbanji.SelectedIndex + 1 + "'); ";
            return ADOTools.ExcuteNoQuerys(strSql);
        }

        //SqlParameter 方法
        public int AddStudentParams(Student s)
        {
            //判断选中的性别radioButton进行性别变量赋值
            int sex = 0;       //存储性别值
            if (radioButtonNan.Checked == true & radioButtonNv.Checked == false) { sex = 1; }   //男
            else if (radioButtonNv.Checked == true & radioButtonNan.Checked == false) { sex = 0; }    //女
            string strSql = "INSERT INTO student VALUES('" + textBoxSname.Text + "'," + sex + "," + Convert.ToInt32(textBoxSage.Text) + ",'" + dateTimePickerSbirthday.Text + "','" + textBoxSphone.Text + "','" + textBoxSaddress.Text + "','" + this.comboBoxSbanji.SelectedIndex + 1 + "'); ";
            SqlParameter[] sp =
            {
                new SqlParameter("@sname",SqlDbType.VarChar),
                new SqlParameter("@ssex",SqlDbType.Int),
                new SqlParameter("@sage",SqlDbType.Int),
                new SqlParameter("@sbirthday",SqlDbType.VarChar),
                new SqlParameter("@sphone",SqlDbType.VarChar),
                new SqlParameter("@saddress",SqlDbType.VarChar),
                new SqlParameter("@cid",SqlDbType.Int)
            };
            sp[0].Value = s.sname;
            sp[1].Value = sex;
            sp[2].Value = s.sage;
            sp[3].Value = s.sbirthday;
            sp[4].Value = s.sphone;
            sp[5].Value = s.saddress;
            sp[6].Value = s.scid;
            return ADOTools.ExcuteNoQuery(strSql,CommandType.Text,sp);
        }

        private void FormStuInsert_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否关闭当前窗口？？\n警告:关闭后您当前输入的内容将会丢失", "确认关闭", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                this.FormClosing -= new FormClosingEventHandler(this.FormStuInsert_FormClosing);
                e.Cancel = false;
            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
