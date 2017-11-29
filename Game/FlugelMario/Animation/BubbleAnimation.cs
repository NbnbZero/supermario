using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Animation
{
    class BubbleAnimation : IAnimationInGame
    {
        public Vector2 Location { get { return location; } set { location = value; } }

        public AnimationState State { get; set; }

        public Vector2 Velocity { get { return new Vector2(0, veloY); } set { } }

        private Vector2 location;
        private float veloY;
        private float accelY;
        private float endpointY;
        private IText textSprite;

        public BubbleAnimation(Vector2 location, string bubble)
        {
            this.textSprite = TextSpriteFactory.Instance.CreateNormalFontTextSpriteSprite();
            this.textSprite.text = bubble;
            this.State = AnimationState.ToBegin;
            this.endpointY = 50;
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
            veloY = -1.5f;
        }

        public void Update()
        {
            if (State == AnimationState.IsPlaying)
            {
                veloY = veloY + accelY;
                location.Y = location.Y + veloY;
                if (location.Y < endpointY)
                {
                    State = AnimationState.Stopped;
                }
            }
            textSprite.Update();
        }
    }
}
