using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPUPC_Module
{
    public class Table
    {
        /// <summary>
        /// RPOS_Table
        /// </summary>
        public struct RPOS_Table
        {
            private double Dat_lon;         //经度，度
            public double dat_lon
            {
                get { return Dat_lon; }
                set { Dat_lon = value; }
            }

            private double Dat_lat;         //纬度，度
            public double dat_lat
            {
                get { return Dat_lat; }
                set { Dat_lat = value; }
            }

            private double Dat_ele;         //海拔高度，米
            public double dat_ele
            {
                get { return Dat_ele; }
                set { Dat_ele = value; }
            }

            private float Y_agl_mtr;        //对地高度，米
            public float y_agl_mtr
            {
                get { return Y_agl_mtr; }
                set { Y_agl_mtr = value; }
            }

            private float Veh_the_loc;      //pitch，度
            public float veh_the_loc
            {
                get { return Veh_the_loc; }
                set { Veh_the_loc = value; }
            }

            private float Veh_psi_loc;      //真实航向，度
            public float veh_psi_loc
            {
                get { return Veh_psi_loc; }
                set { Veh_psi_loc = value; }
            }

            private float Veh_phi_loc;      //roll，度
            public float veh_phi_loc
            {
                get { return Veh_phi_loc; }
                set { Veh_phi_loc = value; }
            }

            private float Vx_wrl;           //X轴速度，向东，米/秒
            public float vx_wrl
            {
                get { return Vx_wrl; }
                set { Vx_wrl = value; }
            }

            private float Vy_wrl;           //Y轴速度，向上，米/秒
            public float vy_wrl
            {
                get { return Vy_wrl; }
                set { Vy_wrl = value; }
            }

            private float Vz_wrl;           //Z轴速度，向南，米/秒
            public float vz_wrl
            {
                get { return Vz_wrl; }
                set { Vz_wrl = value; }
            }

            private float PRad;             //roll率，弧度/秒
            public float Prad
            {
                get { return PRad; }
                set { PRad = value; }
            }

            private float QRad;             //pitch率，弧度/秒
            public float Qrad
            {
                get { return QRad; }
                set { QRad = value; }
            }

            private float RRad;             //yaw率，弧度/秒
            public float Rrad
            {
                get { return RRad; }
                set { RRad = value; }
            }
        };

        public RPOS_Table RPOS_TABLE;

        /// <summary>
        /// RADR_Table
        /// </summary>
        public struct RADR_Table
        {
            private float Lon;               //雷达点经度
            public float lon
            {
                get { return Lon; }
                set { Lon = value; }
            }

            private float Lat;               //雷达点纬度
            public float lat
            {
                get { return Lat; }
                set { Lat = value; }
            }

            private float Storm_level_0_100; //降水量，0-100
            public float  storm_level_0_100
            {
                get { return Storm_level_0_100; }
                set { Storm_level_0_100 = value; }
            }

            private float Storm_hight_meters;//风暴平面海拔，米
            public float storm_hight_meters
            {
                get { return Storm_hight_meters; }
                set { Storm_hight_meters = value; }
            }
        };

        public RADR_Table RADR_TABLE;

        /// <summary>
        /// BECN_Table
        /// </summary>
        public struct BECN_Table
        {
            private char Beacon_major_version;  // 一次发送一个，主版本号
            public char beacon_major_version
            {
                get { return Beacon_major_version; }
                set { Beacon_major_version = value; }
            }

            private char Beacon_minor_version;  // 一次发送一个，副版本号
            public char beacon_minor_version
            {
                get { return Beacon_minor_version; }
                set { Beacon_minor_version = value; }
            }

            private int Application_host_id;    // 1是X-Plane，2是PlaneMaker
            public int application_host_id
            {
                get { return Application_host_id; }
                set { Application_host_id = value; }
            }

            private int Version_number;         // 104103是X-Plane 10.41r3
            public int version_number
            {
                get { return Version_number; }
                set { Version_number = value; }
            }

            private uint Role;                  // 1为主机，2是额外显示，3是IOS
            public uint role
            {
                get { return Role; }
                set { Role = value; }
            }

            private ushort Port;                // X-Plane监听的端口，49000为默认值
            public ushort port
            {
                get { return Port; }
                set { Port = value; }
            }

            private string Computer_name;       // 电脑的主机名，例如Joe’s Macbook
            public string computer_name
            {
                get { return Computer_name; }
                set { Computer_name = value; }
            }
        }

        public BECN_Table BECN_TABLE;

    }
}
