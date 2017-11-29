using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.SpriteFactories
{
    internal class SeaWeedSprite : ISprite
    {
        private Texture2D seaWeedSpriteSheet;

        public SeaWeedSprite(Texture2D seaWeedSpriteSheet)
        {
            this.seaWeedSpriteSheet = seaWeedSpriteSheet;
        }
    }
}