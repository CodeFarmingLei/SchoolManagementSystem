namespace ADO_Demos
{
    partial class FormSCMappingInsert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSCMappingInsert));
            this.comboBoxSid = new System.Windows.Forms.ComboBox();
            this.labelSid = new System.Windows.Forms.Label();
            this.comboBoxCid = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.numericUpDownScore = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScore)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSid
            // 
            this.comboBoxSid.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxSid.FormattingEnabled = true;
            this.comboBoxSid.Location = new System.Drawing.Point(127, 66);
            this.comboBoxSid.Name = "comboBoxSid";
            this.comboBoxSid.Size = new System.Drawing.Size(277, 24);
            this.comboBoxSid.TabIndex = 1;
            // 
            // labelSid
            // 
            this.labelSid.AutoSize = true;
            this.labelSid.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSid.Location = new System.Drawing.Point(45, 69);
            this.labelSid.Name = "labelSid";
            this.labelSid.Size = new System.Drawing.Size(88, 16);
            this.labelSid.TabIndex = 4;
            this.labelSid.Text = "学生编号：";
            // 
            // comboBoxCid
            // 
            this.comboBoxCid.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxCid.FormattingEnabled = true;
            this.comboBoxCid.Location = new System.Drawing.Point(127, 96);
            this.comboBoxCid.Name = "comboBoxCid";
            this.comboBoxCid.Size = new System.Drawing.Size(277, 24);
            this.comboBoxCid.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(45, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "课程编号：";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelScore.Location = new System.Drawing.Point(77, 129);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(56, 16);
            this.labelScore.TabIndex = 8;
            this.labelScore.Text = "分数：";
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(127, 276);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(214, 36);
            this.buttonInsert.TabIndex = 4;
            this.buttonInsert.Text = "添 加";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.ButtonInsert_Click);
            // 
            // numericUpDownScore
            // 
            this.numericUpDownScore.BackColor = System.Drawing.Color.White;
            this.numericUpDownScore.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDownScore.Location = new System.Drawing.Point(127, 127);
            this.numericUpDownScore.Name = "numericUpDownScore";
            this.numericUpDownScore.Size = new System.Drawing.Size(277, 26);
            this.numericUpDownScore.TabIndex = 3;
            // 
            // FormSCMappingInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(470, 377);
            this.Controls.Add(this.numericUpDownScore);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.comboBoxCid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxSid);
            this.Controls.Add(this.labelSid);
            this.EffectCaption = CCWin.TitleType.Title;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSCMappingInsert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "录入学生成绩数据";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSCMappingInsert_FormClosing);
            this.Load += new System.EventHandler(this.FormSCMappingInsert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSid;
        private System.Windows.Forms.Label labelSid;
        private System.Windows.Forms.ComboBox comboBoxCid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.NumericUpDown numericUpDownScore;
    }
}