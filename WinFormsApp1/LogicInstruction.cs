using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class LogicInstruction
    {
        private static void trimOps(ref String[] ops)
        {
            for (int i = 0; i < ops.Length; i++)
            {
                ops[i] = ops[i].Trim();
            }
        }

        public static void AND(string args)
        {
            String[] ops = args.Split(',');
            if (ops.Length > 0)
                trimOps(ref ops);

            if (ops.Length == 1 && args != "")
            {
                string op;
                int OP1 = 0;
                if (ops[0][0] == 'R')
                {
                    op = ops[0].Substring(1);

                    int regNum = Convert.ToInt32(op);
                    OP1 = Config.registers[regNum];

                }
                else
                {
                    //TODO: ERROR

                }
                int tmp1 = Config.ACC;
                int tmp2 = OP1;

                if ((tmp1 & tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 & tmp2) == 0)
                {
                    Config.EQUAL = true;
                    Config.LESS = false;
                    Config.GREATER = false;

                    Config.NZCV |= 4;
                }
                Config.ACC = (Config.ACC & OP1) % 65536;

                if (Config.ACC < 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = true;
                    Config.GREATER = false;

                    Config.ACC = 0;
                }
                else if(Config.ACC > 0){
                    Config.EQUAL = false;
                    Config.LESS = false;
                    Config.GREATER = true;
                }

            }
            else if (ops.Length == 2 && args != "")
            {
                string op;
                int OP1 = 0;
                int regNum = 0;
                if (ops[1][0] == 'R')
                {
                    op = ops[1].Substring(1);
                    regNum = Convert.ToInt32(op);
                    OP1 = Config.registers[regNum];
                }
                else
                {

                    //TODO: ERROR
                }

                if (ops[0][0] == 'R')
                {
                    op = ops[0].Substring(1);
                    regNum = Convert.ToInt32(op);
                }
                else
                {
                    //TODO: ERROR
                }

                int tmp1 = Config.registers[regNum];
                int tmp2 = OP1;


                if ((tmp1 & tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 & tmp2) == 0)
                {
                    Config.EQUAL = true;
                    Config.LESS = false;
                    Config.GREATER = false;

                    Config.NZCV |= 4;
                }
                Config.registers[regNum] = (Config.registers[regNum] & OP1) % 65536;
                if (Config.registers[regNum] < 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = true;
                    Config.GREATER = false;

                    Config.registers[regNum] = 0;


                }
                else if(Config.registers[regNum] > 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = false;
                    Config.GREATER = true;

                }
            }
            else if (ops.Length == 3 && args != "")
            {
                int OP1 = 0, OP2 = 0;
                string op;
                int regNum = 0;
                if (ops[1][0] == 'R')
                {
                    op = ops[1].Substring(1);
                    regNum = Convert.ToInt32(op);
                    OP1 = Config.registers[regNum];
                }
                else
                {

                    //TODO: ERROR
                }

                if (ops[2][0] == 'R')
                {
                    op = ops[2].Substring(1);
                    regNum = Convert.ToInt32(op);
                    OP2 = Config.registers[regNum];
                }
                else
                {

                    //TODO: ERROR
                }

                if (ops[0][0] == 'R')
                {
                    op = ops[0].Substring(1);
                    regNum = Convert.ToInt32(op);
                    
                }
                else
                {

                    //TODO: ERROR
                }

                int tmp1 = OP1;
                int tmp2 = OP2;
                
                if ((tmp1 & tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 & tmp2) == 0)
                {
                    Config.EQUAL = true;
                    Config.LESS = false;
                    Config.GREATER = false;

                    Config.NZCV |= 4;
                }
                Config.registers[regNum] = (OP1 & OP2) % 65536;

                if (Config.registers[regNum] < 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = true;
                    Config.GREATER = false;

                    Config.registers[regNum] = 0;
                }
                if (Config.registers[regNum] > 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = false;
                    Config.GREATER = true;

                }

            }
            else if (ops.Length == 0 || args == "")
            {
                if (Config.USER_STACK - Config.USER_STACK_BASE >= 2)
                {
                    //ACC = OP2 + OP1
                    int OP2 = Config.memory[--Config.USER_STACK];
                    int OP1 = Config.memory[--Config.USER_STACK];
                    int tmp1 = OP1;
                    int tmp2 = OP2;
                    if ((tmp1 & tmp2) > 65535)
                    {
                        Config.NZCV |= 1;
                    }
                    if ((tmp1 & tmp2) == 0)
                    {
                        Config.EQUAL = true;
                        Config.LESS = false;
                        Config.GREATER = false;

                        Config.NZCV |= 4;
                    }


                    Config.ACC = (OP2 & OP1) % 65536;
                    if (Config.ACC < 0)
                    {
                        Config.EQUAL = false;
                        Config.LESS = true;
                        Config.GREATER = false;
                        Config.ACC = 0;
                    }
                    if (Config.ACC > 0)
                    {
                        Config.EQUAL = false;
                        Config.LESS = false;
                        Config.GREATER = true;
                    }

                    Config.memory[Config.USER_STACK++] = Config.ACC;
                }
            }
        }

        public static void OR(string args)
        {
            String[] ops = args.Split(',');
            if (ops.Length > 0)
                trimOps(ref ops);

            if (ops.Length == 1 && args != "")
            {
                string op;
                int OP1 = 0;
                if (ops[0][0] == 'R')
                {
                    op = ops[0].Substring(1);

                    int regNum = Convert.ToInt32(op);
                    OP1 = Config.registers[regNum];

                }
                else
                {
                    //TODO: ERROR

                }
                int tmp1 = Config.ACC;
                int tmp2 = OP1;

                if ((tmp1 | tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 | tmp2) == 0)
                {
                    Config.EQUAL = true;
                    Config.LESS = false;
                    Config.GREATER = false;

                    Config.NZCV |= 4;
                }
                Config.ACC = (Config.ACC | OP1) % 65536;

                if (Config.ACC < 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = true;
                    Config.GREATER = false;

                    Config.ACC = 0;
                }
                if (Config.ACC > 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = false;
                    Config.GREATER = true;

                    
                }

            }
            else if (ops.Length == 2 && args != "")
            {
                string op;
                int OP1 = 0;
                int regNum = 0;
                if (ops[1][0] == 'R')
                {
                    op = ops[1].Substring(1);
                    regNum = Convert.ToInt32(op);
                    OP1 = Config.registers[regNum];
                }
                else
                {

                    //TODO: ERROR
                }

                if (ops[0][0] == 'R')
                {
                    op = ops[0].Substring(1);
                    regNum = Convert.ToInt32(op);
                }
                else
                {
                    //TODO: ERROR
                }

                int tmp1 = Config.registers[regNum];
                int tmp2 = OP1;


                if ((tmp1 | tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 | tmp2) == 0)
                {
                    Config.EQUAL = true;
                    Config.LESS = false;
                    Config.GREATER = false;

                    Config.NZCV |= 4;
                }
                Config.registers[regNum] = (Config.registers[regNum] | OP1) % 65536;
                if (Config.registers[regNum] < 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = true;
                    Config.GREATER = false;

                    Config.registers[regNum] = 0;


                }
                if (Config.ACC > 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = false;
                    Config.GREATER = true;

                }

            }
            else if (ops.Length == 3 && args != "")
            {
                int OP1 = 0, OP2 = 0;
                string op;
                int regNum = 0;
                if (ops[1][0] == 'R')
                {
                    op = ops[1].Substring(1);
                    regNum = Convert.ToInt32(op);
                    OP1 = Config.registers[regNum];
                }
                else
                {

                    //TODO: ERROR
                }

                if (ops[2][0] == 'R')
                {
                    op = ops[2].Substring(1);
                    regNum = Convert.ToInt32(op);
                    OP2 = Config.registers[regNum];
                }
                else
                {

                    //TODO: ERROR
                }

                if (ops[0][0] == 'R')
                {
                    op = ops[0].Substring(1);
                    regNum = Convert.ToInt32(op);

                }
                else
                {

                    //TODO: ERROR
                }

                int tmp1 = OP1;
                int tmp2 = OP2;

                if ((tmp1 | tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 | tmp2) == 0)
                {
                    Config.EQUAL = true;
                    Config.LESS = false;
                    Config.GREATER = false;

                    Config.NZCV |= 4;
                }
                Config.registers[regNum] = (OP1 | OP2) % 65536;

                if (Config.registers[regNum] < 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = true;
                    Config.GREATER = false;

                    Config.registers[regNum] = 0;
                }
                if (Config.registers[regNum] > 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = false;
                    Config.GREATER = true;
                }

            }
            else if (ops.Length == 0 || args == "")
            {
                if (Config.USER_STACK - Config.USER_STACK_BASE >= 2)
                {
                    //ACC = OP2 + OP1
                    int OP2 = Config.memory[--Config.USER_STACK];
                    int OP1 = Config.memory[--Config.USER_STACK];
                    int tmp1 = OP1;
                    int tmp2 = OP2;
                    if ((tmp1 | tmp2) > 65535)
                    {
                        Config.NZCV |= 1;
                    }
                    if ((tmp1 | tmp2) == 0)
                    {
                        Config.EQUAL = true;
                        Config.LESS = false;
                        Config.GREATER = false;

                        Config.NZCV |= 4;
                    }


                    Config.ACC = (OP2 | OP1) % 65536;
                    if (Config.ACC < 0)
                    {
                        Config.EQUAL = false;
                        Config.LESS = true;
                        Config.GREATER = false;
                        Config.ACC = 0;
                    }
                    if (Config.ACC > 0)
                    {
                        Config.EQUAL = false;
                        Config.LESS = false;
                        Config.GREATER = true;
                    }
                    Config.memory[Config.USER_STACK++] = Config.ACC;
                }
            }


        }

        public static void XOR(string args)
        {
            String[] ops = args.Split(',');
            if (ops.Length > 0)
                trimOps(ref ops);

            if (ops.Length == 1 && args != "")
            {
                string op;
                int OP1 = 0;
                if (ops[0][0] == 'R')
                {
                    op = ops[0].Substring(1);

                    int regNum = Convert.ToInt32(op);
                    OP1 = Config.registers[regNum];

                }
                else
                {
                    //TODO: ERROR

                }
                int tmp1 = Config.ACC;
                int tmp2 = OP1;

                if ((tmp1 ^ tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 ^ tmp2) == 0)
                {
                    Config.EQUAL = true;
                    Config.LESS = false;
                    Config.GREATER = false;

                    Config.NZCV |= 4;
                }
                Config.ACC = (Config.ACC ^ OP1) % 65536;

                if (Config.ACC < 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = true;
                    Config.GREATER = false;

                    Config.ACC = 0;
                }

                if (Config.ACC > 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = false;
                    Config.GREATER = true;

                }
            }
            else if (ops.Length == 2 && args != "")
            {
                string op;
                int OP1 = 0;
                int regNum = 0;
                if (ops[1][0] == 'R')
                {
                    op = ops[1].Substring(1);
                    regNum = Convert.ToInt32(op);
                    OP1 = Config.registers[regNum];
                }
                else
                {

                    //TODO: ERROR
                }

                if (ops[0][0] == 'R')
                {
                    op = ops[0].Substring(1);
                    regNum = Convert.ToInt32(op);
                }
                else
                {
                    //TODO: ERROR
                }

                int tmp1 = Config.registers[regNum];
                int tmp2 = OP1;


                if ((tmp1 ^ tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 ^ tmp2) == 0)
                {
                    Config.NZCV |= 4;

                    Config.EQUAL = true;
                    Config.LESS = false;
                    Config.GREATER = false;

                }
                Config.registers[regNum] = (Config.registers[regNum] ^ OP1) % 65536;
                if (Config.registers[regNum] < 0)
                {

                    Config.EQUAL = false;
                    Config.LESS = true;
                    Config.GREATER = false;

                    Config.registers[regNum] = 0;


                }
                if (Config.registers[regNum]> 0)
                {

                    Config.EQUAL = false;
                    Config.LESS = false;
                    Config.GREATER = true;

                }

            }
            else if (ops.Length == 3 && args != "")
            {
                int OP1 = 0, OP2 = 0;
                string op;
                int regNum = 0;
                if (ops[1][0] == 'R')
                {
                    op = ops[1].Substring(1);
                    regNum = Convert.ToInt32(op);
                    OP1 = Config.registers[regNum];
                }
                else
                {

                    //TODO: ERROR
                }

                if (ops[2][0] == 'R')
                {
                    op = ops[2].Substring(1);
                    regNum = Convert.ToInt32(op);
                    OP2 = Config.registers[regNum];
                }
                else
                {

                    //TODO: ERROR
                }

                if (ops[0][0] == 'R')
                {
                    op = ops[0].Substring(1);
                    regNum = Convert.ToInt32(op);

                }
                else
                {

                    //TODO: ERROR
                }

                int tmp1 = OP1;
                int tmp2 = OP2;

                if ((tmp1 ^ tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 ^ tmp2) == 0)
                {
                    Config.EQUAL = true;
                    Config.LESS = false;
                    Config.GREATER = false;

                    Config.NZCV |= 4;
                }
                 if ((tmp1 ^ tmp2) == 0)
                {
                    Config.EQUAL = true;
                    Config.LESS = false;
                    Config.GREATER = false;

                    Config.NZCV |= 4;
                }
                Config.registers[regNum] = (OP1 ^ OP2) % 65536;

                if (Config.registers[regNum] < 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = true;
                    Config.GREATER = false;

                    Config.registers[regNum] = 0;
                }
                if (Config.registers[regNum] > 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = false;
                    Config.GREATER = true;

                }

            }
            else if (ops.Length == 0 || args == "")
            {
                if (Config.USER_STACK - Config.USER_STACK_BASE >= 2)
                {
                    //ACC = OP2 + OP1
                    int OP2 = Config.memory[--Config.USER_STACK];
                    int OP1 = Config.memory[--Config.USER_STACK];
                    int tmp1 = OP1;
                    int tmp2 = OP2;
                    if ((tmp1 ^ tmp2) > 65535)
                    {
                        Config.NZCV |= 1;
                    }
                    if ((tmp1 ^ tmp2) == 0)
                    {
                        Config.EQUAL = true;
                        Config.LESS = false;
                        Config.GREATER = false;

                        Config.NZCV |= 4;
                    }


                    Config.ACC = (OP2 ^ OP1) % 65536;
                    if (Config.ACC < 0)
                    {
                        Config.EQUAL = false;
                        Config.LESS = true;
                        Config.GREATER = false;

                        Config.ACC = 0;
                    }
                    if (Config.ACC > 0)
                    {
                        Config.EQUAL = false;
                        Config.LESS = false;
                        Config.GREATER = true;

                    }


                    Config.memory[Config.USER_STACK++] = Config.ACC;
                }
            }
        }

        public static void LSH(string args)
        {

            String[] ops = args.Split(',');
            if (ops.Length > 0)
                trimOps(ref ops);

            if (ops.Length == 1 && args != "")
            {
                string op;
                int OP1 = 0;
                if (ops[0][0] == 'R')
                {
                    op = ops[0].Substring(1);

                    int regNum = Convert.ToInt32(op);
                    OP1 = Config.registers[regNum];

                }
                else
                {
                    //TODO: ERROR

                }
                int tmp1 = Config.ACC;
                int tmp2 = OP1;

                if ((tmp1 << tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 << tmp2) == 0)
                {
                    Config.EQUAL = true;
                    Config.LESS = false;
                    Config.GREATER = false;

                    Config.NZCV |= 4;
                }
                Config.ACC = (Config.ACC << OP1) % 65536;

                if (Config.ACC < 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = true;
                    Config.GREATER = false;

                    Config.ACC = 0;
                }
                if (Config.ACC > 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = false;
                    Config.GREATER = true;

                    
                }

            }
            else if (ops.Length == 2 && args != "")
            {
                string op;
                int OP1 = 0;
                int regNum = 0;
                if (ops[1][0] == 'R')
                {
                    op = ops[1].Substring(1);
                    regNum = Convert.ToInt32(op);
                    OP1 = Config.registers[regNum];
                }
                else
                {

                    //TODO: ERROR
                }

                if (ops[0][0] == 'R')
                {
                    op = ops[0].Substring(1);
                    regNum = Convert.ToInt32(op);
                }
                else
                {
                    //TODO: ERROR
                }

                int tmp1 = Config.registers[regNum];
                int tmp2 = OP1;


                if ((tmp1 << tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 << tmp2) == 0)
                {
                    Config.EQUAL = true;
                    Config.LESS = false;
                    Config.GREATER = false;

                    Config.NZCV |= 4;
                }
                Config.registers[regNum] = (Config.registers[regNum] << OP1) % 65536;
                if (Config.registers[regNum] < 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = true;
                    Config.GREATER = false;

                    Config.registers[regNum] = 0;


                }

                if (Config.registers[regNum] > 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = false;
                    Config.GREATER = true;
    
                }

            }
            else if (ops.Length == 3 && args != "")
            {
                int OP1 = 0, OP2 = 0;
                string op;
                int regNum = 0;
                if (ops[1][0] == 'R')
                {
                    op = ops[1].Substring(1);
                    regNum = Convert.ToInt32(op);
                    OP1 = Config.registers[regNum];
                }
                else
                {

                    //TODO: ERROR
                }

                if (ops[2][0] == 'R')
                {
                    op = ops[2].Substring(1);
                    regNum = Convert.ToInt32(op);
                    OP2 = Config.registers[regNum];
                }
                else
                {

                    //TODO: ERROR
                }

                if (ops[0][0] == 'R')
                {
                    op = ops[0].Substring(1);
                    regNum = Convert.ToInt32(op);

                }
                else
                {

                    //TODO: ERROR
                }

                int tmp1 = OP1;
                int tmp2 = OP2;

                if ((tmp1 << tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 << tmp2) == 0)
                {
                    Config.EQUAL = true;
                    Config.LESS = false;
                    Config.GREATER = false;

                    Config.NZCV |= 4;
                }
                Config.registers[regNum] = (OP1 << OP2) % 65536;

                if (Config.registers[regNum] < 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = true;
                    Config.GREATER = false;

                    Config.registers[regNum] = 0;
                }
                if (Config.registers[regNum] > 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = false;
                    Config.GREATER = true;
                
                }
            }
            else if (ops.Length == 0 || args == "")
            {
                if (Config.USER_STACK - Config.USER_STACK_BASE >= 2)
                {
                    //ACC = OP2 + OP1
                    int OP2 = Config.memory[--Config.USER_STACK];
                    int OP1 = Config.memory[--Config.USER_STACK];
                    int tmp1 = OP1;
                    int tmp2 = OP2;
                    if ((tmp1 << tmp2) > 65535)
                    {
                        Config.NZCV |= 1;
                    }
                    if ((tmp1 << tmp2) == 0)
                    {
                        Config.EQUAL = true;
                        Config.LESS = false;
                        Config.GREATER = false;

                        Config.NZCV |= 4;
                    }


                    Config.ACC = (OP2 << OP1) % 65536;
                    if (Config.ACC < 0)
                    {
                        Config.EQUAL = false;
                        Config.LESS = true;
                        Config.GREATER = false;
                        Config.ACC = 0;
                    }
                    if (Config.ACC > 0)
                    {
                        Config.EQUAL = false;
                        Config.LESS = false;
                        Config.GREATER = true;
                    }


                    Config.memory[Config.USER_STACK++] = Config.ACC;
                }
            }
        }
        public static void RSH(string args)
        {
            

            String[] ops = args.Split(',');
            if (ops.Length > 0)
                trimOps(ref ops);

            if (ops.Length == 1 && args != "")
            {
                string op;
                int OP1 = 0;
                if (ops[0][0] == 'R')
                {
                    op = ops[0].Substring(1);

                    int regNum = Convert.ToInt32(op);
                    OP1 = Config.registers[regNum];

                }
                else
                {
                    //TODO: ERROR

                }
                int tmp1 = Config.ACC;
                int tmp2 = OP1;

                if ((tmp1 >> tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 >> tmp2) == 0)
                {
                    Config.EQUAL = true;
                    Config.LESS = false;
                    Config.GREATER = false;

                    Config.NZCV |= 4;
                }
                Config.ACC = (Config.ACC >> OP1) % 65536;

                if (Config.ACC < 0)
                {

                    Config.EQUAL = false;
                    Config.LESS = true;
                    Config.GREATER = false;

                    Config.ACC = 0;
                }
                if (Config.ACC > 0)
                {

                    Config.EQUAL = false;
                    Config.LESS = false;
                    Config.GREATER = true;
                }

            }
            else if (ops.Length == 2 && args != "")
            {
                string op;
                int OP1 = 0;
                int regNum = 0;
                if (ops[1][0] == 'R')
                {
                    op = ops[1].Substring(1);
                    regNum = Convert.ToInt32(op);
                    OP1 = Config.registers[regNum];
                }
                else
                {

                    //TODO: ERROR
                }

                if (ops[0][0] == 'R')
                {
                    op = ops[0].Substring(1);
                    regNum = Convert.ToInt32(op);
                }
                else
                {
                    //TODO: ERROR
                }

                int tmp1 = Config.registers[regNum];
                int tmp2 = OP1;


                if ((tmp1 >> tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 >> tmp2) == 0)
                {
                    Config.EQUAL = true;
                    Config.LESS = false;
                    Config.GREATER = false;

                    Config.NZCV |= 4;
                }
                Config.registers[regNum] = (Config.registers[regNum] >> OP1) % 65536;
                if (Config.registers[regNum] < 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = true;
                    Config.GREATER = false;

                    Config.registers[regNum] = 0;


                }
                if (Config.registers[regNum] > 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = false;
                    Config.GREATER = true;



                }


            }
            else if (ops.Length == 3 && args != "")
            {
                int OP1 = 0, OP2 = 0;
                string op;
                int regNum = 0;
                if (ops[1][0] == 'R')
                {
                    op = ops[1].Substring(1);
                    regNum = Convert.ToInt32(op);
                    OP1 = Config.registers[regNum];
                }
                else
                {

                    //TODO: ERROR
                }

                if (ops[2][0] == 'R')
                {
                    op = ops[2].Substring(1);
                    regNum = Convert.ToInt32(op);
                    OP2 = Config.registers[regNum];
                }
                else
                {

                    //TODO: ERROR
                }

                if (ops[0][0] == 'R')
                {
                    op = ops[0].Substring(1);
                    regNum = Convert.ToInt32(op);

                }
                else
                {

                    //TODO: ERROR
                }

                int tmp1 = OP1;
                int tmp2 = OP2;

                if ((tmp1 >> tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 >> tmp2) == 0)
                {
                    Config.EQUAL = true;
                    Config.LESS = false;
                    Config.GREATER = false;

                    Config.NZCV |= 4;
                }
                Config.registers[regNum] = (OP1 >> OP2) % 65536;

                if (Config.registers[regNum] < 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = true;
                    Config.GREATER = false;

                    Config.registers[regNum] = 0;
                }
                if (Config.registers[regNum] > 0)
                {
                    Config.EQUAL = false;
                    Config.LESS = false;
                    Config.GREATER = true;

                }

            }
            else if (ops.Length == 0 || args == "")
            {
                if (Config.USER_STACK - Config.USER_STACK_BASE >= 2)
                {
                    
                    int OP2 = Config.memory[--Config.USER_STACK];
                    int OP1 = Config.memory[--Config.USER_STACK];
                    int tmp1 = OP1;
                    int tmp2 = OP2;
                    if ((tmp1 >> tmp2) > 65535)
                    {
                        Config.NZCV |= 1;
                    }
                    if ((tmp1 >> tmp2) == 0)
                    {
                        Config.NZCV |= 4;
                    }


                    Config.ACC = (OP2 >> OP1) % 65536;
                    if (Config.ACC < 0)
                    {
                        Config.EQUAL = false;
                        Config.LESS = true;
                        Config.GREATER = false;
                        Config.ACC = 0;
                    }
                    if(Config.ACC > 0)
                    {
                        Config.EQUAL = false;
                        Config.LESS = false;
                        Config.GREATER = true;

                    }
                    Config.memory[Config.USER_STACK++] = Config.ACC;
                }
            }
        }

        public static void CMP(string args)
        {
            String[] ops = args.Split(',');
            if (ops.Length > 0)
                trimOps(ref ops);


            if(ops.Length == 2)
            {
                string op;
                int OP1 = 0;
                int OP2 = 0;
                int regNum = 0;
                if (ops[0][0] == 'R')
                {
                    op = ops[0].Substring(1);
                    regNum = Convert.ToInt32(op);
                    OP1 = Config.registers[regNum];
                }
                else
                {

                    //TODO: ERROR
                }

                if (ops[1][0] == 'R')
                {
                    op = ops[1].Substring(1);
                    regNum = Convert.ToInt32(op);
                    OP2 = Config.registers[regNum];
                }
                else
                {
                    //TODO: ERROR
                }


                if(OP1 == OP2)
                {
                    Config.EQUAL = true;

                    Config.LESS = false;
                    Config.GREATER = false;

                    Config.NZCV = 0;

                    Config.NZCV |= 4;
                }
                if(OP1 < OP2)
                {

                    Config.LESS = true;

                    Config.GREATER = false;
                    Config.EQUAL = false;

                    Config.NZCV = 0;

                    Config.NZCV |= 2;

                }
                if (OP1 > OP2)
                {
                    Config.GREATER = true;

                    Config.EQUAL = false;
                    Config.LESS = false;

                    Config.NZCV = 0;
                    Config.NZCV |=8 ;
                }


            }

            




        }

    }
}
