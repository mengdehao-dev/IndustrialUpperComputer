namespace IndustrialUpperComputer
{
    public partial class Form1 : Form
    {
        DeviceController _device;
        
        public Form1()
        {
            InitializeComponent();
            SetUiState(false);
            _device = new DeviceController();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ip = txtIP.Text;
            int port = int.Parse(txtPort.Text);

            if (_device.TcpConnect(ip, port))
            {
                _device.OnDataReceived -= AppendTextToShow;
                _device.NetDisconnected -= OnNetworkBroken;
                _device.OnDataReceived += AppendTextToShow;
                _device.NetDisconnected += OnNetworkBroken;
                SetUiState(true);
                _device.StartReceiving();
                txtShow.AppendText("【系统】连接成功！" + Environment.NewLine);
            }
            else
            {
                MessageBox.Show("连接失败");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string msg = txtInput.Text;
            
            if (string.IsNullOrEmpty(msg))
            {
                MessageBox.Show("请输入信息");
                return;
            }
            if (!_device.IsConnect())
            {
                MessageBox.Show("请先进行连接");
                return;
            }
            if (_device.TcpSend(msg))
            {
                txtInput.Text = "";
                txtShow.AppendText("【客户端】" + msg + Environment.NewLine);     //-------------------主UI显示的行数有限，需要满限定行清除，防止内存爆炸
            }
            else
            {
                MessageBox.Show("发送失败");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _device.TcpClose();
            SetUiState(false);
            _device.OnDataReceived -= AppendTextToShow;
            _device.NetDisconnected -= OnNetworkBroken;
        }

        private void AppendTextToShow(string msg)
        {
            this.Invoke((MethodInvoker)delegate { txtShow.AppendText("【服务端】" + msg + Environment.NewLine); });
        }
        private void OnNetworkBroken()
        {
            
            _device.OnDataReceived -= AppendTextToShow;
            _device.NetDisconnected -= OnNetworkBroken;
            this.Invoke((MethodInvoker)delegate 
            {
                SetUiState(false); 
                txtShow.AppendText("【系统】网络已断开" + Environment.NewLine);
            });
        }

        private void SetUiState(bool isConnect)
        {
            btnConnect.Enabled = !isConnect;
            btnSend.Enabled = isConnect;
            btnClose.Enabled = isConnect;
            txtIP.Enabled = !isConnect;
            txtPort.Enabled = !isConnect;
            if( isConnect )
            {
                lblstatus.BackColor = Color.Green;
            }
            else
            {
                lblstatus.BackColor = Color.Red;
            }
        }
    }
}
