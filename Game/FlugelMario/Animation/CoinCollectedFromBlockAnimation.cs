using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using SuperMario.Enums;
using SuperMario.GameObjects;

namespace SuperMario.Animation
{
    public class CoinCollectedFromBlockAnimation : IAnimationInGame
    {
        public Vector2 Location { get { return location; } set { } }

        public AnimationState State { get; set; }

        public Vector2 Velocity { get { return new Vector2(0, velocityY); } set { } }

        private Vector2 location;
        private float velocityY;
        private float accelerationY;
        private float endLocationY;
        private ISprite coinSprite;
        public CoinCollectedFromBlockAnimation(Vector2 location)
        {
            this.coinSprite = ItemSpriteFactory.Instance.CreateCoinSprite();
            this.State = AnimationState.ToBegin; 
            Rectangle spriteDestination = coinSprite.MakeDestinationRectangle(location);
            int halfOfDestinationHeight = spriteDestination.Height / 2;
            this.endLocationY = location.Y - halfOfDestinationHeight;
            this.location = new Vector2(location.X, endLocationY);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            coinSprite.Draw(spriteBatch, Location);
        }

        public void Update()
        {
            if (State == AnimationState.IsPlaying)
            {
                velocityY = velocityY + accelerationY;
                location.Y = location.Y + velocityY;
                if (location.Y > endLocationY)
                {
                    State = AnimationState.Stopped;
                }
            }
            coinSprite.Update();
        }
        public void StartAnimation()
        {
            State = AnimationState.IsPlaying;
            GameData.GameObjectManager.AddAnimation(this);
            accelerationY = 0.1f;
            velocityY = -1.5f;
        }
    }
}
