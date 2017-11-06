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

        public HUD()
        {

        }

        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("Score");
        }

        public void Draw(SpriteBatch spriteBatch, MarioState marioState, Camera camera, int timeLeft)
        {
            spriteBatch.DrawString(font, "Current Player: Mario", new Vector2(camera.Position.X, camera.Position.Y), Color.Black);
            spriteBatch.DrawString(font, "Points:" + marioState.Points.ToString(), new Vector2(camera.Position.X, camera.Position.Y + 15), Color.Black);
            spriteBatch.DrawString(font, "Coins Collected:" + marioState.Coins.ToString(), new Vector2(camera.Position.X, camera.Position.Y + 30), Color.Black);
            spriteBatch.DrawString(font, "Lives Remaining:" + marioState.Lives.ToString(), new Vector2(camera.Position.X, camera.Position.Y + 45), Color.Black);
            spriteBatch.DrawString(font, "Time Left:" + timeLeft.ToString(), new Vector2(camera.Position.X, camera.Position.Y + 60), Color.Black);
        }
    }
}
