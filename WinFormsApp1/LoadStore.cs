using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class LoadStore
    {
        private static void trimOps(ref String[] ops)
        {
            for (int i = 0; i < ops.Length; i++)
            {
                ops[i] = ops[i].Trim().ToUpper();
            }
        }


        public static void LD(string args)
        {
            String[] ops = args.Split(',');
            if (ops.Length > 0)
                trimOps(ref ops);


            if(ops.Length == 2)
            {
                int OP = 0;

                if (ops[1][0] >= '0' && ops[1][0] <='9')
                     OP = Convert.ToInt32(ops[1]);

                Config.setReg(ops[0], OP);
            }
            else if(ops.Length == 1)
            {
                Config.ACC =  Config.getReg(ops[0]);
            }
            else
            {
                //TODO: Error inavlid number of operands
            }


        }


        public static void ST(string args)
        {
            String[] ops = args.Split(',');
            if (ops.Length > 0)
                trimOps(ref ops);

            if (ops.Length == 2 && args != "")
            {
                int OP1 = Config.getReg(ops[1]);
                int OP2 = Config.getReg(ops[0]);

                Config.memory[OP2] = OP1;

            }
            if(ops.Length == 1)
            {
                int OP1 = Config.getReg(ops[0]);

                Config.memory[OP1] = Config.ACC;

            }
        }

        public static void MOV(string args)
        {
            String[] ops = args.Split(',');
            if (ops.Length > 0)
                trimOps(ref ops);

            if (ops.Length == 2 && args != "")
            {

                int OP = Config.getReg(ops[1]);

                Config.setReg(ops[0], OP);

            }
            else if(ops.Length == 1)
            {
                Config.setReg(ops[0], Config.ACC);
            }

        }

        public static void CLR(string args)
        {
            String[] ops = args.Split(',');
            if (ops.Length > 0)
                trimOps(ref ops);

            if (ops.Length == 1 && args != "")
            {
                Config.setReg(ops[0], 0);
            }
            else if (ops.Length == 0 || args == "")
            {
                Config.ACC = 0;
            }

        }


    }
}
