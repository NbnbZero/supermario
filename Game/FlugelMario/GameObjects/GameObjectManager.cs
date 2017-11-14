 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario;
using Microsoft.Xna.Framework.Graphics;
using static SuperMario.HandleAllCollison;
using SuperMairo.Interfaces;
using SuperMairo.DisplayPanel;
using Microsoft.Xna.Framework;
using SuperMario.Display;
using SuperMario.Enums;
using SuperMairo.HeadsUp;
using SuperMario.GameObjects.ItemGameObjects;
using SuperMario.Animation;

namespace SuperMario.GameObjects
{
    public class GameObjectManager 
    {
        public static List<IGameObject> pipeList;
        public static List<IGameObject> blockList;
        public static List<IGameObject> itemList;
        public static List<IGameObject> enemyList;
        public static List<IGameObject> objectList;
        public static List<IGameObject> cloudList;
        private List<IAnimationInGame> animationList;
        public IAnimation victoryAnimation;
        private MarioObject mario;
        private Game1 game;
        private bool isLevelComplete = false;
        private IDisplayPanel titleDisplayPanel;
        private IDisplayPanel gameOverDisplayPanel;
        private IDisplayPanel marioLifeDisplayPanel;
        private IDisplayPanel headsUpDisplayPanel;
        private IDisplayPanel winningDisplayPanel;

        private const int BufferSize = 32;
        public GameObjectManager(Game1 Game, MarioObject Mario)
        {
            blockList = new List<IGameObject>();
            itemList = new List<IGameObject>();
            enemyList = new List<IGameObject>();
            pipeList = new List<IGameObject>();
            objectList = new List<IGameObject>();
            cloudList = new List<IGameObject>();
            mario = Mario;
            game = Game;
            gameOverDisplayPanel = new GameOverDisplayPanel(game);
            titleDisplayPanel = new TitleDisplayPanel();
            marioLifeDisplayPanel = new MarioLifeDisplayPanel();
            headsUpDisplayPanel = new HeadsUpDisplayPanel();
            animationList = new List<IAnimationInGame>();
            winningDisplayPanel = new WinningDisplayPanel(game);

        }

        public IDisplayPanel TitlePanel
        {
            get
            {
                return titleDisplayPanel;
            }
        }


        public void HandleCollisions()
        {
            HandleAllCollisions(mario, blockList, enemyList, itemList, pipeList);
        }

        public void Update()
        {

            bool updateHUD = true;

            if (true)
            {
                HandleCollisions();
                foreach (IGameObject obj in itemList)
                {
                    obj.Update();
                }
                foreach (IGameObject obj in blockList)
                {
                    obj.Update();
                }
                foreach (IGameObject obj in enemyList)
                {
                    if (IsInView(obj))
                    {
                        obj.Update();
                    }                    
                }
                foreach (IGameObject obj in pipeList)
                {
                    obj.Update();
                }
                foreach (IGameObject obj in objectList)
                {
                    obj.Update();
                }
                foreach (IAnimationInGame obj in animationList)
                {
                    obj.Update();
                }
                if (mario.Location.Y < 400)
                {
                    Camera.Move(mario);
                }
                
            }

            mario.Update();
            CheckAndStartSinglePlayerEndGame();
            if (updateHUD)
            {
                titleDisplayPanel.Update();
                gameOverDisplayPanel.Update();
                marioLifeDisplayPanel.Update();
                headsUpDisplayPanel.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IGameObject obj in objectList)
            {
                obj.Draw(spriteBatch);
            }
            foreach (IGameObject obj in itemList)
            {
                obj.Draw(spriteBatch);
            }
            foreach (IGameObject obj in blockList)
            {
                obj.Draw(spriteBatch);
            }
            foreach (IGameObject obj in enemyList)
            {               
                obj.Draw(spriteBatch);
            }
            foreach(IGameObject obj in pipeList)
            {
                obj.Draw(spriteBatch);
            }
            foreach (IAnimationInGame obj in animationList)
            {
                if (obj.State == AnimationState.IsPlaying)
                    obj.Draw(spriteBatch);
            }

            mario.Draw(spriteBatch);

            titleDisplayPanel.Draw(spriteBatch);
            gameOverDisplayPanel.Draw(spriteBatch);
            marioLifeDisplayPanel.Draw(spriteBatch);
            headsUpDisplayPanel.Draw(spriteBatch);
            winningDisplayPanel.Draw(spriteBatch);
        }

        private void CheckAndStartSinglePlayerEndGame()
        {
            if (!isLevelComplete)
            {
                if (IsEndGame())
                {
                    Game1.State.Proceed();
                    MarioInfo.StopTimer();
                    isLevelComplete = true;
                    ScoringSystem.AddPointsForPole(mario.Destination);
                    IItem flag_ = null;
                   foreach (IGameObject obj in itemList)
                   {
                        if (obj.GetType() == typeof(Flag))
                            flag_ = (IItem)obj;
                   }
                   victoryAnimation = new VictoryAnimation(mario, flag_);
                   victoryAnimation.State = AnimationState.IsPlaying;
                }
            }
            else
            {
                victoryAnimation.Update();
            }
        }
        private bool IsEndGame()
        {
            return mario.Destination.X + mario.Destination.Width >= 3265&&
                   mario.Destination.X + mario.Destination.Width <= 3290;
        }

        private static bool GamePlayable()
        {
            return Game1.State.Type == GameStates.Playing ||
                Game1.State.Type == GameStates.GameComplete;
        }

        private static bool IsInView(IGameObject obj)
        {
            return (obj.Location.X >= Camera.CameraX - BufferSize) &&
                (obj.Location.X <= Camera.CameraX + 2 * Camera.CenterOfScreen) &&
                (obj.Location.Y <= 480);
        }

        public void AddAnimation(IAnimationInGame animation)
        {
            animationList.Add(animation);
        }

    }   
}
 