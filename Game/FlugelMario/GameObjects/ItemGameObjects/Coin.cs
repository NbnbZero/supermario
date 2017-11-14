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
    public class Coin : IItem
    {
        private ISprite sprite;
        public Vector2 Location { get; set; }
        public Vector2 Velocity { get; set; }

        public ObjectType Type { get; } = ObjectType.Coin;

        public Rectangle Destination { get; set; }

        public bool IsCollected { get; set; } = false;
        public bool IsPreparing { get; set; } = true;

        public Coin(Vector2 location)
        {
            sprite = ItemSpriteFactory.Instance.CreateCoinSprite();
            Location = location;
            Destination = sprite.MakeDestinationRectangle(Location);
        }

        public void Collect()
        {
            sprite = (ISprite)ItemSpriteFactory.Instance.CreateDisappearedSprite();
            IsCollected = true;
            SoundManager.Instance.PlayCoinSound();
            CoinSystem.Instance.AddCoin();
            ScoringSystem.AddPointsForCoin(this);
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
        public void ChangeDirection()
        {

        }
    }
}
