using Microsoft.Xna.Framework;
using SuperMario.Enums;
using SuperMairo.SpriteFactories;
using Microsoft.Xna.Framework.Graphics;
using SuperMairo.Interfaces;
using SuperMario.Interfaces;

namespace SuperMario.Animation
{
    public class PoleScoreTextAnimation: IAnimationInGame
    {
        public Vector2 Location { get { return location; } set { location = value; } }

        public AnimationState State { get; set; }

        public Vector2 Velocity { get { return new Vector2(0, poleVelocity); } set { } }

        private Vector2 location;
        private float endpointY;
        private float cameraXTextDistance;
        private IText textSprite;

        private float poleVelocity = -1;

        public PoleScoreTextAnimation(Rectangle marioDestination, Rectangle poleDestination, string score)
        {
            this.textSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            this.textSprite.text = score;
            this.State = AnimationState.ToBegin;
            this.endpointY = marioDestination.Y;
            float startingLocationY = poleDestination.Y + poleDestination.Height - textSprite.MakeDestinationRectangle(new Vector2(0,0)).Height;
            this.location = new Vector2(marioDestination.X + marioDestination.Width + 7, startingLocationY);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            textSprite.Draw(spriteBatch, location);
        }

        public void StartAnimation()
        {
            State = AnimationState.IsPlaying;
            GameData.GameObjectManager.AddAnimation(this);
            cameraXTextDistance = location.X - Camera.CameraX;
        }

        public void Update()
        {
            if (State == AnimationState.IsPlaying && location.Y >= endpointY)
            {
                location.Y = location.Y + poleVelocity;
                location.X = Camera.CameraX + cameraXTextDistance;
                if (location.Y == endpointY)
                {
                    State = AnimationState.Stopped;
                }
            }
            textSprite.Update();
        }
    }
}
