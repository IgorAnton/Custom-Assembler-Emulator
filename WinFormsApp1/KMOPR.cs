using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class KMOPR
    {
        public static NAMES reslove(string s)
        {
            switch (s)
            {
                case "POP":
                    return NAMES.POP;
                case "PUSH":
                    return NAMES.PUSH;
                case "ADD":
                    return NAMES.ADD;
                case "SUB":
                    return NAMES.SUB;
                case "MUL":
                    return NAMES.MUL;
                case "DIV":
                    return NAMES.DIV;
                case "MOD":
                    return NAMES.MOD;

                case "INC":
                    return NAMES.INC;

                case "DEC":
                    return NAMES.DEC;

                case "LSH":
                    return NAMES.LSH;

                case "RSH":
                    return NAMES.RSH;
                case "JUMP":
                    return NAMES.JUMP;
                case "BLSS":
                    return NAMES.BLSS;
                case "BEQ":
                    return NAMES.BEQ;
                case "BGT":
                    return NAMES.BGT;
                case "BGE":
                    return NAMES.BGE;
                case "BLEQ":
                    return NAMES.BLEQ;
                case "MOV":
                    return NAMES.MOV;
                case "BNEQ":
                    return NAMES.BNEQ;
                case "AND":
                    return NAMES.AND;
                case "OR":
                    return NAMES.OR;
                case "XOR":
                    return NAMES.XOR;

                case "CMP":
                    return NAMES.CMP;

                case "LD":
                    return NAMES.LD;

                case "ST":
                    return NAMES.ST;

                case "CLR":
                    return NAMES.CLR;

                case "JSR":
                    return NAMES.JSR;
                case "RTS":
                    return NAMES.RTS;
                case "HALT":
                    return NAMES.HALT;
                
                default:
                    return 0;
            }
        }

        public static void execute(NAMES op_code,string line)
        {
            String[] first_split = new String[2];
            first_split[0] = "";
            first_split[1] = "";
            first_split = line.Split(' ',2); // ? 

            first_split[0] = first_split[0].Trim();
            if (first_split.Length > 1)
            {
                first_split[1] = first_split[1].Trim();
            }
           
            

            switch (op_code)
            {
                case NAMES.POP:
                    {
                        if(first_split.Length == 1)
                            Stack.POP("");
                        else
                            Stack.POP(first_split[1]);
                        break;
                    }
                case NAMES.PUSH:
                    {
                        if (first_split.Length == 1)
                            Stack.PUSH("");
                        else
                            Stack.PUSH(first_split[1]);
                        break;
                    }
                case NAMES.ADD:
                    {
                        if (first_split.Length == 1)
                            ArithmeticInstructions.ADD("");
                        else
                            ArithmeticInstructions.ADD(first_split[1]);
                        break;
                    }
                case NAMES.SUB:
                    {
                        if(first_split.Length == 1)
                            ArithmeticInstructions.SUB("");
                        else
                            ArithmeticInstructions.SUB(first_split[1]);
                        break;
                    }
                case NAMES.MUL:
                    {
                        if (first_split.Length == 1)
                            ArithmeticInstructions.MUL("");
                        else
                            ArithmeticInstructions.MUL(first_split[1]);
                        break;
                    }
                case NAMES.DIV:
                    {
                        if (first_split.Length == 1)
                            ArithmeticInstructions.DIV("");
                        else
                            ArithmeticInstructions.DIV(first_split[1]);
                        break;
                    }
                case NAMES.MOD:
                    {
                        if (first_split.Length == 1)
                            ArithmeticInstructions.MOD("");
                        else
                            ArithmeticInstructions.MOD(first_split[1]);
                        break;
                    }
                case NAMES.INC:
                    {
                        if (first_split.Length == 1)
                            ArithmeticInstructions.INC("");
                        else
                            ArithmeticInstructions.INC(first_split[1]);

                        break;
                    }
                case NAMES.DEC:
                    {
                        if (first_split.Length == 1)
                            ArithmeticInstructions.DEC("");
                        else
                            ArithmeticInstructions.DEC(first_split[1]);

                        break;
                    }
                case NAMES.LSH:
                    {
                        if (first_split.Length == 1)
                            LogicInstruction.LSH("");
                        else
                            LogicInstruction.LSH(first_split[1]);

                        break;
                    }
                case NAMES.RSH:
                    {
                        if (first_split.Length == 1)
                            LogicInstruction.RSH("");

                        else
                            LogicInstruction.RSH(first_split[1]);

                        break;
                    }
                case NAMES.JUMP:
                    {
                        Branch_Jump.JUMP(first_split[1]);

                        break;
                    }
                case NAMES.BLSS:
                    {
                        Branch_Jump.BLSS(first_split[1]);
                        break;
                    }
                case NAMES.BEQ:
                    {
                        Branch_Jump.BEQ(first_split[1]);
                        break;
                    }
                case NAMES.BGT:
                    {
                        Branch_Jump.BGT(first_split[1]);
                        break;
                    }
                case NAMES.BGE:
                    {
                        Branch_Jump.BGE(first_split[1]);
                        break;
                    }
                case NAMES.BLEQ:
                    {
                        Branch_Jump.BLEQ(first_split[1]);
                        break;
                    }
                case NAMES.BNEQ:
                    {
                        Branch_Jump.BNEQ(first_split[1]);
                        break;
                    }
                case NAMES.MOV:
                    {
                        LoadStore.MOV(first_split[1]);
                        break;
                    }
                case NAMES.JSR:
                    {
                        Branch_Jump.JSR(first_split[1]);
                        break;
                    }
                case NAMES.RTS:
                    {
                        Branch_Jump.RTS();
                        break;
                    }

                case NAMES.AND:
                    {
                        if (first_split.Length == 1)
                            LogicInstruction.AND("");
                        else
                            LogicInstruction.AND(first_split[1]);
                        break;
                    }
                case NAMES.OR:
                    {
                        if (first_split.Length == 1)
                            LogicInstruction.OR("");
                        else
                            LogicInstruction.OR(first_split[1]);
                        break;
                    }
                case NAMES.XOR:
                    {

                        if (first_split.Length == 1)
                            LogicInstruction.XOR("");
                        else
                            LogicInstruction.XOR(first_split[1]);
                        break;
                    }
                case NAMES.LD:
                    {
                        if (first_split.Length == 1)
                            LoadStore.LD("");
                        else
                            LoadStore.LD(first_split[1]);
                        break;
                    }
                case NAMES.ST:
                    {
                        if (first_split.Length == 1)
                            LoadStore.ST("");
                        else
                            LoadStore.ST(first_split[1]);
                        break;
                    }

                case NAMES.CMP:
                    {
                        LogicInstruction.CMP(first_split[1]);

                        break;
                    }

                case NAMES.CLR:
                    {
                        if (first_split.Length == 1)
                            LoadStore.CLR("");
                        else
                            LoadStore.CLR(first_split[1]);
                        break;
                    }


                case NAMES.HALT:
                    {
                        Config.RUNNIGN = false;
                        if (!Config.ERROR_DETECTED)
                        {
                            Config.HALT_MSG = "Build executed successfully!";
                        }
                        else
                        {
                            Config.HALT_MSG = "Build didn't execut successfully!";
                        }

                        Config.instrucitonsInBinary[Config.PC] = Memory.formZeroAddres("HALT");
                        Config.PC -= 4;
                        break;
                    }
                
            }
        }
    }

    

    public enum NAMES
    {
        POP     =   0x01,
        PUSH    =   0x02,
        ADD     =   0x03,
        SUB     =   0x04,
        MUL     =   0x05,
        DIV     =   0x06,
        MOD     =   0x07,
        LSH     =   0x08,
        RSH     =   0x09,
        JUMP    =   0x0A,
        BLSS    =   0X0B,
        BEQ     =   0X0C,
        BGT     =   0X0D,
        BGE     =   0X0E,
        BLEQ    =   0X0F,
        MOV     =   0X10,
        INC     =   0x11,
        DEC     =   0X12,
        JSR     =   0x13,
        RTS     =   0x14,
        BNEQ    =   0x15,
        AND     =   0x16,
        OR      =   0x17,
        XOR     =   0x18,
        CMP     =   0x19,
        LD      =   0x1A,
        ST      =   0x1B,
        CLR     =   0x1C,
        HALT    =   0XFF
    }

    

    
}
