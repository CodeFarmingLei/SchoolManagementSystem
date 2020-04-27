using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_Demos
{
    public partial class FormAbout : CCSkinMain
    {
        //初始化信息
        string banben = ConfigurationManager.AppSettings["banben"].ToString();
        string zuoze = ConfigurationManager.AppSettings["zuoze"].ToString();
        string qq = ConfigurationManager.AppSettings["qq"].ToString();

        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            //加载读取到的信息到相应文本控件
            labelBanben.Text += banben;
            labelZuoZhe.Text += zuoze;
            labelQW.Text += qq;
        }

        private void pictureBoxZuoZhe_Click(object sender, EventArgs e)
        {
            
        }

        //动态显示开发者头像
        int index = 0;
        private void timerImg_Tick(object sender, EventArgs e)
        {
            index++;
            if (index % 2 == 0)
            {
                pictureBoxZuoZhe.Image = Resource1.ZuoZheimg2;
            }
            else
            {
                pictureBoxZuoZhe.Image = Resource1.ZuoZheimg1;
            }
        }

        private void FormAbout_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
