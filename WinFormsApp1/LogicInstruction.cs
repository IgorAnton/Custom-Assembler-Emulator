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
                int OP1 = Config.getReg(ops[0]);

                int tmp1 = Config.ACC;
                int tmp2 = OP1;

                if ((tmp1 & tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 & tmp2) == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                Config.ACC = (Config.ACC & OP1) % 65536;

                if (Config.ACC < 0)
                {
                    Config.setLESS();

                    Config.ACC = 0;
                }
                if (Config.ACC > 0)
                {
                    Config.setGREATER();
                }


            }
            else if (ops.Length == 2 && args != "")
            {

                int OP1 = 0, OP2 = 0; ;


                OP1 = Config.getReg(ops[1]);
                OP2 = Config.getReg(ops[0]);

                int tmp1 = OP2;
                int tmp2 = OP1;


                if ((tmp1 & tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                else if ((tmp1 & tmp2) == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }

                Config.setReg(ops[0], (OP2 & OP1) % 65536);

                if (Config.getReg(ops[0]) < 0)
                {
                    Config.setEQAUL();

                    Config.setReg(ops[0], 0);

                }
                if (Config.getReg(ops[0]) > 0)
                {
                    Config.setGREATER();

                }


            }
            else if (ops.Length == 3 && args != "")
            {
                int OP1 = 0, OP2 = 0;


                OP1 = Config.getReg(ops[1]);
                OP2 = Config.getReg(ops[2]);

                int tmp1 = OP1;
                int tmp2 = OP2;

                if ((tmp1 & tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 & tmp2) == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                Config.setReg(ops[0], (OP1 & OP2) % 65536);

                if (Config.getReg(ops[0]) < 0)
                {
                    Config.setLESS();

                    Config.setReg(ops[0], 0);
                }
                if (Config.getReg(ops[0]) > 0)
                {
                    Config.setGREATER();

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
                    if ((tmp1 & tmp2) > 65535)
                    {
                        Config.NZCV |= 1;
                    }
                    if ((tmp1 & tmp2) == 0)
                    {
                        Config.setEQAUL();

                        Config.NZCV |= 4;
                    }


                    Config.ACC = (OP2 & OP1) % 65536;

                    if (Config.ACC < 0)
                    {
                        Config.setLESS();
                        Config.ACC = 0;
                    }
                    if (Config.ACC > 0)
                    {
                        Config.setGREATER();

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
                int OP1 = Config.getReg(ops[0]);

                int tmp1 = Config.ACC;
                int tmp2 = OP1;

                if ((tmp1 | tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 | tmp2) == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                Config.ACC = (Config.ACC | OP1) % 65536;

                if (Config.ACC < 0)
                {
                    Config.setLESS();

                    Config.ACC = 0;
                }
                if (Config.ACC > 0)
                {
                    Config.setGREATER();
                }

            }
            else if (ops.Length == 2 && args != "")
            {

                int OP1 = 0, OP2 = 0; ;


                OP1 = Config.getReg(ops[1]);
                OP2 = Config.getReg(ops[0]);

                int tmp1 = OP2;
                int tmp2 = OP1;


                if ((tmp1 | tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                else if ((tmp1 | tmp2) == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }

                Config.setReg(ops[0], (OP2 | OP1) % 65536);

                if (Config.getReg(ops[0]) < 0)
                {
                    Config.setEQAUL();

                    Config.setReg(ops[0], 0);


                }
                if (Config.getReg(ops[0]) > 0)
                {
                    Config.setGREATER();

                }

            }
            else if (ops.Length == 3 && args != "")
            {
                int OP1 = 0, OP2 = 0;


                OP1 = Config.getReg(ops[1]);
                OP2 = Config.getReg(ops[2]);

                int tmp1 = OP1;
                int tmp2 = OP2;

                if ((tmp1 | tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 | tmp2) == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                Config.setReg(ops[0], (OP1 | OP2) % 65536);

                if (Config.getReg(ops[0]) < 0)
                {
                    Config.setLESS();

                    Config.setReg(ops[0], 0);
                }
                if (Config.getReg(ops[0]) > 0)
                {
                    Config.setGREATER();

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
                    if ((tmp1 | tmp2) > 65535)
                    {
                        Config.NZCV |= 1;
                    }
                    if ((tmp1 | tmp2) == 0)
                    {
                        Config.setEQAUL();

                        Config.NZCV |= 4;
                    }


                    Config.ACC = (OP2 | OP1) % 65536;

                    if (Config.ACC < 0)
                    {
                        Config.setLESS();
                        Config.ACC = 0;
                    }
                    if (Config.ACC > 0)
                    {
                        Config.setGREATER();

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
                int OP1 = Config.getReg(ops[0]);

                int tmp1 = Config.ACC;
                int tmp2 = OP1;

                if ((tmp1 ^ tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 ^ tmp2) == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                Config.ACC = (Config.ACC ^ OP1) % 65536;

                if (Config.ACC < 0)
                {
                    Config.setLESS();

                    Config.ACC = 0;
                }
                if (Config.ACC > 0)
                {
                    Config.setGREATER();
                }


            }
            else if (ops.Length == 2 && args != "")
            {

                int OP1 = 0, OP2 = 0; ;


                OP1 = Config.getReg(ops[1]);
                OP2 = Config.getReg(ops[0]);

                int tmp1 = OP2;
                int tmp2 = OP1;


                if ((tmp1 ^ tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                else if ((tmp1 ^ tmp2) == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }

                Config.setReg(ops[0], (OP2 ^ OP1) % 65536);

                if (Config.getReg(ops[0]) < 0)
                {
                    Config.setEQAUL();

                    Config.setReg(ops[0], 0);


                }
                if (Config.getReg(ops[0]) > 0)
                {
                    Config.setGREATER();

                }

               

            }
            else if (ops.Length == 3 && args != "")
            {
                int OP1 = 0, OP2 = 0;


                OP1 = Config.getReg(ops[1]);
                OP2 = Config.getReg(ops[2]);

                int tmp1 = OP1;
                int tmp2 = OP2;

                if ((tmp1 ^ tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 ^ tmp2) == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                Config.setReg(ops[0], (OP1 ^ OP2) % 65536);

                if (Config.getReg(ops[0]) < 0)
                {
                    Config.setLESS();

                    Config.setReg(ops[0], 0);
                }
                if (Config.getReg(ops[0]) > 0)
                {
                    Config.setGREATER();

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
                    if ((tmp1 ^ tmp2) > 65535)
                    {
                        Config.NZCV |= 1;
                    }
                    if ((tmp1 ^ tmp2) == 0)
                    {
                        Config.setEQAUL();

                        Config.NZCV |= 4;
                    }


                    Config.ACC = (OP2 ^ OP1) % 65536;

                    if (Config.ACC < 0)
                    {
                        Config.setLESS();
                        Config.ACC = 0;
                    }
                    if (Config.ACC > 0)
                    {
                        Config.setGREATER();

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
                int OP1 = Config.getReg(ops[0]);

                int tmp1 = Config.ACC;
                int tmp2 = OP1;

                if ((tmp1 << tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 << tmp2) == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                Config.ACC = (Config.ACC << OP1) % 65536;

                if (Config.ACC < 0)
                {
                    Config.setLESS();

                    Config.ACC = 0;
                }
                if (Config.ACC > 0)
                {
                    Config.setGREATER();
                }
               
            }
            else if (ops.Length == 2 && args != "")
            {
                
                int OP1 = 0, OP2 = 0; ;
                

                OP1 = Config.getReg(ops[1]);
                OP2 = Config.getReg(ops[0]);

                int tmp1 = OP2;
                int tmp2 = OP1;


                if ((tmp1 << tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                else if ((tmp1 << tmp2) == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }

                Config.setReg(ops[0], (OP2 << OP1) % 65536);

                if (Config.getReg(ops[0]) < 0)
                {
                    Config.setEQAUL();

                    Config.setReg(ops[0], 0);


                }
                if (Config.getReg(ops[0]) > 0)
                {
                    Config.setGREATER();

                }

            }
            else if (ops.Length == 3 && args != "")
            {
                int OP1 = 0, OP2 = 0;


                OP1 = Config.getReg(ops[1]);
                OP2 = Config.getReg(ops[2]);

                int tmp1 = OP1;
                int tmp2 = OP2;

                if ((tmp1 << tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 << tmp2) == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                Config.setReg(ops[0], (OP1 << OP2) % 65536);

                if (Config.getReg(ops[0]) < 0)
                {
                    Config.setLESS();

                    Config.setReg(ops[0], 0);
                }
                if (Config.getReg(ops[0]) > 0)
                {
                    Config.setGREATER();

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
                    if ((tmp1 << tmp2) > 65535)
                    {
                        Config.NZCV |= 1;
                    }
                    if ((tmp1 << tmp2) == 0)
                    {
                        Config.setEQAUL();

                        Config.NZCV |= 4;
                    }


                    Config.ACC = (OP2 << OP1) % 65536;

                    if (Config.ACC < 0)
                    {
                        Config.setLESS();
                        Config.ACC = 0;
                    }
                    if (Config.ACC > 0)
                    {
                        Config.setGREATER();

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

                int OP1 = Config.getReg(ops[0]);
                
                int tmp1 = Config.ACC;
                int tmp2 = OP1;

                if ((tmp1 >> tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 >> tmp2) == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                Config.ACC = (Config.ACC >> OP1) % 65536;

                if (Config.ACC < 0)
                {
                    Config.setLESS();

                    Config.ACC = 0;
                }
                if (Config.ACC > 0)
                {

                    Config.setGREATER();
                }

            }
            else if (ops.Length == 2 && args != "")
            {
                
                int OP1 = 0, OP2 = 0; ;
                

                OP1 = Config.getReg(ops[1]);
                OP2 = Config.getReg(ops[0]);

                int tmp1 = OP2;
                int tmp2 = OP1;


                if ((tmp1 >> tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                else if ((tmp1 >> tmp2) == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }

                Config.setReg(ops[0], (OP2 >> OP1) %65536 );

                if (Config.getReg(ops[0]) < 0)
                {
                    Config.setEQAUL();

                    Config.setReg(ops[0], 0);


                }
                if (Config.getReg(ops[0]) > 0)
                {
                    Config.setGREATER();

                }

            }
            else if (ops.Length == 3 && args != "")
            {
                int OP1 = 0, OP2 = 0;
                

                OP1 = Config.getReg(ops[1]);
                OP2 = Config.getReg(ops[2]);

                int tmp1 = OP1;
                int tmp2 = OP2;

                if ((tmp1 >> tmp2) > 65535)
                {
                    Config.NZCV |= 1;
                }
                if ((tmp1 >> tmp2) == 0)
                {
                    Config.setEQAUL();

                    Config.NZCV |= 4;
                }
                Config.setReg(ops[0] , (OP1 >> OP2) % 65536);

                if (Config.getReg(ops[0]) < 0)
                {
                    Config.setLESS();

                    Config.setReg(ops[0], 0);
                }
                if (Config.getReg(ops[0] )> 0)
                {
                    Config.setGREATER();

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
                        Config.setEQAUL();

                        Config.NZCV |= 4;
                    }


                    Config.ACC = (OP2 >> OP1) % 65536;
                    if (Config.ACC < 0)
                    {
                        Config.setLESS();
                        Config.ACC = 0;
                    }
                    if(Config.ACC > 0)
                    {
                        Config.setGREATER();

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
                int OP1 = 0;
                int OP2 = 0;
                

                OP1 = Config.getReg(ops[0]);
                OP2 = Config.getReg(ops[1]);


                if(OP1 == OP2)
                {
                    Config.setEQAUL();

                    Config.NZCV = 0;

                    Config.NZCV |= 4;
                }
                if(OP1 < OP2)
                {

                    Config.setLESS();
                    Config.NZCV = 0;

                    Config.NZCV |= 2;

                }
                if (OP1 > OP2)
                {
                    Config.setGREATER();

                    Config.NZCV = 0;
                    Config.NZCV |=8 ;
                }

             


            }
            if(ops.Length == 1)
            {
                int OP1 = Config.getReg(ops[0]);

                if (Config.ACC  == OP1)
                {
                    Config.setEQAUL();

                    Config.NZCV = 0;

                    Config.NZCV |= 4;
                }
                if (Config.ACC < OP1)
                {

                    Config.setLESS();
                    Config.NZCV = 0;

                    Config.NZCV |= 2;

                }
                if (Config.ACC > OP1 )
                {
                    Config.setGREATER();

                    Config.NZCV = 0;
                    Config.NZCV |= 8;
                }

            }
        }

    }
}
