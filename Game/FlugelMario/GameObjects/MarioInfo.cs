using Microsoft.Xna.Framework;
using SuperMairo.HeadsUp;
using SuperMario.GameObjects;
using SuperMario.Interfaces;
using SuperMario.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SuperMario
{   
    static class MarioInfo
    {      
        public static int[] MarioLife { get; } = {3};
        public static int HighestScore { get; set; } = 0;
        public static int Time { get; set; } = 0;
        private static int counter = 0;
        private static bool isTimeCounting = false;
        private static bool isWarningPlaying = false;
        public static void UpdateHighestScore()
        {
            if (ScoringSystem.Score > HighestScore)
            {
                HighestScore = ScoringSystem.Score;
            }
        }

        public static void ResetTimer()
        {
            Time = 400;
            isTimeCounting = false;
        }

        public static void ClearTimer()
        {
            Time = 0;
            isTimeCounting = false;
        }

        public static void StartTimer()
        {
            isTimeCounting = true;
        }

        public static void StopTimer()
        {
            isTimeCounting = false;
        }

        public static void timeCount(GameTime gameTime, IMario mario)
        {
            if (isTimeCounting)
            {
                counter += gameTime.ElapsedGameTime.Milliseconds;
                if (counter >= 1000)
                {
                    Time--;
                    counter = 0;
                }
                if (Time == 100)
                {
                    if (!isWarningPlaying)
                    {
                        SoundManager.Instance.PlayWarningSound();
                    }
                    isWarningPlaying = true;

                }
                if (Time == 0)
                {
                    isTimeCounting = false;
                    mario.State.Terminated();
                }
            }
        }
    }
}
