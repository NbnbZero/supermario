using SuperMario.GameObjects;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static SuperMario.GameObjects.GameObjectType;
using SuperMario.Sound;
using SuperMario.Heads_Up;

namespace SuperMario
{
    public class UpMushroom : IItem
    {
        private ISprite sprite;
        public Vector2 Location { get; set; }
        private Vector2 initialLocation;
        public ObjectType Type { get; } = ObjectType.UpMushroom;

        public Rectangle Destination { get; set; }

        public bool IsCollected { get; set; } = false;
        public bool IsPreparing { get; set; } = true;
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }

        public UpMushroom(Vector2 location)
        {
            sprite = ItemSpriteFactory.Instance.CreateUpMushroomSprite();

            this.Location = location;
            initialLocation = location;
            Destination = sprite.MakeDestinationRectangle(Location);
            Velocity = new Vector2(0, -0.5f);
            Acceleration = new Vector2(0, 0);
        }

        public void Collect()
        {
            sprite = (ISprite)ItemSpriteFactory.Instance.CreateDisappearedSprite();
            IsCollected = true;
            MarioInfo.MarioLife[0]++;
            SoundManager.Instance.Play1UpSound();
            ScoringSystem.AddPointsForGMush(this);
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
                    Velocity = new Vector2(2, 0);
                    Acceleration = new Vector2(0, GameData.Gravity);
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
