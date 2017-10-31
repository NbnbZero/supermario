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
        bool revealed;
        public bool Hidden;
        int counter = 0;

        public ItemSprite(Texture2D texture, Vector2 location, bool hidden) : base(texture, location)
        {
            Hidden = hidden;
            revealed = false;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (revealed && counter < Height)
            {
                Location = new Vector2(Location.X, Location.Y - 1);
                counter++;
            }
            base.Draw(spriteBatch, location);
        }

        public override void Update(Viewport viewport, Vector2 marioLocation)
        {
            base.Update(viewport, marioLocation);
        }

        public void Reveal()
        {
            revealed = true;
        }
    }
}
