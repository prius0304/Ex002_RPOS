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
    public partial class Form1 : Form
    {
        XPUPC xpupc = new XPUPC();
        public Form1()
        {
            InitializeComponent();
        }
    }
}
