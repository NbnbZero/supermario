using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;

namespace SuperMario.States.EnemyStates
{
    public class GoombaDeadState : IEnemyState
    {
        public Sprite StateSprite { get; set; }

        public GoombaDeadState()
        {
            StateSprite = EnemySpriteFactory.Instance.CreateDeadGoombaSprite(StateSprite.Location);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            StateSprite.Draw(spriteBatch, location);
        }

        public void Terminate()
        {       
        }

        public void Update()
        {
        }
    }
}
