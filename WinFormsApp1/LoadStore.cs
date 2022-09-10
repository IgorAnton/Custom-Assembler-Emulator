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
                int OP1 = 0;


                if (ops[1][0] >='0' && ops[1][0] <='9')
                {
                    string op = ops[1];

                    OP1 = Convert.ToInt32(op);
                }
                else
                {
                    //TODO: Error invalid arg
                }

                if (ops[0][0] == 'R')
                {
                    int regNum = Convert.ToInt32(ops[0].Substring(1)) ;
                    Config.registers[regNum] = OP1;   

                }

            }
            else if(ops.Length == 1)
            {
                int OP1 = 0;


                if (ops[0][0] >= '0' && ops[0][0] <= '9')
                {
                    OP1 = Convert.ToInt32(ops[0]);
                }
                else  if (ops[0][0] == 'R')
                {
                    int regNum = Convert.ToInt32(ops[0].Substring(1));
                    

                    OP1 = Config.registers[regNum];
                    

                }

                Config.ACC = OP1;

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
                int OP1 = 0;

                if (ops[1][0] == 'R')
                {
                    string op = ops[1].Substring(1);

                    int regNum = Convert.ToInt32(op);

                    OP1 = Config.registers[regNum];
                }

                if (ops[0][0] == 'R')
                {
                    string op = ops[0].Substring(1);
                    int regNum = Convert.ToInt32(op);

                    int memLoc = Config.registers[regNum];

                    Config.memory[memLoc] = OP1;

                }


            }
        }

        public static void MOV(string args)
        {
            String[] ops = args.Split(',');
            if (ops.Length > 0)
                trimOps(ref ops);

            if (ops.Length == 2 && args != "")
            {
                int OP1 = 0;

                if (ops[1][0] == '(' && ops[1][ops[1].Length - 1] == ')')
                {
                    string op = ops[1].Substring(1, ops[1].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        OP1 = Config.memory[Config.registers[regNum]];
                    }
                    else
                    {
                        //TODO: ERROR
                    }
                }
                else
                {
                    if (ops[1][0] == 'R')
                    {
                        string op = ops[1].Substring(1);
                        int regNum = Convert.ToInt32(op);
                        OP1 = Config.registers[regNum];

                    }
                    else
                    {
                        
                            //TODO: ERROR
                        
                    }
                }

                if (ops[0][0] == '(' && ops[0][ops[0].Length - 1] == ')')
                {
                    string op = ops[0].Substring(1, ops[0].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        Config.memory[Config.registers[regNum]] = OP1;
                    }
                    else
                    {
                        //TODO: ERROR
                    }

                }
                else
                {
                    if (ops[0][0] == 'R')
                    {
                        string op = ops[0].Substring(1);
                        int regNum = Convert.ToInt32(op);
                        Config.registers[regNum] = OP1;

                    }
                    else
                    {
                        //TODO: ERROR
                    }
                }



            }

        }

    }
}
