using SuperMario.GameObjects;
using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.SpriteFactories;

namespace SuperMario.States.EnemyStates
{
    public class GoombaAliveState : IEnemyState
    {
        public Sprite StateSprite { get; set; }

        private Goomba2 goomba;

        public GoombaAliveState(Goomba2 goomba)
        {
            StateSprite = EnemySpriteFactory.Instance.CreateGoombaSprite();
            this.goomba = goomba;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            StateSprite.Draw(spriteBatch, location);
        }

        public void Terminate()
        {
            goomba.State = new GoombaDeadState();
        }
        public void Update()
        {        
            StateSprite.Update();
        }
    }
}
