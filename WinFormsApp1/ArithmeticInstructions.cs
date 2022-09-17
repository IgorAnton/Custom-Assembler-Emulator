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

                OP1 = Config.getReg(ops[0]);

                if (Config.ACC + OP1 > 65535)
                {
                    Config.NZCV |= 1;
                }
                if (Config.ACC + OP1 == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                else if(Config.ACC + OP1 < 0)
                {

                    Config.setLESS();
                }
                else if (Config.ACC + OP1 > 0 )
                {
                    Config.setGREATER();
                }
                Config.ACC = (Config.ACC + OP1) % 65536;

                Config.instrucitonsInBinary[Config.PC] = Memory.formOneAddres("ADD", ops[0]);

              

            } else if (ops.Length == 2 && args != "") // two operands ADD OP2,OP1
            {
                int OP1, OP2;

                OP2 = Config.getReg(ops[1]);
                OP1 = Config.getReg(ops[0]);

                Config.setReg(ops[0], (OP1 + OP2) % 65536 );

                if (OP2 + OP1 > 65535)
                {
                    Config.NZCV |= 1;
                }
                if (OP2 + OP1 == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                else if (OP2 + OP1 > 0)
                {

                    Config.setGREATER();
                }
                else if(OP2 + OP1 < 0)
                {
                    Config.setLESS();
                }

                Config.instrucitonsInBinary[Config.PC] = Memory.formTwoAddres("ADD", ops[0], ops[1]) ;

            }                                       //                   ops[0] ops[1] ops[2]
            else if (ops.Length == 3 && args != "") // three operands ADD OP3 , OP2 , OP1
            {
                

                int OP2 = 0, OP1 = 0;

                OP2 = Config.getReg(ops[1]);
                OP1 = Config.getReg(ops[2]);

                Config.setReg(ops[0], (OP1 + OP2) % 65536);

                if (OP2 + OP1 > 65535)
                {
                    Config.NZCV |= 1;
                }
                if (OP2 + OP1 == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                else if (OP2 + OP1 > 0)
                {

                    Config.setGREATER();
                }
                else if (OP2 + OP1 < 0)
                {
                    Config.setLESS();
                }

                Config.instrucitonsInBinary[Config.PC ] = Memory.formThreeAddres("ADD",  ops[0], ops[1], ops[2]) ;

            }
            else if (ops.Length == 0 || args == "") // zero operands
            {

                if (Config.USER_STACK - Config.USER_STACK_BASE >= 2)
                {
                    //ACC = OP2 + OP1
                    int OP2 = Config.memory[--Config.USER_STACK];
                    int OP1 = Config.memory[--Config.USER_STACK];

                    if (OP2 + OP1 > 65535)
                    {
                        Config.NZCV |= 1;
                    }
                    if (OP2 + OP1 == 0)
                    {
                        Config.setEQAUL();

                        Config.NZCV |= 4;
                    }
                    else if (OP2 + OP1 > 0)
                    {

                        Config.setGREATER();
                    }
                    else if (OP2 + OP1 < 0)
                    {
                        Config.setLESS();
                    }


                    Config.ACC = (OP2 + OP1) % 65536;
                    Config.memory[Config.USER_STACK++] = Config.ACC;

                    Config.instrucitonsInBinary[Config.PC] = Memory.formZeroAddres("ADD") ;
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

                OP1 = Config.getReg(ops[0]);

                if (Config.ACC - OP1 > 65535)
                {
                    Config.NZCV |= 1;
                }
                if (Config.ACC - OP1 == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                else if (Config.ACC - OP1 < 0)
                {
                    Config.ACC = 0;

                    Config.setLESS();

                    return;
                }
                else if (Config.ACC - OP1 > 0)
                {
                    

                    Config.setGREATER();

                    
                }

                Config.ACC = (Config.ACC - OP1) % 65536;

                Config.instrucitonsInBinary[Config.PC] = Memory.formOneAddres("SUB", ops[0]);

            }
            else if (ops.Length == 2 && args != "") // two operands ADD OP2,OP1
            {
                int OP1, OP2;

                OP2 = Config.getReg(ops[1]);

                OP1 = Config.getReg(ops[0]);

                Config.setReg(ops[0], (OP1 - OP2) % 65536);

                if (OP1 - OP2 > 65535)
                {
                    Config.NZCV |= 1;
                }
                if (OP1 - OP2 == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                else if (OP1 - OP2 > 0)
                {
                    Config.setGREATER();
                }
                else if (OP1 - OP2 < 0)
                {
                    Config.NZCV |= 8;

                    Config.setReg(ops[0], 0);

                    Config.setLESS();
                }

                Config.instrucitonsInBinary[Config.PC] = Memory.formTwoAddres("SUB", ops[0], ops[1]);

            }                                       //                   ops[0] ops[1] ops[2]
            else if (ops.Length == 3 && args != "") // three operands ADD OP3 , OP2 , OP1
            {


                int OP2 = 0, OP1 = 0;

                OP2 = Config.getReg(ops[1]);
                OP1 = Config.getReg(ops[2]);

                Config.setReg(ops[0], (OP2 - OP1) % 65536);

                if (OP2 - OP1 > 65535)
                {
                    Config.NZCV |= 1;
                }
                if (OP2 - OP1 == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                else if (OP2 - OP1 > 0)
                {

                    Config.setGREATER();
                }
                else if (OP2 - OP1 < 0)
                {
                    Config.setReg(ops[0], 0);

                    Config.NZCV |= 8;

                    Config.setLESS();
                }

                Config.instrucitonsInBinary[Config.PC] = Memory.formThreeAddres("SUB", ops[0], ops[1], ops[2]);

            }
            else if (ops.Length == 0 || args == "") // zero operands
            {

                if (Config.USER_STACK - Config.USER_STACK_BASE >= 2)
                {
                    //ACC = OP2 + OP1
                    int OP2 = Config.memory[--Config.USER_STACK];
                    int OP1 = Config.memory[--Config.USER_STACK];

                    if (OP2 - OP1 > 65535)
                    {
                        Config.NZCV |= 1;
                    }
                    if (OP2 - OP1 == 0)
                    {
                        Config.setEQAUL();

                        Config.NZCV |= 4;
                    }
                    else if (OP2 - OP1 > 0)
                    {

                        Config.setGREATER();
                    }
                    


                    Config.ACC = (OP2 - OP1) % 65536;

                    if (OP2 - OP1 < 0)
                    {
                        Config.ACC = 0;

                        Config.setLESS();
                    }
                    Config.memory[Config.USER_STACK++] = Config.ACC;

                    Config.instrucitonsInBinary[Config.PC] = Memory.formZeroAddres("SUB");

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

                OP1 = Config.getReg(ops[0]);

                if (Config.ACC * OP1 > 65535)
                {
                    Config.NZCV |= 1;
                }
                if (Config.ACC * OP1 == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                else if (Config.ACC *  OP1 < 0)
                {
                    Config.ACC = 0;

                    Config.setLESS();

                    return;
                }
                else if (Config.ACC * OP1 > 0)
                {
                    Config.setGREATER();

                }

                Config.ACC = (Config.ACC * OP1) % 65536;

                Config.instrucitonsInBinary[Config.PC] = Memory.formOneAddres("MUL", ops[0]);


            }
            else if (ops.Length == 2 && args != "") // two operands ADD OP2,OP1
            {
                int OP1, OP2;

                OP2 = Config.getReg(ops[1]);

                OP1 = Config.getReg(ops[0]);

                Config.setReg(ops[0], (OP2 * OP1) % 65536);

                if (OP2 * OP1 > 65535)
                {
                    Config.NZCV |= 1;
                }
                if (OP2 * OP1 == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                else if (OP2 * OP1 > 0)
                {

                    Config.setGREATER();
                }
                else if (OP2 * OP1 < 0)
                {
                    Config.NZCV |= 8;

                    Config.setReg(ops[0], 0);

                    Config.setLESS();
                }
                Config.instrucitonsInBinary[Config.PC] = Memory.formTwoAddres("MUL", ops[0], ops[1]);

            }                                       //                   ops[0] ops[1] ops[2]
            else if (ops.Length == 3 && args != "") // three operands ADD OP3 , OP2 , OP1
            {


                int OP2 = 0, OP1 = 0;

                OP2 = Config.getReg(ops[1]);
                OP1 = Config.getReg(ops[2]);

                Config.setReg(ops[0], (OP2 * OP1) % 65536);

                if (OP2 * OP1 > 65535)
                {
                    Config.NZCV |= 1;
                }
                if (OP2 * OP1 == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                else if (OP2 * OP1 > 0)
                {

                    Config.setGREATER();
                }
                else if (OP2 * OP1 < 0)
                {
                    Config.setReg(ops[0], 0);

                    Config.NZCV |= 8;

                    Config.setLESS();
                }

                Config.instrucitonsInBinary[Config.PC] = Memory.formThreeAddres("MUL", ops[0], ops[1], ops[2]);

            }
            else if (ops.Length == 0 || args == "") // zero operands
            {

                if (Config.USER_STACK - Config.USER_STACK_BASE >= 2)
                {
                    //ACC = OP2 + OP1
                    int OP2 = Config.memory[--Config.USER_STACK];
                    int OP1 = Config.memory[--Config.USER_STACK];

                    if (OP2 * OP1 > 65535)
                    {
                        Config.NZCV |= 1;
                    }
                    if (OP2 * OP1 == 0)
                    {
                        Config.setEQAUL();

                        Config.NZCV |= 4;
                    }
                    else if (OP2 * OP1 > 0)
                    {

                        Config.setGREATER();
                    }



                    Config.ACC = (OP2 * OP1) % 65536;

                    if (OP2 * OP1 < 0)
                    {
                        Config.ACC = 0;

                        Config.setLESS();
                    }
                    Config.memory[Config.USER_STACK++] = Config.ACC;

                    Config.instrucitonsInBinary[Config.PC] = Memory.formZeroAddres("MUL");

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

                OP1 = Config.getReg(ops[0]);

                if(OP1 == 0)
                {
                    //TODO : ERROR
                    return;
                }

                if (Config.ACC / OP1 > 65535)
                {
                    Config.NZCV |= 1;
                }
                if (Config.ACC / OP1 == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                else if (Config.ACC / OP1 < 0)
                {
                    Config.ACC = 0;

                    Config.setLESS();

                    return;
                }
                else if (Config.ACC / OP1 > 0)
                {
                    Config.setGREATER();

                }

                Config.ACC = (Config.ACC / OP1) % 65536;

                Config.instrucitonsInBinary[Config.PC] = Memory.formOneAddres("DIV", ops[0]);
            }
            else if (ops.Length == 2 && args != "") // two operands ADD OP1,OP2
            {
                int OP1, OP2;

                OP2 = Config.getReg(ops[1]);

                OP1 = Config.getReg(ops[0]);

                if(OP2 == 0)
                {
                    //TODO: ERROR
                    return;
                }

                Config.setReg(ops[0], (OP1 / OP2) % 65536);

                if (OP2 / OP1 > 65535)
                {
                    Config.NZCV |= 1;
                }
                if (OP2 / OP1 == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                else if (OP2 / OP1 > 0)
                {

                    Config.setGREATER();
                }
                else if (OP2 / OP1 < 0)
                {
                    Config.NZCV |= 8;

                    Config.setReg(ops[0], 0);

                    Config.setLESS();
                }

                Config.instrucitonsInBinary[Config.PC] = Memory.formTwoAddres("DIV", ops[0], ops[1]);

            }                                       //                   ops[0] ops[1] ops[2]
            else if (ops.Length == 3 && args != "") // three operands ADD OP3 , OP2 , OP1
            {


                int OP2 = 0, OP1 = 0;

                OP2 = Config.getReg(ops[1]);
                OP1 = Config.getReg(ops[2]);

                Config.setReg(ops[0], (OP2 / OP1) % 65536);

                if(OP1 == 0)
                {
                    //TODO: ERROR
                    return;
                }


                if (OP2 / OP1 > 65535)
                {
                    Config.NZCV |= 1;
                }
                if (OP2 * OP1 == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                else if (OP2 / OP1 > 0)
                {

                    Config.setGREATER();
                }
                else if (OP2 / OP1 < 0)
                {
                    Config.setReg(ops[0], 0);

                    Config.NZCV |= 8;

                    Config.setLESS();
                }

                Config.instrucitonsInBinary[Config.PC] = Memory.formThreeAddres("DIV", ops[0], ops[1], ops[2]);

            }
            else if (ops.Length == 0 || args == "") // zero operands
            {

                if (Config.USER_STACK - Config.USER_STACK_BASE >= 2)
                {
                    //ACC = OP2 + OP1
                    int OP2 = Config.memory[--Config.USER_STACK];
                    int OP1 = Config.memory[--Config.USER_STACK];

                    if(OP1 == 0)
                    {
                        // TODO: ERROR
                        return;
                    }

                    if (OP2 / OP1 > 65535)
                    {
                        Config.NZCV |= 1;
                    }
                    if (OP2 / OP1 == 0)
                    {
                        Config.setEQAUL();

                        Config.NZCV |= 4;
                    }
                    else if (OP2 /  OP1 > 0)
                    {

                        Config.setGREATER();
                    }



                    Config.ACC = (OP2 / OP1) % 65536;

                    if (OP2 / OP1 < 0)
                    {
                        Config.ACC = 0;

                        Config.setLESS();
                    }
                    Config.memory[Config.USER_STACK++] = Config.ACC;

                    Config.instrucitonsInBinary[Config.PC] = Memory.formZeroAddres("DIV");
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

                OP1 = Config.getReg(ops[0]);

                if (Config.ACC % OP1 > 65535)
                {
                    Config.NZCV |= 1;
                }
                if (Config.ACC % OP1 == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                else if (Config.ACC % OP1 < 0)
                {
                    Config.ACC = 0;

                    Config.setLESS();

                    return;
                }
                else if (Config.ACC % OP1 > 0)
                {
                    Config.setGREATER();

                }

                Config.ACC = (Config.ACC % OP1) % 65536;

                Config.instrucitonsInBinary[Config.PC] = Memory.formOneAddres("MOD", ops[0]);


            }
            else if (ops.Length == 2 && args != "") // two operands ADD OP2,OP1
            {
                int OP1, OP2;

                OP2 = Config.getReg(ops[1]);

                OP1 = Config.getReg(ops[0]);

                

                Config.setReg(ops[0], (OP1%OP2) % 65536);

                if (OP2 % OP1 > 65535)
                {
                    Config.NZCV |= 1;
                }
                if (OP2 % OP1 == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                else if (OP2 % OP1 > 0)
                {

                    Config.setGREATER();
                }
                else if (OP2 % OP1 < 0)
                {
                    Config.NZCV |= 8;

                    Config.setReg(ops[0], 0);

                    Config.setLESS();
                }

                Config.instrucitonsInBinary[Config.PC] = Memory.formTwoAddres("MOD", ops[0], ops[1]);

            }                                       //                   ops[0] ops[1] ops[2]
            else if (ops.Length == 3 && args != "") // three operands ADD OP3 , OP2 , OP1
            {


                int OP2 = 0, OP1 = 0;

                OP2 = Config.getReg(ops[1]);
                OP1 = Config.getReg(ops[2]);

                Config.setReg(ops[0], (OP2 % OP1) % 65536);

                if (OP2 % OP1 > 65535)
                {
                    Config.NZCV |= 1;
                }
                if (OP2 % OP1 == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                else if (OP2 % OP1 > 0)
                {

                    Config.setGREATER();
                }
                else if (OP2 % OP1 < 0)
                {
                    Config.setReg(ops[0], 0);

                    Config.NZCV |= 8;

                    Config.setLESS();
                }

                Config.instrucitonsInBinary[Config.PC] = Memory.formThreeAddres("MOD", ops[0], ops[1], ops[2]);

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
                    if (OP2 % OP1 == 0)
                    {
                        Config.setEQAUL();

                        Config.NZCV |= 4;
                    }
                    else if (OP2 % OP1 > 0)
                    {

                        Config.setGREATER();
                    }

                    Config.ACC = (OP2 % OP1) % 65536;

                    if (OP2 % OP1 < 0)
                    {
                        Config.ACC = 0;

                        Config.setLESS();
                    }
                    Config.memory[Config.USER_STACK++] = Config.ACC;

                    Config.instrucitonsInBinary[Config.PC] = Memory.formZeroAddres("MOD");

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

                int OP = Config.getReg(ops[0]);
                
                if(OP + 1 > 65536)
                {
                    Config.NZCV |= 1;

                }
                if(OP+1 == 0)
                {
                    Config.NZCV |= 4;
                    Config.setEQAUL();
                }
                else if(OP+1 < 0)
                {
                    Config.setReg(ops[0], 0);
                    Config.NZCV |= 8;
                    Config.setLESS();
                    return;
                }
                else if(OP+1 > 0)
                {
                    Config.setGREATER();
                }

                Config.setReg(ops[0], (OP + 1) % 65536);

                Config.instrucitonsInBinary[Config.PC] = Memory.formOneAddres("INC", ops[0]);

            }
            else if (ops.Length == 0 || args == "")
            {
                if (Config.ACC + 1 > 65535)
                {
                    Config.NZCV |= 1;
                    Config.NZCV |= 2;
                }
                else if (Config.ACC + 1 == 0)
                {
                    Config.NZCV |= 4;

                    Config.setEQAUL();

                }
                else if(Config.ACC + 1 > 0)
                {
                    Config.setGREATER();

                }
                else if(Config.ACC + 1 < 0)
                {
                    Config.NZCV |= 8;
                    Config.ACC = 0;
                    Config.setLESS();

                    return;
                }


                Config.ACC = (Config.ACC + 1) % 65535;

                Config.instrucitonsInBinary[Config.PC] = Memory.formZeroAddres("INC");
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

                int OP = Config.getReg(ops[0]);


                if (OP - 1 > 65536)
                {
                    Config.NZCV |= 1;

                }
                if (OP - 1 == 0)
                {
                    Config.NZCV |= 4;
                    Config.setEQAUL();
                }
                else if (OP - 1 < 0)
                {
                    Config.setReg(ops[0], 0);
                    Config.NZCV |= 8;
                    Config.setLESS();
                    return;
                }
                else if (OP - 1 > 0)
                {
                    Config.setGREATER();
                }

                Config.setReg(ops[0], (OP - 1) % 65536);

                Config.instrucitonsInBinary[Config.PC] = Memory.formOneAddres("DEC", ops[0]);

            }
            else if (ops.Length == 0 || args == "")
            {
                if (Config.ACC - 1 > 65535)
                {
                    Config.NZCV |= 1;
                    Config.NZCV |= 2;
                }
                else if (Config.ACC - 1 == 0)
                {
                    Config.NZCV |= 4;

                    Config.setEQAUL();

                }
                else if (Config.ACC - 1 > 0)
                {
                    Config.setGREATER();

                }
                else if (Config.ACC - 1 < 0)
                {
                    Config.NZCV |= 8;
                    Config.ACC = 0;
                    Config.setLESS();

                    return;
                }


                Config.ACC = (Config.ACC - 1) % 65535;

                Config.instrucitonsInBinary[Config.PC] = Memory.formZeroAddres("DEC");
            }
            else
            {
                //TODO: ERROR
            }
        }

    }
}


