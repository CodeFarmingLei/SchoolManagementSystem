using CCWin;
using StudentMSAdo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_Demos
{
    public partial class FormNew : CCSkinMain
    {
        public FormNew()
        {
            InitializeComponent();
        }

        private void FormNew_Load(object sender, EventArgs e)
        {
            GetSysUser();
        }

        private void buttonDataSet_Click(object sender, EventArgs e)
        {
            GetDataSetInList();
        }

        private void buttonInsertType_Click(object sender, EventArgs e)
        {
            //调用插入测试数据方法
            TransactionStu();
        }

        private void buttonATDataSet_Click(object sender, EventArgs e)
        {
            ATGetDataSet();
        }

        private void buttonATInsertType_Click(object sender, EventArgs e)
        {

        }

        private void buttonTruncate_Click(object sender, EventArgs e)
        {
            DelDateTable();
        }

        private void buttonInsertAdmin_Click(object sender, EventArgs e)
        {
            InsertAdminDs();
        }


        //====================自定义方法集====================
        string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();

        //读取系统登录用户数据填充到控件
        public void GetSysUser()
        {
            DataTable sysUserdt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataAdapter adapter = null;
            SqlDataReader reader = null;
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                string strSql = " SELECT * FROM system_users ";
                cmd = new SqlCommand(strSql, conn);
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(sysUserdt);   //填充数据到临时数据表格
                skinDataGridView1.DataSource = sysUserdt;
                reader = cmd.ExecuteReader();
                if (!(reader.HasRows))
                {
                    MessageBox.Show("数据库内没有数据...", "执行成功", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        //DataSet读取数据存到List泛型集合
        public void GetDataSetInList()
        {
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataAdapter adapter = null;
            SqlDataReader reader = null;
            DataTable dt = new DataTable();
            List<Student> list = new List<Student>();
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                string strSql = "SELECT * FROM student";
                cmd = new SqlCommand(strSql, conn);
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);   //填充数据到临时数据表格
                reader = cmd.ExecuteReader();
                //foreach迭代方式
                //foreach (DataRow dr in dt.Rows) { }

                //while迭代方式
                while (reader.Read())
                {
                    //Student s = new Student();
                    //s.Sid = Convert.ToInt32(reader["sid"]);
                    //s.Sname = reader["sname"].ToString();
                    //s.Ssex = Convert.ToInt32(reader["ssex"]);
                    //s.Sage = Convert.ToInt32(reader["sage"]);
                    //s.Sbirthday = reader["sbirthday"].ToString();
                    //s.Sphone = reader["sphone"].ToString();
                    //s.Saddress = reader["saddress"].ToString();
                    //s.Sbanji = reader["sbanji"].ToString();
                    //list.Add(s);

                    Student s = new Student()
                    {
                        sid = Convert.ToInt32(reader["sid"]),
                        sname = reader["sname"].ToString(),
                        ssex = Convert.ToInt32(reader["ssex"]),
                        sage = Convert.ToInt32(reader["sage"]),
                        sbirthday = reader["sbirthday"].ToString(),
                        sphone = reader["sphone"].ToString(),
                        saddress = reader["saddress"].ToString(),
                        scid = Convert.ToInt32(reader["scid"]),
                        spassword = reader["spassword"].ToString()
                    };
                    list.Add(s);
                }
                //统计已存储到List内数据的行数量(表达式：总行数减一行空白行)
                int index = (list.Count) - 1;
                if (reader.HasRows)
                {
                    MessageBox.Show("读取数据完成!!\n共读取到 " + index + " 行数据。", "执行成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("数据库内没有数据", "执行成功", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        //事务操作：批量插入数据
        public void TransactionStu()
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlTransaction tran = null;
            SqlCommand cmd = null;
            try
            {
                conn.Open();
                tran = conn.BeginTransaction();
                string strSql =
                @" 
                    INSERT INTO student VALUES('Admin',1,DATEDIFF(YY, '1990-01-01', GETDATE()),'1990-01-01','13888888888','湖南长沙',1,'123456');
                    INSERT INTO student VALUES('张明全',1,DATEDIFF(YY, '1990-01-01', GETDATE()),'1990-01-01','13812345678','湖南长沙',1,'456789');
                    INSERT INTO student VALUES('李菲',1,DATEDIFF(YY, '1991-02-02', GETDATE()),'1991-02-02','15041576258','湖北宜昌',2,'789123');
                    INSERT INTO student VALUES('于寄谦',1,DATEDIFF(YY, '1992-03-03', GETDATE()),'1992-03-03','13945624865','甘肃天水',4,'147258');
                    INSERT INTO student VALUES('刘国正',1,DATEDIFF(YY, '1993-04-04', GETDATE()),'1993-04-04','15842548964','山东荷泽',1,'258369');
                    INSERT INTO student VALUES('周接轮',1,DATEDIFF(YY, '1995-06-07', GETDATE()),'1995-06-07','17654254892','台湾新竹',4,'369147');
                    INSERT INTO student VALUES('巩小妹',0,DATEDIFF(YY, '1996-03-22', GETDATE()),'1996-03-22','13545568785','香港龙湾',3,'111222');
                    INSERT INTO student VALUES('巩大妹',0,DATEDIFF(YY, '1994-02-01', GETDATE()),'1994-02-01','13042148961','香港龙湾',3,'333444');
                    INSERT INTO student VALUES('张明敏',0,DATEDIFF(YY, '1997-05-12', GETDATE()),'1997-05-12','13848754865','北京顺义',2,'555666');
                    INSERT INTO student VALUES('矛十八',1,DATEDIFF(YY, '1998-06-07', GETDATE()),'1998-06-07','16514567869','四川棉阳',4,'777888');
                    INSERT INTO student VALUES('罗林光',1,DATEDIFF(YY, '1999-02-04', GETDATE()),'1999-02-04','17532448546','陕西临潼',2,'999000');
                    INSERT INTO student VALUES('司马坡',1,DATEDIFF(YY, '1997-04-06', GETDATE()),'1997-04-06','13545678924','新疆喀什',1,'112233');
                    INSERT INTO student VALUES('罗宇飞',1,DATEDIFF(YY, '1999-04-06', GETDATE()),'1999-04-06','13545645924','浙江杭州',6,'445566');
                    INSERT INTO student VALUES('吴强',1,DATEDIFF(YY, '1993-08-21', GETDATE()),'1993-08-21','13645646215','云南大理',5,'778899');
                    INSERT INTO student VALUES('王小明',1,DATEDIFF(YY, '1996-02-23', GETDATE()),'1996-02-23','13701257945','黑龙江鸡西',7,'123123');
                    INSERT INTO student VALUES('李科',1,DATEDIFF(YY, '1998-09-16', GETDATE()),'1998-09-16','15846532452','浙江杭州',3,'456456');
                ";
                cmd = new SqlCommand(strSql, conn);
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
                tran.Commit();
                MessageBox.Show("批量插入执行完成!!","操作成功",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                conn.Dispose();
            }
        }

        //插入一条管理员测试数据
        public void InsertAdminDs()
        {
            SqlConnection conn = new SqlConnection(connStr);

            //初始化 Student 类
            Student s = new Student();
            s.sname = "Admin";
            s.ssex = 1;
            s.sage = 20;
            s.sbirthday = "1980-01-01";
            s.sphone = "13824685790";
            s.saddress = "海南三亚";
            s.scid = 1;
            s.spassword = "123456";

            //SQL添加语句VALUES写变量占位名
            string strSql = "INSERT INTO student VALUES(@sname,@ssex,@sage,@sbirthday,@sphone,@saddress,@scid,@spassword);";
            
            //详细定义占位变量内的数据类型
            SqlParameter[] spArray =
            {
                new SqlParameter("@sname",SqlDbType.VarChar),
                new SqlParameter("@ssex",SqlDbType.Int),
                new SqlParameter("@sage",SqlDbType.Int),
                new SqlParameter("@sbirthday",SqlDbType.VarChar),
                new SqlParameter("@sphone",SqlDbType.VarChar),
                new SqlParameter("@saddress",SqlDbType.VarChar),
                new SqlParameter("@scid",SqlDbType.Int),
                new SqlParameter("@spassword",SqlDbType.VarChar),
            };
            
            //将里面的占位变量赋值
            spArray[0].Value = s.sname;
            spArray[1].Value = s.ssex;
            spArray[2].Value = s.sage;
            spArray[3].Value = s.sbirthday;
            spArray[4].Value = s.sphone;
            spArray[5].Value = s.saddress;
            spArray[6].Value = s.scid;

            SqlCommand cmd = null;
            try
            {
                conn.Open();
                cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddRange(spArray);
                int flag = cmd.ExecuteNonQuery();
                MessageBox.Show(flag > 0 ? "插入成功！！\n\n插入数据内容：\n姓名："+s.sname + "\n性别："+s.ssex + "\n年龄："+s.sage + "\n生日："+s.sbirthday + "\n电话号码："+s.sphone + "\n地址："+s.saddress + "\n班级："+s.scid + "\n密码："+s.spassword + "" : "插入失败","提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }

        }

        //数据查询操作
        public void ExecuteReader()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string strSql = "SELECT * FROM student";
                using (SqlCommand cmd = new SqlCommand(strSql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //reader.Read();
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["sid"]);
                            MessageBox.Show(id.ToString());
                        }
                    }
                }
            }

        }

        //调用ADOTools工具类执行方法
        public void ATGetDataSet()
        {
            string strSql = "SELECT * FROM student";
            SqlDataReader reader = ADOTools.ExcuteReader(strSql); ;
            List<Student> list = new List<Student>();
            while (reader.Read())
            {
                Student s = new Student()
                {
                    sid = Convert.ToInt32(reader["sid"]),
                    sname = reader["sname"].ToString(),
                    ssex = Convert.ToInt32(reader["ssex"]),
                    sage = Convert.ToInt32(reader["sage"]),
                    sbirthday = reader["sbirthday"].ToString(),
                    sphone = reader["sphone"].ToString(),
                    saddress = reader["saddress"].ToString(),
                    scid = Convert.ToInt32(reader["scid"])
                    
                };
                list.Add(s);
            }
            DataTable dt = ADOTools.ExcuteDataTable(strSql);
            //统计读取到数据的行数量(表达式：总行数减一行空白行)
            int Listindex = (list.Count) - 1;       //List总行数
            int DataTableindex = (list.Count) - 1;      //DateTable总行数
            MessageBox.Show("读取数据完成!!\nList内共读取到 " + Listindex + " 行数据。\nDateTable内共读取到 " + DataTableindex + " 行数据。", "执行成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        //清空数据表数据
        public void DelDateTable()
        {
            string strSql = " TRUNCATE TABLE student; ";
            int flag = ADOTools.SqlDataReader(strSql);
            MessageBox.Show("数据清空完成!!\n表内为 " + (flag+1) + " 行数据。", "执行成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void FormNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void SkinButtonSql_Click(object sender, EventArgs e)
        {
            //执行导出脚本操作
            //读取资源文件的脚本数据保存到字符串
            string txtStr = Resource1.Student测试用数据库;

            //打开保存文件对话框
            saveFileDialogSQL.ShowDialog();

            try
            {
                string path = saveFileDialogSQL.FileName;    //存储保存文件路径

                //创建文件流
                FileStream mySaveFs = new FileStream(path, FileMode.Create);

                //创建写入器
                StreamWriter mySw = new StreamWriter(mySaveFs);
                mySw.Write(txtStr);  //将脚本文件数据写入文件

                mySw.Close();   //关闭写入器
                mySaveFs.Close();   //关闭文件流

                //结果反馈
                if (File.Exists(saveFileDialogSQL.FileName))
                {
                    MessageBox.Show("SQL脚本保存成功!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("此脚本文件已存在与该位置...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show("本次保存异常!! 可能原因如下~\n\n1.可能您关闭了保存文件对话框或者点击了取消按钮。\n2.程序脚本处理出错。\n\n如频出现此问题请联系开发者获取帮助", "本次保存异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
        }
    }
}
