namespace WindowsFormsApp3
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblInputText = new System.Windows.Forms.Label();
            this.lblShowText = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtShow = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnSelectImg = new System.Windows.Forms.Button();
            this.btnLearnModel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(131, 359);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(255, 359);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(554, 359);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(70, 55);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(68, 15);
            this.lblIP.TabIndex = 3;
            this.lblIP.Text = "IP地址：";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(435, 55);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(67, 15);
            this.lblPort.TabIndex = 6;
            this.lblPort.Text = "端口号：";
            // 
            // lblInputText
            // 
            this.lblInputText.AutoSize = true;
            this.lblInputText.Location = new System.Drawing.Point(58, 272);
            this.lblInputText.Name = "lblInputText";
            this.lblInputText.Size = new System.Drawing.Size(67, 15);
            this.lblInputText.TabIndex = 7;
            this.lblInputText.Text = "发送窗口";
            // 
            // lblShowText
            // 
            this.lblShowText.AutoSize = true;
            this.lblShowText.Location = new System.Drawing.Point(58, 124);
            this.lblShowText.Name = "lblShowText";
            this.lblShowText.Size = new System.Drawing.Size(67, 15);
            this.lblShowText.TabIndex = 8;
            this.lblShowText.Text = "显示窗口";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(131, 52);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(133, 25);
            this.txtIP.TabIndex = 9;
            this.txtIP.Text = "192.168.1.40";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(496, 52);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(133, 25);
            this.txtPort.TabIndex = 12;
            this.txtPort.Text = "8000";
            // 
            // txtShow
            // 
            this.txtShow.Location = new System.Drawing.Point(131, 110);
            this.txtShow.Multiline = true;
            this.txtShow.Name = "txtShow";
            this.txtShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtShow.Size = new System.Drawing.Size(498, 133);
            this.txtShow.TabIndex = 13;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(131, 269);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(498, 49);
            this.txtInput.TabIndex = 14;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(668, 120);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 15;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnSelectImg
            // 
            this.btnSelectImg.Location = new System.Drawing.Point(668, 164);
            this.btnSelectImg.Name = "btnSelectImg";
            this.btnSelectImg.Size = new System.Drawing.Size(75, 23);
            this.btnSelectImg.TabIndex = 16;
            this.btnSelectImg.Text = "选择图片";
            this.btnSelectImg.UseVisualStyleBackColor = true;
            this.btnSelectImg.Click += new System.EventHandler(this.btnSelectImg_Click);
            // 
            // btnLearnModel
            // 
            this.btnLearnModel.Location = new System.Drawing.Point(668, 207);
            this.btnLearnModel.Name = "btnLearnModel";
            this.btnLearnModel.Size = new System.Drawing.Size(75, 23);
            this.btnLearnModel.TabIndex = 17;
            this.btnLearnModel.Text = "学习模板";
            this.btnLearnModel.UseVisualStyleBackColor = true;
            this.btnLearnModel.Click += new System.EventHandler(this.btnLearnModel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLearnModel);
            this.Controls.Add(this.btnSelectImg);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.txtShow);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.lblShowText);
            this.Controls.Add(this.lblInputText);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblInputText;
        private System.Windows.Forms.Label lblShowText;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtShow;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnSelectImg;
        private System.Windows.Forms.Button btnLearnModel;
    }
}

