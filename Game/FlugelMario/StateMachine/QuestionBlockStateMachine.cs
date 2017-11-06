using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace SuperMario.StateMachine
{
    public class QuestionmarkBlockStateMachine : IBlockStateMachine
    {
        private ISprite sprite;
        private bool used;
        public bool Used { get { return used; } }

        public QuestionmarkBlockStateMachine()
        {
            this.sprite = BlockSpriteFactory.Instance.CreateQuestionBlock();
            used = false;
        }

        public void BeTriggered()
        {
            if (used == false)
            {
                this.sprite = BlockSpriteFactory.Instance.CreateUsedBlock();
                used = true;
            }
        }

        public void Update()
        {
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return sprite.MakeDestinationRectangle(location);
        }
    }
}
