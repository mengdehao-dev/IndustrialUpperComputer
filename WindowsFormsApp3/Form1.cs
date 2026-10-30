using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private DeviceController _device;
        private string _currentImagePath = ""; // 存当前选中的图片的路径
        private HTuple _modelID = null;
        private HTuple _roiRow1 = 220, _roiCol1 = 68, _roiRow2 = 424, _roiCol2 = 589;
        public Form1()
        {
            InitializeComponent();
            _device = new DeviceController();
            SetUiState(false);
        }
        private void SetUiState(bool connected)
        {
            btnConnect.Enabled = !connected;
            btnSend.Enabled = connected;
            btnClose.Enabled = connected;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _device?.TcpClose();
            return;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ip = txtIP.Text;
            int port = int.Parse(txtPort.Text);
            this.Cursor = Cursors.WaitCursor;
            bool ok = _device.TcpConnect(ip,port);
            this.Cursor = Cursors.Default;
            if(ok)
            {
                //1.设置状态
                SetUiState(true);
                //2.订阅事件（保证事件没有重复订阅）
                _device.Ondatareceived -= AppendText;
                _device.Ondatareceived += AppendText;
                //3.异步监听
                _device.StartReceiving();
                MessageBox.Show("连接成功");
            }
            else
            {
                MessageBox.Show("连接失败");
            }
        }



        // 视觉匹配函数
        private string DoVisionMatch()
        {
            try
            {
                if (string.IsNullOrEmpty(_currentImagePath))
                {
                    return "Vision Error: No Image selected";
                }
                if(_modelID == null)
                {
                    return "Vision Error: Model not learned";
                }

                HObject image;
                HOperatorSet.ReadImage(out image, _currentImagePath);

                HTuple row, column, angle, score;
                HOperatorSet.FindShapeModel(image, _modelID, -0.39, 0.79, 0.5, 1, 0.5, "least_squares", 0, 0.8, out row, out column, out angle, out score);

                //封装成VisionResult类
                VisionResult result = new VisionResult
                {
                    SN = "SN" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                    Row = row.D,
                    Column = column.D,
                    Angle = angle.D,
                    Score = score.D,
                    IsOk = score.D > 0.8,
                    Time = DateTime.Now,
                };
                // 返回坐标报文
                // --- 新增：写入数据库 ------------------------------------------------------------------------------------  
                Task.Run(() =>
                {
                    try
                    {
                        DbHelper db = new DbHelper();

                        bool saveOk = db.InsertResult(result.SN, result.Row, result.Column, result.Angle, result.Score, result.IsOk);
                        if (!saveOk)
                        {
                            System.Diagnostics.Debug.WriteLine("写入数据库失败！");
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("后台数据库线程异常：" + ex.Message);
                    }
                });
                return JsonConvert.SerializeObject(result);
            }
            // ---------------------------------------------------------------------------------------------------------------
            catch (Exception ex)
            {
                //把真实错误写入日志
                System.Diagnostics.Debug.WriteLine("视觉处理失败：" + ex.Message);
                // 返回带错误原因的信息给设备
                return $"Vision Error: {ex.Message}";
            }           
        }
    // 匿名委托函数
        private void AppendText(string msg)
        {
            //1. 收到指令，触发视觉
            string result = DoVisionMatch();

            //2. 把结果通过TCP发给设备
            _device.TcpSend(result);

            //3. UI显示
            this.Invoke((MethodInvoker)delegate
            {
                txtShow.AppendText("服务端："+msg+Environment.NewLine);
                txtShow.AppendText("视觉结果已发送："+ result + Environment.NewLine);
            });
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string inputMsg = txtInput.Text;
            if(!_device.IsTcpConnect())
            {
                MessageBox.Show("请先进行连接");
                return;
            }
            if(string.IsNullOrEmpty(inputMsg))
            {
                MessageBox.Show("请正确输入信息");
                return;
            }
            if(_device.TcpSend(inputMsg))
            {
                txtShow.AppendText("客户端："+inputMsg+Environment.NewLine);
                txtInput.Text = "";
                MessageBox.Show("发送成功");
            }
            else
            {
                MessageBox.Show("发送失败");
            }

        }

        private void btnLearnModel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentImagePath))
            {
                MessageBox.Show("请先选择一张标准图片！");
                return;
            }

            try
            {
                HObject image, rectangle, imageReduced;
                HOperatorSet.ReadImage(out image, _currentImagePath);

                // 使用全局保存的ROI坐标画框
                HOperatorSet.GenRectangle1(out rectangle, _roiRow1, _roiCol1, _roiRow2, _roiCol2);
                HOperatorSet.ReduceDomain(image, rectangle, out imageReduced);

                // 清理旧模板（如果存在的话），防止内存泄漏
                if (_modelID != null)
                {
                    HOperatorSet.ClearShapeModel(_modelID);
                }

                // 核心：只在这里建一次模板，存入全局变量 _modelID
                HOperatorSet.CreateShapeModel(imageReduced, "auto", -0.39, 0.79, "auto", "auto", "use_polarity", "auto", "auto", out _modelID);

                MessageBox.Show("模板学习成功！可以开始检测了。");
            }
            catch (Exception ex)
            {
                MessageBox.Show("模板学习失败: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _device.TcpClose();
            _device.Ondatareceived -= AppendText;
            SetUiState(false);
            txtShow.AppendText("【系统】连接已断开"+Environment.NewLine);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DbHelper db = new DbHelper();

            // 假设你刚才生成的一条SN码是 "SN20261019200046"
            // 你可以在 SSMS 里复制一条真实的 SN 码放进来
            string testSN = "SN20261019200635";

            DataTable dt = db.QueryBySN(testSN);

            if (dt != null && dt.Rows.Count > 0)
            {
                // 取第一行数据，显示得分看看
                string score = dt.Rows[0]["Score"].ToString();
                MessageBox.Show($"查询成功，查到 {dt.Rows.Count} 条数据。得分：{score}");
            }
            else
            {
                MessageBox.Show("未查询到该 SN 码的数据！");
            }
        }

        private void btnSelectImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "图片文件|*.jpg;*.png;*.bmp";
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    _currentImagePath = ofd.FileName;
                    txtShow.AppendText("【系统】已加载图片：" + _currentImagePath + Environment.NewLine);
                }
            } 
        }
    }
    
}
