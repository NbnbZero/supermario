using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;

namespace SuperMario.States.EnemyStates
{
    public class GoombaDeadState : IEnemyState
    {
        public ISprite StateSprite { get; set; }
        private int count = 0;

        public GoombaDeadState()
        {
            StateSprite = EnemySpriteFactory.Instance.CreateDeadGoombaSprite();
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
                StateSprite = ItemSpriteFactory.Instance.CreateDisappearedSprite() ;
        }
        public void ChangeDirection()
        {
        }
    }
}
