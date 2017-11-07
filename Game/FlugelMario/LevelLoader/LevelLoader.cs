using SuperMario.Interfaces;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using SuperMario.Enums;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using TileDefinition;
using SuperMario.GameObjects;

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
            LoadBlocks();
            LoadEnemies();
            LoadItems();
            
        }
        public void LoadMarioStart()
        {
            List<StartData> myObjects = new List<StartData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<StartData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create("Level.xml"))
            {
                myObjects = (List<StartData>)serializer.Deserialize(reader);
            }         
            
        }
        public void LoadBlocks()
        {
            List<BlockData> myObjects = new List<BlockData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<BlockData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create("Level.xml"))
            {
                myObjects = (List<BlockData>)serializer.Deserialize(reader);
            }
            for (int i = 0; i < 1094; i = i + 16)
            {
                objectMagager.Add(new BrickBlock(new Vector2(i, 200)));
            }
           
            
                foreach (BlockData block in myObjects)
                {
                    switch (block.State)
                    {
                        case BlockType.Brick:
                            objectMagager.Add(new BrickBlock(new Vector2(block.xLocation, block.yLocation)));
                            break;
                        case BlockType.Stair:
                            objectMagager.Add(new StairBlock(new Vector2(block.xLocation, block.yLocation)));
                            break;
                        case BlockType.Question:
                            if (block.itemType == ItemType.Flower)
                            {
                                QuestionBlock FlowerBlock = new QuestionBlock(new Vector2(block.xLocation, block.yLocation));
                                objectMagager.Add(FlowerBlock);
                            }
                            else if (block.itemType == ItemType.Star)
                            {
                                QuestionBlock StarBlock = new QuestionBlock(new Vector2(block.xLocation, block.yLocation));
                                objectMagager.Add(StarBlock);
                            }
                            else if (block.itemType == ItemType.UpMushroom)
                            {
                                QuestionBlock UpMushroomBlock = new QuestionBlock(new Vector2(block.xLocation, block.yLocation));
                                objectMagager.Add(UpMushroomBlock);
                            }
                            else if (block.itemType == ItemType.SuperMushroom)
                            {
                                QuestionBlock SuperMushroomBlock = new QuestionBlock(new Vector2(block.xLocation, block.yLocation));
                                objectMagager.Add(SuperMushroomBlock);
                            }
                            break;
                        case BlockType.Floor:
                            objectMagager.Add(new BrickBlock(new Vector2(block.xLocation, block.yLocation)));
                            break;
                    }
                }
            
        }

        public void LoadItems()
        {
            List<ItemData> myObjects = new List<ItemData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<ItemData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create("Level.xml"))
            {
                myObjects = (List<ItemData>)serializer.Deserialize(reader);
            }

                foreach (ItemData item in myObjects)
                {
                    switch (item.itemType)
                    {
                        case ItemType.Coin:
                            objectMagager.Add(new Coin(new Vector2(item.xLocation, item.yLocation)));
                            break;
                        case ItemType.Flower:
                            objectMagager.Add(new FireFlower(new Vector2(item.xLocation, item.yLocation)));
                            break;
                        case ItemType.SuperMushroom:
                            objectMagager.Add(new SuperMushroom(new Vector2(item.xLocation, item.yLocation)));
                            break;
                        case ItemType.UpMushroom:
                            objectMagager.Add(new UpMushroom(new Vector2(item.xLocation, item.yLocation)));
                            break;
                        case ItemType.Star:
                            objectMagager.Add(new Star(new Vector2(item.xLocation, item.yLocation)));
                            break;
                    }

                }
            
        }

        public void LoadEnemies()
        {
            List<EnemyData> myObjects = new List<EnemyData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<EnemyData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create("Level.xml"))
            {
                myObjects = (List<EnemyData>)serializer.Deserialize(reader);
            }

            
                foreach (EnemyData enemy in myObjects)
                {
                    switch (enemy.enemyType)
                    {
                        case EnemyType.Goomba:
                            objectMagager.Add(new Goomba(new Vector2(enemy.xLocation, enemy.yLocation)));
                            break;
                        case EnemyType.Koopa:
                            objectMagager.Add(new Koopa(new Vector2(enemy.xLocation, enemy.yLocation)));
                            break;
                    }
                }
            
        }
    }
}
