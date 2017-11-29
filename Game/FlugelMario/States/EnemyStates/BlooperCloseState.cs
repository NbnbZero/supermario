using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;

namespace SuperMario.States.EnemyStates
{
    public class BlooperCloseState : IEnemyState
    {
        public ISprite StateSprite { get; set; }
        private int count = 0;

        public BlooperCloseState()
        {
            StateSprite = EnemySpriteFactory.Instance.CreateBlooperCloseSprite();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            StateSprite.Draw(spriteBatch, location);
        }

        public void Terminate(String direction)
        {
        }

        public void Update()
        {
            count++;
            if (count > 60)
                StateSprite = EnemySpriteFactory.Instance.CreateBlooperCloseSprite();
        }
        public void ChangeDirection()
        {
        }
    }
}
