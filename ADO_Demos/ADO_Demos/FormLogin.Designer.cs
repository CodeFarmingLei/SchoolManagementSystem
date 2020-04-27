namespace ADO_Demos
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.textBoxPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSel = new System.Windows.Forms.GroupBox();
            this.radioButtonAdmin = new System.Windows.Forms.RadioButton();
            this.radioButtonTeacher = new System.Windows.Forms.RadioButton();
            this.radioButtonStudent = new System.Windows.Forms.RadioButton();
            this.linkLabelAdmin = new System.Windows.Forms.LinkLabel();
            this.skinButtonRun = new CCWin.SkinControl.SkinButton();
            this.skinTextBoxUser = new CCWin.SkinControl.SkinWaterTextBox();
            this.groupBoxSel.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPwd
            // 
            this.textBoxPwd.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPwd.Location = new System.Drawing.Point(173, 107);
            this.textBoxPwd.MaxLength = 10;
            this.textBoxPwd.Name = "textBoxPwd";
            this.textBoxPwd.Size = new System.Drawing.Size(312, 35);
            this.textBoxPwd.TabIndex = 2;
            this.textBoxPwd.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(95, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 35);
            this.label2.TabIndex = 17;
            this.label2.Text = "密码";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(95, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 35);
            this.label1.TabIndex = 15;
            this.label1.Text = "账号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxSel
            // 
            this.groupBoxSel.Controls.Add(this.radioButtonAdmin);
            this.groupBoxSel.Controls.Add(this.radioButtonTeacher);
            this.groupBoxSel.Controls.Add(this.radioButtonStudent);
            this.groupBoxSel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxSel.Location = new System.Drawing.Point(129, 160);
            this.groupBoxSel.Name = "groupBoxSel";
            this.groupBoxSel.Size = new System.Drawing.Size(321, 73);
            this.groupBoxSel.TabIndex = 20;
            this.groupBoxSel.TabStop = false;
            this.groupBoxSel.Text = "选择登录用户身份";
            // 
            // radioButtonAdmin
            // 
            this.radioButtonAdmin.AutoSize = true;
            this.radioButtonAdmin.Location = new System.Drawing.Point(197, 34);
            this.radioButtonAdmin.Name = "radioButtonAdmin";
            this.radioButtonAdmin.Size = new System.Drawing.Size(106, 20);
            this.radioButtonAdmin.TabIndex = 5;
            this.radioButtonAdmin.Text = "系统管理员";
            this.radioButtonAdmin.UseVisualStyleBackColor = true;
            // 
            // radioButtonTeacher
            // 
            this.radioButtonTeacher.AutoSize = true;
            this.radioButtonTeacher.Location = new System.Drawing.Point(117, 34);
            this.radioButtonTeacher.Name = "radioButtonTeacher";
            this.radioButtonTeacher.Size = new System.Drawing.Size(58, 20);
            this.radioButtonTeacher.TabIndex = 4;
            this.radioButtonTeacher.Text = "教师";
            this.radioButtonTeacher.UseVisualStyleBackColor = true;
            // 
            // radioButtonStudent
            // 
            this.radioButtonStudent.AutoSize = true;
            this.radioButtonStudent.Checked = true;
            this.radioButtonStudent.Location = new System.Drawing.Point(30, 34);
            this.radioButtonStudent.Name = "radioButtonStudent";
            this.radioButtonStudent.Size = new System.Drawing.Size(58, 20);
            this.radioButtonStudent.TabIndex = 3;
            this.radioButtonStudent.TabStop = true;
            this.radioButtonStudent.Text = "学生";
            this.radioButtonStudent.UseVisualStyleBackColor = true;
            // 
            // linkLabelAdmin
            // 
            this.linkLabelAdmin.AutoSize = true;
            this.linkLabelAdmin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabelAdmin.Location = new System.Drawing.Point(371, 337);
            this.linkLabelAdmin.Name = "linkLabelAdmin";
            this.linkLabelAdmin.Size = new System.Drawing.Size(203, 14);
            this.linkLabelAdmin.TabIndex = 21;
            this.linkLabelAdmin.TabStop = true;
            this.linkLabelAdmin.Text = "=====点此进入开发者模式=====";
            this.linkLabelAdmin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelAdmin_LinkClicked);
            // 
            // skinButtonRun
            // 
            this.skinButtonRun.BackColor = System.Drawing.Color.Transparent;
            this.skinButtonRun.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.skinButtonRun.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButtonRun.DownBack = null;
            this.skinButtonRun.DownBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.skinButtonRun.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButtonRun.ForeColor = System.Drawing.Color.Green;
            this.skinButtonRun.Location = new System.Drawing.Point(129, 262);
            this.skinButtonRun.MouseBack = null;
            this.skinButtonRun.Name = "skinButtonRun";
            this.skinButtonRun.NormlBack = null;
            this.skinButtonRun.Size = new System.Drawing.Size(321, 38);
            this.skinButtonRun.TabIndex = 6;
            this.skinButtonRun.Text = "=====登  录=====";
            this.skinButtonRun.UseVisualStyleBackColor = false;
            this.skinButtonRun.Click += new System.EventHandler(this.SkinButtonRun_Click);
            // 
            // skinTextBoxUser
            // 
            this.skinTextBoxUser.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinTextBoxUser.Location = new System.Drawing.Point(173, 66);
            this.skinTextBoxUser.Name = "skinTextBoxUser";
            this.skinTextBoxUser.Size = new System.Drawing.Size(312, 35);
            this.skinTextBoxUser.TabIndex = 1;
            this.skinTextBoxUser.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBoxUser.WaterText = "";
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(580, 357);
            this.Controls.Add(this.skinTextBoxUser);
            this.Controls.Add(this.skinButtonRun);
            this.Controls.Add(this.linkLabelAdmin);
            this.Controls.Add(this.groupBoxSel);
            this.Controls.Add(this.textBoxPwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.EffectCaption = CCWin.TitleType.Title;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student 校务数据管理平台 (登录) ----- 版本号：";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLogin_FormClosing);
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.groupBoxSel.ResumeLayout(false);
            this.groupBoxSel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxSel;
        private System.Windows.Forms.RadioButton radioButtonAdmin;
        private System.Windows.Forms.RadioButton radioButtonTeacher;
        private System.Windows.Forms.RadioButton radioButtonStudent;
        private System.Windows.Forms.LinkLabel linkLabelAdmin;
        private CCWin.SkinControl.SkinButton skinButtonRun;
        private CCWin.SkinControl.SkinWaterTextBox skinTextBoxUser;
    }
}