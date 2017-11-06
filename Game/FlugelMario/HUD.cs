using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.States.MarioStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlugelMario
{
    public class HUD
    {
        SpriteFont font;
        public int maxTime;
        public int Points;
        public int Coins;
        public int Lives;

        public HUD()
        {
            maxTime = 400;
            Points = 0;
            Coins = 0;
            Lives = 3;
        }

        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("Score");
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera, int timeLeft)
        {
            spriteBatch.DrawString(font, "Current Player: Mario", new Vector2(camera.Position.X, camera.Position.Y), Color.Black);
            spriteBatch.DrawString(font, "Points:" + Points.ToString(), new Vector2(camera.Position.X, camera.Position.Y + 20), Color.Black);
            spriteBatch.DrawString(font, "Coins Collected:" + Coins.ToString(), new Vector2(camera.Position.X, camera.Position.Y + 40), Color.Black);
            spriteBatch.DrawString(font, "Lives Remaining:" + Lives.ToString(), new Vector2(camera.Position.X, camera.Position.Y + 60), Color.Black);
            spriteBatch.DrawString(font, "Time Left:" + (maxTime - timeLeft).ToString(), new Vector2(camera.Position.X, camera.Position.Y + 80), Color.Black);
        }
    }
}
