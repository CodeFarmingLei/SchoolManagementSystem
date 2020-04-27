namespace ADO_Demos
{
    partial class FormTeaUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTeaUpdate));
            this.labelidTip = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSbanji = new System.Windows.Forms.ComboBox();
            this.textBoxTpwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelSname = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.labelLock = new System.Windows.Forms.Label();
            this.comboBoxTprofession = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelidTip
            // 
            this.labelidTip.AutoSize = true;
            this.labelidTip.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelidTip.Location = new System.Drawing.Point(145, 71);
            this.labelidTip.Name = "labelidTip";
            this.labelidTip.Size = new System.Drawing.Size(145, 16);
            this.labelidTip.TabIndex = 34;
            this.labelidTip.Text = "请优先输入序号ID";
            // 
            // textBoxID
            // 
            this.textBoxID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxID.Location = new System.Drawing.Point(145, 38);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(277, 26);
            this.textBoxID.TabIndex = 33;
            this.textBoxID.TextChanged += new System.EventHandler(this.TextBoxID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(83, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "序号ID：";
            // 
            // comboBoxSbanji
            // 
            this.comboBoxSbanji.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxSbanji.FormattingEnabled = true;
            this.comboBoxSbanji.Location = new System.Drawing.Point(145, 153);
            this.comboBoxSbanji.Name = "comboBoxSbanji";
            this.comboBoxSbanji.Size = new System.Drawing.Size(277, 24);
            this.comboBoxSbanji.TabIndex = 35;
            // 
            // textBoxTpwd
            // 
            this.textBoxTpwd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxTpwd.Location = new System.Drawing.Point(145, 245);
            this.textBoxTpwd.MaxLength = 6;
            this.textBoxTpwd.Name = "textBoxTpwd";
            this.textBoxTpwd.Size = new System.Drawing.Size(277, 26);
            this.textBoxTpwd.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(31, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 42;
            this.label3.Text = "教师登录密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(63, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 41;
            this.label2.Text = "课程专业：";
            // 
            // textBoxTname
            // 
            this.textBoxTname.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxTname.Location = new System.Drawing.Point(145, 183);
            this.textBoxTname.Name = "textBoxTname";
            this.textBoxTname.Size = new System.Drawing.Size(277, 26);
            this.textBoxTname.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(95, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 40;
            this.label4.Text = "姓名：";
            // 
            // labelSname
            // 
            this.labelSname.AutoSize = true;
            this.labelSname.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSname.Location = new System.Drawing.Point(63, 156);
            this.labelSname.Name = "labelSname";
            this.labelSname.Size = new System.Drawing.Size(88, 16);
            this.labelSname.TabIndex = 37;
            this.labelSname.Text = "教室编号：";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(145, 338);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(214, 36);
            this.buttonUpdate.TabIndex = 43;
            this.buttonUpdate.Text = "更新数据";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // labelLock
            // 
            this.labelLock.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLock.Location = new System.Drawing.Point(12, 105);
            this.labelLock.Name = "labelLock";
            this.labelLock.Size = new System.Drawing.Size(492, 342);
            this.labelLock.TabIndex = 44;
            this.labelLock.Text = "请先完成上面验证";
            this.labelLock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxTprofession
            // 
            this.comboBoxTprofession.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxTprofession.FormattingEnabled = true;
            this.comboBoxTprofession.Items.AddRange(new object[] {
            "体育",
            "计算机",
            "数学",
            "化学"});
            this.comboBoxTprofession.Location = new System.Drawing.Point(145, 215);
            this.comboBoxTprofession.Name = "comboBoxTprofession";
            this.comboBoxTprofession.Size = new System.Drawing.Size(277, 24);
            this.comboBoxTprofession.TabIndex = 45;
            // 
            // FormTeaUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(516, 456);
            this.Controls.Add(this.labelLock);
            this.Controls.Add(this.comboBoxTprofession);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.comboBoxSbanji);
            this.Controls.Add(this.textBoxTpwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxTname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelSname);
            this.Controls.Add(this.labelidTip);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.label1);
            this.EffectCaption = CCWin.TitleType.Title;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormTeaUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更新教师数据";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTeaUpdate_FormClosing);
            this.Load += new System.EventHandler(this.FormTeaUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelidTip;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSbanji;
        private System.Windows.Forms.TextBox textBoxTpwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelSname;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label labelLock;
        private System.Windows.Forms.ComboBox comboBoxTprofession;
    }
}