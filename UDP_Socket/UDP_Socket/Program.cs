using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace UDP_Socket
{
    class Program
    {
        static Socket server;
        static byte[] RPOS = new byte[7] { 0x52, 0x50, 0x4F, 0x53, 0x00, 0x31, 0x00 };
        static void Main(string[] args)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 56833));
            Console.WriteLine("服务端开启！");

            Thread t1 = new Thread(ReciveMsg);
            t1.Start();

            Thread t2 = new Thread(sendMsg);
            t2.Start();
        }

        static void sendMsg()
        {
            EndPoint point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 49000);
            while (true)
            {
                string msg = Console.ReadLine();
                //server.SendTo(Encoding.UTF8.GetBytes(msg), point);
                server.SendTo(RPOS, point);
            }
        }

        static void ReciveMsg()
        {
            while (true)
            {
                EndPoint point = new IPEndPoint(IPAddress.Any, 0);
                byte[] buffer = new byte[1024];
                int length = server.ReceiveFrom(buffer, ref point);
                string message = Encoding.UTF8.GetString(buffer, 0, length);
                Console.WriteLine(point.ToString() + " " + message);
            }
        }
    }
}
