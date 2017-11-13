using SuperMario.GameObjects;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static SuperMario.GameObjects.GameObjectType;
using SuperMario.Sound;
using SuperMairo.HeadsUp;
using System;

namespace SuperMario
{
    public class PiranhaPlants : IItem
    {
        public ISprite sprite;
        public Vector2 Location { get; set; }
        private Vector2 initialLocation;

        public Rectangle Destination { get; set; }

        public ObjectType Type { get; } = ObjectType.PiranhaPlants;

        public bool IsPreparing { get; set; } = true;
        public Vector2 Velocity { get; set; }
        public bool IsCollected { get; set; }
        private MarioObject mario;
        private bool adjectent = false;

        public PiranhaPlants(Vector2 location, MarioObject Mario)
        {
            sprite = ItemSpriteFactory.Instance.CreatePiranhaPlantsSprite();
            Location = location;
            initialLocation = location;
            Destination = sprite.MakeDestinationRectangle(Location);
            Velocity = new Vector2(0, -0.2f);
            mario = Mario;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location);
        }

        public void Collect()
        {
        }

        public void Update()
        {
            if (Math.Abs(Location.X - mario.Location.X) < 50)
            {
                Location = new Vector2(Location.X, Location.Y + 2);
                Destination = sprite.MakeDestinationRectangle(Location);
                if (Location.Y >= initialLocation.Y - Destination.Height + 2 * 1)
                {
                    Velocity = new Vector2(0, 0);
                }
                adjectent = true;
                IsPreparing = true;
                return;
            }

            if (Math.Abs(Location.X - mario.Location.X) > 50)
            {
                adjectent = false;
                Velocity = new Vector2(0, -0.2f);
            }

            if (IsPreparing && !adjectent)
            {
                Location = new Vector2(Location.X, Location.Y + Velocity.Y);
                Destination = sprite.MakeDestinationRectangle(Location);
                if (Location.Y <= initialLocation.Y - Destination.Height + 2 * 1)
                {
                    Velocity = new Vector2(0, 0);
                    IsPreparing = false;
                }
                return;
            }           

            Destination = sprite.MakeDestinationRectangle(Location);
            sprite.Update();
        }

        public void ChangeDirection()
        {
        }
    }
}


