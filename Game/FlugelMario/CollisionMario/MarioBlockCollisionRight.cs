using Microsoft.Xna.Framework;
using SuperMario.Enums;
using SuperMario.GameObjects;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public class MarioBlockCollisionRight : ICollisionCommand
    {
        public MarioBlockCollisionRight()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            if (mario.State.MarioShape == Shape.Dead)
            {
                return;
            }
            if (gameObject2.GetType() == typeof(HiddenBlock))
            {
                HiddenBlock hiddenBlock = (HiddenBlock)gameObject2;
                if (!hiddenBlock.Used) return;
            }

            
            int marioPreY = (int)(mario.Destination.Y - (mario.Velocity.Y - 1));

            if (marioPreY + mario.Destination.Height <= gameObject2.Destination.Y) //from right top
            {
                ICollisionCommand TopCommand = new MarioBlockCollisionTop();
                TopCommand.Execute(gameObject1, gameObject2);
                return;
            }
            else if(marioPreY >= gameObject2.Destination.Y + gameObject2.Destination.Height) //from right bot
            {
                ICollisionCommand BotCommand = new MarioBlockCollisionBottom();
                BotCommand.Execute(gameObject1, gameObject2);
                return;
            }
            mario.Location = new Vector2(gameObject2.Destination.X + gameObject2.Destination.Width + 1, mario.Destination.Y);
            if (mario.Velocity.X < 0)
            {
                mario.Velocity = new Vector2(0, mario.Velocity.Y);
            }
        }
    }
}
