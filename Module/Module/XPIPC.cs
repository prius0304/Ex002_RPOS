using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPIPC_Module
{
    public class XPIPC
    {
        public variable Offset = new variable();

        public int Process(byte[] argv)
        {
            try
            {
                byte[] command_name_byte = new byte[4];
                byte[] command_argv = new byte[argv.Length - 5];

                for(int i = 0; i < 4; i++)
                    command_name_byte[i] = argv[i];
                string command_name = System.Text.Encoding.Default.GetString(command_name_byte);
                for (int i = 0; i < argv.Length - 5; i++)
                    command_argv[i] = argv[i + 5];

                Console.WriteLine(command_name);

                switch(command_name)
                {
                    case "RPOS":
                        RPOS_Process(command_argv);
                        break;
                    case "RADR":
                        RADR_Process(command_argv);
                        break;
                    default:
                        Console.WriteLine("Can't find command.");
                        break;
                }

                return 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        private int RPOS_Process(byte[] argv)
        {
            try
            {
                Offset.dat_lon = xp2double(argv, 0);
                Offset.dat_lat = xp2double(argv, 8);
                Offset.dat_ele = xp2double(argv, 16);
                Offset.y_agl_mtr = xp2float(argv, 24);
                Offset.veh_the_loc = xp2float(argv, 28);
                Offset.veh_psi_loc = xp2float(argv, 32);
                Offset.veh_phi_loc = xp2float(argv, 36);
                Offset.vx_wrl = xp2float(argv, 40);
                Offset.vy_wrl = xp2float(argv, 44);
                Offset.vz_wrl = xp2float(argv, 58);
                Offset.Prad = xp2float(argv, 52);
                Offset.Qrad = xp2float(argv, 56);
                Offset.Rrad = xp2float(argv, 60);
                return 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        private int RADR_Process(byte[] argv)
        {
            try
            {
                Offset.lon = xp2float(argv, 0);
                Offset.lat = xp2float(argv, 4);
                Offset.storm_level_0_100 = xp2float(argv, 8);
                Offset.storm_hight_meters = xp2float(argv, 12);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public byte[] VEHX(int p, double dat_lat, double dat_lon, double dat_ele, float veh_psi_true, float veh_the, float veh_phi)
        {
            byte[] command_arr = new byte[45];
            string2xp("VEHX", command_arr, 0);
            int2xp(p, command_arr, 5);
            double2xp(dat_lat, command_arr, 9);
            double2xp(dat_lon, command_arr, 17);
            double2xp(dat_ele, command_arr, 25);
            float2xp(veh_psi_true, command_arr, 33);
            float2xp(veh_the, command_arr, 37);
            float2xp(veh_phi, command_arr, 41);

            return command_arr;
        }

        #region "数型转换方法"
        private int xp2int(byte[] sou_arr, int a)
        {
            try
            {
                byte[] array = new byte[4];
                for (int i = a; i < a + 4; i++)
                    array[i - a] = sou_arr[i];
                return BitConverter.ToInt32(array, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -999;
            }
        }
        private float xp2float(byte[] sou_arr, int a)
        {
            try
            {
                byte[] array = new byte[4];
                for (int i = a; i < a + 4; i++)
                    array[i - a] = sou_arr[i];
                return BitConverter.ToSingle(array, 0);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -999;
            }
        }
        private double xp2double(byte[] sou_arr, int a)
        {
            try
            {
                byte[] array = new byte[8];
                for (int i = a; i < a + 8; i++)
                    array[i - a] = sou_arr[i];
                return BitConverter.ToDouble(array, 0);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -999;
            }
        }
        private int int2xp(int val, byte[] des_arr, int a)
        {
            try
            {
                byte[] temp = BitConverter.GetBytes(val);
                for (int i = 0; i < 4; i++)
                    des_arr[i + a] = temp[i];

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
        private int float2xp(float val, byte[] des_arr, int a)
        {
            try
            {
                byte[] temp = BitConverter.GetBytes(val);
                for (int i = 0; i < 4; i++)
                    des_arr[i + a] = temp[i];

                return 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
        private int double2xp(double val, byte[] des_arr, int a)
        {
            try
            {
                byte[] temp = BitConverter.GetBytes(val);
                for (int i = 0; i < 8; i++)
                    des_arr[i+a] = temp[i];

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
        private int string2xp(string val, byte[] des_arr, int a)
        {
            try
            {
                for (int i = 0; i < val.Length; i++)
                    des_arr[i+a] = Convert.ToByte(val[i]);

                des_arr[ a + 5] = 0x00;

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
        #endregion
    }
}
