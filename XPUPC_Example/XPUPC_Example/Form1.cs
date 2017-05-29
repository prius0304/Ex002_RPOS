﻿using System;
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
            xpupc.Set_Ethe("127.0.0.1", 49000, 56000);
            xpupc.Open();
        }
    }
}
