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
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            xpupc.Open();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            xpupc.RPOS_Freq(60);
        }

        private void btn_Flapsup_Click(object sender, EventArgs e)
        {
            xpupc.CMND("sim/flight_controls/flaps_up");
        }

        private void btn_Flapsdown_Click(object sender, EventArgs e)
        {
            xpupc.CMND("sim/flight_controls/flaps_down");
        }
    }
}
