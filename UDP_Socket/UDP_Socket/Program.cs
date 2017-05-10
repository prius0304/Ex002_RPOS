using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Net;
using System.Net.Sockets;

using XPIPC_Module;

namespace UDP_Socket
{
    class Program
    {
        static Socket server;
		static CLI cli = new CLI();
        static string IP_ADD = "127.0.0.1";
        static int Loc_Port = 56833;
        static int Des_Port = 49000;
        static XPIPC xpipc = new XPIPC();

        static byte[] help = new byte[4] { 0x48, 0x45, 0x4C, 0x50 };
        static byte[] RPOS = new byte[] { 0x52, 0x50, 0x4F, 0x53, 0x00, 0x36, 0x30, 0x00 };

        static void sendMsg()
        {
            EndPoint point = new IPEndPoint(IPAddress.Parse(IP_ADD), Des_Port);
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
                byte[] buffer = new byte[509];
                int length = server.ReceiveFrom(buffer, ref point);
                //string message = Encoding.UTF8.GetString(buffer, 0, length);
                //Console.WriteLine(point.ToString() + "   " + message);

                xpipc.Process(buffer);
                display_rpos();
            }
        }

        static void display_rpos()
        {
            Console.Clear();
            Console.WriteLine("dat_lon=         " + xpipc.Offset.dat_lon);
            Console.WriteLine("dat_lat=         " + xpipc.Offset.dat_lat);
            Console.WriteLine("dat_ele=         " + xpipc.Offset.dat_ele);
            Console.WriteLine("y_agl_mtr=       " + xpipc.Offset.y_agl_mtr);
            Console.WriteLine("veh_the_loc=     " + xpipc.Offset.veh_the_loc);
            Console.WriteLine("veh_psi_loc=     " + xpipc.Offset.veh_psi_loc);
            Console.WriteLine("veh_phi_loc=     " + xpipc.Offset.veh_phi_loc);
            Console.WriteLine("vx_wrl=          " + xpipc.Offset.vx_wrl);
            Console.WriteLine("vy_wrl=          " + xpipc.Offset.vy_wrl);
            Console.WriteLine("vz_wrl=          " + xpipc.Offset.vz_wrl);
            Console.WriteLine("Prad=            " + xpipc.Offset.Prad);
            Console.WriteLine("Qrad=            " + xpipc.Offset.Qrad);
            Console.WriteLine("Rrad=            " + xpipc.Offset.Rrad);
        }

        static void Main(string[] args)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            server.Bind(new IPEndPoint(IPAddress.Parse(IP_ADD), Loc_Port));
            Console.WriteLine("服务端开启！");

            Thread t1 = new Thread(ReciveMsg);
            t1.Start();

            Thread t2 = new Thread(sendMsg);
            t2.Start();
        }
    }
}
