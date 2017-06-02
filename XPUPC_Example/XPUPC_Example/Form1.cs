using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XPUPC_Module;

namespace XPUPC_Example
{
    public partial class FormMain : Form
    {
        XPUPC xpupc = new XPUPC();
        
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            tb_Status.BackColor = Color.Red;
            xpupc.DEBUG(1);
        }

        private void btConn_Click(object sender, EventArgs e)
        {
            int res;

            if (xpupc.Satus())
            {
                res = xpupc.Close();
                if (res == 0)
                {
                    tb_Status.BackColor = Color.Red;
                    tb_Status.Text = "unconnect";
                    btConn.Text = "Connect";

                    tb_DesIP.Enabled = true;
                    tb_DesPT.Enabled = true;
                    tb_SouPT.Enabled = true;
                    btChangeEth.Enabled = true;
                }
            }
            else
            {
                res = xpupc.Open();
                if (res == 0)
                {
                    tb_Status.BackColor = Color.Green;
                    tb_Status.Text = "connected";
                    btConn.Text = "Disconnect";

                    tb_DesIP.Enabled = false;
                    tb_DesPT.Enabled = false;
                    tb_SouPT.Enabled = false;
                    btChangeEth.Enabled = false;
                }
            }
        }

        private void btChangeEth_Click(object sender, EventArgs e)
        {
            int res;
            res = xpupc.Set_Ethe(tb_DesIP.Text, int.Parse(tb_DesPT.Text), int.Parse(tb_SouPT.Text));
            if (res == 0)
                MessageBox.Show("Ethernet parameter change success.");
            else
                MessageBox.Show("Ethernet parameter change failed.");
        }

        private void bt_SetRPOS_Click(object sender, EventArgs e)
        {
            try
            {
                int Frq = int.Parse(tb_RPOS_Frq.Text);
                xpupc.Set_RPOS_Freq(Frq);
                timerRPOS.Enabled = true;
                if (Frq == 0)
                    timerRPOS.Enabled = false;
            }
            catch(Exception ex)
            {
                xpupc.Set_RPOS_Freq(0);
                tb_RPOS_Frq.Text = "0";
                timerRPOS.Enabled = false;
            }
        }

        private void timerRPOS_Tick(object sender, EventArgs e)
        {
            tb_RPOS_Lon.Text = xpupc.RPOS_TABLE.dat_lon.ToString();
            tb_RPOS_Lat.Text = xpupc.RPOS_TABLE.dat_lat.ToString();
            tb_RPOS_Ele.Text = xpupc.RPOS_TABLE.dat_ele.ToString();
            tb_RPOS_GH.Text = xpupc.RPOS_TABLE.y_agl_mtr.ToString();
            tb_RPOS_Pitch.Text = xpupc.RPOS_TABLE.veh_the_loc.ToString();
            tb_RPOS_Head.Text = xpupc.RPOS_TABLE.veh_psi_loc.ToString();
            tb_RPOS_Roll.Text = xpupc.RPOS_TABLE.veh_phi_loc.ToString();
            tb_RPOS_X.Text = xpupc.RPOS_TABLE.vx_wrl.ToString();
            tb_RPOS_Y.Text = xpupc.RPOS_TABLE.vy_wrl.ToString();
            tb_RPOS_Z.Text = xpupc.RPOS_TABLE.vz_wrl.ToString();
            tb_RPOS_P.Text = xpupc.RPOS_TABLE.Prad.ToString();
            tb_RPOS_Q.Text = xpupc.RPOS_TABLE.Qrad.ToString();
            tb_RPOS_R.Text = xpupc.RPOS_TABLE.Rrad.ToString();
        }
    }
}
