using SuperMario.Interfaces;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using SuperMario.Enums;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using TileDefinition;
using SuperMario.GameObjects;
using System;
using SuperMario.GameObjects.ItemGameObjects;

namespace SuperMario
{
    public class LevelLoader
    {
        private GameObjectManager objectMagager;
        public LevelLoader(GameObjectManager gameManager)
        {
            objectMagager = gameManager;            
        }

        public void Load()
        {
            //LoadMarioStart();
            LoadBlocks();
            LoadEnemies();
            LoadItems();
            LoadPipe();
        }

        /*public void LoadMarioStart()
        {   
            List<StartData> myObjects = new List<StartData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<StartData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create("Level.xml"))
            {
                myObjects = (List<StartData>)serializer.Deserialize(reader);
            }
            foreach (StartData marioStart in myObjects)
            {
                objectMagager.Add(new MarioObject(new Vector2(marioStart.xLocation, marioStart.yLocation)));
            }
        }*/


        public void LoadBlocks()
        {
            List<BlockData> myObjects = new List<BlockData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<BlockData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create("../../../../LevelLoader/Level.xml"))
            {
                myObjects = (List<BlockData>)serializer.Deserialize(reader);
            }
                    
                foreach (BlockData block in myObjects)
                {                                           
                //add Floor & Used block object
                switch (block.State)
                        {
                            case BlockType.Brick:
                                GameObjectManager.blockList.Add(new BrickBlock(new Vector2(block.xLocation, block.yLocation)));
                                break;
                            case BlockType.Stair:
                                GameObjectManager.blockList.Add(new StairBlock(new Vector2(block.xLocation, block.yLocation)));
                            break;
                            case BlockType.Floor:
                                GameObjectManager.blockList.Add(new FloorBlock(new Vector2(block.xLocation, block.yLocation)));
                                break;
                            case BlockType.Question:
                                                if (block.itemType == ItemType.Flower)
                                                {
                                                    GameObjectManager.itemList.Add(new FireFlower(new Vector2(block.xLocation, block.yLocation)));
                                                }
                                                else if (block.itemType == ItemType.Star)
                                                {
                                                    GameObjectManager.itemList.Add(new Star(new Vector2(block.xLocation, block.yLocation)));
                                                }
                                                else if (block.itemType == ItemType.UpMushroom)
                                                {
                                                    GameObjectManager.itemList.Add(new UpMushroom(new Vector2(block.xLocation, block.yLocation)));
                                                }
                                                else if (block.itemType == ItemType.SuperMushroom)
                                                {
                                                    GameObjectManager.itemList.Add(new SuperMushroom(new Vector2(block.xLocation, block.yLocation)));
                                                }
                                                GameObjectManager.blockList.Add(new QuestionBlock(new Vector2(block.xLocation, block.yLocation)));
                                                break;
                        }
                }
            
        }


        public void LoadItems()
        {
            List<ItemData> myObjects = new List<ItemData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<ItemData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create("../../../../LevelLoader/Level.xml"))
            {
                myObjects = (List<ItemData>)serializer.Deserialize(reader);
            }

                foreach (ItemData item in myObjects)
                {
                    switch (item.itemType)
                    {
                        case ItemType.Coin:
                            GameObjectManager.itemList.Add(new Coin(new Vector2(item.xLocation, item.yLocation)));
                            break;
                        case ItemType.Flower:
                            GameObjectManager.itemList.Add(new FireFlower(new Vector2(item.xLocation, item.yLocation)));
                            break;
                        case ItemType.SuperMushroom:
                            GameObjectManager.itemList.Add(new SuperMushroom(new Vector2(item.xLocation, item.yLocation)));
                            break;
                        case ItemType.UpMushroom:
                            GameObjectManager.itemList.Add(new UpMushroom(new Vector2(item.xLocation, item.yLocation)));
                            break;
                        case ItemType.Star:
                            GameObjectManager.itemList.Add(new Star(new Vector2(item.xLocation, item.yLocation)));
                            break;
                    }

                }
            
        }

        public void LoadEnemies()
        {
            List<EnemyData> myObjects = new List<EnemyData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<EnemyData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create("../../../../LevelLoader/Level.xml"))
            {
                myObjects = (List<EnemyData>)serializer.Deserialize(reader);
            }

            
                foreach (EnemyData enemy in myObjects)
                {
                    switch (enemy.enemyType)
                    {
                        case EnemyType.Goomba:
                            GameObjectManager.enemyList.Add(new Goomba(new Vector2(enemy.xLocation, enemy.yLocation)));
                            break;
                        case EnemyType.Koopa:
                            GameObjectManager.enemyList.Add(new Koopa(new Vector2(enemy.xLocation, enemy.yLocation)));
                            break;
                    }
                }
            
        }

        private void LoadPipe()
        {
            List<PipeData> myObjects = new List<PipeData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<PipeData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create("../../../../LevelLoader/Level.xml"))
            {
                myObjects = (List<PipeData>)serializer.Deserialize(reader);
            }

            //TODO: add more cases
            foreach (PipeData pipe in myObjects)
            {
                switch (pipe.PipeType)
                {
                    case PipeType.Pipe:
                        System.Console.WriteLine("create pipe");
                        GameObjectManager.objectList.Add(new Pipe(new Vector2(pipe.xLocation, pipe.yLocation)));
                        break;
                }
            }
        }
    }
}
