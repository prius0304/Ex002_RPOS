#define DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace XPUPC_Module
{
    public class XPUPC
    {
        static string Des_IP = "127.0.0.1";
        static int Des_Port = 49000;
        static int Sou_Port = 56833;
        static Socket server;

        static Thread T1;

        /// <summary>
        /// UDP发送函数
        /// </summary>
        /// <param name="argv">参数1</param>
        /// <returns> result </returns>
        private int SendMsg(byte[] argv)
        {
            try
            {
                EndPoint point = new IPEndPoint(IPAddress.Parse(Des_IP), Des_Port);
                server.SendTo(argv, point);
#if DEBUG
                Console.WriteLine("Send Message:");
                for (int i = 0; i < argv.Length; i++)
                    Console.Write(argv[i] + " ");
                Console.WriteLine();
#endif
                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        /// <summary>
        /// UDP接收函数
        /// </summary>
        /// <returns> result </returns>
        private void ReceiveMsg()
        {
            while(true)
            {
                try
                {
                    EndPoint point = new IPEndPoint(IPAddress.Any, 0);
                    byte[] buffer = new byte[509];

                    //Process();

#if DEBUG
                    Console.WriteLine("Receive Message:");
                    for (int i = 0; i < buffer.Length; i++)
                        Console.Write(buffer[i] + " ");
                    Console.WriteLine();
#endif
                }
                catch (Exception ex)
                {
#if DEBUG
                    Console.WriteLine("接收消息错误。问题捕捉如下：");
                    Console.WriteLine(ex.Message);
#endif 
                }
            }
        }

        /// <summary>
        /// UDP启动函数
        /// </summary>
        /// <returns> result </returns>
        public int Open()
        {
            try
            {
                server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                server.Bind(new IPEndPoint(IPAddress.Parse(Des_IP), Sou_Port));

                T1 = new Thread(ReceiveMsg);

                T1.Start();
#if DEBUG
                Console.WriteLine("XPUPC Started.");
#endif
                return 0;
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("Failed to open. Catch:");
                Console.WriteLine(ex.Message);
#endif
                return -1;
            }
        }

        /// <summary>
        /// UDP停止函数
        /// </summary>
        /// <returns> result </returns>
        public int Close()
        {
            try
            {
                if (T1.IsAlive == true)
                {
                    T1.Abort();
                    while (T1.ThreadState != ThreadState.Aborted)
                        Thread.Sleep(100);
                }

                server.Dispose();

#if DEBUG
                Console.WriteLine("XPUPC Closed.");
#endif
                return 0;
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine("Failed to close. Catch:");
                Console.WriteLine(ex.Message);
#endif
                return -1;
            }
        }

        /// <summary>
        /// 更改目的IP
        /// </summary>
        /// <param name="IP_Address">参数1</param>
        /// <returns> result </returns>
        public int IP_CHG(string IP_Address)
        {
            if (Regex.IsMatch(IP_Address, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$") == true)
            {
                Des_IP = IP_Address;
                return 0;
            }
            else
                return -1;
        }
    }
}
