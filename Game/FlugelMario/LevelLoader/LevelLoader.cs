using SuperMario.Interfaces;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using SuperMario.Enums;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using TileDefinition;
using SuperMario.States.MarioStates;

namespace SuperMario
{
    public static class LevelLoader
    {
        public static MarioState LoadLevel(List<Sprite> sprites)
        {
            var marioState = LoadMarioStart();
            LoadBlocks(sprites);
            LoadItems(sprites);
            LoadEnemies(sprites);

            return marioState;
        }
        public static MarioState LoadMarioStart()
        {
            List<StartData> myObjects = new List<StartData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<StartData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create("Level.xml"))
            {
                myObjects = (List<StartData>)serializer.Deserialize(reader);
            }
            return new MarioState(new Vector2(myObjects[0].xLocation, myObjects[0].yLocation), myObjects[0].xMax, myObjects[0].yMax);
        }
        public static void LoadBlocks(List<Sprite> sprites)
        {
            List<BlockData> myObjects = new List<BlockData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<BlockData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create("Level1.xml"))
            {
                myObjects = (List<BlockData>)serializer.Deserialize(reader);
            }
            for (int i = 0; i < 1094; i = i + 16)
            {
                sprites.Add(BlockSpriteFactory.Instance.CreateRockBlock(new Vector2(i,400)));
                sprites.Add(BlockSpriteFactory.Instance.CreateRockBlock(new Vector2(i, 416)));
            }
           
            if (sprites != null)
            {
                foreach (BlockData block in myObjects)
                {
                    switch (block.State)
                    {
                        case BlockType.Brick:
                            sprites.Add(BlockSpriteFactory.Instance.CreateBrickBlock(new Vector2(block.xLocation, block.yLocation), ItemSpriteFactory.Instance.MakeHiddenSprite(block.itemType, new Vector2(block.xLocation, block.yLocation))));
                            break;
                        case BlockType.Stair:
                            sprites.Add(BlockSpriteFactory.Instance.CreateStairBlock(new Vector2(block.xLocation, block.yLocation)));
                            break;
                        case BlockType.Used:
                            sprites.Add(BlockSpriteFactory.Instance.CreateUsedBlock(new Vector2(block.xLocation, block.yLocation), null));
                            break;
                        case BlockType.Question:
                            sprites.Add(BlockSpriteFactory.Instance.CreateQuestionBlock(new Vector2(block.xLocation, block.yLocation), ItemSpriteFactory.Instance.MakeHiddenSprite(block.itemType, new Vector2(block.xLocation, block.yLocation))));
                            break;
                        case BlockType.Floor:
                            sprites.Add(BlockSpriteFactory.Instance.CreateRockBlock(new Vector2(block.xLocation, block.yLocation)));
                            break;
                    }
                }
            }
        }

        public static void LoadItems(List<Sprite> sprites)
        {
            List<ItemData> myObjects = new List<ItemData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<ItemData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create("Level1.xml"))
            {
                myObjects = (List<ItemData>)serializer.Deserialize(reader);
            }

            if (sprites != null)
            {
                foreach (ItemData item in myObjects)
                {
                    switch (item.itemType)
                    {
                        case ItemType.Coin:
                            sprites.Add(ItemSpriteFactory.Instance.CreateCoinSprite(new Vector2(item.xLocation, item.yLocation), false));
                            break;
                        case ItemType.Flower:
                            sprites.Add(ItemSpriteFactory.Instance.CreateFlowerSprite(new Vector2(item.xLocation, item.yLocation), false));
                            break;
                        case ItemType.SuperMushroom:
                            sprites.Add(ItemSpriteFactory.Instance.CreateSuperMushroomSprite(new Vector2(item.xLocation, item.yLocation), false));
                            break;
                        case ItemType.UpMushroom:
                            sprites.Add(ItemSpriteFactory.Instance.CreateUpMushroomSprite(new Vector2(item.xLocation, item.yLocation), false));
                            break;
                        case ItemType.Star:
                            sprites.Add(ItemSpriteFactory.Instance.CreateStarSprite(new Vector2(item.xLocation, item.yLocation), false));
                            break;
                    }

                }
            }
        }

        public static void LoadEnemies(List<Sprite> sprites)
        {
            List<EnemyData> myObjects = new List<EnemyData>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<EnemyData>), new XmlRootAttribute("Map"));
            using (XmlReader reader = XmlReader.Create("Level1.xml"))
            {
                myObjects = (List<EnemyData>)serializer.Deserialize(reader);
            }

            if (sprites != null)
            {
                foreach (EnemyData enemy in myObjects)
                {
                    switch (enemy.enemyType)
                    {
                        case EnemyType.Goomba:
                            sprites.Add(EnemySpriteFactory.Instance.CreateGoombaSprite(new Vector2(enemy.xLocation, enemy.yLocation)));
                            break;
                        case EnemyType.Koopa:
                            sprites.Add(EnemySpriteFactory.Instance.CreateKoopaSprite(new Vector2(enemy.xLocation, enemy.yLocation)));
                            break;
                    }
                }
            }
        }
    }
}
