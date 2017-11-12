using SuperMario.GameObjects;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static SuperMario.GameObjects.GameObjectType;
using SuperMario.Sound;

namespace SuperMario
{
    public class Star : IItem
    {
        private ISprite sprite;
        public Vector2 Location { get; set; }
        private Vector2 initialLocation;
        public Rectangle Destination { get; set; }

        public ObjectType Type { get; } = ObjectType.Star;

        public bool IsCollected { get; set; } = false;
        public bool IsPreparing { get; set; } = true;
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }

        public Star(Vector2 location)
        {
            sprite = ItemSpriteFactory.Instance.CreateStarSprite();
            Location = location;
            initialLocation = location;
            Destination = sprite.MakeDestinationRectangle(Location);
            Velocity = new Vector2(0, -0.5f);
            Acceleration = new Vector2(0, 0);
        }
        public void Collect()
        {
            sprite = (ISprite)ItemSpriteFactory.Instance.CreateDisappearedSprite();
            IsCollected = true;
            SoundManager.Instance.PlayPowerUpSound();
            SoundManager.Instance.PlayStarSong();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.Location);
        }

        public void Update()
        {
            if (IsPreparing)
            {
                Location = new Vector2(Location.X, Location.Y + Velocity.Y);
                Destination = sprite.MakeDestinationRectangle(Location);
                if (Location.Y <= initialLocation.Y - this.Destination.Height)
                {
                    this.Velocity = new Vector2(3, 0);
                    this.Acceleration = new Vector2(0, GameData.Gravity);
                    IsPreparing = false;
                }
                return;
            }

            if (Velocity.Y < 3)
            {
                this.Velocity = new Vector2(this.Velocity.X, this.Velocity.Y + this.Acceleration.Y);
            }
            this.Location = new Vector2(this.Location.X + this.Velocity.X, this.Location.Y + this.Velocity.Y);
            Destination = sprite.MakeDestinationRectangle(Location);
            sprite.Update();
        }

        public void ChangeDirection()
        {
            Velocity = new Vector2(-Velocity.X, Velocity.Y);
        }
    }
}
