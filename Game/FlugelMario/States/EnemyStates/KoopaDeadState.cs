using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario;
using FlugelMario.GameObjects.EnemyGameObjects;
using SuperMario.SpriteFactories;

namespace FlugelMario.States.EnemyStates
{
    public class KoopaDeadState : IEnemyState
    {
        public ISprite StateSprite { get; set; }
        private Koopa koopa;
        private int totalDuration = 200;
        private int duration;

        public KoopaDeadState(Koopa _koopa)
        {
            this.koopa = _koopa;
            StateSprite = EnemySpriteFactory.Instance.CreateDeadKoopaSprite();
            duration = totalDuration;
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
            if (koopa.Velocity.X != 0)
            {
                duration = totalDuration;
            }
            else
            {
                duration--;
            }

            if (duration == 0)
            {
                koopa.Velocity = new Vector2(-1, 0);
                koopa.State = new KoopaAliveState(koopa);
            }

            StateSprite.Update();
        }
    }
}
