using Microsoft.Xna.Framework;
using SuperMairo.HeadsUp;
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
        public static int[] MarioLife { get; } = {3};
        public static int HighestScore { get; set; } = 0;
        public static int Time { get; set; } = 0;
        private static int counter = 0;
        private static bool isTimeTicking = false;
        public static void UpdateHighestScore()
        {
            if (ScoringSystem.Score > HighestScore)
            {
                HighestScore = ScoringSystem.Score;
            }
        }
    }
}
