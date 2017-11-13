using Microsoft.Xna.Framework;
using SuperMario.Animation;
using SuperMario.GameObjects;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMairo.DisplayPanel;
using SuperMario.Sound;

namespace SuperMairo.HeadsUp
{
    public class ScoringSystem
    {
        private static int score = 0;
        public static int Score { get { return score; } }
        public static int flagScore = 0;
        public static int Flagscore { get { return flagScore; } }

        private static List<IGameObject> flagParts=new List<IGameObject>();
        private static int FlagCutOff1 = 1;
        private static int FlagCutOff2 = 3;
        private static int FlagCutOff3 = 5;
        private static int FlagCutOff4 = 7;
        private static int CutOffScore1 = 200;
        private static int CutOffScore2 = 500;
        private static int CutOffScore3 = 1000;
        private static int CutOffScore4 = 2000;

        public static void RegisgerFlagPole(IGameObject pole)
        {
            flagParts.Add(pole);
        }
        public static void ResetScore()
        {
            score = 0;
        }

        public static void AddPointsForBreakingBlock(IGameObject block)
        {
            score += 50;
            ScoreAnimation(block, "50");
        }

        public static void AddPointsForCollectingPwrUp(IGameObject PUitem)
        {
            score+=1000;
            ScoreAnimation(PUitem, "1000");
        }

        public static void AddPointsForCoin(IGameObject coin)
        {
            score += 200;
            ScoreAnimation(coin, "200");
        }

        public static void AddPointsForGMush(IGameObject GMush)
        {
            ScoreAnimation(GMush, "1UP");
        }

        public static void AddPointsForStompingEnemy(IGameObject enemy)
        {
            score += 100;
            ScoreAnimation(enemy, "100");
        }
        public static void AddPointsForPole(Rectangle marioDestination)
        {
            if (marioDestination.Y <= flagParts[FlagCutOff1].Destination.Y)
            {
                flagScore += CutOffScore1;
            }else if(marioDestination.Y < flagParts[FlagCutOff2].Destination.Y)
            {
                flagScore += CutOffScore2;
            }
            else if (marioDestination.Y < flagParts[FlagCutOff3].Destination.Y)
            {
                flagScore += CutOffScore3;
            }
            else if (marioDestination.Y < flagParts[FlagCutOff4].Destination.Y)
            {
                flagScore += CutOffScore4;
            }
            score += flagScore;
            CreateNewScoreAnimation(marioDestination, flagParts[flagParts.Count - 1].Destination, flagScore);
        }
        public static void AddPointsForRestTime()
        {
            score += 10;
            SoundManager.Instance.PlayCoinSound();
        }

        private static void ScoreAnimation(IGameObject obj, String scoreToDisplay)
        {
            Rectangle objDestination = obj.Destination;
            Vector2 location = new Vector2(objDestination.X, objDestination.Y);
            IAnimationInGame scoreAnimation = new ScoreTextAnimation(location, scoreToDisplay);
            scoreAnimation.StartAnimation();
        }

        private static void CreateNewScoreAnimation(Rectangle marioDestination, Rectangle poleDestination, int scoreToDisplay)
        {
            IAnimationInGame scoreAnimation = new PoleScoreTextAnimation(marioDestination, poleDestination, "" + scoreToDisplay);
            scoreAnimation.StartAnimation();
        }
    }
}
