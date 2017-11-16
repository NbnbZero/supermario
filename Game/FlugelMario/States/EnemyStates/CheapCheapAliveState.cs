using SuperMario.Interfaces;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario;
using SuperMario.SpriteFactories;
using SuperMario.States.EnemyStates;

namespace SuperMario.States.EnemyStates
{
    public class CheapCheapAliveState : IEnemyState
    {
        public ISprite StateSprite { get; set; }

        private CheapCheap cheapcheap;

        public CheapCheapAliveState(CheapCheap Cheapcheap)
        {
            StateSprite = EnemySpriteFactory.Instance.CreateCheapCheapSprite();
            this.cheapcheap = Cheapcheap;
        }

        public void ChangeDirection()
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            StateSprite.Draw(spriteBatch, location);
        }

        public void Terminate(string direction)
        {
        }

        public void Update()
        {
            StateSprite.Update();
        }
    }
}
