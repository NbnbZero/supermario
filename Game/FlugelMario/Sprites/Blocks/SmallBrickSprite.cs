using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using FlugelMario;

namespace SuperMario.Sprites.Block
{
    class SmallBrickSprite : Sprite
    {

        private Rectangle sourceRectangle;
        private Rectangle ltDestRect;
        private Rectangle rtDestRect;
        private Rectangle lbDestRect;
        private Rectangle rbDestRect;
        private Color color;
        private float horiSpeed = 2f;
        private float vertSpeed = -5;
        private float vertAcce = 0.5f; 

        private int width;
        private int height;

        private bool isInitial = true;
        private int counter = 100;

        public SmallBrickSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {
            this.Texture = texture;
            width = Texture.Width;
            height = Texture.Height;
            this.color = Color.White;
            sourceRectangle = new Rectangle(0, 0, width, height);
        }

        public SmallBrickSprite(Texture2D texture, bool underground,Vector2 location) : base(texture, location)
        {
            this.Texture = texture;
            width = Texture.Width;
            height = Texture.Height;
            this.color = Color.DeepSkyBlue;
            sourceRectangle = new Rectangle(0, 0, width, height);
            underground.ToString();
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (isInitial)
            {
                ltDestRect = new Rectangle((int)location.X, (int)location.Y, width, height);
                rtDestRect = new Rectangle((int)location.X + width, (int)location.Y, width, height);
                lbDestRect = new Rectangle((int)location.X, (int)location.Y + height, width, height);
                rbDestRect = new Rectangle((int)location.X + width, (int)location.Y + height, width, height);
                
                isInitial = false;
            }

            if (counter > 0)
            {
                spriteBatch.Draw(this.Texture, ltDestRect, sourceRectangle, color);
                spriteBatch.Draw(this.Texture, rtDestRect, sourceRectangle, color);
                spriteBatch.Draw(this.Texture, lbDestRect, sourceRectangle, color);
                spriteBatch.Draw(this.Texture, rbDestRect, sourceRectangle, color);
            }

        }

        public override void Update(Viewport viewport, Vector2 marioLocation)
        {
            
            if (isInitial)
            {
                return;
            }
            if(counter > 0)
            {
                ltDestRect.X = (int)(ltDestRect.X - horiSpeed);
                ltDestRect.Y = (int)(ltDestRect.Y + vertSpeed);

                rtDestRect.X = (int)(rtDestRect.X + horiSpeed);
                rtDestRect.Y = (int)(rtDestRect.Y + vertSpeed);

                lbDestRect.X = (int)(lbDestRect.X - horiSpeed);
                lbDestRect.Y = (int)(lbDestRect.Y + vertSpeed);

                rbDestRect.X = (int)(rbDestRect.X + horiSpeed);
                rbDestRect.Y = (int)(rbDestRect.Y + vertSpeed);
                vertSpeed += vertAcce;
                counter--;
            }
            
        }
    }
}
