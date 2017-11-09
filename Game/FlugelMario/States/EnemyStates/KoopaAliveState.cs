using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario;
using SuperMario.SpriteFactories;

namespace SuperMario.States.EnemyStates
{
    public class KoopaAliveState : IEnemyState
    {
        public ISprite StateSprite { get; set; }
        private Koopa koopa;

        public KoopaAliveState(Koopa _koopa)
        {
            StateSprite = EnemySpriteFactory.Instance.CreateKoopaSprite();
            this.koopa = _koopa;
        }

        public void ChangeDirection()
        {
            koopa.State = new KoopaAliveRightState(koopa);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            StateSprite.Draw(spriteBatch, location);
        }

        public void Terminate(string direction)
        {
            if (direction.ToUpper().Equals("TOP"))
                koopa.State = new KoopaDeadState(koopa);
        }

        public void Update()
        {
            StateSprite.Update();
        }
    }
}
