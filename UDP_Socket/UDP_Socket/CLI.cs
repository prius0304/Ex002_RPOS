using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDP_Socket
{
    public class CLI
    {
        int cmd_num_current = 0;

		struct CMD_List
		{
			public byte[] name;
			public string usage;
			public delegate void DelegateMethod(byte[] argv);
			public DelegateMethod delegateMethod;

			public void RunDelegateMethods(byte[] argv)
			{
				if (delegateMethod != null)
					delegateMethod.Invoke(argv);
			}
		}

        CMD_List[] cmd_list = new CMD_List[50];

		int Subyte(byte[] new_arr, byte[] raw_arr, int a, int b)
		{
			if (raw_arr.Length >= b)
			{
				for (int i = a; i<b; i++)
					new_arr[i-a] = raw_arr[i];
				return 0;
			}
			else
			{
				Console.WriteLine("Error!\n");
				return -1;
			}
		}

		private void CMD_Register(byte[] name, string usage, CMD_List.DelegateMethod method)
		{
            int ret;

            Subyte(cmd_list[cmd_num_current].name, name, 0, name.Length);
            cmd_list[cmd_num_current].usage = usage;
            cmd_list[cmd_num_current].delegateMethod = method;

            cmd_num_current++;
		}

		public CLI()
		{
            byte[] rpos = new byte[] { 0x52, 0x50, 0x4F, 0x53 };
            CMD_Register(rpos, "RPOS", RPOS);
		}
        public void command(byte[] args)
        {
            byte[] Command_name = new byte[4];
            byte[] Command_value = new byte[514];

            if (args.Length > 5)
            {
                Subyte(Command_name, args, 0, 3);
                Subyte(Command_value, args, 5, args.Length);
            }
            else
            {
                Subyte(Command_name, args, 0, 3);
                Subyte(Command_value, args, 4, 4);
            }

            for (int i = 0; i < Command_name.Length; i++)
                Console.Write(Command_name[i] + " ");
            Console.WriteLine();
            for (int i = 0; i < Command_value.Length; i++)
                Console.Write(Command_value[i] + " ");
            Console.WriteLine();
        }


        public void RPOS(byte[] argv)
        {
            Console.WriteLine("YES");
        }
    }
}
