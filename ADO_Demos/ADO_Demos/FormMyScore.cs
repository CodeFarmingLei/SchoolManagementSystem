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
    public partial class FormMyScore : CCSkinMain
    {
        static string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        //存储学生ID
        public int studentID = 0;

        public FormMyScore()
        {
            InitializeComponent();
        }

        private void FormMyScore_Load(object sender, EventArgs e)
        {
            GetRead();
        }

        private void GroupBoxMe_Enter(object sender, EventArgs e)
        {

        }

        //填充读取到的用户数据到各个控件
        public void GetRead()
        {
            SqlCommand cmdGet = null;
            SqlDataReader readerGet = null;
            try
            {
                conn.Open();
                string strSql = " SELECT S.sid,S.sname,S.ssex,S.sage,S.sbirthday,S.sphone,S.saddress,C.cname,S.spassword FROM student AS S LEFT JOIN classInfo AS C ON C.cid = S.scid WHERE sid=" + studentID;
                cmdGet = new SqlCommand(strSql, conn);
                readerGet = cmdGet.ExecuteReader();
                while (readerGet.Read())
                {
                    textBoxSname.Text = readerGet["sname"].ToString();
                    //判断性别数值并选中相应控件
                    if (Convert.ToInt32(readerGet["ssex"].ToString()) == 0)
                    {
                        textBoxSex.Text = "女";
                    }
                    else if (Convert.ToInt32(readerGet["ssex"].ToString()) == 1)
                    {
                        textBoxSex.Text = "男";
                    }
                    textBoxSage.Text = readerGet["sage"].ToString();
                    textBoxSbirthday.Text = readerGet["sbirthday"].ToString();
                    textBoxSphone.Text = readerGet["sphone"].ToString();
                    textBoxSaddress.Text = readerGet["saddress"].ToString();
                    textBoxSbanji.Text = readerGet["cname"].ToString();
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

        //读取成绩表数据填充到dataGridView控件
        DataTable SCMappingdt = new DataTable();  //成绩表
        public void SCMappingRead()
        {
            SCMappingdt.Clear();     //清空临时数据表格(避免多次点击后数据重复添加)
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataAdapter adapter = null;
            SqlDataReader reader = null;
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                string strSql = @" SELECT SC.scid,S.sname,C.cname,SC.score FROM SC_Mapping AS SC
                                            LEFT JOIN student AS S ON SC.sid = S.sid
                                            LEFT JOIN course AS C ON SC.cid = C.cid 
                                            WHERE SC.sid = "+ studentID + "";
                cmd = new SqlCommand(strSql, conn);
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(SCMappingdt);   //填充数据到临时数据表格
                this.dataGridViewSCMapping.DataSource = SCMappingdt;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("成绩数据读取完成!!", "执行成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("您还没有考试成绩...\n(或者您的数据没有统计到数据库)", "执行成功", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                reader.Close();
                adapter.Dispose();
                cmd.Dispose();
                conn.Dispose();
            }
        }

        private void GroupBoxFullScore_Enter(object sender, EventArgs e)
        {
            SCMappingRead();
        }

        private void FormMyScore_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
