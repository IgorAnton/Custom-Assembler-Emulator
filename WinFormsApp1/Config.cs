﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
     class Config
    {

        public static int[] registers = new int[32];
        public static int ACC = 0;
        public static int PC = 1000;

        public static int[] memory = new int[65536];

        public static int SYS_STACK_BASE = 49152;
        public static int SYS_STACK = 49152;
        public static int USER_STACK_BASE = 57344;
        public static int USER_STACK = 57344;
        public static bool ERROR_DETECTED = false;
        public static int NZCV = 0;
        public static bool RUNNIGN = true;
        public static string HALT_MSG = "";

        public static bool EQUAL = false;
        public static bool LESS = false;
        public static bool GREATER = false;

        public static Dictionary<String, int> labels = new Dictionary<string, int>();
        public static int codeIndex = 0;

        public static void resetConfig()
        {
            Array.Clear(registers,0, registers.Length);
            ACC = 0;
            PC = 1000;
            RUNNIGN = true;
            Array.Clear(memory, 0, memory.Length);
            codeIndex = 0;
            SYS_STACK_BASE = 49152;
            SYS_STACK = 49152;
            USER_STACK_BASE = 57344;
            USER_STACK = 57344;
            ERROR_DETECTED = false;
            NZCV = 0;
            HALT_MSG = "";

            EQUAL = false;
            LESS = false;
            GREATER = false;

            labels.Clear();
    }


    }
}