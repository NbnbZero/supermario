using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Sprites
{
    public class Text : IText
    {
        public string text { get; set; }

        public Texture2D Texture { get; set; } = null;

        private SpriteFont font;
        private Vector2 size;

        public Text(SpriteFont font)
        {
            this.font = font;
            this.size = new Vector2(0, 0);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.DrawString(font, text, location, Color.White);
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            size = font.MeasureString(text);
            return new Rectangle((int)location.X, (int)location.Y, (int)size.X, (int)size.Y);
        }

        public void Update()
        {
            size = font.MeasureString(text);
        }
    }
}
