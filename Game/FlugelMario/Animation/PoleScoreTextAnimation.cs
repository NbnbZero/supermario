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
        private float endLocationY;
        private float cameraXToTextDistance;
        private IText textSprite;
        private int locationXFix = 7;

        private float poleVelocity = -1;

        public PoleScoreTextAnimation(Rectangle marioDestination, Rectangle poleDestination, string score)
        {
            this.textSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            this.textSprite.text = score;
            this.State = AnimationState.NotStart;
            this.endLocationY = marioDestination.Y;
            float startingLocationY = poleDestination.Y + poleDestination.Height - textSprite.MakeDestinationRectangle(new Vector2(0,0)).Height;
            this.location = new Vector2(marioDestination.X + marioDestination.Width + locationXFix, startingLocationY);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            textSprite.Draw(spriteBatch, location);
        }

        public void StartAnimation()
        {
            State = AnimationState.IsPlaying;
            GameData.GameObjectManager.AddAnimation(this);
            cameraXToTextDistance = location.X - Camera.CameraX;
        }

        public void Update()
        {
            if (State == AnimationState.IsPlaying && location.Y >= endLocationY)
            {
                location.Y = location.Y + poleVelocity;
                location.X = Camera.CameraX + cameraXToTextDistance;
            }
            textSprite.Update();
        }
    }
}
