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
    /// <summary>
    /// XPUPC主类
    /// </summary>
    public class XPUPC
    {
        static string Des_IP = "127.0.0.1";
        static int Des_Port = 49000;
        static int Sou_Port = 56833;
        static Socket server;

        static Thread T1;

        public Variable varible = new Variable();
        public Constants constants = new Constants();

        #region "UDP 部分"

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
                    int length = server.ReceiveFrom(buffer, ref point);

                    if (length != 0)
                    {
                        //Process();

#if DEBUG
                        Console.WriteLine("Receive Message:");
                        for (int i = 0; i < length; i++)
                            Console.Write(buffer[i] + " ");
                        Console.WriteLine();
                    }
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

        /// <summary>
        /// 更改源端口号
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public int Sou_Port_CHG(int port)
        {
            try
            {
                Sou_Port = port;
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        #endregion

        #region "数型转换方法"

        /// <summary>
        /// byte数据转化为int
        /// </summary>
        /// <param name="sou_arr"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        private int xp2int(byte[] sou_arr, int pos)
        {
            try
            {
                byte[] array = new byte[4];
                for (int i = pos; i < pos + 4; i++)
                    array[i - pos] = sou_arr[i];
                return BitConverter.ToInt32(array, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -999;
            }
        }

        /// <summary>
        /// byte数据转化为float
        /// </summary>
        /// <param name="sou_arr"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        private float xp2float(byte[] sou_arr, int pos)
        {
            try
            {
                byte[] array = new byte[4];
                for (int i = pos; i < pos + 4; i++)
                    array[i - pos] = sou_arr[i];
                return BitConverter.ToSingle(array, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -999;
            }
        }

        /// <summary>
        /// byte数据转化为double
        /// </summary>
        /// <param name="sou_arr"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        private double xp2double(byte[] sou_arr, int pos)
        {
            try
            {
                byte[] array = new byte[8];
                for (int i = pos; i < pos + 8; i++)
                    array[i - pos] = sou_arr[i];
                return BitConverter.ToDouble(array, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -999;
            }
        }

        /// <summary>
        /// int数据转化为byte
        /// </summary>
        /// <param name="val"></param>
        /// <param name="des_arr"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        private int int2xp(int val, byte[] des_arr, int pos)
        {
            try
            {
                byte[] temp = BitConverter.GetBytes(val);
                for (int i = 0; i < 4; i++)
                    des_arr[i + pos] = temp[i];

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// float数据转化为byte
        /// </summary>
        /// <param name="val"></param>
        /// <param name="des_arr"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        private int float2xp(float val, byte[] des_arr, int pos)
        {
            try
            {
                byte[] temp = BitConverter.GetBytes(val);
                for (int i = 0; i < 4; i++)
                    des_arr[i + pos] = temp[i];

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// double数据转化为byte
        /// </summary>
        /// <param name="val"></param>
        /// <param name="des_arr"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        private int double2xp(double val, byte[] des_arr, int pos)
        {
            try
            {
                byte[] temp = BitConverter.GetBytes(val);
                for (int i = 0; i < 8; i++)
                    des_arr[i + pos] = temp[i];

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// string数据转化为byte
        /// </summary>
        /// <param name="val"></param>
        /// <param name="des_arr"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        private int string2xp(string val, byte[] des_arr, int pos)
        {
            try
            {
                for (int i = 0; i < val.Length; i++)
                    des_arr[i + pos] = Convert.ToByte(val[i]);

                des_arr[val.Length + pos] = 0x00;

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        #endregion

        #region "数据处理"
        public void MakeAVal()
        {
            varible.RPOS_dat_lat = 2;
        }
        #endregion

        #region "指令发送"
        /// <summary>
        /// 改变RPOS的频率
        /// </summary>
        /// <param name="frequency"></param>
        public int RPOS_Freq(int frequency)
        {
            try
            {
                string freq_str = Convert.ToString(frequency);
                byte[] command = new byte[freq_str.Length + 6];
                string2xp("RADR", command, 0);
                string2xp(freq_str, command, 5);
                SendMsg(command);
                return 0;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        /// <summary>
        /// 改变RADR的频率
        /// </summary>
        /// <param name="frequency"></param>
        public int RADA_Freq(int frequency)
        {
            try
            {
                string freq_str = Convert.ToString(frequency);
                byte[] command = new byte[freq_str.Length + 6];
                string2xp("RADR", command, 0);
                string2xp(freq_str, command, 5);
                SendMsg(command);
                return 0;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        /// <summary>
        /// VEHX
        /// </summary>
        /// <param name="p"></param>
        /// <param name="dat_lon"></param>
        /// <param name="dat_lat"></param>
        /// <param name="dat_ele"></param>
        /// <param name="veh_psi_true"></param>
        /// <param name="veh_the"></param>
        /// <param name="veh_phi"></param>
        /// <returns></returns>
        public int VEHX(int p, double dat_lon, double dat_lat, double dat_ele, float veh_psi_true, float veh_the, float veh_phi)
        {
            try
            {
                byte[] command = new byte[45];
                string2xp("VEHX", command, 0);
                int2xp(p, command, 5);
                double2xp(dat_lat, command, 9);
                double2xp(dat_lon, command, 17);
                double2xp(dat_ele, command, 25);
                float2xp(veh_psi_true, command, 33);
                float2xp(veh_the, command, 37);
                float2xp(veh_phi, command, 41);
                SendMsg(command);
                return 0;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        /// <summary>
        /// ACFN
        /// </summary>
        /// <param name="acfn_p"></param>
        /// <param name="acfn_path_rel"></param>
        /// <param name="livery_index"></param>
        /// <returns></returns>
        public int ACFN(int acfn_p, string acfn_path_rel, int livery_index)
        {
            try
            {
                byte[] command = new byte[165];
                string2xp("ACFN", command, 0);
                int2xp(acfn_p, command, 5);
                string2xp(acfn_path_rel, command, 9);
                int2xp(livery_index, command, 161);
                SendMsg(command);
                return 0;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        /// <summary>
        /// PREL
        /// </summary>
        /// <param name="type_start"></param>
        /// <param name="p_idx"></param>
        /// <param name="apt_id"></param>
        /// <param name="apt_rwy_idx"></param>
        /// <param name="apt_rwy_dir"></param>
        /// <param name="dob_lat_deg"></param>
        /// <param name="dob_lon_deg"></param>
        /// <param name="dob_ele_mtr"></param>
        /// <param name="dob_psi_tru"></param>
        /// <param name="dob_spd_msc"></param>
        /// <returns></returns>
        public int PREL(int type_start, int p_idx, string apt_id, int apt_rwy_idx, int apt_rwy_dir, double dob_lat_deg, double dob_lon_deg, double dob_ele_mtr, double dob_psi_tru, double dob_spd_msc)
        {
            try
            {
                byte[] command = new byte[69];
                string2xp("PREL", command, 0);
                int2xp(type_start, command, 5);
                int2xp(p_idx, command, 9);
                string2xp(apt_id, command, 13);
                int2xp(apt_rwy_idx, command, 21);
                int2xp(apt_rwy_dir, command, 25);
                double2xp(dob_lat_deg, command, 29);
                double2xp(dob_lon_deg, command, 37);
                double2xp(dob_ele_mtr, command, 45);
                double2xp(dob_psi_tru, command, 53);
                double2xp(dob_spd_msc, command, 61);
                SendMsg(command);
                return 0;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        /// <summary>
        /// ACPR
        /// </summary>
        /// <param name="acfn_p"></param>
        /// <param name="acfn_path_rel"></param>
        /// <param name="livery_index"></param>
        /// <param name="type_start"></param>
        /// <param name="p_idx"></param>
        /// <param name="apt_id"></param>
        /// <param name="apt_rwy_idx"></param>
        /// <param name="apt_rwy_dir"></param>
        /// <param name="dob_lat_deg"></param>
        /// <param name="dob_lon_deg"></param>
        /// <param name="dob_ele_mtr"></param>
        /// <param name="dob_psi_tru"></param>
        /// <param name="dob_spd_msc"></param>
        /// <returns></returns>
        public int ACPR(int acfn_p, string acfn_path_rel, int livery_index, int type_start, int p_idx, string apt_id, int apt_rwy_idx, int apt_rwy_dir, double dob_lat_deg, double dob_lon_deg, double dob_ele_mtr, double dob_psi_tru, double dob_spd_msc)
        {
            try
            {
                byte[] command = new byte[229];

                string2xp("ACPR", command, 0);
                int2xp(acfn_p, command, 5);
                string2xp(acfn_path_rel, command, 9);
                int2xp(livery_index, command, 160);

                string2xp("", command, 164);

                int2xp(type_start, command, 165);
                int2xp(p_idx, command, 169);
                string2xp(apt_id, command, 173);
                int2xp(apt_rwy_idx, command, 181);
                int2xp(apt_rwy_dir, command, 185);
                double2xp(dob_lat_deg, command, 189);
                double2xp(dob_lon_deg, command, 197);
                double2xp(dob_ele_mtr, command, 205);
                double2xp(dob_psi_tru, command, 213);
                double2xp(dob_spd_msc, command, 221);
                SendMsg(command);
                return 0;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        /// <summary>
        /// CMND
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public int CMND(string method)
        {
            try
            {
                byte[] command = new byte[6 + method.Length];
                string2xp("CMND", command, 0);
                string2xp(method, command, 5);
                SendMsg(command);
                return 0;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }
        #endregion
    }
}
