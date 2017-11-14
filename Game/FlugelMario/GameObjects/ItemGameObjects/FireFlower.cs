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
    public class FireFlower : IItem
    {
        public ISprite sprite;
        public Vector2 Location { get; set; }
        private Vector2 initialLocation;

        public Rectangle Destination { get; set; }

        public ObjectType Type { get; } = ObjectType.FireFlower;

        public bool IsCollected { get; set; } = false;
        public bool IsPreparing { get; set; } = true;
        public Vector2 Velocity { get; set; }
        public FireFlower(Vector2 location)
        {
            sprite = ItemSpriteFactory.Instance.CreateFlowerSprite();
            Location = location;
            initialLocation = location;
            Destination = sprite.MakeDestinationRectangle(Location);
            Velocity = new Vector2(0, -0.5f);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Location);
        }

        public void Collect()
        {
            sprite = (ISprite)ItemSpriteFactory.Instance.CreateDisappearedSprite();
            SoundManager.Instance.PlayPowerUpSound();
            IsCollected = true;
            ScoringSystem.AddPointsForCollectingPwrUp(this);
        }

        public void Update()
        {
            if (IsPreparing)
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
            throw new System.NotImplementedException();
        }
    }
}

