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

        private void btConn_Click(object sender, EventArgs e)
        {
            xpupc.DEBUG(1);
            xpupc.ISE6(1, "0001:0002:0003:0004:0005:ffff:111.112.113.114", 49000,1);
        }
    }
}
