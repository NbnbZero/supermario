using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperMario.SpriteFactories;
using static SuperMario.GameObjects.GameObjectType;

namespace SuperMario.GameObjects
{
    public class SeaWeed:IBlock
    {
        private ISprite sprite;
        public ObjectType Type { get; } = ObjectType.Block;
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }

        public SeaWeed(Vector2 location)
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
