using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMairo.Interfaces;
using SuperMairo.SpriteFactories;
using SuperMario.Enums;
using SuperMario.GameObjects;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Animation
{
    class ScoreTextAnimation : IAnimationInGame
    {
        public Vector2 Location { get { return location; } set { location = value; } }

        public AnimationState State { get; set; }

        public Vector2 Velocity { get { return new Vector2(0, veloY); } set { } }

        private const float YOffset = 15;
        private Vector2 location;
        private float veloY;
        private float accelY;
        private float endpointY;
        private float cameraXTextDistance;
        private IText textSprite;

        public ScoreTextAnimation(Vector2 location, string score)
        {
            this.textSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            this.textSprite.text = score;
            this.State = AnimationState.ToBegin;
            this.endpointY = location.Y - YOffset;
            this.location = location;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            textSprite.Draw(spriteBatch, location);
        }

        public void StartAnimation()
        {
            State = AnimationState.IsPlaying;
            GameData.GameObjectManager.AddAnimation(this);
            accelY = 0.005f;
            veloY = -1.5f;
            cameraXTextDistance = location.X - Camera.CameraX;
        }

        public void Update()
        {
            if (State == AnimationState.IsPlaying)
            {
                veloY = veloY + accelY;
                location.Y = location.Y + veloY;
                location.X = Camera.CameraX + cameraXTextDistance;
                if (location.Y < endpointY)
                {
                    State = AnimationState.Stopped;
                }
            }
            textSprite.Update();
        }
    }
}
