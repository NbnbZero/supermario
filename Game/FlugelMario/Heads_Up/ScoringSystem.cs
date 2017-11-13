using Microsoft.Xna.Framework;
using SuperMario.Animation;
using SuperMario.GameObjects;
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
        private static GameObjectManager objM;
        private static List<IGameObject> flagParts;
        public ScoringSystem(GameObjectManager ObjM)
        {
            objM = ObjM;
            flagParts = new List<IGameObject>();
        }

        public static void RegisgerFlagPole(IGameObject pole)
        {
            flagParts.Add(pole);
        }
        public static void ResetScore()
        {
            score = 0;
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

        private static void ScoreAnimation(IGameObject obj, String scoreToDisplay)
        {
            Rectangle objDestination = obj.Destination;
            Vector2 location = new Vector2(objDestination.X, objDestination.Y);
            IAnimationInGame scoreAnimation = new ScoreTextAnimation(location, scoreToDisplay, objM);
            scoreAnimation.StartAnimation();
        }
    }
}
