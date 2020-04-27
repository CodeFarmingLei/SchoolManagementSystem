namespace ADO_Demos
{
    partial class FormCourseInsert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCourseInsert));
            this.labelCtid = new System.Windows.Forms.Label();
            this.textBoxCname = new System.Windows.Forms.TextBox();
            this.labelCname = new System.Windows.Forms.Label();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.comboBoxCtid = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelCtid
            // 
            this.labelCtid.AutoSize = true;
            this.labelCtid.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCtid.Location = new System.Drawing.Point(51, 100);
            this.labelCtid.Name = "labelCtid";
            this.labelCtid.Size = new System.Drawing.Size(88, 16);
            this.labelCtid.TabIndex = 2;
            this.labelCtid.Text = "教师编号：";
            // 
            // textBoxCname
            // 
            this.textBoxCname.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxCname.Location = new System.Drawing.Point(128, 129);
            this.textBoxCname.Name = "textBoxCname";
            this.textBoxCname.Size = new System.Drawing.Size(277, 26);
            this.textBoxCname.TabIndex = 2;
            // 
            // labelCname
            // 
            this.labelCname.AutoSize = true;
            this.labelCname.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCname.Location = new System.Drawing.Point(51, 132);
            this.labelCname.Name = "labelCname";
            this.labelCname.Size = new System.Drawing.Size(88, 16);
            this.labelCname.TabIndex = 4;
            this.labelCname.Text = "课程名称：";
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(128, 297);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(214, 36);
            this.buttonInsert.TabIndex = 3;
            this.buttonInsert.Text = "添 加";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.ButtonInsert_Click);
            // 
            // comboBoxCtid
            // 
            this.comboBoxCtid.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxCtid.FormattingEnabled = true;
            this.comboBoxCtid.Location = new System.Drawing.Point(128, 97);
            this.comboBoxCtid.Name = "comboBoxCtid";
            this.comboBoxCtid.Size = new System.Drawing.Size(277, 24);
            this.comboBoxCtid.TabIndex = 1;
            // 
            // FormCourseInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(470, 377);
            this.Controls.Add(this.comboBoxCtid);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.textBoxCname);
            this.Controls.Add(this.labelCname);
            this.Controls.Add(this.labelCtid);
            this.EffectCaption = CCWin.TitleType.Title;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormCourseInsert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加课程数据";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCourseInsert_FormClosing);
            this.Load += new System.EventHandler(this.FormCourseInsert_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelCtid;
        private System.Windows.Forms.TextBox textBoxCname;
        private System.Windows.Forms.Label labelCname;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.ComboBox comboBoxCtid;
    }
}