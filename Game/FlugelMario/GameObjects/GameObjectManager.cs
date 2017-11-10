 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario;
using Microsoft.Xna.Framework.Graphics;
using static SuperMario.HandleAllCollison;

namespace SuperMario.GameObjects
{
    public class GameObjectManager
    {
        public static List<IGameObject> pipeList;
        public static List<IGameObject> blockList;
        public static List<IGameObject> itemList;
        public static List<IGameObject> enemyList;
        private MarioObject mario;

        public GameObjectManager(MarioObject Mario)
        {
            blockList = new List<IGameObject>();
            itemList = new List<IGameObject>();
            enemyList = new List<IGameObject>();
            pipeList = new List<IGameObject>();
            mario = Mario;
        }        

        public void HandleCollisions()
        {
            HandleAllCollisions(mario, blockList, enemyList, itemList, pipeList);
        }

        public void Update()
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
                obj.Update();
            }
            foreach (IGameObject obj in pipeList)
            {
                obj.Update();
            }

            mario.Update();

            Camera.Move(mario);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
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
            mario.Draw(spriteBatch);
        }


        

        

        




    }   
}
