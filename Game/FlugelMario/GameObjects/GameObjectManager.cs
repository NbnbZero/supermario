using System;
using System.Collections.Generic;
using System.Linq;E:\AU2017\CSE3902\mario\Game\FlugelMario\GameObjects\GameObjectManager.cs
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.GameObjects
{
    public class GameObjectManager
    {
        private List<IGameObject> objectList;
        private List<IGameObject> blockList;
        private List<IGameObject> itemList;
        private List<IGameObject> enemyList;
        public GameObjectManager()
        {
            blockList = new List<IGameObject>();
            itemList = new List<IGameObject>();
            enemyList = new List<IGameObject>();
            objectList = new List<IGameObject>();
        }
        
        public void Update()
        {
            foreach(IGameObject obj in objectList)
            {
                obj.Update();
            }
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
            foreach(IGameObject obj in objectList)
            {
                obj.Draw(spriteBatch);
            }
        }
        public void Add(IGameObject obj)
        {
            objectList.Add(obj);
        }


        

        

        




    }   
}
