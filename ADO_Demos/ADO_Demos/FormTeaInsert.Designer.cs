namespace ADO_Demos
{
    partial class FormTeaInsert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTeaInsert));
            this.labelSname = new System.Windows.Forms.Label();
            this.textBoxTname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTpwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.comboBoxSbanji = new System.Windows.Forms.ComboBox();
            this.comboBoxTprofession = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelSname
            // 
            this.labelSname.AutoSize = true;
            this.labelSname.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSname.Location = new System.Drawing.Point(57, 97);
            this.labelSname.Name = "labelSname";
            this.labelSname.Size = new System.Drawing.Size(88, 16);
            this.labelSname.TabIndex = 2;
            this.labelSname.Text = "教室编号：";
            // 
            // textBoxTname
            // 
            this.textBoxTname.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxTname.Location = new System.Drawing.Point(139, 124);
            this.textBoxTname.Name = "textBoxTname";
            this.textBoxTname.Size = new System.Drawing.Size(277, 26);
            this.textBoxTname.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(89, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "姓名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(57, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "课程专业：";
            // 
            // textBoxTpwd
            // 
            this.textBoxTpwd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxTpwd.Location = new System.Drawing.Point(139, 186);
            this.textBoxTpwd.MaxLength = 6;
            this.textBoxTpwd.Name = "textBoxTpwd";
            this.textBoxTpwd.Size = new System.Drawing.Size(277, 26);
            this.textBoxTpwd.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(25, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "教师登录密码：";
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(130, 307);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(214, 36);
            this.buttonInsert.TabIndex = 5;
            this.buttonInsert.Text = "添 加";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.ButtonInsert_Click);
            // 
            // comboBoxSbanji
            // 
            this.comboBoxSbanji.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxSbanji.FormattingEnabled = true;
            this.comboBoxSbanji.Location = new System.Drawing.Point(139, 94);
            this.comboBoxSbanji.Name = "comboBoxSbanji";
            this.comboBoxSbanji.Size = new System.Drawing.Size(277, 24);
            this.comboBoxSbanji.TabIndex = 1;
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
            this.comboBoxTprofession.Location = new System.Drawing.Point(139, 156);
            this.comboBoxTprofession.Name = "comboBoxTprofession";
            this.comboBoxTprofession.Size = new System.Drawing.Size(277, 24);
            this.comboBoxTprofession.TabIndex = 3;
            // 
            // FormTeaInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(470, 377);
            this.Controls.Add(this.comboBoxTprofession);
            this.Controls.Add(this.comboBoxSbanji);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.textBoxTpwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxTname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelSname);
            this.EffectCaption = CCWin.TitleType.Title;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormTeaInsert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加教师数据";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTeaInsert_FormClosing);
            this.Load += new System.EventHandler(this.FormTeaInsert_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelSname;
        private System.Windows.Forms.TextBox textBoxTname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTpwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.ComboBox comboBoxSbanji;
        private System.Windows.Forms.ComboBox comboBoxTprofession;
    }
}