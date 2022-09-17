using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Stack
    {

        public static void PUSH(String args)
        {
            String[] ops = args.Split(' ');

            if(ops.Length == 1 && args != "")
            {
                int regNum = Convert.ToInt32(ops[0].Substring(1, ops[0].Length-1));

                int reg = Config.registers[regNum];

                Config.memory[Config.USER_STACK] = reg;
                Config.USER_STACK++;

                Config.instrucitonsInBinary[Config.PC] = Memory.formOneAddres("PUSH", ops[0]);

            }
            else if (ops.Length == 0 || args == "")
            {
                Config.memory[Config.USER_STACK] = Config.ACC;
                Config.USER_STACK++;

                Config.instrucitonsInBinary[Config.PC] = Memory.formZeroAddres("PUSH");
            }
            else
            {
                // TODO: ERROR invalid number of operators
            }

        }
        public static void POP(String args)
        {
            String[] ops = args.Split(' ');

            if(ops.Length == 1 && args != "")
            {
                int regNum = Convert.ToInt32(ops[0].Substring(1, ops[0].Length - 1));

                int popped = Config.memory[--Config.USER_STACK];
                

                Config.registers[regNum] = popped;

                Config.instrucitonsInBinary[Config.PC] = Memory.formOneAddres("POP", ops[0]);
            }
            else if(ops.Length == 0 || args == "")
            {

                int popped = Config.memory[--Config.USER_STACK];
                
                Config.ACC = popped;

                Config.instrucitonsInBinary[Config.PC] = Memory.formZeroAddres("POP");

            }
            else
            {
                // TODO: ERROR invalid number of operators
            }
        }

    }
}
