using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using static SuperMario.GameObjects.GameObjectType;

namespace SuperMario.GameObjects
{
    public class UnderwaterBlock: IBlock
    {
        private ISprite sprite;
        public ObjectType Type { get; } = ObjectType.Block;
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }

        public UnderwaterBlock(Vector2 location)
        {
            sprite = BlockSpriteFactory.Instance.CreateUnderwaterBlock();
            Location = location;
            Destination = sprite.MakeDestinationRectangle(Location);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location);
        }

        public void Trigger()
        {
        }

        public void Update()
        {
            Destination = sprite.MakeDestinationRectangle(Location);
            sprite.Update();
        }
    }
}
