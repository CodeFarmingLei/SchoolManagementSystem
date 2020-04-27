namespace ADO_Demos
{
    partial class FormPwdUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPwdUpdate));
            this.textBoxThisPwd = new System.Windows.Forms.TextBox();
            this.labelThisPwd = new System.Windows.Forms.Label();
            this.textBoxNewPwd1 = new System.Windows.Forms.TextBox();
            this.labelNewPwd1 = new System.Windows.Forms.Label();
            this.textBoxNewPwd2 = new System.Windows.Forms.TextBox();
            this.labelNewPwd2 = new System.Windows.Forms.Label();
            this.buttonUpdateOK = new System.Windows.Forms.Button();
            this.labelidTip = new System.Windows.Forms.Label();
            this.labelThisIdTip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxThisPwd
            // 
            this.textBoxThisPwd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxThisPwd.Location = new System.Drawing.Point(212, 52);
            this.textBoxThisPwd.Name = "textBoxThisPwd";
            this.textBoxThisPwd.Size = new System.Drawing.Size(277, 26);
            this.textBoxThisPwd.TabIndex = 5;
            this.textBoxThisPwd.UseSystemPasswordChar = true;
            this.textBoxThisPwd.TextChanged += new System.EventHandler(this.TextBoxThisPwd_TextChanged);
            // 
            // labelThisPwd
            // 
            this.labelThisPwd.AutoSize = true;
            this.labelThisPwd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelThisPwd.Location = new System.Drawing.Point(98, 55);
            this.labelThisPwd.Name = "labelThisPwd";
            this.labelThisPwd.Size = new System.Drawing.Size(120, 16);
            this.labelThisPwd.TabIndex = 6;
            this.labelThisPwd.Text = "请输入旧密码：";
            // 
            // textBoxNewPwd1
            // 
            this.textBoxNewPwd1.Enabled = false;
            this.textBoxNewPwd1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxNewPwd1.Location = new System.Drawing.Point(212, 121);
            this.textBoxNewPwd1.Name = "textBoxNewPwd1";
            this.textBoxNewPwd1.Size = new System.Drawing.Size(277, 26);
            this.textBoxNewPwd1.TabIndex = 7;
            this.textBoxNewPwd1.UseSystemPasswordChar = true;
            // 
            // labelNewPwd1
            // 
            this.labelNewPwd1.AutoSize = true;
            this.labelNewPwd1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNewPwd1.Location = new System.Drawing.Point(98, 124);
            this.labelNewPwd1.Name = "labelNewPwd1";
            this.labelNewPwd1.Size = new System.Drawing.Size(120, 16);
            this.labelNewPwd1.TabIndex = 8;
            this.labelNewPwd1.Text = "请输入新密码：";
            // 
            // textBoxNewPwd2
            // 
            this.textBoxNewPwd2.Enabled = false;
            this.textBoxNewPwd2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxNewPwd2.Location = new System.Drawing.Point(212, 163);
            this.textBoxNewPwd2.Name = "textBoxNewPwd2";
            this.textBoxNewPwd2.Size = new System.Drawing.Size(277, 26);
            this.textBoxNewPwd2.TabIndex = 9;
            this.textBoxNewPwd2.UseSystemPasswordChar = true;
            // 
            // labelNewPwd2
            // 
            this.labelNewPwd2.AutoSize = true;
            this.labelNewPwd2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNewPwd2.Location = new System.Drawing.Point(66, 166);
            this.labelNewPwd2.Name = "labelNewPwd2";
            this.labelNewPwd2.Size = new System.Drawing.Size(152, 16);
            this.labelNewPwd2.TabIndex = 10;
            this.labelNewPwd2.Text = "请再次输入新密码：";
            // 
            // buttonUpdateOK
            // 
            this.buttonUpdateOK.Location = new System.Drawing.Point(149, 240);
            this.buttonUpdateOK.Name = "buttonUpdateOK";
            this.buttonUpdateOK.Size = new System.Drawing.Size(257, 36);
            this.buttonUpdateOK.TabIndex = 11;
            this.buttonUpdateOK.Text = "确 定 修 改";
            this.buttonUpdateOK.UseVisualStyleBackColor = true;
            this.buttonUpdateOK.Click += new System.EventHandler(this.ButtonUpdateOK_Click);
            // 
            // labelidTip
            // 
            this.labelidTip.AutoSize = true;
            this.labelidTip.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelidTip.Location = new System.Drawing.Point(209, 81);
            this.labelidTip.Name = "labelidTip";
            this.labelidTip.Size = new System.Drawing.Size(144, 16);
            this.labelidTip.TabIndex = 32;
            this.labelidTip.Text = "请优先输入旧密码";
            // 
            // labelThisIdTip
            // 
            this.labelThisIdTip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelThisIdTip.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelThisIdTip.Location = new System.Drawing.Point(12, 298);
            this.labelThisIdTip.Name = "labelThisIdTip";
            this.labelThisIdTip.Size = new System.Drawing.Size(544, 25);
            this.labelThisIdTip.TabIndex = 33;
            this.labelThisIdTip.Text = "您的ID是：";
            this.labelThisIdTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormPwdUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(568, 332);
            this.Controls.Add(this.labelThisIdTip);
            this.Controls.Add(this.labelidTip);
            this.Controls.Add(this.buttonUpdateOK);
            this.Controls.Add(this.textBoxNewPwd2);
            this.Controls.Add(this.labelNewPwd2);
            this.Controls.Add(this.textBoxNewPwd1);
            this.Controls.Add(this.labelNewPwd1);
            this.Controls.Add(this.textBoxThisPwd);
            this.Controls.Add(this.labelThisPwd);
            this.EffectCaption = CCWin.TitleType.Title;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormPwdUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更改登录密码";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPwdUpdate_FormClosing);
            this.Load += new System.EventHandler(this.FormStuPwdUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxThisPwd;
        private System.Windows.Forms.Label labelThisPwd;
        private System.Windows.Forms.TextBox textBoxNewPwd1;
        private System.Windows.Forms.Label labelNewPwd1;
        private System.Windows.Forms.TextBox textBoxNewPwd2;
        private System.Windows.Forms.Label labelNewPwd2;
        private System.Windows.Forms.Button buttonUpdateOK;
        private System.Windows.Forms.Label labelidTip;
        private System.Windows.Forms.Label labelThisIdTip;
    }
}