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
using SuperMario.GameObjects.PipeGameObjects;
using SuperMarioGameObjects;
using SuperMario.SCsystem;

namespace SuperMario
{
    public class LevelLoader
    {
        private GameObjectManager objectMagager;
        private MarioObject mario;
        public LevelLoader(GameObjectManager gameManager, MarioObject Mario)
        {
            objectMagager = gameManager;
            mario = Mario;
        }

        public void Load(string file)
        {
            LoadBlocks(file);
            LoadEnemies(file);
            LoadItems(file);
            LoadPipe(file);
            LoadObject(file);
        }


        public void LoadBlocks(string file)
        {
            List<BlockData> myObjects = new List<BlockData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<BlockData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create(file))
            {
                myObjects = (List<BlockData>)serializer.Deserialize(reader);
            }
            #region Floor
            if (file == "./LevelLoader/Level1.xml")
            {
                for (int i = 0; i < 1200; i += 16)
                {
                    GameObjectManager.blockList.Add(new FloorBlock(new Vector2(i, 400)));
                }
                for (int i = 1250; i < 1500; i += 16)
                {
                    GameObjectManager.blockList.Add(new FloorBlock(new Vector2(i, 400)));
                }
                for (int i = 1550; i < 2300; i += 16)
                {
                    GameObjectManager.blockList.Add(new FloorBlock(new Vector2(i, 400)));
                }
                for (int i = 2350; i < 3700; i += 16)
                {
                    GameObjectManager.blockList.Add(new FloorBlock(new Vector2(i, 400)));
                }
                for (int i = 620; i < 1390; i += 16)
                {
                    GameObjectManager.blockList.Add(new BrickBlock(new Vector2(i, 642)));
                }
                for (int i = 800; i < 1100; i += 16)
                {
                    GameObjectManager.blockList.Add(new BrickBlock(new Vector2(i, 626)));
                    GameObjectManager.blockList.Add(new BrickBlock(new Vector2(i, 610)));
                    GameObjectManager.blockList.Add(new BrickBlock(new Vector2(i, 594)));
                }
            }
            else if (file == "./LevelLoader/Level2.xml")
            {
                for (int i = -32; i < 1500; i += 16)
                {
                    GameObjectManager.blockList.Add(new UnderwaterBlock(new Vector2(i, 400)));
                }
                for (int i = 1650; i < 2500; i += 16)
                {
                    GameObjectManager.blockList.Add(new UnderwaterBlock(new Vector2(i, 400)));
                }
                for (int i = 2700; i < 3600; i += 16)
                {
                    GameObjectManager.blockList.Add(new UnderwaterBlock(new Vector2(i, 400)));
                }
                for (int i = 562; i < 1500; i += 16)
                {
                    GameObjectManager.blockList.Add(new FloorBlock(new Vector2(i, 820)));
                }
            }
                #endregion
            foreach (BlockData block in myObjects)
                {                                           
                    switch (block.State)
                        {
                            case BlockType.Brick:
                                if (block.itemType == ItemType.Coin)
                                {
                                    GameObjectManager.blockList.Add(new CoinBrickBlock(new Vector2(block.xLocation, block.yLocation)));
                                }
                                else
                                {
                                    GameObjectManager.blockList.Add(new BrickBlock(new Vector2(block.xLocation, block.yLocation)));
                                }
                                break;
                            case BlockType.Stair:
                                GameObjectManager.blockList.Add(new StairBlock(new Vector2(block.xLocation, block.yLocation)));
                                break;
                            case BlockType.Broken:
                                GameObjectManager.blockList.Add(new FloorBlock(new Vector2(block.xLocation, block.yLocation)));
                                break;
                            case BlockType.Question:
                                QuestionBlock question = new QuestionBlock(new Vector2(block.xLocation, block.yLocation));
                                if (block.itemType == ItemType.Flower)
                                {
                                      question.hiddenItem = ItemType.Flower;
                                      GameObjectManager.blockList.Add(question);
                                }
                                else if (block.itemType == ItemType.Star)
                                {
                                    question.hiddenItem = ItemType.Star;
                                    GameObjectManager.blockList.Add(question);
                                }
                                else if (block.itemType == ItemType.UpMushroom)
                                {
                                    question.hiddenItem = ItemType.UpMushroom;
                                    GameObjectManager.blockList.Add(question);
                                }
                                else if (block.itemType == ItemType.SuperMushroom)
                                {
                                     question.hiddenItem = ItemType.SuperMushroom;
                                     GameObjectManager.blockList.Add(question);
                                }                                 
                                else if (block.itemType == ItemType.Coin)
                                {
                                    question.hiddenItem = ItemType.Coin;
                                    GameObjectManager.blockList.Add(question);
                                } 
                                break;
                            case BlockType.Hidden:
                                GameObjectManager.blockList.Add(new HiddenBlock(new Vector2(block.xLocation, block.yLocation)));
                                break;
                            case BlockType.UnderwaterBlock:
                                GameObjectManager.blockList.Add(new UnderwaterBlock(new Vector2(block.xLocation, block.yLocation)));
                                break;
                            case BlockType.SeaWeed:
                                GameObjectManager.blockList.Add(new SeaWeed(new Vector2(block.xLocation, block.yLocation)));
                                break;
                }
                }
            
        }


        public void LoadItems(string file)
        {
            List<ItemData> myObjects = new List<ItemData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<ItemData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create(file))
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
                        case ItemType.Flag:
                            GameObjectManager.itemList.Add(new Flag(new Vector2(item.xLocation, item.yLocation)));
                            break;
                        case ItemType.FlagTop:
                            GameObjectManager.itemList.Add(new FlagTop(new Vector2(item.xLocation, item.yLocation)));
                            break;
                        case ItemType.FlagPole:
                            ScoringSystem.RegisgerFlagPole(new FlagPole(new Vector2(item.xLocation, item.yLocation)));
                            GameObjectManager.itemList.Add(new FlagPole(new Vector2(item.xLocation, item.yLocation)));
                            break;
                        case ItemType.PiranhaPlants:
                            GameObjectManager.itemList.Add(new PiranhaPlants(new Vector2(item.xLocation, item.yLocation), mario));
                            break;
                }

                }
            
        }

        public void LoadEnemies(string file)
        {
            List<EnemyData> myObjects = new List<EnemyData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<EnemyData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create(file))
            {
                myObjects = (List<EnemyData>)serializer.Deserialize(reader);
            }
           
            foreach (EnemyData enemy in myObjects)
            {
                switch (enemy.enemyType)
                {
                    case EnemyType.Koopa:
                        GameObjectManager.enemyList.Add(new Koopa(new Vector2(enemy.xLocation, enemy.yLocation)));
                        break;
                    case EnemyType.Goomba:
                        GameObjectManager.enemyList.Add(new Goomba(new Vector2(enemy.xLocation, enemy.yLocation)));
                        break;
                    case EnemyType.Blooper:
                        GameObjectManager.enemyList.Add(new Blooper(new Vector2(enemy.xLocation, enemy.yLocation)));
                        break;
                    case EnemyType.CheapCheap:
                        GameObjectManager.enemyList.Add(new CheapCheap(new Vector2(enemy.xLocation, enemy.yLocation)));
                        break;
                }
            }
            
        }

        private void LoadPipe(string file)
        {
            List<PipeData> myObjects = new List<PipeData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<PipeData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create(file))
            {
                myObjects = (List<PipeData>)serializer.Deserialize(reader);
            }

            foreach (PipeData pipe in myObjects)
            {
                switch (pipe.PipeType)
                {
                    case PipeType.Pipe:
                        GameObjectManager.pipeList.Add(new Pipe(new Vector2(pipe.xLocation, pipe.yLocation)));
                        break;
                    case PipeType.MediumPipe:
                        GameObjectManager.pipeList.Add(new MediumPipe(new Vector2(pipe.xLocation, pipe.yLocation)));
                        break;
                    case PipeType.BigPipe:
                        GameObjectManager.pipeList.Add(new BigPipe(new Vector2(pipe.xLocation, pipe.yLocation),new Vector2(660,500)));
                        break;
                    case PipeType.LPipeBottom:
                        GameObjectManager.pipeList.Add(new LPipeBottom(new Vector2(pipe.xLocation, pipe.yLocation),new Vector2(2500,0)));
                        break;
                    case PipeType.LPipeTop:
                        GameObjectManager.pipeList.Add(new LPipeTop(new Vector2(pipe.xLocation, pipe.yLocation)));
                        break;
                }
            }
        }

        private void LoadObject(string file)
        {
            List<ObjectData> myObjects = new List<ObjectData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<ObjectData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create(file))
            {
                myObjects = (List<ObjectData>)serializer.Deserialize(reader);
            }
            if (file == "./LevelLoader/Level2.xml")
            {
                for (int i = -40; i < 3600; i += 14)
                {
                    GameObjectManager.objectList.Add(new Wave(new Vector2(i, 0)));
                }
            }

            foreach (ObjectData obj in myObjects)
            {
                switch (obj.BackgourndObj)
                {
                    case BackgroundObjType.Castle:
                        GameObjectManager.objectList.Add(new Castle(new Vector2(obj.xLocation, obj.yLocation)));
                        break;
                    case BackgroundObjType.BigHill:
                        GameObjectManager.objectList.Add(new BigHill(new Vector2(obj.xLocation, obj.yLocation)));
                        break;
                    case BackgroundObjType.BigCloud:
                        GameObjectManager.cloudList.Add(new BigCloud(new Vector2(obj.xLocation, obj.yLocation)));
                        break;
                    case BackgroundObjType.BigBush:
                        GameObjectManager.objectList.Add(new BigBush(new Vector2(obj.xLocation, obj.yLocation)));
                        break;
                    case BackgroundObjType.MediumCloud:
                        GameObjectManager.cloudList.Add(new MediumCloud(new Vector2(obj.xLocation, obj.yLocation)));
                        break;
                    case BackgroundObjType.MediumBush:
                        GameObjectManager.objectList.Add(new MediumBush(new Vector2(obj.xLocation, obj.yLocation)));
                        break;
                    case BackgroundObjType.SmallHill:
                        GameObjectManager.objectList.Add(new SmallHill(new Vector2(obj.xLocation, obj.yLocation)));
                        break;
                    case BackgroundObjType.SmallCloud:
                        GameObjectManager.cloudList.Add(new SmallCloud(new Vector2(obj.xLocation, obj.yLocation)));
                        break;
                    case BackgroundObjType.SmallBush:
                        GameObjectManager.objectList.Add(new SmallBush(new Vector2(obj.xLocation, obj.yLocation)));
                        break;
                    case BackgroundObjType.blackbackground:
                        GameObjectManager.objectList.Add(new BlackBackground(new Vector2(obj.xLocation, obj.yLocation)));
                        break;
                }
            }
        }
    }
}
