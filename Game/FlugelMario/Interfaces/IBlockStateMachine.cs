using SuperMario.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Interfaces
{
    public interface IBlockStateMachine
    {
        bool Used { get; }
        void BeTriggered();
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        Rectangle MakeDestinationRectangle(Vector2 location);
    }
}
