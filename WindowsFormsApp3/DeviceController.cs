using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class DeviceController
    {
        private TcpClient _tcpClient;
        public event Action<string> Ondatareceived;
        //连接函数
        public bool TcpConnect(string ip, int port)
        {
            //1.判空
            if (_tcpClient != null)
            {
                try
                {
                    _tcpClient.Close();
                }
                catch
                {
                }
                _tcpClient = null;
            }
            //2.申请
            _tcpClient = new TcpClient();
            //3.连接
            try
            {
                var result = _tcpClient.BeginConnect(ip, port, null, null);
                if (!result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(2)))
                {
                    _tcpClient.Close();
                    return false;
                }
                _tcpClient.EndConnect(result);
                return true;
            }
            //4.返回异常
            catch (SocketException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        // 判连函数
        public bool IsTcpConnect()
        {
            return _tcpClient != null&& _tcpClient.Connected;
        }
        //异步接收函数
        public void StartReceiving()
        {
            Task.Run(() =>
            {

                while (_tcpClient != null && _tcpClient.Connected)
                {
                    try
                    {
                        NetworkStream stream = _tcpClient.GetStream();
                        // 注意：目前 Demo 报文较短，暂未做 TCP 粘包/半包处理。
                        // 实际工业现场：需在此处设计“长度前缀(前4字节为长度)”或“特定结束符(如\r\n)”解析器。
                        byte[] buffer = new byte[1024];
                        int readByte = stream.Read(buffer, 0, buffer.Length);
                        if (readByte > 0)
                        {
                            string DataReceivedMsg = Encoding.UTF8.GetString(buffer, 0, readByte);
                            if (Ondatareceived != null)
                            {
                                Ondatareceived(DataReceivedMsg);
                            }
                        }
                    }
                    catch { break; }
                }
            });

        }

        // 发送函数
        public bool TcpSend(string msg)
        {
            if(!IsTcpConnect())
            {
                return false;
            }
            try
            {
                NetworkStream stream = _tcpClient.GetStream();
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(msg);
                stream.Write(buffer, 0, buffer.Length);
                return true;
            }
            catch
            {
                return false;
            }
         }
        // 关闭函数
        public void TcpClose()
        {
            if(_tcpClient != null)
            {
                try
                {
                    _tcpClient.GetStream()?.Close();
                }
                catch { }
                try
                {
                    _tcpClient.Close();
                }
                catch { }
            }
            _tcpClient = null;
            return;
        }

    }
}
