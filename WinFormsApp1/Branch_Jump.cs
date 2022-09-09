using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Branch_Jump
    {

        public static void JUMP(string args)
        {
            if(args == null)
            {
                //TODO: ERROR
                return;
            }
            args = args.Trim();
            int jumpIndex = Config.labels[args];

            Config.codeIndex = jumpIndex-1;

        }

        public static void BEQ(string args)
        {
            if (args == null)
            {
                //TODO: ERROR
                return;
            }
            args = args.Trim();
            int jumpIndex = Config.labels[args];
            int uslov = Config.NZCV & 4;
            if(uslov != 0)
            {
                Config.codeIndex = jumpIndex - 1;
            }

        }
        public static void BLSS(string args)
        {

            if (args == null)
            {
                //TODO: ERROR
                return;
            }
            args = args.Trim();
            int jumpIndex = Config.labels[args];
            int uslov =  (Config.NZCV & 2);
            //(Config.NZCV & 8) ^
            if (uslov != 0)
            {
                Config.codeIndex = jumpIndex - 1;
            }

        }

        public static void BGT(string args)
        {

            if (args == null)
            {
                //TODO: ERROR
                return;
            }
            args = args.Trim();
            int jumpIndex = Config.labels[args];
            int uslov = ((Config.NZCV & 8) ) ;
                //^ (Config.NZCV & 1)) | (Config.NZCV & 4);

            if (uslov == 0)
            {
                Config.codeIndex = jumpIndex - 1;
            }

        }
        public static void BGE(string args)
        {

            if (args == null)
            {
                //TODO: ERROR
                return;
            }
            args = args.Trim();
            int jumpIndex = Config.labels[args];
            int uslov = ((Config.NZCV & 8) ^ (Config.NZCV & 1)) ; // N xor V = 0

            if (uslov == 0)
            {
                Config.codeIndex = jumpIndex - 1;
            }
        }
        public static void BLEQ(string args)
        {

            if (args == null)
            {
                //TODO: ERROR
                return;
            }
            args = args.Trim();
            int jumpIndex = Config.labels[args];
            int uslov = ((Config.NZCV & 8) ^ (Config.NZCV & 1)) | (Config.NZCV & 4);

            if (uslov != 0)
            {
                Config.codeIndex = jumpIndex - 1;
            }

        }
        public static void BNEQ(string args)
        {
            if (args == null)
            {
                //TODO: ERROR
                return;
            }
            args = args.Trim();
            int jumpIndex = Config.labels[args];
            int uslov = Config.NZCV & 4;
            if (uslov == 0)
            {
                Config.codeIndex = jumpIndex - 1;
            }

        }
        
        public static void JSR(string args)
        {

            if (args == null)
            {
                //TODO: ERROR
                return;
            }
            args = args.Trim();
            int jumpIndex = Config.labels[args];
            Config.memory[Config.SYS_STACK++] = Config.PC;
            Config.memory[Config.SYS_STACK++] = Config.NZCV;
            Config.memory[Config.SYS_STACK++] = Config.codeIndex ;
            Config.PC = jumpIndex * 4 + 1000;
            Config.codeIndex = jumpIndex - 1;

        }
        public static void RTS()
        {
            Config.codeIndex = Config.memory[--Config.SYS_STACK];
            Config.NZCV = Config.memory[--Config.SYS_STACK];
            Config.PC = Config.memory[--Config.SYS_STACK];
        }


    }
}
