using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public interface ISprite
    {
        Texture2D Texture { get; set; }
        void Update();
        Rectangle MakeDestinationRectangle(Vector2 location);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
