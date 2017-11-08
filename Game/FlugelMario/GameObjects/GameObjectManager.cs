using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.GameObjects
{
    public class GameObjectManager
    {
        public static List<IGameObject> objectList;
        public static List<IGameObject> blockList;
        public static List<IGameObject> itemList;
        public static List<IGameObject> enemyList;
        private MarioObject mario;
        public GameObjectManager(MarioObject Mario)
        {
            blockList = new List<IGameObject>();
            itemList = new List<IGameObject>();
            enemyList = new List<IGameObject>();
            objectList = new List<IGameObject>();
            mario = Mario;
        }
        

        public void HandleCollisions()
        {
            CollisionHandler myhandler = new CollisionHandler(mario);
            foreach(IGameObject obj in blockList) {
                myhandler.HandleBlockCollision(obj);
            }  
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
            mario.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IGameObject obj in itemList)
            {

                obj.Draw(spriteBatch);
            }
            foreach (IGameObject obj in blockList)
            {
                System.Console.WriteLine(obj.GetType().ToString());
                obj.Draw(spriteBatch);
            }
            foreach (IGameObject obj in enemyList)
            {               
                obj.Draw(spriteBatch);
            }
            foreach(IGameObject obj in objectList)
            {
                obj.Draw(spriteBatch);
            }
            mario.Draw(spriteBatch);
        }


        

        

        




    }   
}
