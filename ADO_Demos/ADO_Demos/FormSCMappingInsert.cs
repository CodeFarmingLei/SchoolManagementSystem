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
    public partial class FormSCMappingInsert : CCSkinMain
    {
        public FormSCMappingInsert()
        {
            InitializeComponent();
        }

        private void FormSCMappingInsert_Load(object sender, EventArgs e)
        {
            ComboBoxAdd();
        }

        //填充下拉框数据
        string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;
        string strSql = null;
        public void ComboBoxAdd()
        {
            conn = new SqlConnection(connStr);
            conn.Open();
            strSql = "SELECT * FROM Student";
            cmd = new SqlCommand(strSql, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxSid.Items.Add(reader["sid"].ToString());
            }
            reader.Close();
            cmd.Clone();
            //=======================================
            strSql = "SELECT * FROM course";
            cmd = new SqlCommand(strSql, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxCid.Items.Add(reader["cid"].ToString());
            }
        }

        //输入内容验证
        public bool CheckInput()
        {
            if (comboBoxSid.Text == "")
            {
                MessageBox.Show("请选择学生编号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (comboBoxCid.Text == "")
            {
                MessageBox.Show("请选择课程编号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (numericUpDownScore.Value < 100 || numericUpDownScore.Value > 0)
            {
                MessageBox.Show("分数不能大于100或者小于0", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ButtonInsert_Click(object sender, EventArgs e)
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
                    string strSql = "INSERT INTO SC_Mapping VALUES('" + (this.comboBoxSid.SelectedIndex + 1) + "'," + (this.comboBoxCid.SelectedIndex + 1) + "," + numericUpDownScore.Value + "'); ";
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

        private void FormSCMappingInsert_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否关闭当前窗口？？\n警告:关闭后您当前输入的内容将会丢失", "确认关闭", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                this.FormClosing -= new FormClosingEventHandler(this.FormSCMappingInsert_FormClosing);
                e.Cancel = false;
            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
