using CCWin;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace ADO_Demos
{
    public partial class FormLogin : CCSkinMain
    {
        //读取配置文件信息
        static string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
        string banben = ConfigurationManager.AppSettings["banben"].ToString();

        //获取登录窗体用户选择的登录用户身份(0:开发者，1:学生，2:教师，3:管理员)
        public int flag = 0;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            //加载版本号信息赋值到标题文本
            this.Text += banben;
        }

        //语音播放事件
        public void spVoice()
        {
            Type type = Type.GetTypeFromProgID("SAPI.SpVoice");
            dynamic spVoice = Activator.CreateInstance(type);
            if (flag == 0)
            {
                spVoice.Speak("您已进入开发者模式");
            }
            else if (flag == 1)
            {
                spVoice.Speak("您已进入学生模式");
            }
            else if (flag == 2)
            {
                spVoice.Speak("您已进入教师模式");
            }
            else if (flag == 3)
            {
                spVoice.Speak("您已进入管理员模式");
            }
        }

        //执行登录操作
        public void loginRun()
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            string strSql = null;
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                //判断用户选择的登录身份，选择相应的数据查询SQL
                if (radioButtonStudent.Checked == true)
                {
                    strSql = " SELECT * FROM student WHERE sid='" + skinTextBoxUser.Text + "' AND spassword='" + textBoxPwd.Text + "'; ";
                }
                else if (radioButtonTeacher.Checked == true)
                {
                    strSql = " SELECT * FROM teacher WHERE tid='" + skinTextBoxUser.Text + "' AND tpassword='" + textBoxPwd.Text + "'; ";
                }
                else if (radioButtonAdmin.Checked == true)
                {
                    strSql = " SELECT * FROM system_users WHERE ucode='" + skinTextBoxUser.Text + "' AND upwd='" + textBoxPwd.Text + "'; ";
                }
                
                cmd = new SqlCommand(strSql, conn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    //判断用户选择的登录身份，显示该身份可用的主页面功能
                    if (radioButtonStudent.Checked == true)
                    {
                        this.Hide();    //隐藏当前窗体
                        FormMain FormAdminMain = new FormMain();
                        flag = 1;       //将权限设置为学生
                        FormAdminMain.flag = flag;     //将当前值传到主窗体
                        FormAdminMain.userid = Convert.ToInt32(skinTextBoxUser.Text);   //设置ID信息
                        FormAdminMain.Show();
                        //创建新线程播放语音，便于窗体加载与与语音播报同时进行
                        Thread thread = new Thread(spVoice);
                        thread.Start();
                    }
                    else if (radioButtonTeacher.Checked == true)
                    {
                        this.Hide();    //隐藏当前窗体
                        FormMain FormAdminMain = new FormMain();
                        flag = 2;       //将权限设置为教师
                        FormAdminMain.flag = flag;     //将当前值传到主窗体
                        FormAdminMain.userid = Convert.ToInt32(skinTextBoxUser.Text);   //设置ID信息
                        FormAdminMain.Show();
                        //创建新线程播放语音，便于窗体加载与与语音播报同时进行
                        Thread thread = new Thread(spVoice);
                        thread.Start();
                    }
                    else if (radioButtonAdmin.Checked == true)
                    {
                        //管理员身份显示全部功能
                        this.Hide();    //隐藏当前窗体
                        FormMain FormAdminMain = new FormMain();
                        flag = 3;       //将权限设置为管理员
                        FormAdminMain.flag = flag;     //将当前值传到主窗体
                        FormAdminMain.userid = Convert.ToInt32(skinTextBoxUser.Text);   //设置ID信息
                        FormAdminMain.Show();
                        //创建新线程播放语音，便于窗体加载与与语音播报同时进行
                        Thread thread = new Thread(spVoice);
                        thread.Start();
                    }
                    
                }
                else
                {
                    MessageBox.Show("本次登录失败，请检查后重试...\n\n可能原因如下：\n1.账户和密码输入错误(均区分大小写)\n2.该账户可能不存在于您选中的用户群体。", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库操作异常!!\n请联系开发者获取帮助", "未知错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
            finally
            {
                reader.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }

        private void LinkLabelAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();    //隐藏当前窗体
            FormMain FormMain = new FormMain();
            FormMain.flag = 0;      //将权限设置为开发者
            FormMain.Show();
            //创建新线程播放语音，便于窗体加载与与语音播报同时进行
            Thread thread = new Thread(spVoice);
            thread.Start();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否退出本程序？？", "确认退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                this.FormClosing -= new FormClosingEventHandler(this.FormLogin_FormClosing);
                Application.Exit();
            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void SkinButtonRun_Click(object sender, EventArgs e)
        {
            loginRun();
        }
    }
}
