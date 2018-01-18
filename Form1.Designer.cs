namespace nelke
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.richTextBoxStatus = new System.Windows.Forms.RichTextBox();
            this.dataGridViewInfo = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.Telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GetCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SendCoupon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detail2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GetCode2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SendCoupon2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxStatus
            // 
            this.richTextBoxStatus.Location = new System.Drawing.Point(26, 689);
            this.richTextBoxStatus.Name = "richTextBoxStatus";
            this.richTextBoxStatus.Size = new System.Drawing.Size(1204, 76);
            this.richTextBoxStatus.TabIndex = 41;
            this.richTextBoxStatus.Text = "";
            // 
            // dataGridViewInfo
            // 
            this.dataGridViewInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Telephone,
            this.Login,
            this.Detail,
            this.GetCode,
            this.SendCoupon,
            this.Detail2,
            this.GetCode2,
            this.SendCoupon2});
            this.dataGridViewInfo.Location = new System.Drawing.Point(27, 131);
            this.dataGridViewInfo.Name = "dataGridViewInfo";
            this.dataGridViewInfo.RowTemplate.Height = 30;
            this.dataGridViewInfo.Size = new System.Drawing.Size(1204, 527);
            this.dataGridViewInfo.TabIndex = 40;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 62);
            this.button1.TabIndex = 39;
            this.button1.Text = "运行";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Telephone
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Telephone.DefaultCellStyle = dataGridViewCellStyle1;
            this.Telephone.HeaderText = "Telephone";
            this.Telephone.Name = "Telephone";
            this.Telephone.ReadOnly = true;
            // 
            // Login
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Login.DefaultCellStyle = dataGridViewCellStyle2;
            this.Login.HeaderText = "登录";
            this.Login.Name = "Login";
            this.Login.ReadOnly = true;
            this.Login.Width = 120;
            // 
            // Detail
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Detail.DefaultCellStyle = dataGridViewCellStyle3;
            this.Detail.HeaderText = "Detail";
            this.Detail.Name = "Detail";
            this.Detail.ReadOnly = true;
            this.Detail.Width = 120;
            // 
            // GetCode
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GetCode.DefaultCellStyle = dataGridViewCellStyle4;
            this.GetCode.HeaderText = "GetCode";
            this.GetCode.Name = "GetCode";
            this.GetCode.ReadOnly = true;
            this.GetCode.Width = 120;
            // 
            // SendCoupon
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SendCoupon.DefaultCellStyle = dataGridViewCellStyle5;
            this.SendCoupon.HeaderText = "SendCoupon";
            this.SendCoupon.Name = "SendCoupon";
            this.SendCoupon.ReadOnly = true;
            this.SendCoupon.Width = 120;
            // 
            // Detail2
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Detail2.DefaultCellStyle = dataGridViewCellStyle6;
            this.Detail2.HeaderText = "Detail2";
            this.Detail2.Name = "Detail2";
            this.Detail2.ReadOnly = true;
            this.Detail2.Width = 120;
            // 
            // GetCode2
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GetCode2.DefaultCellStyle = dataGridViewCellStyle7;
            this.GetCode2.HeaderText = "GetCode2";
            this.GetCode2.Name = "GetCode2";
            this.GetCode2.ReadOnly = true;
            this.GetCode2.Width = 120;
            // 
            // SendCoupon2
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SendCoupon2.DefaultCellStyle = dataGridViewCellStyle8;
            this.SendCoupon2.HeaderText = "SendCoupon2";
            this.SendCoupon2.Name = "SendCoupon2";
            this.SendCoupon2.ReadOnly = true;
            this.SendCoupon2.Width = 120;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 798);
            this.Controls.Add(this.richTextBoxStatus);
            this.Controls.Add(this.dataGridViewInfo);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxStatus;
        private System.Windows.Forms.DataGridView dataGridViewInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn GetCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SendCoupon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detail2;
        private System.Windows.Forms.DataGridViewTextBoxColumn GetCode2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SendCoupon2;
    }
}

