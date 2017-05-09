using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    public class variable
    {
        public double dat_lon;      //经度，度
        public double dat_lat;      //纬度，度
        public double dat_ele;      //海拔高度，米
        public float y_agl_mtr;     //对地高度，米
        public float veh_the_loc;   //pitch，度
        public float veh_psi_loc;   //真实航向，度
        public float veh_phi_loc;   //roll，度
        public float vx_wrl;        //X轴速度，向东，米/秒
        public float vy_wrl;        //Y轴速度，向上，米/秒
        public float vz_wrl;        //Z轴速度，向南，米/秒
        public float Prad;          //roll率，弧度/秒
        public float Qrad;          //pitch率，弧度/秒
        public float Rrad;          //yaw率，弧度/秒
    }

    public class XPIPC
    {
        public variable Offset = new variable();
        public int RPOS_Process(byte[] argv)
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
    }
}
