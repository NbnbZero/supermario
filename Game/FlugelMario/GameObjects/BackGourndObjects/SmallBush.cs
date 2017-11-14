using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario;
using SuperMario.GameObjects;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioGameObjects
{
    public class SmallBush : IGameObject
    {
        private ISprite sprite;
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }
        public GameObjectType.ObjectType Type { get; } = GameObjectType.ObjectType.SmallBush;
        public SmallBush(Vector2 location)
        {
            sprite = BackgroundSpriteFactory.Instance.CreateSmallBushSprite();
            Location = location;
            Destination = sprite.MakeDestinationRectangle(Location);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.Location);
        }
        public void Update()
        {
            Destination = sprite.MakeDestinationRectangle(Location);
            sprite.Update();
        }
    }
}
