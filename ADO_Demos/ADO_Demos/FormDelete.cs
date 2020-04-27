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
    public partial class FormDelete : CCSkinMain
    {
        //标识符：判断当前登录用户所属类别，从而从相应的表中删除数据
        //1.学生，2.教师，3.课程，4.班级，5.成绩
        public int Delflag = 1;

        //存储主窗体传递的ID值
        public string id = null;

        public FormDelete()
        {
            InitializeComponent();
        }

        //初始化删除提示文本
        public void DelTipText()
        {
            if (Delflag == 1)
            {
                labelMessage.Text = "删除学生数据";
            }
            else if (Delflag == 2)
            {
                labelMessage.Text = "删除教师数据";
            }
            else if (Delflag == 3)
            {
                labelMessage.Text = "删除课程数据";
            }
            else if (Delflag == 4)
            {
                labelMessage.Text = "删除班级数据";
            }
            else if (Delflag == 5)
            {
                labelMessage.Text = "删除成绩数据";
            }
        }

        //执行删除功能
        private void buttonDel_Click(object sender, EventArgs e)
        {
            //读取配置文件信息
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            //SqlDataReader reader = cmd.ExecuteReader(); 
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                string strSql = null;
                //判断用户选择的登录身份，选择相应的数据查询SQL
                if (Delflag == 1)   //学生表
                {
                    strSql = "DELETE FROM student WHERE sid=" + Convert.ToInt32(textBoxID.Text);
                }
                else if (Delflag == 2)  //教师表
                {
                    strSql = "DELETE FROM teacher WHERE tid=" + Convert.ToInt32(textBoxID.Text);
                }
                else if (Delflag == 3)  //课程表
                {
                    strSql = "DELETE FROM course WHERE cid=" + Convert.ToInt32(textBoxID.Text);
                }
                else if (Delflag == 4)  //班级表
                {
                    strSql = "DELETE FROM classInfo WHERE cid=" + Convert.ToInt32(textBoxID.Text);
                }
                else if (Delflag == 5)  //成绩表
                {
                    strSql = "DELETE FROM SC_Mapping WHERE scid=" + Convert.ToInt32(textBoxID.Text);
                }
                cmd = new SqlCommand(strSql, conn);
                int flag = cmd.ExecuteNonQuery();
                if (flag > 0)
                {
                    labelMessage.ForeColor = Color.Green;
                    labelMessage.Text = "数据删除成功!!";
                }
                else
                {
                    labelMessage.ForeColor = Color.Red;
                    labelMessage.Text = "删除失败!! 包含该ID的数据不存在，请重新输入...";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }

        }

        private void FormDelete_Load(object sender, EventArgs e)
        {
            if (id != null)
            {
                textBoxID.Text = id;
            }

            DelTipText();
        }

        private void FormDelete_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否关闭当前窗口？？\n警告:关闭后您当前输入的内容将会丢失", "确认关闭", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                this.FormClosing -= new FormClosingEventHandler(this.FormDelete_FormClosing);
                e.Cancel = false;
            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
