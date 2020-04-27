using ADO_Demos.common;
using CCWin;
using StudentMSBll;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace ADO_Demos
{
    public partial class FormMain : CCSkinMain
    {
        //获取登录窗体用户选择的登录用户身份(0:开发者，1:学生，2:教师，3:管理员)
        public int flag = 0;
        //获取用户ID数据
        public int userid = 0;

        //数据库连接密钥
        //string connectionStr = "server=.;database=Student;uid=Admin;pwd=246800";

        //临时存储数据库数据
        DataTable Studentdt = new DataTable();       //学生表
        DataTable Teacherdt = new DataTable();       //教师表
        DataTable classInfodt = new DataTable();      //班级表
        DataTable CourseInfodt = new DataTable();   //课程表
        DataTable SCMappingdt = new DataTable();  //成绩表

        //记录数据页码
        int StudentDBIndex = 1;
        int TeacherDBIndex = 1;
        int ClassInfoDBIndex = 1;
        int CourseInfoDBIndex = 1;
        int SCMappingDBIndex = 1;

        //读取配置文件信息
        static string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
        string name = ConfigurationManager.AppSettings["name"].ToString();
        string banben = ConfigurationManager.AppSettings["banben"].ToString();
        string pagesize = ConfigurationManager.AppSettings["PageSize"].ToString();

        //数据库连接操作
        SqlConnection conn = new SqlConnection(connStr);

        //初始化数据访问层
        private StudentService stubll = new StudentService();
        private teacherService teabll = new teacherService();
        private courseService coubll = new courseService();
        private classInfoService clabll = new classInfoService();
        private SC_MappingService scmbll = new SC_MappingService();
        private system_usersService subll = new system_usersService();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //设置主窗体标题文本
            this.Text = "Student 校务数据管理平台 ----- 版本号：" + banben + "";
            //设置用户身份
            UserCheck();
            //默认选中学生数据Tab选项卡
            skinTabControlDate.SelectedTab = skinTabPageStudent;
            //测试功能：填充读取到的配置数据到下方文本信息区
            this.richTextBox1.Text = "数据库连接代码：" + connStr + "\n姓名：" + name + "\n每页显示数据条数：" + pagesize;
        }

        /// <summary>
        /// 判断当前登录用户身份，隐藏相关功能控件
        /// </summary>
        public void UserCheck()
        {
            string shenfen = null;
            if (flag == 0)
            {
                shenfen = "开发者";
            }
            if (flag == 1)
            {
                shenfen = "学生";
                toolStripSeparator2.Visible = false;
                toolStripSeparator3.Visible = false;
                toolStripSeparator4.Visible = false;
                toolStripSeparator5.Visible = false;
                toolStripDropDownButton2.Visible = false;
                toolStripDropDownButton3.Visible = false;
                toolStripDropDownButton4.Visible = false;
                toolStripDropDownButton5.Visible = false;
            }
            else if (flag == 2)
            {
                shenfen = "教师";
                toolStripSeparator1.Visible = false;
                toolStripSeparator2.Visible = false;
                toolStripSeparator3.Visible = false;
                toolStripSeparator4.Visible = false;
                toolStripDropDownButton1.Visible = false;
                toolStripDropDownButton2.Visible = false;
                toolStripDropDownButton3.Visible = false;
                toolStripDropDownButton4.Visible = false;
            }
            else if (flag == 3)
            {
                shenfen = "管理员";
                查看我的成绩单ToolStripMenuItem1.Enabled = false;
                更改登录密码ToolStripMenuItem1.Enabled = false;
            }
            //设置底部用户身份文本
            toolStripStatusLabelUser.Text += shenfen;
        }

        /// <summary>
        /// 清空控件内数据
        /// </summary>
        public void ClearDGV()
        {
            Studentdt.Clear();     //清空临时数据表格
            this.skinDataGridViewStudent.DataSource = Studentdt;       //重新加载临时数据表格
            classInfodt.Clear();
            this.skinDataGridViewClassInfo.DataSource = classInfodt;
            Teacherdt.Clear();
            this.skinDataGridViewTeacher.DataSource = Teacherdt;
            CourseInfodt.Clear();
            this.skinDataGridViewCourse.DataSource = CourseInfodt;
            SCMappingdt.Clear();
            this.skinDataGridViewSCMapping.DataSource = SCMappingdt;
            //清空完成
            MessageBox.Show("数据清空完成!!", "执行成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void ConnStateOpen()
        {
            if (conn.State == ConnectionState.Closed || skinbuttonConnSwitch.Text == "开启数据库连接")
            {
                conn.Open();
                skinToolStrip1.Enabled = true;
                skinbuttonLock.Visible = false;
                //LockHideShow();
                skinButtonClear.Enabled = true;
                skinbuttonConnSwitch.Text = "关闭数据库连接";
                MessageBox.Show("打开数据库连接成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("当前数据库连接已打开", "数据库已连接", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void ConnStateClose()
        {
            if (conn.State == ConnectionState.Open || skinbuttonConnSwitch.Text == "关闭数据库连接")
            {
                conn.Close();
                skinToolStrip1.Enabled = false;
                skinbuttonLock.Visible = true;
                //LockHideShow();
                skinButtonClear.Enabled = false;
                skinbuttonConnSwitch.Text = "开启数据库连接";
                MessageBox.Show("关闭数据库连接成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("当前数据库连接已关闭", "数据库连接已关闭", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        /// <summary>
        /// 退出程序事件
        /// </summary>
        public void exitApp()
        {
            FormMain_FormClosing(null,null);
        }

        /// <summary>
        /// 计算 Student 表内数据可分出的页数总数
        /// </summary>
        /// <returns></returns>
        private int StuGetTotal()
        {
            int total = stubll.GetDBRows();
            if (total % PageConfig.GetPageSize() != 0) //计算是否有余数
            {
                return total / PageConfig.GetPageSize() + 1;    //有余数多加1页
            }
            else
            {
                return total / PageConfig.GetPageSize();    //正常分页
            }
        }

        /// <summary>
        /// 计算 Teacher 表内数据可分出的页数总数
        /// </summary>
        /// <returns></returns>
        private int TeaGetTotal()
        {
            int total = teabll.GetDBRows();
            if (total % PageConfig.GetPageSize() != 0) //计算是否有余数
            {
                return total / PageConfig.GetPageSize() + 1;    //有余数多加1页
            }
            else
            {
                return total / PageConfig.GetPageSize();    //正常分页
            }
        }

        /// <summary>
        /// 计算 ClassInfo 表内数据可分出的页数总数
        /// </summary>
        /// <returns></returns>
        private int ClaGetTotal()
        {
            int total = clabll.GetDBRows();
            if (total % PageConfig.GetPageSize() != 0) //计算是否有余数
            {
                return total / PageConfig.GetPageSize() + 1;    //有余数多加1页
            }
            else
            {
                return total / PageConfig.GetPageSize();    //正常分页
            }
        }

        /// <summary>
        /// 计算 CourseInfo 表内数据可分出的页数总数
        /// </summary>
        /// <returns></returns>
        private int CouGetTotal()
        {
            int total = coubll.GetDBRows();
            if (total % PageConfig.GetPageSize() != 0) //计算是否有余数
            {
                return total / PageConfig.GetPageSize() + 1;    //有余数多加1页
            }
            else
            {
                return total / PageConfig.GetPageSize();    //正常分页
            }
        }

        /// <summary>
        /// 计算 SC_Mapping 表内数据可分出的页数总数
        /// </summary>
        /// <returns></returns>
        private int SCMGetTotal()
        {
            int total = scmbll.GetDBRows();
            if (total % PageConfig.GetPageSize() != 0) //计算是否有余数
            {
                return total / PageConfig.GetPageSize() + 1;    //有余数多加1页
            }
            else
            {
                return total / PageConfig.GetPageSize();    //正常分页
            }
        }

        private void tabControlDate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        /*工具栏相关操作===================================================*/

        private void 查询全部学生信息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //设定相关选项卡为选中状态
            this.skinTabControlDate.SelectedTab = skinTabPageStudent;
            Studentdt = stubll.GetDataByPage(PageConfig.GetPageSize(), StudentDBIndex);   //填充数据到临时数据表格
            skinDataGridViewStudent.DataSource = Studentdt;     //填充数据显示控件
            skinLabelPage.Text = "当前第" + StudentDBIndex + "页/共" + StuGetTotal() + "页";
        }

        private void 添加学生数据ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //打开添加学生数据窗体
            FormStuInsert FormStuInsert = new FormStuInsert();
            FormStuInsert.Show();
        }

        private void 更新学生数据ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //打开更新学生数据窗体
            FormStuUpdate FormStuUpdate = new FormStuUpdate();
            FormStuUpdate.Show();
        }

        private void 删除学生数据ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //打开删除学生数据窗体
            FormDelete FormFullDelete = new FormDelete();
            FormFullDelete.Delflag = 1;
            FormFullDelete.Show();
        }

        private void 查看我的成绩单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //打开查看我的成绩单窗口
            FormMyScore FormMyScore = new FormMyScore();
            FormMyScore.studentID = userid;
            FormMyScore.Show();
        }

        private void 更改登录密码ToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            //打开更改登录密码窗体
            FormPwdUpdate FormPwdUpdate = new FormPwdUpdate();
            FormPwdUpdate.id = userid;
            FormPwdUpdate.userflag = 1;
            FormPwdUpdate.Show();
        }

        private void 查询全部教师数据ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //设定相关选项卡为选中状态
            this.skinTabControlDate.SelectedTab = skinTabPageTeacher;
            Teacherdt = teabll.GetDataByPage(PageConfig.GetPageSize(), TeacherDBIndex);   //填充数据到临时数据表格
            skinDataGridViewTeacher.DataSource = Teacherdt;     //填充数据显示控件
            skinLabelPage.Text = "当前第" + TeacherDBIndex + "页/共" + TeaGetTotal() + "页";
        }

        private void 添加教师数据ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //打开添加教师数据窗体
            FormTeaInsert FormTeaInsert = new FormTeaInsert();
            FormTeaInsert.Show();
        }

        private void 更新教师数据ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //打开更新教师数据窗体
            FormTeaUpdate FormTeaUpdate = new FormTeaUpdate();
            FormTeaUpdate.Show();
        }

        private void 删除教师数据ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //打开删除数据窗体
            FormDelete FormFullDelete = new FormDelete();
            FormFullDelete.Delflag = 2;
            FormFullDelete.Show();
        }

        private void 更改登录密码ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //打开更改密码窗体
            FormPwdUpdate FormPwdUpdate = new FormPwdUpdate();
            FormPwdUpdate.id = userid;
            FormPwdUpdate.userflag = 2;
            FormPwdUpdate.Show();
        }

        private void 查询全部课程信息ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //设定相关选项卡为选中状态
            this.skinTabControlDate.SelectedTab = skinTabPageCourse;
            CourseInfodt = coubll.GetDataByPage(PageConfig.GetPageSize(), CourseInfoDBIndex);   //填充数据到临时数据表格
            skinDataGridViewCourse.DataSource = CourseInfodt;     //填充数据显示控件
            skinLabelPage.Text = "当前第" + CourseInfoDBIndex + "页/共" + CouGetTotal() + "页";
        }

        private void 添加课程数据ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //打开添加课程数据窗体
            FormCourseInsert FormCourseInsert = new FormCourseInsert();
            FormCourseInsert.Show();
        }

        private void 删除课程数据ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //打开删除数据窗体
            FormDelete FormFullDelete = new FormDelete();
            FormFullDelete.Delflag = 3;
            FormFullDelete.Show();
        }

        private void 查询全部班级信息ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //设定相关选项卡为选中状态
            this.skinTabControlDate.SelectedTab = skinTabPageClassInfo;
            classInfodt = clabll.GetDataByPage(PageConfig.GetPageSize(), ClassInfoDBIndex);   //填充数据到临时数据表格
            skinDataGridViewClassInfo.DataSource = classInfodt;     //填充数据显示控件
            skinLabelPage.Text = "当前第" + ClassInfoDBIndex + "页/共" + ClaGetTotal() + "页";
        }

        private void 添加班级数据ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //打开添加班级数据窗体
            FormClassInfoInsert FormClassInfoInsert = new FormClassInfoInsert();
            FormClassInfoInsert.Show();
        }

        private void 删除班级数据ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //打开删除数据窗体
            FormDelete FormFullDelete = new FormDelete();
            FormFullDelete.Delflag = 4;
            FormFullDelete.Show();
        }

        private void 查询全部学生成绩信息ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //设定相关选项卡为选中状态
            this.skinTabControlDate.SelectedTab = skinTabPageSCmapping;
            SCMappingdt = scmbll.GetDataByPage(PageConfig.GetPageSize(), SCMappingDBIndex);   //填充数据到临时数据表格
            skinDataGridViewSCMapping.DataSource = SCMappingdt;     //填充数据显示控件
            skinLabelPage.Text = "当前第" + SCMappingDBIndex + "页/共" + SCMGetTotal() + "页";
        }

        private void 录入学生成绩数据ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //打开录入学生成绩数据窗体
            FormSCMappingInsert FormSCMappingInsert = new FormSCMappingInsert();
            FormSCMappingInsert.Show();
        }

        private void 删除成绩数据ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //打开删除数据窗体
            FormDelete FormFullDelete = new FormDelete();
            FormFullDelete.Delflag = 5;
            FormFullDelete.Show();
        }

        private void 使用说明ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            //打开使用说明窗体
            FormHelp FormHelp = new FormHelp();
            FormHelp.Show();
        }

        private void 关于程序ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            //打开关于程序窗体
            FormAbout FormAbout = new FormAbout();
            FormAbout.Show();
        }

        /*===============================================================*/

        private void 打开数据库连接OnDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnStateOpen();
        }

        private void 关闭数据库连接OffDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnStateClose();
        }

        private void 查看当前连接状态ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                MessageBox.Show("当前数据库连接处于:【已连接】状态", "数据库连接状态信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (conn.State == ConnectionState.Closed)
            {
                MessageBox.Show("当前数据库连接处于:【已关闭】状态", "数据库连接状态信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 打开功能测试窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 开发者功能测试区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNew FormNew = new FormNew();
            FormNew.Show();
        }

        /// <summary>
        /// 退出程序事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否退出本程序？？", "确认退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                this.FormClosing -= new FormClosingEventHandler(this.FormMain_FormClosing);
                System.Environment.Exit(0);
            }
        }

        /// <summary>
        /// 打开使用说明窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 使用说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHelp FormHelp = new FormHelp();
            FormHelp.Show();
        }

        /// <summary>
        /// 打开关于程序窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 关于程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout FormAbout = new FormAbout();
            FormAbout.Show();
        }

        private void SkinbuttonConnSwitch_Click(object sender, EventArgs e)
        {
            //判断控件文本进行相应操作
            if (skinbuttonConnSwitch.Text == "开启数据库连接")
            {
                ConnStateOpen();
            }
            else if (skinbuttonConnSwitch.Text == "关闭数据库连接")
            {
                ConnStateClose();
            }
        }

        /// <summary>
        /// 执行清空显示方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SkinButtonClear_Click(object sender, EventArgs e)
        {
            ClearDGV();
        }

        /// <summary>
        /// 确认退出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否退出本程序？？", "确认退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                this.FormClosing -= new FormClosingEventHandler(this.FormMain_FormClosing);
                System.Environment.Exit(0);
            }
            else if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void DataGridViewStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// 打开关于程序窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripStatusLabelAbout_Click(object sender, EventArgs e)
        {
            FormAbout FormAbout = new FormAbout();
            FormAbout.Show();
        }

        //学生数据右键菜单相关操作
        private void 修改此数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStuUpdate FormStuUpdate = new FormStuUpdate();
            FormStuUpdate.id = skinDataGridViewStudent.SelectedRows[0].Cells[0].Value.ToString();
            FormStuUpdate.Show();
        }

        private void 删除此数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDelete FormDelete = new FormDelete();
            FormDelete.Delflag = 1;     //将删除身份设置为学生
            FormDelete.id = skinDataGridViewStudent.SelectedRows[0].Cells[0].Value.ToString();
            FormDelete.Show();
        }

        //教师数据右键菜单相关操作
        private void ToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            FormTeaUpdate FormTeaUpdate = new FormTeaUpdate();
            FormTeaUpdate.id = skinDataGridViewTeacher.SelectedRows[0].Cells[0].Value.ToString();
            FormTeaUpdate.Show();
        }

        private void ToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            FormDelete FormDelete = new FormDelete();
            FormDelete.Delflag = 2;     //将删除身份设置为教师
            FormDelete.id = skinDataGridViewTeacher.SelectedRows[0].Cells[0].Value.ToString();
            FormDelete.Show();
        }

        //课程数据右键菜单相关操作
        private void ToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            FormDelete FormDelete = new FormDelete();
            FormDelete.Delflag = 3;     //将删除身份设置为课程
            FormDelete.id = skinDataGridViewCourse.SelectedRows[0].Cells[0].Value.ToString();
            FormDelete.Show();
        }

        //班级数据右键菜单相关操作
        private void ToolStripMenuItem16_Click(object sender, EventArgs e)
        {
            FormDelete FormDelete = new FormDelete();
            FormDelete.Delflag = 4;     //将删除身份设置为班级
            FormDelete.id = skinDataGridViewClassInfo.SelectedRows[0].Cells[0].Value.ToString();
            FormDelete.Show();
        }

        //学生成绩数据右键菜单相关操作
        private void ToolStripMenuItem19_Click(object sender, EventArgs e)
        {
            FormDelete FormDelete = new FormDelete();
            FormDelete.Delflag = 5;     //将删除身份设置为成绩
            FormDelete.id = skinDataGridViewSCMapping.SelectedRows[0].Cells[0].Value.ToString();
            FormDelete.Show();
        }

        private void SkinPanelPage_Paint(object sender, PaintEventArgs e)
        {

        }

        //==================跳转页面相关操作==================

        /// <summary>
        /// 跳转至首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SkinButtonLeft_Click(object sender, EventArgs e)
        {
            //判断当前选中数据页
            if (skinTabControlDate.SelectedTab == skinTabPageStudent)
            {
                StudentDBIndex = 1;
                Studentdt = stubll.GetDataByPage(PageConfig.GetPageSize(), StudentDBIndex);   //填充数据到临时数据表格
                skinDataGridViewStudent.DataSource = Studentdt;     //填充数据显示控件
                skinLabelPage.Text = "当前第" + StudentDBIndex + "页/共" + StuGetTotal() + "页";
            }
            else if (skinTabControlDate.SelectedTab == skinTabPageTeacher)
            {
                TeacherDBIndex = 1;
                Teacherdt = teabll.GetDataByPage(PageConfig.GetPageSize(), StudentDBIndex);   //填充数据到临时数据表格
                skinDataGridViewTeacher.DataSource = Teacherdt;     //填充数据显示控件
                skinLabelPage.Text = "当前第" + TeacherDBIndex + "页/共" + TeaGetTotal() + "页";
            }
            else if (skinTabControlDate.SelectedTab ==skinTabPageCourse)
            {
                CourseInfoDBIndex = 1;
                CourseInfodt = coubll.GetDataByPage(PageConfig.GetPageSize(), CourseInfoDBIndex);   //填充数据到临时数据表格
                skinDataGridViewCourse.DataSource = CourseInfodt;     //填充数据显示控件
                skinLabelPage.Text = "当前第" + CourseInfoDBIndex + "页/共" + CouGetTotal() + "页";
            }
            else if (skinTabControlDate.SelectedTab ==skinTabPageClassInfo)
            {
                ClassInfoDBIndex = 1;
                classInfodt = clabll.GetDataByPage(PageConfig.GetPageSize(), StudentDBIndex);   //填充数据到临时数据表格
                skinDataGridViewClassInfo.DataSource = classInfodt;     //填充数据显示控件
                skinLabelPage.Text = "当前第" + ClassInfoDBIndex + "页/共" + ClaGetTotal() + "页";
            }
            else if (skinTabControlDate.SelectedTab == skinTabPageSCmapping)
            {
                SCMappingDBIndex = 1;
                SCMappingdt = scmbll.GetDataByPage(PageConfig.GetPageSize(), SCMappingDBIndex);   //填充数据到临时数据表格
                skinDataGridViewSCMapping.DataSource = SCMappingdt;     //填充数据显示控件
                skinLabelPage.Text = "当前第" + SCMappingDBIndex + "页/共" + SCMGetTotal() + "页";
            }
        }

        /// <summary>
        /// 跳转至尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SkinButtonRight_Click(object sender, EventArgs e)
        {
            //判断当前选中数据页
            if (skinTabControlDate.SelectedTab == skinTabPageStudent)
            {
                StudentDBIndex = StuGetTotal();
                Studentdt = stubll.GetDataByPage(PageConfig.GetPageSize(), StuGetTotal());   //填充数据到临时数据表格
                skinDataGridViewStudent.DataSource = Studentdt;     //填充数据显示控件
                skinLabelPage.Text = "当前第" + StudentDBIndex + "页/共" + StuGetTotal() + "页";
            }
            else if (skinTabControlDate.SelectedTab == skinTabPageTeacher)
            {
                TeacherDBIndex = TeaGetTotal();
                Teacherdt = teabll.GetDataByPage(PageConfig.GetPageSize(), TeaGetTotal());   //填充数据到临时数据表格
                skinDataGridViewTeacher.DataSource = Teacherdt;     //填充数据显示控件
                skinLabelPage.Text = "当前第" + TeacherDBIndex + "页/共" + TeaGetTotal() + "页";
            }
            else if (skinTabControlDate.SelectedTab == skinTabPageCourse)
            {
                CourseInfoDBIndex = CouGetTotal();
                CourseInfodt = coubll.GetDataByPage(PageConfig.GetPageSize(), CourseInfoDBIndex);   //填充数据到临时数据表格
                skinDataGridViewCourse.DataSource = CourseInfodt;     //填充数据显示控件
                skinLabelPage.Text = "当前第" + CourseInfoDBIndex + "页/共" + CouGetTotal() + "页";
            }
            else if (skinTabControlDate.SelectedTab == skinTabPageClassInfo)
            {
                ClassInfoDBIndex = ClaGetTotal();
                classInfodt = clabll.GetDataByPage(PageConfig.GetPageSize(), ClassInfoDBIndex);   //填充数据到临时数据表格
                skinDataGridViewClassInfo.DataSource = classInfodt;     //填充数据显示控件
                skinLabelPage.Text = "当前第" + ClassInfoDBIndex + "页/共" + ClaGetTotal() + "页";
            }
            else if (skinTabControlDate.SelectedTab == skinTabPageSCmapping)
            {
                SCMappingDBIndex = SCMGetTotal();
                SCMappingdt = scmbll.GetDataByPage(PageConfig.GetPageSize(), SCMappingDBIndex);   //填充数据到临时数据表格
                skinDataGridViewSCMapping.DataSource = SCMappingdt;     //填充数据显示控件
                skinLabelPage.Text = "当前第" + SCMappingDBIndex + "页/共" + SCMGetTotal() + "页";
            }
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SkinButtonUp_Click(object sender, EventArgs e)
        {
            //判断当前选中数据页
            if (skinTabControlDate.SelectedTab == skinTabPageStudent)
            {
                StudentDBIndex--;
                if (StudentDBIndex < 1)
                {
                    MessageBox.Show("当前已经是第一页", "提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    StudentDBIndex = 1;
                }
                Studentdt = stubll.GetDataByPage(PageConfig.GetPageSize(), StudentDBIndex);   //填充数据到临时数据表格
                skinDataGridViewStudent.DataSource = Studentdt;     //填充数据显示控件
                skinLabelPage.Text = "当前第" + StudentDBIndex + "页/共" + StuGetTotal() + "页";
            }
            else if (skinTabControlDate.SelectedTab == skinTabPageTeacher)
            {
                TeacherDBIndex--;
                if (TeacherDBIndex < 1)
                {
                    MessageBox.Show("当前已经是第一页", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    TeacherDBIndex = 1;
                }
                Teacherdt = teabll.GetDataByPage(PageConfig.GetPageSize(), TeacherDBIndex);   //填充数据到临时数据表格
                skinDataGridViewTeacher.DataSource = Teacherdt;     //填充数据显示控件
                skinLabelPage.Text = "当前第" + TeacherDBIndex + "页/共" + TeaGetTotal() + "页";
            }
            else if (skinTabControlDate.SelectedTab == skinTabPageCourse)
            {
                CourseInfoDBIndex--;
                if (CourseInfoDBIndex < 1)
                {
                    MessageBox.Show("当前已经是第一页", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    CourseInfoDBIndex = 1;
                }
                CourseInfodt = coubll.GetDataByPage(PageConfig.GetPageSize(), CourseInfoDBIndex);   //填充数据到临时数据表格
                skinDataGridViewCourse.DataSource = CourseInfodt;     //填充数据显示控件
                skinLabelPage.Text = "当前第" + CourseInfoDBIndex + "页/共" + CouGetTotal() + "页";
            }
            else if (skinTabControlDate.SelectedTab == skinTabPageClassInfo)
            {
                ClassInfoDBIndex--;
                if (ClassInfoDBIndex < 1)
                {
                    MessageBox.Show("当前已经是第一页", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ClassInfoDBIndex = 1;
                }
                classInfodt = clabll.GetDataByPage(PageConfig.GetPageSize(), ClassInfoDBIndex);   //填充数据到临时数据表格
                skinDataGridViewClassInfo.DataSource = classInfodt;     //填充数据显示控件
                skinLabelPage.Text = "当前第" + ClassInfoDBIndex + "页/共" + ClaGetTotal() + "页";
            }
            else if (skinTabControlDate.SelectedTab == skinTabPageSCmapping)
            {
                SCMappingDBIndex--;
                if (SCMappingDBIndex < 1)
                {
                    MessageBox.Show("当前已经是第一页", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    SCMappingDBIndex = 1;
                }
                SCMappingdt = scmbll.GetDataByPage(PageConfig.GetPageSize(), SCMappingDBIndex);   //填充数据到临时数据表格
                skinDataGridViewSCMapping.DataSource = SCMappingdt;     //填充数据显示控件
                skinLabelPage.Text = "当前第" + SCMappingDBIndex + "页/共" + SCMGetTotal() + "页";
            }
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SkinButtonDown_Click(object sender, EventArgs e)
        {
            //判断当前选中数据页
            if (skinTabControlDate.SelectedTab == skinTabPageStudent)
            {
                StudentDBIndex++;
                if (StudentDBIndex > StuGetTotal())
                {
                    MessageBox.Show("当前已经是最后一页", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    StudentDBIndex = StuGetTotal();
                }
                else
                {
                    Studentdt = stubll.GetDataByPage(PageConfig.GetPageSize(), StudentDBIndex);   //填充数据到临时数据表格
                    skinDataGridViewStudent.DataSource = Studentdt;     //填充数据显示控件
                    skinLabelPage.Text = "当前第" + StudentDBIndex + "页/共" + StuGetTotal() + "页";
                }
            }
            else if (skinTabControlDate.SelectedTab == skinTabPageTeacher)
            {
                TeacherDBIndex++;
                if (TeacherDBIndex > TeaGetTotal())
                {
                    MessageBox.Show("当前已经是最后一页", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    StudentDBIndex = TeaGetTotal();
                }
                else
                {
                    Teacherdt = teabll.GetDataByPage(PageConfig.GetPageSize(), TeacherDBIndex);   //填充数据到临时数据表格
                    skinDataGridViewTeacher.DataSource = Teacherdt;     //填充数据显示控件
                    skinLabelPage.Text = "当前第" + TeacherDBIndex + "页/共" + TeaGetTotal() + "页";
                }
            }
            else if (skinTabControlDate.SelectedTab == skinTabPageCourse)
            {
                CourseInfoDBIndex++;
                if (CourseInfoDBIndex > CouGetTotal())
                {
                    MessageBox.Show("当前已经是最后一页", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    CourseInfoDBIndex = CouGetTotal();
                }
                else
                {
                    CourseInfodt = coubll.GetDataByPage(PageConfig.GetPageSize(), CourseInfoDBIndex);   //填充数据到临时数据表格
                    skinDataGridViewCourse.DataSource = CourseInfodt;     //填充数据显示控件
                    skinLabelPage.Text = "当前第" + CourseInfoDBIndex + "页/共" + CouGetTotal() + "页";
                }
            }
            else if (skinTabControlDate.SelectedTab == skinTabPageClassInfo)
            {
                ClassInfoDBIndex++;
                if (ClassInfoDBIndex > ClaGetTotal())
                {
                    MessageBox.Show("当前已经是最后一页", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    StudentDBIndex = ClaGetTotal();
                }
                else
                {
                    classInfodt = clabll.GetDataByPage(PageConfig.GetPageSize(), ClassInfoDBIndex);   //填充数据到临时数据表格
                    skinDataGridViewClassInfo.DataSource = classInfodt;     //填充数据显示控件
                    skinLabelPage.Text = "当前第" + ClassInfoDBIndex + "页/共" + ClaGetTotal() + "页";
                }
            }
            else if (skinTabControlDate.SelectedTab == skinTabPageSCmapping)
            {
                SCMappingDBIndex++;
                if (SCMappingDBIndex > SCMGetTotal())
                {
                    MessageBox.Show("当前已经是最后一页", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    SCMappingDBIndex = SCMGetTotal();
                }
                else
                {
                    SCMappingdt = scmbll.GetDataByPage(PageConfig.GetPageSize(), SCMappingDBIndex);   //填充数据到临时数据表格
                    skinDataGridViewSCMapping.DataSource = SCMappingdt;     //填充数据显示控件
                    skinLabelPage.Text = "当前第" + SCMappingDBIndex + "页/共" + SCMGetTotal() + "页";
                }
            }
        }

        private void 用户登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin FormLogin = new FormLogin();
            FormLogin.Show();
        }

        private void 退出程序ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            exitApp();
        }

        private void 帮助中心ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            使用说明ToolStripMenuItem_Click(null, null);
        }

        private void 关于程序ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            关于程序ToolStripMenuItem_Click(null, null);
        }

        private void 用户登录ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            用户登录ToolStripMenuItem_Click(null, null);
        }
    }
}
