using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Sprites.Items
{
    public abstract class ItemSprite : Sprite
    {
        bool revealed = false;
        int counter = 0;
        public ItemSprite(Texture2D texture, Vector2 location) : base(texture, location) { }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (revealed && counter < Height)
            {
                Location = new Vector2(Location.X, Location.Y + 1);
            }
            base.Draw(spriteBatch, location);
        }
        public void Reveal()
        {
            revealed = true;
        }
    }
}
