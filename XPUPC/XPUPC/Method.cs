using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XPUPC_Module
{
    public class Method : Table
    {
        protected bool Debug_Switch = false;

        /// <summary>
        /// Get Time Now
        /// </summary>
        /// <returns></returns>
        protected string GetTime()
        {
            return (DateTime.Now.ToLocalTime().ToString() + ": ");
        }

        /// <summary>
        /// Debug Switch
        /// </summary>
        /// <param name="Switch"></param>
        public void DEBUG(short Switch)
        {
            if (Switch != 0)
                Debug_Switch = true;
            else
                Debug_Switch = false;
        }

        #region "Convert Functions"

        /// <summary>
        /// Convert to Int
        /// </summary>
        /// <param name="Sou_Arr"></param>
        /// <param name="Position"></param>
        /// <returns></returns>
        protected int ToInt(byte[] Sou_Arr, int Position)
        {
            try
            {
                byte[] array = new byte[4];
                for (int i = Position; i < Position + 4; i++)
                    array[i - Position] = Sou_Arr[i];
                return BitConverter.ToInt32(array, 0);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(GetTime() + "Conver to int error. Raw Data:" + Sou_Arr);
                return -999;
            }
        }

        /// <summary>
        /// Convert to Float
        /// </summary>
        /// <param name="Sou_Arr"></param>
        /// <param name="Postion"></param>
        /// <returns></returns>
        protected float ToFloat(byte[] Sou_Arr, int Postion)
        {
            try
            {
                byte[] array = new byte[4];
                for (int i = Postion; i < Postion + 4; i++)
                    array[i - Postion] = Sou_Arr[i];
                return BitConverter.ToSingle(array, 0);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(GetTime() + "Conver to float error. Raw Data:" + Sou_Arr);
                return -999;
            }
        }

        /// <summary>
        /// Convert to Double
        /// </summary>
        /// <param name="Sou_Arr"></param>
        /// <param name="Position"></param>
        /// <returns></returns>
        protected double ToDouble(byte[] Sou_Arr, int Position)
        {
            try
            {
                byte[] array = new byte[8];
                for (int i = Position; i < Position + 8; i++)
                    array[i - Position] = Sou_Arr[i];
                return BitConverter.ToDouble(array, 0);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(GetTime() + "Conver to double error. Raw Data:" + Sou_Arr);
                return -999;
            }
        }

        /// <summary>
        /// Convert to Char
        /// </summary>
        /// <param name="Sou_Arr"></param>
        /// <param name="Position"></param>
        /// <returns></returns>
        protected char ToChar(byte[] Sou_Arr, int Position)
        {
            try
            {
                byte[] array = new byte[4];
                for (int i = Position; i < Position + 4; i++)
                    array[i - Position] = Sou_Arr[i];
                return BitConverter.ToChar(array, 0);
            }
            catch(Exception ex)
            {
                Trace.WriteLine(GetTime() + "Conver to char error. Raw Data:" + Sou_Arr);
                return '-';
            }
        }

        /// <summary>
        /// int数据转化为byte
        /// </summary>
        /// <param name="Val"></param>
        /// <param name="Des_Arr"></param>
        /// <param name="Postion"></param>
        /// <returns></returns>
        protected int IntTo(int Val, byte[] Des_Arr, int Postion)
        {
            try
            {
                byte[] temp = BitConverter.GetBytes(Val);
                for (int i = 0; i < 4; i++)
                    Des_Arr[i + Postion] = temp[i];

                return 0;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(GetTime() + "Int convert error. Raw Data:" + Des_Arr);
                return -1;
            }
        }

        /// <summary>
        /// float数据转化为byte
        /// </summary>
        /// <param name="Val"></param>
        /// <param name="Des_Arr"></param>
        /// <param name="Postion"></param>
        /// <returns></returns>
        protected int FloatTo(float Val, byte[] Des_Arr, int Postion)
        {
            try
            {
                byte[] temp = BitConverter.GetBytes(Val);
                for (int i = 0; i < 4; i++)
                    Des_Arr[i + Postion] = temp[i];

                return 0;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(GetTime() + "Float convert error. Raw Data:" + Des_Arr);
                return -1;
            }
        }

        /// <summary>
        /// double数据转化为byte
        /// </summary>
        /// <param name="Val"></param>
        /// <param name="Des_Arr"></param>
        /// <param name="Postion"></param>
        /// <returns></returns>
        protected int DoubleTo(double Val, byte[] Des_Arr, int Postion)
        {
            try
            {
                byte[] temp = BitConverter.GetBytes(Val);
                for (int i = 0; i < 8; i++)
                    Des_Arr[i + Postion] = temp[i];

                return 0;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(GetTime() + "Double convert error. Raw Data:" + Des_Arr);
                return -1;
            }
        }

        /// <summary>
        /// string数据转化为byte
        /// </summary>
        /// <param name="val"></param>
        /// <param name="Des_Arr"></param>
        /// <param name="Position"></param>
        /// <returns></returns>
        protected int StringTo(string Val, byte[] Des_Arr, int Position)
        {
            try
            {
                for (int i = 0; i < Val.Length; i++)
                    Des_Arr[i + Position] = Convert.ToByte(Val[i]);

                Des_Arr[Val.Length + Position] = 0x00;

                return 0;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(GetTime() + "String convert error. Raw Data:" + Des_Arr);
                return -1;
            }
        }

        #endregion

        #region "Code"

        /// <summary>
        /// Set RPOS Frequency
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns></returns>
        public byte[] RPOS_Freq(int Frequency)
        {
            string freq_str = Convert.ToString(Frequency);
            byte[] command = new byte[freq_str.Length + 6];
            StringTo("RPOS", command, 0);
            StringTo(freq_str, command, 5);
            return command;
        }

        /// <summary>
        /// Set RADA Frequency
        /// </summary>
        /// <param name="Frequency"></param>
        /// <returns></returns>
        public byte[] RADA_Freq(int Frequency)
        {
            string freq_str = Convert.ToString(Frequency);
            byte[] command = new byte[freq_str.Length + 6];
            StringTo("RADR", command, 0);
            StringTo(freq_str, command, 5);
            return command;
        }

        /// <summary>
        /// VEHX
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="Longitude"></param>
        /// <param name="Latitude"></param>
        /// <param name="Elevation"></param>
        /// <param name="Heading"></param>
        /// <param name="Pitch"></param>
        /// <param name="Roll"></param>
        /// <returns></returns>
        public byte[] VEHX(int Index, double Longitude, double Latitude, double Elevation, float Heading, float Pitch, float Roll)
        {
            byte[] command = new byte[45];
            StringTo("VEHX", command, 0);
            IntTo(Index, command, 5);
            DoubleTo(Latitude, command, 9);
            DoubleTo(Longitude, command, 17);
            DoubleTo(Elevation, command, 25);
            FloatTo(Heading, command, 33);
            FloatTo(Pitch, command, 37);
            FloatTo(Roll, command, 41);
            return command;
        }

        /// <summary>
        /// ACFN
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="Dir_Path"></param>
        /// <param name="Livery_Index"></param>
        /// <returns></returns>
        public byte[] ACFN(int Index, string Dir_Path, int Livery_Index)
        {
            byte[] command = new byte[165];
            StringTo("ACFN", command, 0);
            IntTo(Index, command, 5);
            StringTo(Dir_Path, command, 9);
            IntTo(Livery_Index, command, 161);
            return command;
        }

        /// <summary>
        /// PREL
        /// </summary>
        /// <param name="Type_Start"></param>
        /// <param name="Aircraft_Index"></param>
        /// <param name="Airport_ID"></param>
        /// <param name="Airport_Runway"></param>
        /// <param name="Runway_Direction"></param>
        /// <param name="Longitude"></param>
        /// <param name="Latitude"></param>
        /// <param name="Elevation"></param>
        /// <param name="Heading"></param>
        /// <param name="Speed"></param>
        /// <returns></returns>
        public byte[] PREL(int Type_Start, int Aircraft_Index, string Airport_ID, int Airport_Runway, int Runway_Direction, double Longitude, double Latitude, double Elevation, double Heading, double Speed)
        {
            byte[] command = new byte[69];
            StringTo("PREL", command, 0);
            IntTo(Type_Start, command, 5);
            IntTo(Aircraft_Index, command, 9);
            StringTo(Airport_ID, command, 13);
            IntTo(Airport_Runway, command, 21);
            IntTo(Runway_Direction, command, 25);
            DoubleTo(Latitude, command, 29);
            DoubleTo(Longitude, command, 37);
            DoubleTo(Elevation, command, 45);
            DoubleTo(Heading, command, 53);
            DoubleTo(Speed, command, 61);
            return command;
        }

        /// <summary>
        /// ACPR
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="Dir_Path"></param>
        /// <param name="Livery_Index"></param>
        /// <param name="Type_Start"></param>
        /// <param name="Aircraft_Index"></param>
        /// <param name="Airport_ID"></param>
        /// <param name="Airport_Runway"></param>
        /// <param name="Runway_Direction"></param>
        /// <param name="Longitude"></param>
        /// <param name="Latitude"></param>
        /// <param name="Elevation"></param>
        /// <param name="Heading"></param>
        /// <param name="Speed"></param>
        /// <returns></returns>
        public byte[] ACPR(int Index, string Dir_Path, int Livery_Index, int Type_Start, int Aircraft_Index, string Airport_ID, int Airport_Runway, int Runway_Direction, double Longitude, double Latitude, double Elevation, double Heading, double Speed)
        {
            byte[] command = new byte[229];

            StringTo("ACPR", command, 0);
            IntTo(Index, command, 5);
            StringTo(Dir_Path, command, 9);
            IntTo(Livery_Index, command, 160);

            StringTo("", command, 164);

            IntTo(Type_Start, command, 165);
            IntTo(Aircraft_Index, command, 169);
            StringTo(Airport_ID, command, 173);
            IntTo(Airport_Runway, command, 181);
            IntTo(Runway_Direction, command, 185);
            DoubleTo(Latitude, command, 189);
            DoubleTo(Longitude, command, 197);
            DoubleTo(Elevation, command, 205);
            DoubleTo(Heading, command, 213);
            DoubleTo(Speed, command, 221);

            return command;
        }

        /// <summary>
        /// CMND
        /// </summary>
        /// <param name="Method"></param>
        /// <returns></returns>
        public byte[] CMND(string Method)
        {
            byte[] command = new byte[6 + Method.Length];
            StringTo("CMND", command, 0);
            StringTo(Method, command, 5);
            return command;
        }

        /// <summary>
        /// RREF
        /// </summary>
        /// <param name="Frequency"></param>
        /// <param name="DataRef_Index"></param>
        /// <param name="DataRref"></param>
        /// <returns></returns>
        public byte[] RREF(int Frequency, int DataRef_Index, string DataRref)
        {
            byte[] command = new byte[413];
            StringTo("RREF", command, 0);
            IntTo(Frequency, command, 5);
            IntTo(DataRef_Index, command, 9);
            StringTo(DataRref, command, 13);
            return command;
        }

        /// <summary>
        /// DREF
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="DataRef"></param>
        /// <returns></returns>
        public byte[] DREF(dynamic Value, string DataRef)
        {
            Type sysType = Value.GetType();
            byte[] command = new byte[509];
            StringTo("DREF", command, 0);
            StringTo(DataRef, command, 9);

            if (sysType.FullName == "System.Int32")
            {
                int vals = (int)Value;
                IntTo(vals, command, 5);
            }

            if (sysType.FullName == "System.Single" || sysType.FullName == "System.Double")
            {
                float vals = (float)Value;
                FloatTo(vals, command, 5);
            }

            return command;
        }

        /// <summary>
        /// DATA NEED TO BE MODIFIED!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public byte[] DATA(int Index, double Data1, double Data2, double Data3, double Data4, double Data5, double Data6, double Data7, double Data8)
        {
            byte[] command = new byte[73];
            StringTo("DATA", command, 0);
            IntTo(Index, command, 5);
            DoubleTo(Data1, command, 9);
            DoubleTo(Data2, command, 17);
            DoubleTo(Data3, command, 25);
            DoubleTo(Data4, command, 33);
            DoubleTo(Data5, command, 41);
            DoubleTo(Data6, command, 49);
            DoubleTo(Data7, command, 57);
            DoubleTo(Data8, command, 65);
            return command;
        }

        /// <summary>
        /// DESEL UNFINISHED
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public byte[] DESL(int Index)
        {
            byte[] command = new byte[9];
            StringTo("DESL", command, 0);
            StringTo(Index.ToString(), command, 5);
            return command;
        }

        /// <summary>
        /// USEL UNFINISHED
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public byte[] USEL(string Index)
        {
            byte[] command = new byte[9];
            StringTo("USEL", command, 0);
            StringTo(Index.ToString(), command, 5);
            return command;
        }

        /// <summary>
        /// DCOC UNFINISHED
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public byte[] DCOC(string Index)
        {
            byte[] command = new byte[9];
            StringTo("DCOC", command, 0);
            StringTo(Index.ToString(), command, 5);
            return command;
        }

        /// <summary>
        /// UCOC UNFINISHED
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public byte[] UCOC(string Index)
        {
            byte[] command = new byte[9];
            StringTo("UCOC", command, 0);
            StringTo(Index.ToString(), command, 5);
            return command;
        }

        /// <summary>
        /// ISE4
        /// </summary>
        /// <param name="Type_Ethe"></param>
        /// <param name="Destination_IP"></param>
        /// <param name="Destination_Port"></param>
        /// <param name="Multi_IP"></param>
        /// <returns></returns>
        public byte[] ISE4(int Type_Ethe, string Destination_IP, int Destination_Port, int Multi_IP)
        {
            byte[] command = new byte[37];
            StringTo("ISE4", command, 0);

            if (Regex.IsMatch(Destination_IP, @"^(\d{3}.){3}(\d{3})$") == false)
            {
                Trace.WriteLine("ISE4 IP format error. Set to 127.000.000.001 localhost. Prot 49000.");
                Destination_IP = "127.0.0.1";
                Destination_Port = 49000;
            }

            IntTo(Type_Ethe, command, 5);
            StringTo(Destination_IP, command, 9);
            StringTo(Destination_Port.ToString().PadLeft(8, '0'), command, 25);
            IntTo(Multi_IP, command, 33);

            return command;
        }

        /// <summary>
        /// ISE6
        /// </summary>
        /// <param name="Type_Ethe"></param>
        /// <param name="Destination_IP"></param>
        /// <param name="Destination_Port"></param>
        /// <param name="Multi_IP"></param>
        /// <returns></returns>
        public byte[] ISE6(int Type_Ethe, string Destination_IP, int Destination_Port, int Multi_IP)
        {
            byte[] command = new byte[65];
            StringTo("ISE4", command, 0);

            if (Regex.IsMatch(Destination_IP, @"^([\dA-Fa-f]{4}:){6}([\dA-Fa-f]{3}.){3}([\dA-Fa-f]{3})$") == false)
            {
                Trace.WriteLine("ISE6 IP format error. Set to 0000:0000:0000:0000:0000:0000:000.000.000.001. Prot 49000.");
                Destination_IP = "0000:0000:0000:0000:0000:0000:000.000.000.001";
                Destination_Port = 49000;
            }

            IntTo(Type_Ethe, command, 5);
            StringTo(Destination_IP, command, 9);
            StringTo(Destination_Port.ToString().PadLeft(8, '0'), command, 25);
            IntTo(Multi_IP, command, 33);

            return command;
        }

        /// <summary>
        /// SOUN
        /// </summary>
        /// <param name="Frequency"></param>
        /// <param name="Volume"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public byte[] SOUN(int Frequency, int Volume, string Path)
        {
            byte[] command = new byte[514];
            StringTo("SOUN", command, 0);
            IntTo(Frequency, command, 5);
            IntTo(Volume, command, 9);
            StringTo(Path, command, 13);
            return command;
        }

        /// <summary>
        /// LSND
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="Frequency"></param>
        /// <param name="Volume"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public byte[] LSND(int Index, int Frequency, int Volume, string Path)
        {
            byte[] command = new byte[518];
            StringTo("LSND", command, 0);
            IntTo(Index, command, 5);
            IntTo(Frequency, command, 9);
            IntTo(Volume, command, 13);
            StringTo(Path, command, 17);
            return command;
        }

        /// <summary>
        /// SSND
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="Frequency"></param>
        /// <param name="Volume"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public byte[] SSND(int Index, int Frequency, int Volume, string Path)
        {
            byte[] command = new byte[518];
            StringTo("SSND", command, 0);
            IntTo(Index, command, 5);
            IntTo(Frequency, command, 9);
            IntTo(Volume, command, 13);
            StringTo(Path, command, 17);
            return command;
        }

        /// <summary>
        /// OBJN
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public byte[] OBJN(int Index, string Path)
        {
            byte[] command = new byte[510];
            StringTo("OBJN", command, 0);
            IntTo(Index, command, 5);
            StringTo(Path, command, 9);
            return command;
        }

        /// <summary>
        /// OBJL
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="Longitude"></param>
        /// <param name="Latitude"></param>
        /// <param name="Elevation"></param>
        /// <param name="Heading"></param>
        /// <param name="Pitch"></param>
        /// <param name="Roll"></param>
        /// <param name="IsOnGound"></param>
        /// <param name="Smook_Size"></param>
        /// <returns></returns>
        public byte[] OBJL(int Index, double Longitude, double Latitude, double Elevation, float Heading, float Pitch, float Roll, int IsOnGound, float Smook_Size)
        {
            byte[] command = new byte[53];
            StringTo("OBJL", command, 0);
            IntTo(Index, command, 5);
            DoubleTo(Longitude, command, 9);
            DoubleTo(Latitude, command, 17);
            DoubleTo(Elevation, command, 25);
            FloatTo(Heading, command, 33);
            FloatTo(Pitch, command, 37);
            FloatTo(Roll, command, 41);
            IntTo(IsOnGound, command, 45);
            FloatTo(Smook_Size, command, 49);
            return command;
        }


        /// <summary>
        /// ALRT NEED TO BE MODIFIED !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public byte[] ALRT(string msg)
        {
            byte[] command = new byte[966];
            return command;
        }

        /// <summary>
        /// FAIL
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public byte[] FAIL(int Index)
        {
            byte[] command = new byte[9];
            StringTo("FAIL", command, 0);
            StringTo(Index.ToString(), command, 5);
            return command;
        }

        /// <summary>
        /// RECO
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public byte[] RECO(int Index)
        {
            byte[] command = new byte[9];
            StringTo("RECO", command, 0);
            StringTo(Index.ToString(), command, 5);
            return command;
        }

        /// <summary>
        /// NFAL
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public byte[] NFAL(int Index)
        {
            byte[] command = new byte[9];
            StringTo("NFAL", command, 0);
            StringTo(Index.ToString(), command, 5);
            return command;
        }

        /// <summary>
        /// NREC
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public byte[] NREC(int Index)
        {
            byte[] command = new byte[9];
            StringTo("NREC", command, 0);
            StringTo(Index.ToString(), command, 5);
            return command;
        }

        /// <summary>
        /// RESE
        /// </summary>
        /// <returns></returns>
        public byte[] RESE()
        {
            byte[] command = new byte[5];
            StringTo("RESE", command, 0);
            return command;
        }

        /// <summary>
        /// QUIT
        /// </summary>
        /// <returns></returns>
        public byte[] QUIT()
        {
            byte[] command = new byte[5];
            StringTo("QUIT", command, 0);
            return command;
        }

        /// <summary>
        /// SHUT
        /// </summary>
        /// <returns></returns>
        public byte[] SHUT()
        {
            byte[] command = new byte[5];
            StringTo("SHUT", command, 0);
            return command;
        }

        #endregion

        #region "Decode"

        /// <summary>
        /// RPOS Data Process
        /// </summary>
        /// <param name="argv"></param>
        protected void RPOS_Process(byte[] argv)
        {
            RPOS_TABLE.dat_lon = ToDouble(argv, 0);
            RPOS_TABLE.dat_lat = ToDouble(argv, 8);
            RPOS_TABLE.dat_ele = ToDouble(argv, 16);
            RPOS_TABLE.y_agl_mtr = ToFloat(argv, 24);
            RPOS_TABLE.veh_the_loc = ToFloat(argv, 28);
            RPOS_TABLE.veh_psi_loc = ToFloat(argv, 32);
            RPOS_TABLE.veh_phi_loc = ToFloat(argv, 36);
            RPOS_TABLE.vx_wrl = ToFloat(argv, 40);
            RPOS_TABLE.vy_wrl = ToFloat(argv, 44);
            RPOS_TABLE.vz_wrl = ToFloat(argv, 58);
            RPOS_TABLE.Prad = ToFloat(argv, 52);
            RPOS_TABLE.Qrad = ToFloat(argv, 56);
            RPOS_TABLE.Rrad = ToFloat(argv, 60);
        }

        /// <summary>
        /// RADR Data Process
        /// </summary>
        /// <param name="argv"></param>
        protected void RADR_Process(byte[] argv)
        {
            RADR_TABLE.lon = ToFloat(argv, 0);
            RADR_TABLE.lat = ToFloat(argv, 4);
            RADR_TABLE.storm_level_0_100 = ToFloat(argv, 8);
            RADR_TABLE.storm_hight_meters = ToFloat(argv, 12);
        }

        /// <summary>
        /// BECN
        /// </summary>
        /// <param name="argv"></param>
        protected void BECN_Process(byte[] argv)
        {
            int i;

            BECN_TABLE.beacon_major_version = ToChar(argv, 0);
            BECN_TABLE.beacon_minor_version = ToChar(argv, 4);
            BECN_TABLE.application_host_id = ToInt(argv, 8);
            BECN_TABLE.version_number = ToInt(argv, 12);
            BECN_TABLE.role = (uint)ToInt(argv, 16);
            BECN_TABLE.port = (ushort)ToInt(argv, 20);
            BECN_TABLE.computer_name = "";
            for (i = 24; i < argv.Length; i++)
                BECN_TABLE.computer_name += ToChar(argv, i);
        }

        #endregion
    }
}
