using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMairo.HeadsUp
{
    public class ScoringSystem
    {
        private static int score = 0;
        public static int Score { get { return score; } }
        private IMario mario;

        protected Rectangle marioDestination
        {
            get
            {
                if (mario == null)
                    return new Rectangle(0,0,0,0);
                return mario.Destination;
            }
        }

        private static ScoringSystem[] playerScores = { new ScoringSystem(), new ScoringSystem() };

        public void ResetScore()
        {
            score = 0;
        }
        protected void AddToScore(int scoreToAdd)
        {
            score += scoreToAdd;
        }



    }
}
