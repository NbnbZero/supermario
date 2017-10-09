using SuperMario.GameObjects;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
    public class RedMushroom : IItem
    {
        private Sprite sprite;
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }

        public GameObjectType.ObjectType Type { get; } = GameObjectType.ObjectType.RedMushroom;

        public bool IsCollected { get; set; } = false;


        public RedMushroom(Vector2 location)
        {
            sprite = ItemSpriteFactory.Instance.CreateSuperMushroomSprite(location);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.Location);
        }

        public void Collect()
        {
            sprite = ItemSpriteFactory.Instance.CreateDisappearedSprite();
            IsCollected = true;
        }

        public void Update()
        {
        }
    }
}

