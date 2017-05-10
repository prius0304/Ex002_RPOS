using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    public class variable
    {
        #region RPOS
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
        #endregion

        #region RADR
        public float lon;               //雷达点经度
        public float lat;               //雷达点纬度
        public float storm_level_0_100; //降水量，0-100
        public float storm_hight_meters;//风暴平面海拔，米
        #endregion
    }
}
