namespace IndustrialUpperComputer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            cmbCombox = new ComboBox();
            cmbProtocol = new ComboBox();
            txtBaudRate = new TextBox();
            txtPort = new TextBox();
            txtIP = new TextBox();
            lblBaudRate = new Label();
            lblSerialPort = new Label();
            lblPort = new Label();
            lblIP = new Label();
            groupBox2 = new GroupBox();
            lblInput = new Label();
            lblShow = new Label();
            txtInput = new TextBox();
            txtShow = new TextBox();
            btnConnect = new Button();
            btnSend = new Button();
            btnQuery = new Button();
            btnClose = new Button();
            lblStatusText = new Label();
            lblstatus = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbCombox);
            groupBox1.Controls.Add(cmbProtocol);
            groupBox1.Controls.Add(txtBaudRate);
            groupBox1.Controls.Add(txtPort);
            groupBox1.Controls.Add(txtIP);
            groupBox1.Controls.Add(lblBaudRate);
            groupBox1.Controls.Add(lblSerialPort);
            groupBox1.Controls.Add(lblPort);
            groupBox1.Controls.Add(lblIP);
            groupBox1.Location = new Point(24, 31);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(765, 139);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "设备连接栏";
            // 
            // cmbCombox
            // 
            cmbCombox.Enabled = false;
            cmbCombox.FormattingEnabled = true;
            cmbCombox.Location = new Point(316, 92);
            cmbCombox.Name = "cmbCombox";
            cmbCombox.Size = new Size(158, 28);
            cmbCombox.TabIndex = 9;
            // 
            // cmbProtocol
            // 
            cmbProtocol.FormattingEnabled = true;
            cmbProtocol.Items.AddRange(new object[] { "TCP", "Serial" });
            cmbProtocol.Location = new Point(59, 34);
            cmbProtocol.Name = "cmbProtocol";
            cmbProtocol.Size = new Size(151, 28);
            cmbProtocol.TabIndex = 8;
            cmbProtocol.Text = "TCP";
            // 
            // txtBaudRate
            // 
            txtBaudRate.Enabled = false;
            txtBaudRate.Location = new Point(569, 93);
            txtBaudRate.Name = "txtBaudRate";
            txtBaudRate.Size = new Size(159, 27);
            txtBaudRate.TabIndex = 7;
            txtBaudRate.Text = "9600";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(569, 37);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(159, 27);
            txtPort.TabIndex = 5;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(315, 37);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(159, 27);
            txtIP.TabIndex = 4;
            // 
            // lblBaudRate
            // 
            lblBaudRate.AutoSize = true;
            lblBaudRate.Location = new Point(510, 93);
            lblBaudRate.Name = "lblBaudRate";
            lblBaudRate.Size = new Size(54, 20);
            lblBaudRate.TabIndex = 3;
            lblBaudRate.Text = "波特率";
            // 
            // lblSerialPort
            // 
            lblSerialPort.AutoSize = true;
            lblSerialPort.Location = new Point(256, 93);
            lblSerialPort.Name = "lblSerialPort";
            lblSerialPort.Size = new Size(54, 20);
            lblSerialPort.TabIndex = 2;
            lblSerialPort.Text = "串口号";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(510, 37);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(54, 20);
            lblPort.TabIndex = 1;
            lblPort.Text = "端口号";
            // 
            // lblIP
            // 
            lblIP.AutoSize = true;
            lblIP.Location = new Point(256, 37);
            lblIP.Name = "lblIP";
            lblIP.Size = new Size(52, 20);
            lblIP.TabIndex = 0;
            lblIP.Text = "IP地址";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblInput);
            groupBox2.Controls.Add(lblShow);
            groupBox2.Controls.Add(txtInput);
            groupBox2.Controls.Add(txtShow);
            groupBox2.Location = new Point(91, 176);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(698, 228);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "数据收发与追溯";
            // 
            // lblInput
            // 
            lblInput.AutoSize = true;
            lblInput.Location = new Point(30, 176);
            lblInput.Name = "lblInput";
            lblInput.Size = new Size(54, 20);
            lblInput.TabIndex = 12;
            lblInput.Text = "发送框";
            // 
            // lblShow
            // 
            lblShow.AutoSize = true;
            lblShow.Location = new Point(30, 26);
            lblShow.Name = "lblShow";
            lblShow.Size = new Size(54, 20);
            lblShow.TabIndex = 11;
            lblShow.Text = "显示框";
            // 
            // txtInput
            // 
            txtInput.Location = new Point(89, 176);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.ScrollBars = ScrollBars.Vertical;
            txtInput.Size = new Size(578, 35);
            txtInput.TabIndex = 10;
            // 
            // txtShow
            // 
            txtShow.Location = new Point(89, 26);
            txtShow.Multiline = true;
            txtShow.Name = "txtShow";
            txtShow.ScrollBars = ScrollBars.Vertical;
            txtShow.Size = new Size(578, 132);
            txtShow.TabIndex = 9;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(91, 410);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(94, 29);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "连接";
            btnConnect.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(257, 410);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 3;
            btnSend.Text = "发送";
            btnSend.UseVisualStyleBackColor = true;
            // 
            // btnQuery
            // 
            btnQuery.Location = new Point(502, 410);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(94, 29);
            btnQuery.TabIndex = 4;
            btnQuery.Text = "回溯";
            btnQuery.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(657, 410);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 5;
            btnClose.Text = "关闭";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // lblStatusText
            // 
            lblStatusText.AutoSize = true;
            lblStatusText.Location = new Point(12, 247);
            lblStatusText.Name = "lblStatusText";
            lblStatusText.Size = new Size(54, 20);
            lblStatusText.TabIndex = 6;
            lblStatusText.Text = "未连接";
            // 
            // lblstatus
            // 
            lblstatus.BackColor = Color.Red;
            lblstatus.BorderStyle = BorderStyle.FixedSingle;
            lblstatus.Location = new Point(33, 277);
            lblstatus.Name = "lblstatus";
            lblstatus.Size = new Size(25, 25);
            lblstatus.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblstatus);
            Controls.Add(lblStatusText);
            Controls.Add(btnClose);
            Controls.Add(btnQuery);
            Controls.Add(btnSend);
            Controls.Add(btnConnect);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtBaudRate;
        private TextBox txtPort;
        private TextBox txtIP;
        private Label lblBaudRate;
        private Label lblSerialPort;
        private Label lblPort;
        private Label lblIP;
        private GroupBox groupBox2;
        private Button btnConnect;
        private Button btnSend;
        private Button btnQuery;
        private Button btnClose;
        private ComboBox cmbProtocol;
        private TextBox txtInput;
        private TextBox txtShow;
        private Label lblInput;
        private Label lblShow;
        private Label lblStatusText;
        private Label lblstatus;
        private ComboBox cmbCombox;
    }
}
