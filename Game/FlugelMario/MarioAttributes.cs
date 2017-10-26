using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SuperMario
{
    static class MarioAttributes
    {
        public static int[] MarioLife { get; } = {1, 1};

        public static int Time { get; set; } = 0;

        private static bool isTimeTicking = false;

        public static void ResetTimer()
        {
            Time = 300;
            isTimeTicking = false;
        }

        public static void StartTimer()
        {
            isTimeTicking = true;
        }

    }
}
