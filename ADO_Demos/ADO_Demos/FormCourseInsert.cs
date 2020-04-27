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
    public partial class FormCourseInsert : CCSkinMain
    {
        public FormCourseInsert()
        {
            InitializeComponent();
        }

        private void FormCourseInsert_Load(object sender, EventArgs e)
        {
            ComboBoxAdd();
        }

        //填充教师编号下拉框数据
        public void ComboBoxAdd()
        {
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string strSql = "SELECT * FROM teacher";
            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxCtid.Items.Add(reader["tid"].ToString()+"-"+ reader["tname"].ToString());
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
                string strSql = " INSERT INTO course VALUES('" + (this.comboBoxCtid.SelectedIndex + 1) + "','"+textBoxCname.Text+"',0); ";
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

        private void FormCourseInsert_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否关闭当前窗口？？\n警告:关闭后您当前输入的内容将会丢失", "确认关闭", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                this.FormClosing -= new FormClosingEventHandler(this.FormCourseInsert_FormClosing);
                e.Cancel = false;
            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
