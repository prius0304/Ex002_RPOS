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

        int Comparebyte(byte[] a, byte[] b)
        {
            int i;

            if (a.Length == b.Length)
            {
                for (i = 0; i < a.Length; i++)
                    if (a[i] != b[i])
                        return -1;
            }
            else
                return -1;

     
            return 0;
        }

		private void CMD_Register(byte[] name, string usage, CMD_List.DelegateMethod method)
		{
            cmd_list[cmd_num_current].name = name;
            cmd_list[cmd_num_current].usage = usage;
            cmd_list[cmd_num_current].delegateMethod = method;

            cmd_num_current++;
		}

        int CMD_Find(byte[] name)
        {
            int cmd_index = 0;

            while(cmd_index<cmd_num_current)
            {
                if ( Comparebyte(cmd_list[cmd_index].name, name) == 0 )
                    return cmd_index;
                cmd_index++;
            }
            return -1;
        }

        int CMD_Run(byte[] name, byte[] value)
        {
            int cmd_index = 0;

            cmd_index = CMD_Find(name);
            if(cmd_index!=-1)
            {
                cmd_list[cmd_index].RunDelegateMethods(value);
                return 0;
            }
            Console.WriteLine("Run Cmd Error.");
            return -1;
        }

		public CLI()
		{
            byte[] help = new byte[4] { 0x48, 0x45, 0x4C, 0x50 };
            byte[] rpos = new byte[4] { 0x52, 0x50, 0x4F, 0x53 };

            CMD_Register(help, "List all command.", HELP);
            CMD_Register(rpos, "Report Postion.", RPOS);
        }

        public void command(byte[] argv)
        {
            byte[] Command_name = new byte[4];
            byte[] Command_value = new byte[504];

            if (argv.Length > 5)
            {
                Subyte(Command_name, argv, 0, 4);
                Subyte(Command_value, argv, 5, argv.Length);
            }
            else
            {
                Subyte(Command_name, argv, 0, 4);
                Subyte(Command_value, argv, 4, 4);
            }

            CMD_Run(Command_name, Command_value);
        }

        public void HELP(byte[] argv)
        {
            int i;
            for (i = 0; i < cmd_num_current; i++)
                Console.Write(System.Text.Encoding.Default.GetString(cmd_list[i].name) + "     " + cmd_list[i].usage + "\n");
        }

        public void RPOS(byte[] argv)
        {
            Console.WriteLine("YES");
        }
    }
}
