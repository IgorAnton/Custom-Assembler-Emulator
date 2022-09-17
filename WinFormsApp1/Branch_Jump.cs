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

            String jumpAddres = Convert.ToString(jumpIndex*4+0x1000,2);

            Config.instrucitonsInBinary[Config.PC] = Memory.formBranch("JUMP", jumpAddres);

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
            if(Config.EQUAL)
            {
                Config.codeIndex = jumpIndex - 1;

                

            }
            String jumpAddres = Convert.ToString(jumpIndex*4 + 0x1000, 2);

            Config.instrucitonsInBinary[Config.PC] = Memory.formBranch("BEQ", jumpAddres);


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
            if (Config.LESS)
            {
                Config.codeIndex = jumpIndex - 1;
            }

            String jumpAddres = Convert.ToString(jumpIndex*4 + 0x1000, 2);

            Config.instrucitonsInBinary[Config.PC] = Memory.formBranch("BLSS", jumpAddres);

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

            if (Config.GREATER)
            {
                Config.codeIndex = jumpIndex - 1;
            }

            String jumpAddres = Convert.ToString(jumpIndex*4 + 0x1000, 2);

            Config.instrucitonsInBinary[Config.PC] = Memory.formBranch("BGT", jumpAddres);

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

            if (Config.GREATER || Config.EQUAL)
            {
                Config.codeIndex = jumpIndex - 1;
            }

            String jumpAddres = Convert.ToString(jumpIndex*4 + 0x1000, 2);

            Config.instrucitonsInBinary[Config.PC] = Memory.formBranch("BGE", jumpAddres);
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

            if (Config.LESS || Config.EQUAL)
            {
                Config.codeIndex = jumpIndex - 1;
            }

            String jumpAddres = Convert.ToString(jumpIndex*4 + 0x1000, 2);

            Config.instrucitonsInBinary[Config.PC] = Memory.formBranch("BLEQ", jumpAddres);

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
            if (!Config.EQUAL)
            {
                Config.codeIndex = jumpIndex - 1;
            }

            String jumpAddres = Convert.ToString(jumpIndex*4 + 0x1000, 2);

            Config.instrucitonsInBinary[Config.PC] = Memory.formBranch("BNEQ", jumpAddres);

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

            String jumpAddres = Convert.ToString(jumpIndex*4 + 0x1000, 2);

            Config.instrucitonsInBinary[Config.PC] = Memory.formBranch("JSR", jumpAddres);


        }
        public static void RTS()
        {
            Config.codeIndex = Config.memory[--Config.SYS_STACK];
            Config.NZCV = Config.memory[--Config.SYS_STACK];
            Config.PC = Config.memory[--Config.SYS_STACK];

            Config.instrucitonsInBinary[Config.PC] = Memory.formZeroAddres("RTS");
        }


    }
}
