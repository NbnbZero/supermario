using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.StateMachine
{
    class CoinBrickBlockStateMachine:IBlockStateMachine
    {
        private ISprite sprite;
        private bool used;
        public bool Used { get { return used; } }

        public CoinBrickBlockStateMachine()
        {
            this.sprite = BlockSpriteFactory.Instance.CreateBrickBlock();
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
