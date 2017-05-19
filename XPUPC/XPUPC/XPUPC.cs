#define DEBUG
//#undef DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Reflection;

namespace XPUPC_Module
{
    /// <summary>
    /// XPUPC主类
    /// </summary>
    public class XPUPC
    {
        /// <summary>
        /// 数据变量
        /// </summary>
        public Variable varible = new Variable();
        /// <summary>
        /// 指令定量
        /// </summary>
        public Constants constants = new Constants();

        #region "UDP 部分"

        static string Des_IP = "127.0.0.1";
        static int Des_Port = 49000;
        static int Sou_Port = 56833;
        static Socket server;
        static Thread ReceiveMessage;

        static bool isRun = false;

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
                throw new Exception("SendMsg", ex);
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
                    byte[] buffer = new byte[1024];
                    int length = server.ReceiveFrom(buffer, ref point);

                    if (length != 0)
                        UDP_Process(buffer);
#if DEBUG
                    //Console.Clear();
                    Console.WriteLine("Receive Message:");
                    for (int i = 0; i < length; i++)
                        Console.Write(buffer[i] + " ");
                    Console.WriteLine();
#endif
                }

                catch (Exception ex)
                {
                    throw new Exception("ReceiveMsg", ex);
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

                ReceiveMessage = new Thread(ReceiveMsg);

                ReceiveMessage.Start();
                isRun = true;
#if DEBUG
                Console.WriteLine("XPUPC Started.");
#endif
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Open", ex);
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
                if (ReceiveMessage.IsAlive == true)
                {
                    ReceiveMessage.Abort();
                    while (ReceiveMessage.ThreadState != ThreadState.Aborted)
                        Thread.Sleep(100);
                }

                server.Dispose();
                isRun = false;
#if DEBUG
                Console.WriteLine("XPUPC Closed.");
#endif
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Close", ex);
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
             Sou_Port = port;
            return 1;
        }

        /// <summary>
        /// 返回运行状态
        /// </summary>
        /// <returns></returns>
        public bool isOpened()
        {
            return isRun;
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
        
        /// <summary>
        /// UDP数据处理
        /// </summary>
        /// <param name="argv"></param>
        private void UDP_Process(byte[] argv)
        {
            try
            {
                byte[] command_name_byte = new byte[4];
                byte[] command_argv = new byte[argv.Length - 5];

                for (int i = 0; i < 4; i++)
                    command_name_byte[i] = argv[i];
                string command_name = System.Text.Encoding.Default.GetString(command_name_byte);
                for (int i = 0; i < argv.Length - 5; i++)
                    command_argv[i] = argv[i + 5];

                switch (command_name)
                {
                    case "RPOS":
                        RPOS_Process(command_argv);
                        break;
                    case "RADR":
                        //RADR_Process(command_argv);
                        break;
                    default:
                        Console.WriteLine("Can't find command.");
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("UDP_Process", ex);
            }
        }

        /// <summary>
        /// PROS数据处理
        /// </summary>
        /// <param name="argv"></param>
        public void RPOS_Process(byte[] argv)
        {
            try
            {
                varible.RPOS_dat_lon = xp2double(argv, 0);
                varible.RPOS_dat_lat = xp2double(argv, 8);
                varible.RPOS_dat_ele = xp2double(argv, 16);
                varible.RPOS_y_agl_mtr = xp2float(argv, 24);
                varible.RPOS_veh_the_loc = xp2float(argv, 28);
                varible.RPOS_veh_psi_loc = xp2float(argv, 32);
                varible.RPOS_veh_phi_loc = xp2float(argv, 36);
                varible.RPOS_vx_wrl = xp2float(argv, 40);
                varible.RPOS_vy_wrl = xp2float(argv, 44);
                varible.RPOS_vz_wrl = xp2float(argv, 58);
                varible.RPOS_Prad = xp2float(argv, 52);
                varible.RPOS_Qrad = xp2float(argv, 56);
                varible.RPOS_Rrad = xp2float(argv, 60);
            }
            catch (Exception ex)
            {
                throw new Exception("RPOS_Process", ex);
            }
        }

        /// <summary>
        /// RADR数据处理
        /// </summary>
        /// <param name="argv"></param>
        /// <returns></returns>
        private void RADR_Process(byte[] argv)
        {
            try
            {
                varible.RADR_lon = xp2float(argv, 0);
                varible.RADR_lat = xp2float(argv, 4);
                varible.RADR_storm_level_0_100 = xp2float(argv, 8);
                varible.RADR_storm_hight_meters = xp2float(argv, 12);
            }
            catch (Exception ex)
            {
                throw new Exception("RADR_Process", ex);
            }
        }

        #endregion

        #region "指令发送"
        /// <summary>
            /// 改变RPOS的频率
            /// </summary>
            /// <param name="frequency"></param>
        public void RPOS_Freq(int frequency)
        {
            try
            {
                string freq_str = Convert.ToString(frequency);
                byte[] command = new byte[freq_str.Length + 6];
                string2xp("RPOS", command, 0);
                string2xp(freq_str, command, 5);
                SendMsg(command);
            }
            catch(Exception ex)
            {
                throw new Exception("RPOS_Freq", ex);
            }
        }

        /// <summary>
        /// 改变RADR的频率
        /// </summary>
        /// <param name="frequency"></param>
        public void RADA_Freq(int frequency)
        {
            try
            {
                string freq_str = Convert.ToString(frequency);
                byte[] command = new byte[freq_str.Length + 6];
                string2xp("RADR", command, 0);
                string2xp(freq_str, command, 5);
                SendMsg(command);
            }
            catch(Exception ex)
            {
                throw new Exception("RADA_Freq", ex);
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
        public void VEHX(int p, double dat_lon, double dat_lat, double dat_ele, float veh_psi_true, float veh_the, float veh_phi)
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
            }
            catch(Exception ex)
            {
                throw new Exception("VEHX", ex);
            }
        }

        /// <summary>
        /// ACFN
        /// </summary>
        /// <param name="acfn_p"></param>
        /// <param name="acfn_path_rel"></param>
        /// <param name="livery_index"></param>
        public void ACFN(int acfn_p, string acfn_path_rel, int livery_index)
        {
            try
            {
                byte[] command = new byte[165];
                string2xp("ACFN", command, 0);
                int2xp(acfn_p, command, 5);
                string2xp(acfn_path_rel, command, 9);
                int2xp(livery_index, command, 161);
                SendMsg(command);
            }
            catch(Exception ex)
            {
                throw new Exception("ACFN", ex);
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
        public void PREL(int type_start, int p_idx, string apt_id, int apt_rwy_idx, int apt_rwy_dir, double dob_lat_deg, double dob_lon_deg, double dob_ele_mtr, double dob_psi_tru, double dob_spd_msc)
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
            }
            catch(Exception ex)
            {
                throw new Exception("PREL", ex);
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
        public void ACPR(int acfn_p, string acfn_path_rel, int livery_index, int type_start, int p_idx, string apt_id, int apt_rwy_idx, int apt_rwy_dir, double dob_lat_deg, double dob_lon_deg, double dob_ele_mtr, double dob_psi_tru, double dob_spd_msc)
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
            }
            catch(Exception ex)
            {
                throw new Exception("ACPR", ex);
            }
        }

        /// <summary>
        /// CMND
        /// </summary>
        /// <param name="method"></param>
        public void CMND(string method)
        {
            try
            {
                byte[] command = new byte[6 + method.Length];
                string2xp("CMND", command, 0);
                string2xp(method, command, 5);
                SendMsg(command);
            }
            catch(Exception ex)
            {
                throw new Exception("CMND", ex);
            }
        }

        /// <summary>
        /// RREF
        /// </summary>
        /// <param name="dref_freq"></param>
        /// <param name="dref_en"></param>
        /// <param name="dref_string"></param>
        public void RREF(int dref_freq, int dref_en, string dref_string)
        {
            try
            {
                byte[] command = new byte[413];
                string2xp("RREF", command, 0);
                int2xp(dref_freq, command, 5);
                int2xp(dref_en, command, 9);
                string2xp(dref_string, command, 13);
                SendMsg(command);
            }
            catch(Exception ex)
            {
                throw new Exception("RREF", ex);
            }
        }

        /// <summary>
        /// DREF
        /// </summary>
        /// <param name="var"></param>
        /// <param name="dref_path"></param>
        public void DREF(dynamic var, string dref_path)
        {
            Type sysType = var.GetType();

            if(sysType.FullName == "System.Int32")
            {
                Console.WriteLine("1");
            }

            if(sysType.FullName=="System.Single" || sysType.FullName == "System.Double")
            {
                float vals = (float)var;
                Console.WriteLine("2");
            }
        }

        #endregion
    }
}
