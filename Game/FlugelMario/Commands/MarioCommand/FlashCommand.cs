using Microsoft.Xna.Framework;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.Sound;
using SuperMario.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Commands
{
    class FlashCommand : ICommand
    {
        IMario mario;
        public FlashCommand(IMario Mario)
        {
            mario = Mario;
        }
        public void Execute()
        {
            if (mario.Flashable && mario.State.MarioShape==Shape.Fire)
            {
                SoundManager.Instance.PlayFlashSound();
                if (mario.State.MarioDirection == Direction.Right)
                {
                    mario.IsProtected = true;
                    mario.Location = new Vector2(mario.Destination.X + 50, mario.Destination.Y);
                    mario.Flashable = false;
                }
                else if (mario.State.MarioDirection == Direction.Left)
                {
                    mario.IsProtected = true;
                    mario.Location = new Vector2(mario.Destination.X - 50, mario.Destination.Y);
                    mario.Flashable = false;
                }  
            }
        }
    }
}