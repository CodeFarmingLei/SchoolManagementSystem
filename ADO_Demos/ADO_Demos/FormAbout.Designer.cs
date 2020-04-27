namespace ADO_Demos
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.labelBanben = new System.Windows.Forms.Label();
            this.labelZuoZhe = new System.Windows.Forms.Label();
            this.labelQW = new System.Windows.Forms.Label();
            this.pictureBoxZuoZhe = new System.Windows.Forms.PictureBox();
            this.labelTip = new System.Windows.Forms.Label();
            this.timerImg = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZuoZhe)).BeginInit();
            this.SuspendLayout();
            // 
            // labelBanben
            // 
            this.labelBanben.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBanben.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelBanben.Location = new System.Drawing.Point(56, 38);
            this.labelBanben.Name = "labelBanben";
            this.labelBanben.Size = new System.Drawing.Size(358, 28);
            this.labelBanben.TabIndex = 0;
            this.labelBanben.Text = "版本号：";
            this.labelBanben.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelZuoZhe
            // 
            this.labelZuoZhe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelZuoZhe.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelZuoZhe.Location = new System.Drawing.Point(56, 75);
            this.labelZuoZhe.Name = "labelZuoZhe";
            this.labelZuoZhe.Size = new System.Drawing.Size(358, 28);
            this.labelZuoZhe.TabIndex = 1;
            this.labelZuoZhe.Text = "开发者：";
            this.labelZuoZhe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelQW
            // 
            this.labelQW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelQW.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelQW.Location = new System.Drawing.Point(56, 112);
            this.labelQW.Name = "labelQW";
            this.labelQW.Size = new System.Drawing.Size(358, 28);
            this.labelQW.TabIndex = 2;
            this.labelQW.Text = "QQ/WeChat：";
            this.labelQW.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxZuoZhe
            // 
            this.pictureBoxZuoZhe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxZuoZhe.Image = global::ADO_Demos.Resource1.ZuoZheimg1;
            this.pictureBoxZuoZhe.Location = new System.Drawing.Point(156, 195);
            this.pictureBoxZuoZhe.Name = "pictureBoxZuoZhe";
            this.pictureBoxZuoZhe.Size = new System.Drawing.Size(150, 150);
            this.pictureBoxZuoZhe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxZuoZhe.TabIndex = 3;
            this.pictureBoxZuoZhe.TabStop = false;
            this.pictureBoxZuoZhe.Click += new System.EventHandler(this.pictureBoxZuoZhe_Click);
            // 
            // labelTip
            // 
            this.labelTip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTip.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTip.Location = new System.Drawing.Point(56, 348);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(358, 28);
            this.labelTip.TabIndex = 4;
            this.labelTip.Text = "-----感谢您的使用-----";
            this.labelTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerImg
            // 
            this.timerImg.Enabled = true;
            this.timerImg.Interval = 600;
            this.timerImg.Tick += new System.EventHandler(this.timerImg_Tick);
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(470, 407);
            this.Controls.Add(this.labelTip);
            this.Controls.Add(this.pictureBoxZuoZhe);
            this.Controls.Add(this.labelQW);
            this.Controls.Add(this.labelZuoZhe);
            this.Controls.Add(this.labelBanben);
            this.EffectCaption = CCWin.TitleType.Title;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关于程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAbout_FormClosing);
            this.Load += new System.EventHandler(this.FormAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZuoZhe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelBanben;
        private System.Windows.Forms.Label labelZuoZhe;
        private System.Windows.Forms.Label labelQW;
        private System.Windows.Forms.PictureBox pictureBoxZuoZhe;
        private System.Windows.Forms.Label labelTip;
        private System.Windows.Forms.Timer timerImg;
    }
}