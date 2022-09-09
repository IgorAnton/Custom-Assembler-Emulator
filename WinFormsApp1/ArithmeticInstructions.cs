using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class ArithmeticInstructions
    {

        private static void trimOps(ref String[] ops)
        {
            for (int i = 0; i < ops.Length; i++)
            {
                ops[i] = ops[i].Trim();
            }
        }

        public static void ADD(String args)
        {
            String[] ops = args.Split(',');
            if (ops.Length > 0)
                trimOps(ref ops);


            if (ops.Length == 1 && args != "") // one operand
            {
                int OP1 = 0;
                if (ops[0][0] == '(' && ops[0][ops[0].Length - 1] == ')')
                {
                    String op = ops[0].Substring(1, ops[0].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        int mem_loc = Config.memory[reg];
                        OP1 = mem_loc;
                    }
                    else
                    {
                        OP1 = 0;
                        //ERROR

                    }

                }
                else
                {
                    String op = ops[0];

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        OP1 = reg;
                    }
                    else
                    {
                        OP1 = 0;
                        //ERROR
                    }

                }
                if (Config.ACC + OP1 > 65535)
                {
                    Config.NZCV |= 1;
                }
                if (Config.ACC + OP1 == 0)
                {
                    Config.EQUAL = true;
                    Config.LESS = false;
                    Config.GREATER = false;

                    Config.NZCV |= 4;
                }
                Config.ACC = (Config.ACC + OP1) % 65536;


            } else if (ops.Length == 2 && args != "") // two operands ADD OP2,OP1
            {
                int OP1, OP2;

                if (ops[1][0] == '(' && ops[1][ops[1].Length - 1] == ')')
                {
                    String op = ops[1].Substring(1, ops[1].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        int mem_loc = Config.memory[reg];
                        OP1 = mem_loc;
                    }
                    else
                    {
                        OP1 = 0;
                        //ERROR

                    }

                }
                else
                {
                    String op = ops[1];

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        OP1 = reg;
                    }
                    else
                    {
                        OP1 = 0;
                        //ERROR
                    }

                }

                if (ops[0][0] == '(' && ops[0][ops[0].Length - 1] == ')')
                {
                    String op = ops[0].Substring(1, ops[0].Length - 2);


                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];

                        if (Config.memory[reg] + OP1 > 65535)
                        {
                            Config.NZCV |= 1;
                        }
                        if (Config.memory[reg] + OP1 == 0)
                        {
                            Config.EQUAL = true;
                            Config.LESS = false;
                            Config.GREATER = false;

                            Config.NZCV |= 4;
                        }

                        Config.memory[reg] = (Config.memory[reg] + OP1) % 65536;
                    }
                    else
                    {
                        //ERROR
                    }

                }
                else
                {
                    String op = ops[0];

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);

                        if (Config.registers[regNum] + OP1 > 65535)
                        {
                            Config.NZCV |= 1;
                        }
                        if (Config.registers[regNum] + OP1 == 0)
                        {
                            Config.EQUAL = true;
                            Config.LESS = false;
                            Config.GREATER = false;

                            Config.NZCV |= 4;
                        }

                        Config.registers[regNum] = (Config.registers[regNum] + OP1) % 65536;

                    }
                    else
                    {
                        //ERROR: invalid operation

                    }
                }





            }
            else if (ops.Length == 3 && args != "") // three operands
            {
                //ADD OP3,OP2,OP1

                int OP2 = 0, OP1 = 0;

                if (ops[2][0] == '(' && ops[2][ops[2].Length - 1] == ')')
                {
                    string op = ops[2].Substring(1, ops[2].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);

                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        OP1 = Config.memory[reg];

                    }
                    else
                    {
                        //TODO: ERROR
                    }


                } else
                {
                    if (ops[2][0] == 'R')
                    {
                        string op = ops[2].Substring(1);
                        int regNum = Convert.ToInt32(op);
                        OP1 = Config.registers[regNum];
                    }
                    else
                    {
                        //TODO: ERROR
                    }



                }

                if (ops[1][0] == '(' && ops[1][ops[1].Length - 1] == ')')
                {
                    string op = ops[1].Substring(1, ops[1].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);

                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        OP2 = Config.memory[reg];

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
                        OP2 = Config.registers[regNum];
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
                        int reg = Config.registers[regNum];

                        if (OP1 + OP2 > 65535)
                        {
                            Config.NZCV |= 1;
                        }
                        if (OP1 + OP2 == 0) {

                            Config.EQUAL = true;
                            Config.LESS = false;
                            Config.GREATER = false;

                            Config.NZCV |= 4;
                        }

                        Config.memory[reg] = (OP1 + OP2) % 65536;

                    }
                    else
                    {
                        //TODO: ERROR
                    }



                }
                else
                {
                    string op = ops[0];

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        if (OP1 + OP2 > 65535)
                        {
                            Config.NZCV |= 1;
                        }
                        if (OP1 + OP2 == 0)
                        {
                            Config.NZCV |= 4;
                        }
                        Config.registers[regNum] = (OP1 + OP2) % 65536;
                    }
                    else
                    {
                        //TODO: ERROR
                    }
                }


            }
            else if (ops.Length == 0 || args == "") // zero operands
            {

                if (Config.USER_STACK - Config.USER_STACK_BASE >= 2)
                {
                    //ACC = OP2 + OP1
                    int OP2 = Config.memory[--Config.USER_STACK];
                    int OP1 = Config.memory[--Config.USER_STACK];
                    if (OP1 + OP2 > 65535)
                    {
                        Config.NZCV |= 1;
                    }
                    if (OP1 + OP2 == 0)
                    {
                        Config.NZCV |= 4;
                    }


                    Config.ACC = (OP2 + OP1) % 65536;
                    Config.memory[Config.USER_STACK++] = Config.ACC;
                }

            }
            else
            {
                //TODO: ERROR invalid number of arguments
            }


        }
        public static void SUB(String args)
        {
            String[] ops = args.Split(',');
            if (ops.Length > 0)
                trimOps(ref ops);


            if (ops.Length == 1 && args != "") // one operand
            {
                int OP1 = 0;
                if (ops[0][0] == '(' && ops[0][ops[0].Length - 1] == ')')
                {
                    String op = ops[0].Substring(1, ops[0].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        int mem_loc = Config.memory[reg];
                        OP1 = mem_loc;
                    }
                    else
                    {
                        OP1 = 0;
                        //ERROR

                    }

                }
                else
                {
                    String op = ops[0];

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        OP1 = reg;
                    }
                    else
                    {
                        OP1 = 0;
                        //ERROR
                    }

                }
                if (Config.ACC - OP1 < 65535)
                {
                    Config.NZCV |= 1;
                }
                if (Config.ACC - OP1 == 0)
                {
                    Config.NZCV |= 4;
                }
                Config.ACC = (Config.ACC - OP1) % 65536;

                if (Config.ACC < 0)
                {
                    Config.ACC = 0;
                }

            }
            else if (ops.Length == 2 && args != "") // two operands ADD OP2,OP1
            {
                int OP1, OP2;

                if (ops[1][0] == '(' && ops[1][ops[1].Length - 1] == ')')
                {
                    String op = ops[1].Substring(1, ops[1].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        int mem_loc = Config.memory[reg];
                        OP1 = mem_loc;
                    }
                    else
                    {
                        OP1 = 0;
                        //ERROR

                    }

                }
                else
                {
                    String op = ops[1];

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        OP1 = reg;
                    }
                    else
                    {
                        OP1 = 0;
                        //ERROR
                    }

                }

                if (ops[0][0] == '(' && ops[0][ops[0].Length - 1] == ')')
                {
                    String op = ops[0].Substring(1, ops[0].Length - 2);


                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];

                        if (Config.memory[reg] - OP1 < 0)
                        {
                            Config.NZCV |= 1;
                        }
                        if (Config.memory[reg] - OP1 == 0)
                        {
                            Config.NZCV |= 4;
                        }

                        Config.memory[reg] = (Config.memory[reg] - OP1) % 65536;

                        if (Config.memory[reg] < 0)
                        {
                            Config.memory[reg] = 0;
                        }

                    }
                    else
                    {
                        //ERROR
                    }

                }
                else
                {
                    String op = ops[0];

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);

                        if (Config.registers[regNum] - OP1 < 0)
                        {
                            Config.NZCV |= 1;
                        }
                        if (Config.registers[regNum] - OP1 == 0)
                        {
                            Config.NZCV |= 4;
                        }

                        Config.registers[regNum] = (Config.registers[regNum] - OP1) % 65536;
                        if (Config.registers[regNum] < 0)
                        {
                            Config.registers[regNum] = 0;
                        }

                    }
                    else
                    {
                        //ERROR: invalid operation

                    }
                }





            }
            else if (ops.Length == 3 && args != "") // three operands
            {
                //ADD OP3,OP2,OP1

                int OP2 = 0, OP1 = 0;

                if (ops[2][0] == '(' && ops[2][ops[2].Length - 1] == ')')
                {
                    string op = ops[2].Substring(1, ops[2].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);

                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        OP1 = Config.memory[reg];

                    }
                    else
                    {
                        //TODO: ERROR
                    }


                }
                else
                {
                    if (ops[2][0] == 'R')
                    {
                        string op = ops[2].Substring(1);
                        int regNum = Convert.ToInt32(op);
                        OP1 = Config.registers[regNum];
                    }
                    else
                    {
                        //TODO: ERROR
                    }



                }

                if (ops[1][0] == '(' && ops[1][ops[1].Length - 1] == ')')
                {
                    string op = ops[1].Substring(1, ops[1].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);

                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        OP2 = Config.memory[reg];

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
                        OP2 = Config.registers[regNum];
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
                        int reg = Config.registers[regNum];

                        if (OP2 - OP1 < 0)
                        {
                            Config.NZCV |= 1;
                        }
                        if (OP1 - OP2 == 0)
                        {
                            Config.NZCV |= 4;
                        }

                        Config.memory[reg] = (OP2 - OP1) % 65536;

                        if (Config.memory[reg] < 0)
                        {
                            Config.memory[reg] = 0;
                        }

                    }
                    else
                    {
                        //TODO: ERROR
                    }



                }
                else
                {
                    string op = ops[0];

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        if (OP2 - OP1 < 0)
                        {
                            Config.NZCV |= 1;
                        }
                        if (OP1 - OP2 == 0)
                        {
                            Config.NZCV |= 4;
                        }
                        Config.registers[regNum] = (OP2 - OP1) % 65536;

                        if (Config.registers[regNum] < 0)
                        {
                            Config.registers[regNum] = 0;
                        }
                    }
                    else
                    {
                        //TODO: ERROR
                    }
                }


            }
            else if (ops.Length == 0 || args == "") // zero operands
            {

                if (Config.USER_STACK - Config.USER_STACK_BASE >= 2)
                {
                    //ACC = OP2 + OP1
                    int OP2 = Config.memory[--Config.USER_STACK];
                    int OP1 = Config.memory[--Config.USER_STACK];
                    if (OP2 - OP1 < 0)
                    {
                        Config.NZCV |= 1;
                    }
                    if (OP1 - OP2 == 0)
                    {
                        Config.NZCV |= 4;
                    }


                    Config.ACC = (OP2 - OP1) % 65536;
                    if (Config.ACC < 0)
                        Config.ACC = 0;
                    Config.memory[Config.USER_STACK++] = Config.ACC;
                }

            }
            else
            {
                //TODO: ERROR invalid number of arguments
            }

        }

        public static void MUL(String args)
        {

            String[] ops = args.Split(',');
            if (ops.Length > 0)
                trimOps(ref ops);


            if (ops.Length == 1 && args != "") // one operand
            {
                int OP1 = 0;
                if (ops[0][0] == '(' && ops[0][ops[0].Length - 1] == ')')
                {
                    String op = ops[0].Substring(1, ops[0].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        int mem_loc = Config.memory[reg];
                        OP1 = mem_loc;
                    }
                    else
                    {
                        OP1 = 0;
                        //ERROR

                    }

                }
                else
                {
                    String op = ops[0];

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        OP1 = reg;
                    }
                    else
                    {
                        OP1 = 0;
                        //ERROR
                    }

                }
                if (Config.ACC * OP1 > 65535)
                {
                    Config.NZCV |= 1;
                }
                if (Config.ACC * OP1 == 0)
                {
                    Config.NZCV |= 4;
                }
                Config.ACC = (Config.ACC * OP1) % 65536;


            }
            else if (ops.Length == 2 && args != "") // two operands ADD OP2,OP1
            {
                int OP1, OP2;

                if (ops[1][0] == '(' && ops[1][ops[1].Length - 1] == ')')
                {
                    String op = ops[1].Substring(1, ops[1].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        int mem_loc = Config.memory[reg];
                        OP1 = mem_loc;
                    }
                    else
                    {
                        OP1 = 0;
                        //ERROR

                    }

                }
                else
                {
                    String op = ops[1];

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        OP1 = reg;
                    }
                    else
                    {
                        OP1 = 0;
                        //ERROR
                    }

                }

                if (ops[0][0] == '(' && ops[0][ops[0].Length - 1] == ')')
                {
                    String op = ops[0].Substring(1, ops[0].Length - 2);


                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];

                        if (Config.memory[reg] + OP1 > 65535)
                        {
                            Config.NZCV |= 1;
                        }
                        if (Config.memory[reg] + OP1 == 0)
                        {
                            Config.NZCV |= 4;
                        }

                        Config.memory[reg] = (Config.memory[reg] * OP1) % 65536;
                    }
                    else
                    {
                        //ERROR
                    }

                }
                else
                {
                    String op = ops[0];

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);

                        if (Config.registers[regNum] * OP1 > 65535)
                        {
                            Config.NZCV |= 1;
                        }
                        if (Config.registers[regNum] * OP1 == 0)
                        {
                            Config.NZCV |= 4;
                        }

                        Config.registers[regNum] = (Config.registers[regNum] * OP1) % 65536;

                    }
                    else
                    {
                        //ERROR: invalid operation

                    }
                }





            }
            else if (ops.Length == 3 && args != "") // three operands
            {
                //ADD OP3,OP2,OP1

                int OP2 = 0, OP1 = 0;

                if (ops[2][0] == '(' && ops[2][ops[2].Length - 1] == ')')
                {
                    string op = ops[2].Substring(1, ops[2].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);

                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        OP1 = Config.memory[reg];

                    }
                    else
                    {
                        //TODO: ERROR
                    }


                }
                else
                {
                    if (ops[2][0] == 'R')
                    {
                        string op = ops[2].Substring(1);
                        int regNum = Convert.ToInt32(op);
                        OP1 = Config.registers[regNum];
                    }
                    else
                    {
                        //TODO: ERROR
                    }



                }

                if (ops[1][0] == '(' && ops[1][ops[1].Length - 1] == ')')
                {
                    string op = ops[1].Substring(1, ops[1].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);

                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        OP2 = Config.memory[reg];

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
                        OP2 = Config.registers[regNum];
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
                        int reg = Config.registers[regNum];

                        if (OP1 * OP2 > 65535)
                        {
                            Config.NZCV |= 1;
                        }
                        if (OP1 * OP2 == 0)
                        {
                            Config.NZCV |= 4;
                        }

                        Config.memory[reg] = (OP1 * OP2) % 65536;

                    }
                    else
                    {
                        //TODO: ERROR
                    }



                }
                else
                {
                    string op = ops[0];

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        if (OP1 * OP2 > 65535)
                        {
                            Config.NZCV |= 1;
                        }
                        if (OP1 * OP2 == 0)
                        {
                            Config.NZCV |= 4;
                        }
                        Config.registers[regNum] = (OP1 * OP2) % 65536;
                    }
                    else
                    {
                        //TODO: ERROR
                    }
                }


            }
            else if (ops.Length == 0 || args == "") // zero operands
            {

                if (Config.USER_STACK - Config.USER_STACK_BASE >= 2)
                {
                    //ACC = OP2 + OP1
                    int OP2 = Config.memory[--Config.USER_STACK];
                    int OP1 = Config.memory[--Config.USER_STACK];
                    if (OP1 * OP2 > 65535)
                    {
                        Config.NZCV |= 1;
                    }
                    if (OP1 * OP2 == 0)
                    {
                        Config.NZCV |= 4;
                    }


                    Config.ACC = (OP2 * OP1) % 65536;
                    Config.memory[Config.USER_STACK++] = Config.ACC;
                }

            }
            else
            {
                //TODO: ERROR invalid number of arguments
            }
        }

        public static void DIV(String args)
        {
            String[] ops = args.Split(',');
            if (ops.Length > 0)
                trimOps(ref ops);


            if (ops.Length == 1 && args != "") // one operand
            {
                int OP1 = 0;
                if (ops[0][0] == '(' && ops[0][ops[0].Length - 1] == ')')
                {
                    String op = ops[0].Substring(1, ops[0].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        int mem_loc = Config.memory[reg];
                        OP1 = mem_loc;
                    }
                    else
                    {
                        OP1 = 0;
                        //ERROR

                    }

                }
                else
                {
                    String op = ops[0];

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        OP1 = reg;
                    }
                    else
                    {
                        OP1 = 0;
                        //ERROR
                    }

                }
                if (Config.ACC / OP1 > 65535)
                {
                    Config.NZCV |= 1;
                }
                if (Config.ACC / OP1 == 0)
                {
                    Config.NZCV |= 4;
                }

                if (OP1 == 0)
                {
                    //TODO: ERROR zero dvision

                    return;
                }

                Config.ACC = (Config.ACC / OP1) % 65536;

                if (Config.ACC < 0)
                {
                    Config.ACC = 0;
                }

            }
            else if (ops.Length == 2 && args != "") // two operands ADD OP2,OP1
            {
                int OP1, OP2;

                if (ops[1][0] == '(' && ops[1][ops[1].Length - 1] == ')')
                {
                    String op = ops[1].Substring(1, ops[1].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        int mem_loc = Config.memory[reg];
                        OP1 = mem_loc;
                    }
                    else
                    {
                        OP1 = 0;
                        //ERROR

                    }

                }
                else
                {
                    String op = ops[1];

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        OP1 = reg;
                    }
                    else
                    {
                        OP1 = 0;
                        //ERROR
                    }

                }

                if (ops[0][0] == '(' && ops[0][ops[0].Length - 1] == ')')
                {
                    String op = ops[0].Substring(1, ops[0].Length - 2);


                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];

                        if (Config.memory[reg] / OP1 > 65535)
                        {
                            Config.NZCV |= 1;
                        }
                        if (Config.memory[reg] / OP1 == 0)
                        {
                            Config.NZCV |= 4;
                        }

                        if (OP1 == 0)
                        {
                            //TODO: ERROR zero divison
                            return;
                        }


                        Config.memory[reg] = (Config.memory[reg] / OP1) % 65536;

                        if (Config.memory[reg] < 0)
                        {
                            Config.memory[reg] = 0;
                        }

                    }
                    else
                    {
                        //ERROR
                    }

                }
                else
                {
                    String op = ops[0];

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);

                        if (Config.registers[regNum] / OP1 > 65535)
                        {
                            Config.NZCV |= 1;
                        }
                        if (Config.registers[regNum] / OP1 == 0)
                        {
                            Config.NZCV |= 4;
                        }

                        Config.registers[regNum] = (Config.registers[regNum] / OP1) % 65536;
                        if (Config.registers[regNum] < 0)
                        {
                            Config.registers[regNum] = 0;
                        }

                    }
                    else
                    {
                        //ERROR: invalid operation

                    }
                }





            }
            else if (ops.Length == 3 && args != "") // three operands
            {
                //ADD OP3,OP2,OP1

                int OP2 = 0, OP1 = 0;

                if (ops[2][0] == '(' && ops[2][ops[2].Length - 1] == ')')
                {
                    string op = ops[2].Substring(1, ops[2].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);

                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        OP1 = Config.memory[reg];

                    }
                    else
                    {
                        //TODO: ERROR
                    }


                }
                else
                {
                    if (ops[2][0] == 'R')
                    {
                        string op = ops[2].Substring(1);
                        int regNum = Convert.ToInt32(op);
                        OP1 = Config.registers[regNum];
                    }
                    else
                    {
                        //TODO: ERROR
                    }



                }

                if (ops[1][0] == '(' && ops[1][ops[1].Length - 1] == ')')
                {
                    string op = ops[1].Substring(1, ops[1].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);

                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        OP2 = Config.memory[reg];

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
                        OP2 = Config.registers[regNum];
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
                        int reg = Config.registers[regNum];

                        if (OP2 / OP1 > 65535)
                        {
                            Config.NZCV |= 1;
                        }
                        if (OP1 / OP2 == 0)
                        {
                            Config.NZCV |= 4;
                        }

                        Config.memory[reg] = (OP2 / OP1) % 65536;

                        if (Config.memory[reg] < 0)
                        {
                            Config.memory[reg] = 0;
                        }

                    }
                    else
                    {
                        //TODO: ERROR
                    }



                }
                else
                {
                    string op = ops[0];

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        if (OP2 / OP1 > 65535)
                        {
                            Config.NZCV |= 1;
                        }
                        if (OP1 / OP2 == 0)
                        {
                            Config.NZCV |= 4;
                        }
                        Config.registers[regNum] = (OP2 / OP1) % 65536;

                        if (Config.registers[regNum] < 0)
                        {
                            Config.registers[regNum] = 0;
                        }
                    }
                    else
                    {
                        //TODO: ERROR
                    }
                }


            }
            else if (ops.Length == 0 || args == "") // zero operands
            {

                if (Config.USER_STACK - Config.USER_STACK_BASE >= 2)
                {
                    //ACC = OP2 + OP1
                    int OP2 = Config.memory[--Config.USER_STACK];
                    int OP1 = Config.memory[--Config.USER_STACK];
                    if (OP2 / OP1 > 65535)
                    {
                        Config.NZCV |= 1;
                    }
                    if (OP1 / OP2 == 0)
                    {
                        Config.NZCV |= 4;
                    }


                    Config.ACC = (OP2 / OP1) % 65536;
                    if (Config.ACC < 0)
                        Config.ACC = 0;
                    Config.memory[Config.USER_STACK++] = Config.ACC;
                }

            }
            else
            {
                //TODO: ERROR invalid number of arguments
            }
        }
        public static void MOD(String args)
        {
            String[] ops = args.Split(',');
            if (ops.Length > 0)
                trimOps(ref ops);


            if (ops.Length == 1 && args != "") // one operand
            {
                int OP1 = 0;
                if (ops[0][0] == '(' && ops[0][ops[0].Length - 1] == ')')
                {
                    String op = ops[0].Substring(1, ops[0].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        int mem_loc = Config.memory[reg];
                        OP1 = mem_loc;
                    }
                    else
                    {
                        OP1 = 0;
                        //ERROR

                    }

                }
                else
                {
                    String op = ops[0];

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        OP1 = reg;
                    }
                    else
                    {
                        OP1 = 0;
                        //ERROR
                    }

                }
                if (Config.ACC % OP1 > 65535)
                {
                    Config.NZCV |= 1;
                }
                if (Config.ACC % OP1 == 0)
                {
                    Config.NZCV |= 4;
                }
                Config.ACC = (Config.ACC % OP1) % 65536;

                if (Config.ACC < 0)
                {
                    Config.ACC = 0;
                }

            }
            else if (ops.Length == 2 && args != "") // two operands ADD OP2,OP1
            {
                int OP1, OP2;

                if (ops[1][0] == '(' && ops[1][ops[1].Length - 1] == ')')
                {
                    String op = ops[1].Substring(1, ops[1].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        int mem_loc = Config.memory[reg];
                        OP1 = mem_loc;
                    }
                    else
                    {
                        OP1 = 0;
                        //ERROR

                    }

                }
                else
                {
                    String op = ops[1];

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        OP1 = reg;
                    }
                    else
                    {
                        OP1 = 0;
                        //ERROR
                    }

                }

                if (ops[0][0] == '(' && ops[0][ops[0].Length - 1] == ')')
                {
                    String op = ops[0].Substring(1, ops[0].Length - 2);


                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];

                        if (Config.memory[reg] % OP1 > 65535)
                        {
                            Config.NZCV |= 1;
                        }
                        if (Config.memory[reg] % OP1 == 0)
                        {
                            Config.NZCV |= 4;
                        }

                        Config.memory[reg] = (Config.memory[reg] % OP1) % 65536;

                        if (Config.memory[reg] < 0)
                        {
                            Config.memory[reg] = 0;
                        }

                    }
                    else
                    {
                        //ERROR
                    }

                }
                else
                {
                    String op = ops[0];

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);

                        if (Config.registers[regNum] % OP1 > 65535)
                        {
                            Config.NZCV |= 1;
                        }
                        if (Config.registers[regNum] % OP1 == 0)
                        {
                            Config.NZCV |= 4;
                        }

                        Config.registers[regNum] = (Config.registers[regNum] % OP1) % 65536;
                        if (Config.registers[regNum] < 0)
                        {
                            Config.registers[regNum] = 0;
                        }

                    }
                    else
                    {
                        //ERROR: invalid operation

                    }
                }





            }
            else if (ops.Length == 3 && args != "") // three operands
            {
                //ADD OP3,OP2,OP1

                int OP2 = 0, OP1 = 0;

                if (ops[2][0] == '(' && ops[2][ops[2].Length - 1] == ')')
                {
                    string op = ops[2].Substring(1, ops[2].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);

                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        OP1 = Config.memory[reg];

                    }
                    else
                    {
                        //TODO: ERROR
                    }


                }
                else
                {
                    if (ops[2][0] == 'R')
                    {
                        string op = ops[2].Substring(1);
                        int regNum = Convert.ToInt32(op);
                        OP1 = Config.registers[regNum];
                    }
                    else
                    {
                        //TODO: ERROR
                    }



                }

                if (ops[1][0] == '(' && ops[1][ops[1].Length - 1] == ')')
                {
                    string op = ops[1].Substring(1, ops[1].Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);

                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];
                        OP2 = Config.memory[reg];

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
                        OP2 = Config.registers[regNum];
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
                        int reg = Config.registers[regNum];

                        if (OP2 % OP1 > 65535)
                        {
                            Config.NZCV |= 1;
                        }
                        if (OP1 % OP2 == 0)
                        {
                            Config.NZCV |= 4;
                        }

                        Config.memory[reg] = (OP2 % OP1) % 65536;

                        if (Config.memory[reg] < 0)
                        {
                            Config.memory[reg] = 0;
                        }

                    }
                    else
                    {
                        //TODO: ERROR
                    }



                }
                else
                {
                    string op = ops[0];

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        if (OP2 % OP1 > 65535)
                        {
                            Config.NZCV |= 1;
                        }
                        if (OP1 % OP2 == 0)
                        {
                            Config.NZCV |= 4;
                        }
                        Config.registers[regNum] = (OP2 % OP1) % 65536;

                        if (Config.registers[regNum] < 0)
                        {
                            Config.registers[regNum] = 0;
                        }
                    }
                    else
                    {
                        //TODO: ERROR
                    }
                }


            }
            else if (ops.Length == 0 || args == "") // zero operands
            {

                if (Config.USER_STACK - Config.USER_STACK_BASE >= 2)
                {
                    //ACC = OP2 + OP1
                    int OP2 = Config.memory[--Config.USER_STACK];
                    int OP1 = Config.memory[--Config.USER_STACK];
                    if (OP2 % OP1 > 65535)
                    {
                        Config.NZCV |= 1;
                    }
                    if (OP1 % OP2 == 0)
                    {
                        Config.NZCV |= 4;
                    }


                    Config.ACC = (OP2 % OP1) % 65536;
                    if (Config.ACC < 0)
                        Config.ACC = 0;
                    Config.memory[Config.USER_STACK++] = Config.ACC;
                }

            }
            else
            {
                //TODO: ERROR invalid number of arguments
            }
        }

        public static void INC(String args)
        {
            String[] ops = args.Split(',');
            if (ops.Length > 0)
                trimOps(ref ops);

            if (ops.Length == 1 && args != "")
            {
                string op = ops[0];

                if (op[0] == '(' && op[op.Length - 1] == ')')
                {
                    op = op.Substring(1, op.Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];

                        if (Config.memory[reg] + 1 > 65535) {
                            Config.NZCV |= 1;
                            Config.NZCV |= 2;
                        }

                        Config.memory[reg] = (Config.memory[reg] + 1) % 65536;

                    }
                    else
                    {
                        //TODO: ERROR
                    }
                }
                else
                {
                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);

                        if (Config.registers[regNum] + 1 > 65535)
                        {
                            Config.NZCV |= 1;
                            Config.NZCV |= 2;
                        }

                        Config.registers[regNum] = (Config.registers[regNum] + 1) % 65536;

                    }
                    else
                    {
                        //TODO: ERROR
                    }
                }

            }
            else if (ops.Length == 0 || args == "")
            {
                if (Config.ACC + 1 > 65535)
                {
                    Config.NZCV |= 1;
                    Config.NZCV |= 2;
                }

                Config.ACC = (Config.ACC + 1) % 65535;
            }
            else
            {
                //TODO: ERROR
            }
        }

        public static void DEC(String args)
        {
            String[] ops = args.Split(',');
            if (ops.Length > 0)
                trimOps(ref ops);

            if (ops.Length == 1 && args != "")
            {
                string op = ops[0];

                if (op[0] == '(' && op[op.Length - 1] == ')')
                {
                    op = op.Substring(1, op.Length - 2);

                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);
                        int reg = Config.registers[regNum];

                        if (Config.memory[reg] - 1 < 0)
                        {
                            Config.NZCV |= 1;
                        }
                        if (Config.memory[reg] - 1 == 0)
                        {
                            Config.NZCV |= 4;
                        }

                        Config.memory[reg] = (Config.memory[reg] - 1) % 65536;

                    }
                    else
                    {
                        //TODO: ERROR
                    }
                }
                else
                {
                    if (op[0] == 'R')
                    {
                        op = op.Substring(1);
                        int regNum = Convert.ToInt32(op);

                        if (Config.registers[regNum] - 1 < 0)
                        {
                            Config.NZCV |= 1;
                        }
                        if (Config.registers[regNum] - 1 == 0)
                        {
                            Config.NZCV |= 4;
                        }

                        Config.registers[regNum] = (Config.registers[regNum] - 1) % 65536;

                    }
                    else
                    {
                        //TODO: ERROR
                    }
                }

            }
            else if (ops.Length == 0 || args == "")
            {
                if (Config.ACC - 1 < 0)
                {
                    Config.NZCV |= 1;
                }
                if (Config.ACC - 1 == 0)
                {
                    Config.NZCV |= 4;
                }

                Config.ACC = (Config.ACC - 1) % 65535;
            }
            else
            {
                //TODO: ERROR
            }
        }


        

    }
}


