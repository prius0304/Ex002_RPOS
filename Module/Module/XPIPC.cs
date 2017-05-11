using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPIPC_Module
{
    public class XPIPC
    {
        public variable offset = new variable();

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

        public byte[] RPOS(int freq)
        {
            try
            {
                string freq_str = Convert.ToString(freq);
                byte[] command_arr = new byte[freq_str.Length+6];
                string2xp("RPOS", command_arr, 0);
                string2xp(freq_str, command_arr, 5);
                return command_arr;
            }
            catch (Exception ex)
            {
                byte[] err = new byte[1] { 0 };
                Console.WriteLine(ex.Message);
                return err;
            }
        }

        public byte[] RADR(int freq)
        {
            try
            {
                string freq_str = Convert.ToString(freq);
                byte[] command_arr = new byte[freq_str.Length + 6];
                string2xp("RADR", command_arr, 0);
                string2xp(freq_str, command_arr, 5);
                return command_arr;

            }
            catch (Exception ex)
            {
                byte[] err = new byte[1] { 0 };
                Console.WriteLine(ex.Message);
                return err;
            }
        }

        private int RPOS_Process(byte[] argv)
        {
            try
            {
                offset.dat_lon = xp2double(argv, 0);
                offset.dat_lat = xp2double(argv, 8);
                offset.dat_ele = xp2double(argv, 16);
                offset.y_agl_mtr = xp2float(argv, 24);
                offset.veh_the_loc = xp2float(argv, 28);
                offset.veh_psi_loc = xp2float(argv, 32);
                offset.veh_phi_loc = xp2float(argv, 36);
                offset.vx_wrl = xp2float(argv, 40);
                offset.vy_wrl = xp2float(argv, 44);
                offset.vz_wrl = xp2float(argv, 58);
                offset.Prad = xp2float(argv, 52);
                offset.Qrad = xp2float(argv, 56);
                offset.Rrad = xp2float(argv, 60);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        private int RADR_Process(byte[] argv)
        {
            try
            {
                offset.lon = xp2float(argv, 0);
                offset.lat = xp2float(argv, 4);
                offset.storm_level_0_100 = xp2float(argv, 8);
                offset.storm_hight_meters = xp2float(argv, 12);
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
            try
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
            catch(Exception ex)
            {
                byte[] err = new byte[1] { 0 };
                Console.WriteLine(ex.Message);
                return err;
            }
        }

        public byte[] ACFN(int acfn_p, string acfn_path_rel, int livery_index)
        {
            try
            {
                byte[] command_arr = new byte[165];
                string2xp("ACFN", command_arr, 0);
                int2xp(acfn_p, command_arr, 5);
                string2xp(acfn_path_rel, command_arr, 9);
                int2xp(livery_index, command_arr, 161);
                return command_arr;
            }
            catch (Exception ex)
            {
                byte[] err = new byte[1] { 0 };
                Console.WriteLine(ex.Message);
                return err;
            }
        }

        public byte[] PREL(int type_start, int p_idx, string apt_id, int apt_rwy_idx, int apt_rwy_dir, double dob_lat_deg, double dob_lon_deg,double dob_ele_mtr, double dob_psi_tru, double dob_spd_msc)
        {
            try
            {
                byte[] command_arr = new byte[69];
                string2xp("PREL", command_arr, 0);
                int2xp(type_start, command_arr, 5);
                int2xp(p_idx, command_arr, 9);
                string2xp(apt_id, command_arr, 13);
                int2xp(apt_rwy_idx, command_arr, 21);
                int2xp(apt_rwy_dir, command_arr, 25);
                double2xp(dob_lat_deg, command_arr,29);
                double2xp(dob_lon_deg, command_arr,37);
                double2xp(dob_ele_mtr, command_arr,45);
                double2xp(dob_psi_tru, command_arr,53);
                double2xp(dob_spd_msc, command_arr,61);

                return command_arr;
            }
            catch (Exception ex)
            {
                byte[] err = new byte[1] { 0 };
                Console.WriteLine(ex.Message);
                return err;
            }
        }

        public byte[] ACPR(int acfn_p, string acfn_path_rel, int livery_index, int type_start, int p_idx, string apt_id, int apt_rwy_idx, int apt_rwy_dir, double dob_lat_deg, double dob_lon_deg, double dob_ele_mtr, double dob_psi_tru, double dob_spd_msc)
        {
            try
            {
                byte[] command_arr = new byte[229];

                string2xp("ACPR", command_arr, 0);
                int2xp(acfn_p, command_arr, 5);
                string2xp(acfn_path_rel, command_arr, 9);
                int2xp(livery_index, command_arr, 160);

                string2xp("", command_arr, 164);

                int2xp(type_start, command_arr, 165);
                int2xp(p_idx, command_arr, 169);
                string2xp(apt_id, command_arr, 173);
                int2xp(apt_rwy_idx, command_arr, 181);
                int2xp(apt_rwy_dir, command_arr, 185);
                double2xp(dob_lat_deg, command_arr, 189);
                double2xp(dob_lon_deg, command_arr, 197);
                double2xp(dob_ele_mtr, command_arr, 205);
                double2xp(dob_psi_tru, command_arr, 213);
                double2xp(dob_spd_msc, command_arr, 221);

                return command_arr;
            }
            catch (Exception ex)
            {
                byte[] err = new byte[1] { 0 };
                Console.WriteLine(ex.Message);
                return err;
            }
        }

        public byte[] CMND(string method)
        {
            try
            {
                byte[] command_arr = new byte[6 + method.Length];
                string2xp("CMND", command_arr, 0);
                string2xp(method, command_arr, 5);
                return command_arr;
            }
            catch (Exception ex)
            {
                byte[] err = new byte[1] { 0 };
                Console.WriteLine(ex.Message);
                return err;
            }
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
                    des_arr[i + a] = Convert.ToByte(val[i]);

                des_arr[ val.Length + a] = 0x00;

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
