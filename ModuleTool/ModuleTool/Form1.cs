using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using XPIPC_Module;

namespace ModuleTool
{
    public partial class FormMain : Form
    {
        XPIPC xpipc = new XPIPC();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        { 
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string str = textBox1.Text;
                string val = "";
                int i;

                str = str.Replace(" ", "");
                str = str.Replace(",", "");
                str = str.Replace("0x", "");
                str = str.Replace("0X", "");

                byte[] array = new byte[str.Length / 2];

                for ( i = 0 ; i < str.Length; i++)
                {
                    val += str[i];
                    if(i%2==1)
                    {
                        array[i/2] = byte.Parse(val,System.Globalization.NumberStyles.HexNumber);
                        val = "";
                    }
                }

                xpipc.Process(array);
                display_rpos();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void display_rpos()
        {
            Console.Clear();
            Console.WriteLine("dat_lon=         " + xpipc.offset.dat_lon);
            Console.WriteLine("dat_lat=         " + xpipc.offset.dat_lat);
            Console.WriteLine("dat_ele=         " + xpipc.offset.dat_ele);
            Console.WriteLine("y_agl_mtr=       " + xpipc.offset.y_agl_mtr);
            Console.WriteLine("veh_the_loc=     " + xpipc.offset.veh_the_loc);
            Console.WriteLine("veh_psi_loc=     " + xpipc.offset.veh_psi_loc);
            Console.WriteLine("veh_phi_loc=     " + xpipc.offset.veh_phi_loc);
            Console.WriteLine("vx_wrl=          " + xpipc.offset.vx_wrl);
            Console.WriteLine("vy_wrl=          " + xpipc.offset.vy_wrl);
            Console.WriteLine("vz_wrl=          " + xpipc.offset.vz_wrl);
            Console.WriteLine("Prad=            " + xpipc.offset.Prad);
            Console.WriteLine("Qrad=            " + xpipc.offset.Qrad);
            Console.WriteLine("Rrad=            " + xpipc.offset.Rrad);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            byte[] temp = xpipc.ACFN(0, @"Aircraft\Laminar Research\Cirrus SF-50\CirrusSF50.acf", 0);
            for (int i =0;i<temp.Length;i++)
                Console.Write(temp[i] + " ");
        }
    }
}
