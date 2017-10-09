using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;

namespace SuperMario
{
    public abstract class BlockSprite : Sprite
    {
        protected BlockSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {

        }
    }
}
