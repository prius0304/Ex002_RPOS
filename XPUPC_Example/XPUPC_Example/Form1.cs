using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using XPUPC_Module;

namespace XPUPC_Example
{
    public partial class Form1 : Form
    {
        XPUPC xpupc = new XPUPC();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            timerRPOS.Enabled = false;
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            if (xpupc.isOpened() == false)
            {
                xpupc.Open();
                txtState.Text = Convert.ToString(xpupc.isOpened());
                btnConn.Text = "Close";
            }
            else
            {
                xpupc.Close();
                txtState.Text = Convert.ToString(xpupc.isOpened());
                btnConn.Text = "Open";
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                int Rate = Convert.ToInt32(txtRPOSFreq.Text);
                if (Rate >= 0)
                {
                    xpupc.RPOS_Freq(Rate);
                    if (Rate != 0)
                        timerRPOS.Enabled = true;
                    else
                        timerRPOS.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btn_Flapsup_Click(object sender, EventArgs e)
        {
            xpupc.CMND("sim/flight_controls/flaps_up");
        }

        private void btn_Flapsdown_Click(object sender, EventArgs e)
        {
            xpupc.CMND("sim/flight_controls/flaps_down");
        }

        private void timerRPOS_Tick(object sender, EventArgs e)
        {
            try
            {
                txtLongtitude.Text = xpupc.varible.RPOS_dat_lon.ToString();
                txtLatitude.Text = xpupc.varible.RPOS_dat_lat.ToString();
                txtElevation.Text = xpupc.varible.RPOS_dat_ele.ToString();
                txtMeter.Text = xpupc.varible.RPOS_y_agl_mtr.ToString();
                txtPitch.Text = xpupc.varible.RPOS_veh_the_loc.ToString();
                txtYaw.Text = xpupc.varible.RPOS_veh_psi_loc.ToString();
                txtRoll.Text = xpupc.varible.RPOS_veh_psi_loc.ToString();
                txtXs.Text = xpupc.varible.RPOS_vx_wrl.ToString();
                txtYs.Text = xpupc.varible.RPOS_vy_wrl.ToString();
                txtZs.Text = xpupc.varible.RPOS_vz_wrl.ToString();
                txtRr.Text = xpupc.varible.RPOS_Prad.ToString();
                txtPr.Text = xpupc.varible.RPOS_Qrad.ToString();
                txtYr.Text = xpupc.varible.RPOS_Rrad.ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnRADR_Click(object sender, EventArgs e)
        {
            xpupc.DREF(1.13, "");
        }
    }
}
