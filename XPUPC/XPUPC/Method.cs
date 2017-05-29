using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPUPC_Module
{
    public class Method
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
        /// byte数据转化为double
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
    }
}
