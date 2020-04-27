namespace ADO_Demos
{
    partial class FormClassInfoInsert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClassInfoInsert));
            this.textBoxCname = new System.Windows.Forms.TextBox();
            this.labelCname = new System.Windows.Forms.Label();
            this.labelTips = new System.Windows.Forms.Label();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.labelHelp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxCname
            // 
            this.textBoxCname.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxCname.Location = new System.Drawing.Point(180, 43);
            this.textBoxCname.Name = "textBoxCname";
            this.textBoxCname.Size = new System.Drawing.Size(277, 26);
            this.textBoxCname.TabIndex = 3;
            this.textBoxCname.TextChanged += new System.EventHandler(this.TextBoxCname_TextChanged);
            // 
            // labelCname
            // 
            this.labelCname.AutoSize = true;
            this.labelCname.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCname.Location = new System.Drawing.Point(70, 46);
            this.labelCname.Name = "labelCname";
            this.labelCname.Size = new System.Drawing.Size(120, 16);
            this.labelCname.TabIndex = 2;
            this.labelCname.Text = "输入班级编号：";
            // 
            // labelTips
            // 
            this.labelTips.AutoSize = true;
            this.labelTips.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTips.Location = new System.Drawing.Point(463, 46);
            this.labelTips.Name = "labelTips";
            this.labelTips.Size = new System.Drawing.Size(104, 16);
            this.labelTips.TabIndex = 4;
            this.labelTips.Text = "(格式：S100)";
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(180, 147);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(277, 36);
            this.buttonInsert.TabIndex = 6;
            this.buttonInsert.Text = "添 加";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.ButtonInsert_Click);
            // 
            // labelHelp
            // 
            this.labelHelp.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelHelp.Location = new System.Drawing.Point(70, 81);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(497, 27);
            this.labelHelp.TabIndex = 35;
            this.labelHelp.Text = "请按照格式输入班级编号";
            this.labelHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormClassInfoInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(630, 205);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.labelTips);
            this.Controls.Add(this.textBoxCname);
            this.Controls.Add(this.labelCname);
            this.EffectCaption = CCWin.TitleType.Title;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormClassInfoInsert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加班级数据";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClassInfoInsert_FormClosing);
            this.Load += new System.EventHandler(this.FormClassInfoInsert_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCname;
        private System.Windows.Forms.Label labelCname;
        private System.Windows.Forms.Label labelTips;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Label labelHelp;
    }
}