namespace ADO_Demos
{
    partial class FormNew
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNew));
            this.buttonDataSet = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonInsertAdmin = new System.Windows.Forms.Button();
            this.buttonTruncate = new System.Windows.Forms.Button();
            this.buttonInsertType = new System.Windows.Forms.Button();
            this.toolTipTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonATDataSet = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBoxSysUser = new System.Windows.Forms.GroupBox();
            this.skinDataGridView1 = new CCWin.SkinControl.SkinDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.skinButtonSql = new CCWin.SkinControl.SkinButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.saveFileDialogSQL = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxSysUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinDataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDataSet
            // 
            this.buttonDataSet.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonDataSet.Location = new System.Drawing.Point(6, 25);
            this.buttonDataSet.Name = "buttonDataSet";
            this.buttonDataSet.Size = new System.Drawing.Size(236, 33);
            this.buttonDataSet.TabIndex = 0;
            this.buttonDataSet.Text = "DataReader or List";
            this.toolTipTip.SetToolTip(this.buttonDataSet, "读取数据库数据填充到List集合\r\n\r\n提示已填充到List内的数据共包括多少行。");
            this.buttonDataSet.UseVisualStyleBackColor = true;
            this.buttonDataSet.Click += new System.EventHandler(this.buttonDataSet_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonInsertAdmin);
            this.groupBox1.Controls.Add(this.buttonTruncate);
            this.groupBox1.Controls.Add(this.buttonInsertType);
            this.groupBox1.Controls.Add(this.buttonDataSet);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(7, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 183);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库功能测试";
            // 
            // buttonInsertAdmin
            // 
            this.buttonInsertAdmin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonInsertAdmin.Location = new System.Drawing.Point(6, 64);
            this.buttonInsertAdmin.Name = "buttonInsertAdmin";
            this.buttonInsertAdmin.Size = new System.Drawing.Size(236, 33);
            this.buttonInsertAdmin.TabIndex = 3;
            this.buttonInsertAdmin.Text = "插入一条管理员数据";
            this.toolTipTip.SetToolTip(this.buttonInsertAdmin, "内容包括一条Admin管理员数据加15条测试数据。");
            this.buttonInsertAdmin.UseVisualStyleBackColor = true;
            this.buttonInsertAdmin.Click += new System.EventHandler(this.buttonInsertAdmin_Click);
            // 
            // buttonTruncate
            // 
            this.buttonTruncate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonTruncate.Location = new System.Drawing.Point(6, 103);
            this.buttonTruncate.Name = "buttonTruncate";
            this.buttonTruncate.Size = new System.Drawing.Size(236, 33);
            this.buttonTruncate.TabIndex = 2;
            this.buttonTruncate.Text = "清空数据表数据";
            this.toolTipTip.SetToolTip(this.buttonTruncate, "内容包括一条Admin管理员数据加15条测试数据。");
            this.buttonTruncate.UseVisualStyleBackColor = true;
            this.buttonTruncate.Click += new System.EventHandler(this.buttonTruncate_Click);
            // 
            // buttonInsertType
            // 
            this.buttonInsertType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonInsertType.Location = new System.Drawing.Point(6, 142);
            this.buttonInsertType.Name = "buttonInsertType";
            this.buttonInsertType.Size = new System.Drawing.Size(236, 33);
            this.buttonInsertType.TabIndex = 1;
            this.buttonInsertType.Text = "一键批量插入测试数据";
            this.toolTipTip.SetToolTip(this.buttonInsertType, "内容包括一条Admin管理员数据加15条测试数据。");
            this.buttonInsertType.UseVisualStyleBackColor = true;
            this.buttonInsertType.Click += new System.EventHandler(this.buttonInsertType_Click);
            // 
            // buttonATDataSet
            // 
            this.buttonATDataSet.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonATDataSet.Location = new System.Drawing.Point(6, 25);
            this.buttonATDataSet.Name = "buttonATDataSet";
            this.buttonATDataSet.Size = new System.Drawing.Size(236, 33);
            this.buttonATDataSet.TabIndex = 0;
            this.buttonATDataSet.Text = "获取Studnet表总行数";
            this.toolTipTip.SetToolTip(this.buttonATDataSet, "读取数据库数据填充到List集合\r\n\r\n提示已填充到List和DateTable内的数据共包括多少行。");
            this.buttonATDataSet.UseVisualStyleBackColor = true;
            this.buttonATDataSet.Click += new System.EventHandler(this.buttonATDataSet_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonATDataSet);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(7, 220);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 116);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ADOTools 工具类测试";
            // 
            // groupBoxSysUser
            // 
            this.groupBoxSysUser.Controls.Add(this.skinDataGridView1);
            this.groupBoxSysUser.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxSysUser.Location = new System.Drawing.Point(261, 31);
            this.groupBoxSysUser.Name = "groupBoxSysUser";
            this.groupBoxSysUser.Size = new System.Drawing.Size(469, 464);
            this.groupBoxSysUser.TabIndex = 3;
            this.groupBoxSysUser.TabStop = false;
            this.groupBoxSysUser.Text = "管理员用户账户信息一览";
            // 
            // skinDataGridView1
            // 
            this.skinDataGridView1.AllowUserToAddRows = false;
            this.skinDataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.skinDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this.skinDataGridView1.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.skinDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.skinDataGridView1.ColumnFont = null;
            this.skinDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle26.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.skinDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.skinDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.skinDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.skinDataGridView1.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.skinDataGridView1.DefaultCellStyle = dataGridViewCellStyle27;
            this.skinDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinDataGridView1.EnableHeadersVisualStyles = false;
            this.skinDataGridView1.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.skinDataGridView1.HeadFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinDataGridView1.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.skinDataGridView1.Location = new System.Drawing.Point(3, 22);
            this.skinDataGridView1.Name = "skinDataGridView1";
            this.skinDataGridView1.ReadOnly = true;
            this.skinDataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.skinDataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.skinDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle28;
            this.skinDataGridView1.RowTemplate.Height = 23;
            this.skinDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.skinDataGridView1.Size = new System.Drawing.Size(463, 439);
            this.skinDataGridView1.TabIndex = 0;
            this.skinDataGridView1.TitleBack = null;
            this.skinDataGridView1.TitleBackColorBegin = System.Drawing.Color.White;
            this.skinDataGridView1.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(196)))), ((int)(((byte)(242)))));
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "uid";
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 130;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ucode";
            this.Column2.HeaderText = "账号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 130;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "upwd";
            this.Column3.HeaderText = "密码";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 130;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.skinButtonSql);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(7, 342);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(248, 153);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "其他功能";
            // 
            // skinButtonSql
            // 
            this.skinButtonSql.BackColor = System.Drawing.Color.Transparent;
            this.skinButtonSql.BaseColor = System.Drawing.SystemColors.ActiveCaption;
            this.skinButtonSql.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButtonSql.DownBack = null;
            this.skinButtonSql.Location = new System.Drawing.Point(6, 25);
            this.skinButtonSql.MouseBack = null;
            this.skinButtonSql.Name = "skinButtonSql";
            this.skinButtonSql.NormlBack = null;
            this.skinButtonSql.Size = new System.Drawing.Size(236, 38);
            this.skinButtonSql.TabIndex = 0;
            this.skinButtonSql.Text = "保存项目所需SQL脚本到本地";
            this.skinButtonSql.UseVisualStyleBackColor = false;
            this.skinButtonSql.Click += new System.EventHandler(this.SkinButtonSql_Click);
            // 
            // saveFileDialogSQL
            // 
            this.saveFileDialogSQL.DefaultExt = "sql";
            this.saveFileDialogSQL.FileName = "Student测试用数据库";
            this.saveFileDialogSQL.InitialDirectory = "E:\\";
            this.saveFileDialogSQL.Title = "请选择SQL文件的保存路径";
            // 
            // FormNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(739, 506);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBoxSysUser);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.EffectCaption = CCWin.TitleType.Title;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "功能测试";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNew_FormClosing);
            this.Load += new System.EventHandler(this.FormNew_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBoxSysUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinDataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDataSet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonInsertType;
        private System.Windows.Forms.ToolTip toolTipTip;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonATDataSet;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button buttonTruncate;
        private System.Windows.Forms.Button buttonInsertAdmin;
        private System.Windows.Forms.GroupBox groupBoxSysUser;
        private CCWin.SkinControl.SkinDataGridView skinDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.GroupBox groupBox3;
        private CCWin.SkinControl.SkinButton skinButtonSql;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSQL;
    }
}