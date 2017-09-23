using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using FlugelMario.Interfaces;
using FlugelMario.AbstractClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlugelMario.States.MarioPowerUpState
{
    public class MarioPowerUp : IPowerUp
    {
        public MarioState.MarioShapeEnums MarioShape { get; set; }
        public IController KeyboadrController { get; set; }


        public void Update()
        {
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Y))
            {
                MarioShape = MarioState.MarioShapeEnums.Small;
            }
            else if (keyboard.IsKeyDown(Keys.U))
            {
                MarioShape = MarioState.MarioShapeEnums.Big;
            }
            else if (keyboard.IsKeyDown(Keys.O))
            {
                MarioShape = MarioState.MarioShapeEnums.Fire;
            }
            else if (keyboard.IsKeyDown(Keys.U))
            {
                MarioShape = MarioState.MarioShapeEnums.Dead;
            }
        }
    }
}
