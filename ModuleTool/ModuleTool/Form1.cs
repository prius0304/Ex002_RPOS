using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Module;

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
            Console.WriteLine("dat_lon=         " + xpipc.Offset.dat_lon);
            Console.WriteLine("dat_lat=         " + xpipc.Offset.dat_lat);
            Console.WriteLine("dat_ele=         " + xpipc.Offset.dat_ele);
            Console.WriteLine("y_agl_mtr=       " + xpipc.Offset.y_agl_mtr);
            Console.WriteLine("veh_the_loc=     " + xpipc.Offset.veh_the_loc);
            Console.WriteLine("veh_psi_loc=     " + xpipc.Offset.veh_psi_loc);
            Console.WriteLine("veh_phi_loc=     " + xpipc.Offset.veh_phi_loc);
            Console.WriteLine("vx_wrl=          " + xpipc.Offset.vx_wrl);
            Console.WriteLine("vy_wrl=          " + xpipc.Offset.vy_wrl);
            Console.WriteLine("vz_wrl=          " + xpipc.Offset.vz_wrl);
            Console.WriteLine("Prad=            " + xpipc.Offset.Prad);
            Console.WriteLine("Qrad=            " + xpipc.Offset.Qrad);
            Console.WriteLine("Rrad=            " + xpipc.Offset.Rrad);
        }

    }
}
