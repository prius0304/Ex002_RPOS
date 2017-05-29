using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace XPUPC_Module
{
    public class XPUPC : Method
    {
        static string DestP_IP;
        static int DestP_PT;
        static int SouP_PT;
        static Socket server;
        static Thread T_ReceiveMsg;
        static bool isRun;

        /// <summary>
        /// XPUDP constructor
        /// </summary>
        public XPUPC()
        {
            DestP_IP = "127.0.0.1";
            DestP_PT = 49000;
            SouP_PT = 56833;
            isRun = false;
            Trace.WriteLineIf(Debug_Switch, GetTime() + "XPUDP created.");
        }

        /// <summary>
        /// XPUDP constructor
        /// </summary>
        /// <param name="Des_IP"></param>
        /// <param name="Des_PT"></param>
        /// <param name="Sou_PT"></param>
        public XPUPC(string Des_IP, int Des_PT, int Sou_PT)
        {
            Set_Ethe(Des_IP, Des_PT, Sou_PT);
        }

        /// <summary>
        /// XPUDP destructor
        /// </summary>
        ~XPUPC()
        {
            Close();
            Trace.WriteLineIf(Debug_Switch, GetTime() + "XPUDP dispossed.");
        }

        /// <summary>
        /// UDP Open
        /// </summary>
        /// <returns></returns>
        public int Open()
        {
            try
            {
                server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                server.Bind(new IPEndPoint(IPAddress.Parse(DestP_IP), SouP_PT));
                T_ReceiveMsg = new Thread(ReceiveMsg);
                T_ReceiveMsg.Start();

                isRun = true;

                Trace.WriteLineIf(Debug_Switch, GetTime() + "UDP started.");

                return 0;
            }
            catch (Exception ex)
            {
                isRun = false;
                Trace.WriteLineIf(Debug_Switch, GetTime() + "Failed to start UDP.");
                return -1;
            }
        }

        /// <summary>
        /// UDP Close
        /// </summary>
        /// <returns></returns>
        public int Close()
        {
            try
            {
                if (T_ReceiveMsg.IsAlive == true)
                {
                    T_ReceiveMsg.Abort();
                    while (T_ReceiveMsg.ThreadState != System.Threading.ThreadState.Aborted)
                        Thread.Sleep(10);
                }

                Trace.WriteLineIf(Debug_Switch, GetTime() + "UDP closed.");
                server.Dispose();
                isRun = false;

                return 0;
            }
            catch (Exception ex)
            {
                isRun = true;
                Trace.WriteLineIf(Debug_Switch, GetTime() + "Failed to close UDP.");
                return -1;
            }
        }

        /// <summary>
        /// Return running status
        /// </summary>
        /// <returns></returns>
        public bool Satus()
        {
            return isRun;
        }

        /// <summary>
        /// Change Destination IP and port
        /// </summary>
        /// <param name="Des_IP"></param>
        /// <param name="Des_PT"></param>
        /// <param name="Sou_IP"></param>
        /// <param name="Sou_PT"></param>
        /// <returns></returns>
        public int Set_Ethe(string Des_IP, int Des_PT, int Sou_PT)
        {
            if (Regex.IsMatch(Des_IP, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$") == true)
            {
                DestP_IP = Des_IP;
                DestP_PT = Des_PT;
                SouP_PT = Sou_PT;

                Trace.WriteLineIf(Debug_Switch, GetTime() 
                    + "Dest IP changed to " + DestP_IP
                    + " Dest Port change to " + DestP_PT
                    + " Sou Port change to " + SouP_PT);

                return 0;
            }

            Trace.WriteLineIf(Debug_Switch, GetTime() + "Set Ethernet failed. Maybe something is wrong with the IP formart.");
            return -1;
        }

        /// <summary>
        /// UDP send a message
        /// </summary>
        /// <param name="argv"></param>
        /// <returns></returns>
        private int SendMsg(byte[] argv)
        {
            try
            {
                EndPoint point = new IPEndPoint(IPAddress.Parse(DestP_IP), DestP_PT);
                server.SendTo(argv, point);
                Trace.WriteLineIf(Debug_Switch, GetTime() + "SendMsg: " + argv);
                return 0;
            }
            catch (Exception ex)
            {
                Trace.WriteLineIf(Debug_Switch, GetTime() + "Set Ethernet failed. Maybe something is wrong with the IP formart.");
                return -1;
            }
        }

        /// <summary>
        /// Receive Message
        /// </summary>
        private void ReceiveMsg()
        {
            while (true)
            {
                try
                {
                    EndPoint point = new IPEndPoint(IPAddress.Any, 0);
                    byte[] buffer = new byte[1024];
                    int length = server.ReceiveFrom(buffer, ref point);

                    //if (length != 0)
                        //UDP_Process(buffer);
                    Trace.WriteLineIf(Debug_Switch, GetTime() + "ReceiveMsg: " + buffer);
                }

                catch (Exception ex)
                {
                    Trace.WriteLineIf(Debug_Switch, GetTime() + "ReceiveMsg error.");
                }
            }
        }
    }
}
