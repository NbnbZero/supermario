using SuperMario.GameObjects;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static SuperMario.GameObjects.GameObjectType;
using SuperMario.Sound;
using SuperMairo.HeadsUp;

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

        public PiranhaPlants(Vector2 location)
        {
            sprite = ItemSpriteFactory.Instance.CreatePiranhaPlantsSprite();
            Location = location;
            initialLocation = location;
            Destination = sprite.MakeDestinationRectangle(Location);
            Velocity = new Vector2(0, -0.2f);
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
            if (IsPreparing)
            {
                Location = new Vector2(Location.X, Location.Y + Velocity.Y);
                Destination = sprite.MakeDestinationRectangle(Location);
                if (Location.Y <= initialLocation.Y - Destination.Height + 2)
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


