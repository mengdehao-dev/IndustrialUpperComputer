using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace IndustrialUpperComputer
{
    public class DeviceController
    {
        //变量定义
        private TcpClient _tcpClient;
        public event Action<string> OnDataReceived;
        public event Action NetDisconnected;
        //连接函数
        public bool TcpConnect(string ip,int port)
        {
            try
            {
                if(_tcpClient != null) { _tcpClient.Close(); }
            }
            catch(Exception ex) { System.Diagnostics.Debug.WriteLine("创建连接时_tcpClient.Close()关闭失败" + ex.Message);  }
            _tcpClient = null;
            _tcpClient = new TcpClient();
            try
            {
                var result = _tcpClient.BeginConnect(ip,port,null,null);
                if(!result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(2)))
                {
                    _tcpClient?.Close();
                    _tcpClient?.Dispose();
                    _tcpClient = null;
                    return false;
                }
                _tcpClient.EndConnect(result);
                return true;
            }
            catch(SocketException ex)
            {
                _tcpClient?.Close();
                _tcpClient?.Dispose();
                _tcpClient = null;
                System.Diagnostics.Debug.WriteLine("创建连接由于网络端口问题导致失败" + ex.Message);
                return false;
            }
            catch(Exception ex)
            {
                _tcpClient?.Close();
                _tcpClient?.Dispose();
                _tcpClient = null;
                System.Diagnostics.Debug.WriteLine("创建连接失败" + ex.Message);
                return false;
            }
        }
        //发送函数
        public bool TcpSend(string msg)
        {
            if(!IsConnect())
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
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("信息发送抛出异常" + ex.Message);
                return false;
            }
        }
        //断开函数
        public void TcpClose()
        {
            if(_tcpClient != null)
            {
                try
                {
                    _tcpClient.GetStream()?.Close();
                }
                catch(Exception ex) { System.Diagnostics.Debug.WriteLine("TcpClose时_tcpClient.GetStream()?.Close()抛出异常" + ex.Message); }
                try
                {
                    _tcpClient?.Close();
                    _tcpClient?.Dispose();
                    _tcpClient = null;
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine("TcpClose时_tcpClient?.Close()抛出异常" + ex.Message); }
            }
            return;
        }
        //异步接收函数
        public void StartReceiving()
        {
            Task.Run(() =>
            {
                while(IsConnect())
                {
                    try
                    {
                        NetworkStream stream = _tcpClient.GetStream();
                        byte[] buffer = new byte[1024];                             //---------------------------------------------没有防粘包
                        int readByte = stream.Read(buffer, 0, buffer.Length);
                        if(readByte > 0)
                        {
                            string receivedText = System.Text.Encoding.UTF8.GetString(buffer,0,readByte);
                            OnDataReceived?.Invoke(receivedText);
                        }
                        if(readByte == 0)
                        {
                            HandleDisconnected();
                            break; //服务端决定断开连接，就跳出循环
                        }
                    }
                    catch(Exception ex)
                    {
                        HandleDisconnected();
                        System.Diagnostics.Debug.WriteLine("接收后台信息时抛出异常" + ex.Message);  //-----------------日志与配置类后期完善
                        break;
                    }
                }
            });
        }
        //辅助函数——判连函数
        public bool IsConnect()
        {
            return _tcpClient != null && _tcpClient.Connected;
        }
        //内部断开函数
        private void HandleDisconnected()
        {
            TcpClose();    //-------------------------------------断网和主UI关闭抢用同一份资源，会形成空指针崩溃，后续线程安全完善

            NetDisconnected?.Invoke();
        }
    }
}
