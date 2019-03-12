using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario;
using SuperMario.Display;
using SuperMario.GameObjects;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using SuperMario.States.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public class Peach : IItem
    {
        private ISprite sprite;
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }
        public GameObjectType.ObjectType Type { get; } = GameObjectType.ObjectType.Peach;
        public Vector2 Velocity { get; set; }
        public bool IsCollected { get; set; } = false;
        public bool IsPreparing { get; set; }
        private Game1 mygame;

        public Peach(Vector2 location, Game1 game)
        {
            sprite = ItemSpriteFactory.Instance.CreatePeachSprite();
            Location = location;
            Destination = sprite.MakeDestinationRectangle(Location);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.Location);
        }
        public void Update()
        {
            if (IsCollected)
            {
                sprite = ItemSpriteFactory.Instance.CreateDisappearedSprite();
            }
        }

        public void Collect()
        {
        }

        public void ChangeDirection()
        {
        }
    }
}
