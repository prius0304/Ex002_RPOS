using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPUPC_Module
{
    /// <summary>
    /// 变量表
    /// </summary>
    public class Variable
    {
        public double RPOS_dat_lon;         //经度，度
        public double RPOS_dat_lat;         //纬度，度
        public double RPOS_dat_ele;         //海拔高度，米
        public float RPOS_y_agl_mtr;        //对地高度，米
        public float RPOS_veh_the_loc;      //pitch，度
        public float RPOS_veh_psi_loc;      //真实航向，度
        public float RPOS_veh_phi_loc;      //roll，度
        public float RPOS_vx_wrl;           //X轴速度，向东，米/秒
        public float RPOS_vy_wrl;           //Y轴速度，向上，米/秒
        public float RPOS_vz_wrl;           //Z轴速度，向南，米/秒
        public float RPOS_Prad;             //roll率，弧度/秒
        public float RPOS_Qrad;             //pitch率，弧度/秒
        public float RPOS_Rrad;             //yaw率，弧度/秒

        public float RADR_lon;               //雷达点经度
        public float RADR_lat;               //雷达点纬度
        public float RADR_storm_level_0_100; //降水量，0-100
        public float RADR_storm_hight_meters;//风暴平面海拔，米

        /// <summary>
        /// 初始化Variable
        /// </summary>
        public Variable()
        {
            RPOS_dat_lon = 0;
            RPOS_dat_lat = 0;
            RPOS_dat_ele = 0;
            RPOS_y_agl_mtr = 0;
            RPOS_veh_the_loc = 0;
            RPOS_veh_psi_loc = 0;
            RPOS_veh_phi_loc = 0;
            RPOS_vx_wrl = 0;
            RPOS_vy_wrl = 0;
            RPOS_vz_wrl = 0;
            RPOS_Prad = 0;
            RPOS_Qrad = 0;
            RPOS_Rrad = 0;

            RADR_lon = 0;
            RADR_lat = 0;
            RADR_storm_level_0_100 = 0;
            RADR_storm_hight_meters = 0;
        }
    }

    /// <summary>
    /// 常量表
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// START参数
        /// </summary>
        public class START
        {
            public const int loc_repeat_last = 5;       // 给ATC或重置飞行使用
            public const int loc_specify_lle = 6;       // 给地图使用
            public const int loc_general_area = 7;  // 自动加载飞机并增加飞机数量
            public const int loc_nearest_apt = 8;       // 加载新飞机，不改变位置
            public const int loc_snap_load = 9;         // 从快照中加载，不改变航路与飞机位置
            public const int loc_ram = 10;              // 斜坡开始
            public const int loc_tak = 11;              // 跑道上起飞
            public const int loc_vfr = 12;              // VFR进近
            public const int loc_ifr = 13;              // IFR进近
            public const int loc_grs = 14;              // 草地跑道
            public const int loc_drt = 15;              // 脏跑道
            public const int loc_grv = 16;              // 砂石跑道
            public const int loc_wat = 17;              // 水上机位
            public const int loc_pad = 18;              // 直升机停机坪
            public const int loc_cat = 19;              // 舰载平台
            public const int loc_tow = 20;              // 滑翔机，牵引机
            public const int loc_win = 21;              // 滑翔机，卷扬机
            public const int loc_frm = 22;              // 编队飞行
            public const int loc_Are = 23;              // 重新加油- Boom
            public const int loc_Nre = 24;              // 重新加油 - Basket
            public const int loc_drp = 25;              // B52投掷
            public const int loc_pig = 26;              // 坨着航天飞机
            public const int loc_car = 27;              // 运输机进近
            public const int loc_fri = 28;              // 护卫舰进近
            public const int loc_rig = 29;              // 少油进近
            public const int loc_pla = 30;              // 重油进近
            public const int loc_fir = 31;              // 森林火灾进近
            public const int loc_SO1 = 32;              // 航天飞机
            public const int loc_SO2 = 33;              //  ""
            public const int loc_SO3 = 34;              //  ""
            public const int loc_SO4 = 35;              //  ""
            public const int loc_shuttle_glide = 36; 	// 只能用于抛投坨着的航天飞机
        }
    }
}
