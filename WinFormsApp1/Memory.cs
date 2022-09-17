using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Memory
    {
        public static Dictionary<String, String> OP_CODES = new Dictionary<String, String>();

        public static Dictionary<int, String> MACHINE_STATE = new Dictionary<int, String>();
       public static void initOPCODES()
        {
            //stack

            OP_CODES["POP"]     =   "100000";
            OP_CODES["PUSH"]    =   "100001";

            //arithmetic instructions

            OP_CODES["ADD"]     =   "001000";
            OP_CODES["SUB"]     =   "001001";
            OP_CODES["MUL"]     =   "001010";
            OP_CODES["DIV"]     =   "001011";
            OP_CODES["MOD"]     =   "001100";
            OP_CODES["INC"]     =   "001101";
            OP_CODES["DEC"]     =   "001110";

            //logical instructions

            OP_CODES["AND"]     =   "000001";
            OP_CODES["OR"]      =   "000010";
            OP_CODES["XOR"]     =   "000011";
            OP_CODES["CMP"]     =   "000100";
            OP_CODES["LSH"]     =   "000101";
            OP_CODES["RSH"]     =   "000110";

            //jump and branch insturctions

            OP_CODES["JUMP"]    =   "010000";
            OP_CODES["BLSS"]    =   "010001";
            OP_CODES["BEQ"]     =   "010010";
            OP_CODES["BGT"]     =   "010011";
            OP_CODES["BGE"]     =   "010100";
            OP_CODES["BLEQ"]    =   "010101";
            OP_CODES["BNEQ"]    =   "010110";
            OP_CODES["JSR"]     =   "010111";
            OP_CODES["RTS"]     =   "011000";

            //LD ST MOV CLR

            OP_CODES["LD"]      =   "110000";
            OP_CODES["ST"]      =   "110001";
            OP_CODES["MOV"]     =   "110010";
            OP_CODES["CLR"]     =   "110011";


            //HALT

            OP_CODES["HALT"]    =   "111111";

        }

        

        public static void initMACHINESTATE()
        {
            MACHINE_STATE[0] = "00";    //0-addres
            MACHINE_STATE[1] = "01";    //1-addres
            MACHINE_STATE[2] = "10";    //2-addres
            MACHINE_STATE[3] = "11";    //3-addres
        }

        public static String getOPCODE(String name)
        {
            return OP_CODES[name];
        }

        public static String getMACHINESTATE(int state)
        {
            return MACHINE_STATE[state];
        }
        
        public static String formFirstByte(String name,int state)
        {
            return  getOPCODE(name) +  getMACHINESTATE(state);

        }

        private static string getRegNumInBin(String reg)
        {
            if (reg != null)
            {

                reg = reg.ToUpper();
                int regNum = 0;
                if (reg[0] != 'R')
                {
                    regNum = Convert.ToInt32(reg);
                }
                else
                {
                    reg = reg.Substring(1);

                    regNum = Convert.ToInt32(reg);
                }

;
                reg = Convert.ToString(regNum, 2);

                return reg.PadLeft(8, '0');

            }
            else
            {
                return "".PadLeft(8, '0');
            }

        }

        public static String formByte(String register)
        {
                return getRegNumInBin(register);
            
        }


        public static String formZeroAddres(String name) {

            return " | " + formFirstByte(name, 0) + " " + "".PadLeft(8, '0') + " " + "".PadLeft(8, '0') + " " + "".PadLeft(8, '0') + " | ";
        }

        public static String formOneAddres(String name, String register)
        {
            return " | " + formFirstByte(name, 1) + " " + formByte(register) + " " + "".PadLeft(8, '0') + " " + "".PadLeft(8, '0') + " | ";
        }

        public static String formBranch(String name, String label)
        {
            return " | " + formFirstByte(name, 1) + " " + label.PadLeft(24,'0') + " | " ;
        }

        public static String formTwoAddres(String name,String register1,String register2)
        {
            return " | " + formFirstByte(name, 2) + " " + formByte(register1) + " " + formByte(register2) + " " + "".PadLeft(8, '0') + " | ";

        }

        public static String formThreeAddres(String name,  String register1, String register2,String register3)
        {
            return " | " + formFirstByte(name, 3) + " " + formByte(register1) + " " + formByte(register2) + " " + formByte(register3) + " | ";

        }


        public static String formMemory(String name, String[] operands)
        {
            string ret = "";

            if(operands.Length == 0 )
            {
                ret = formZeroAddres(name);
            }
            else if(operands.Length == 1  )
            {
                ret = formOneAddres(name, operands[0]);
            }
            else if(operands.Length == 2 )
            {
                ret = formTwoAddres(name, operands[0], operands[1]);
            }
            
            else if(operands.Length == 3)
            {
                ret = formThreeAddres(name, operands[0], operands[1], operands[2]);
            }
            else
            {
                //TODO: ERROR
            }

            return ret;
        }

        

    }
}
