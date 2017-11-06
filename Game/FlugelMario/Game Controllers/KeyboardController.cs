using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using SuperMario.States.MarioStates;
using SuperMario.Interfaces;
using SuperMario.Commands.ControllerCommand;
namespace SuperMario.Game_Controllers
{
    class KeyboardControls
    {
        private IMario mario;
        private Game1 mygame;
        private Dictionary<Keys, ICommand> commandDict = new Dictionary<Keys, ICommand>();
        private Dictionary<Keys, ICommand> releasedCommandDict = new Dictionary<Keys, ICommand>();
        private Keys[] preKeys = new Keys[0];

        public KeyboardControls()
        {
        }

        public void RegisterCommand()
        {
            commandDict.Add(Keys.Left, new LeftMarioCommand(mario));
            commandDict.Add(Keys.Right, new RightMarioCommand(mario));
            commandDict.Add(Keys.Down, new MarioCrouchCommand(mario));
            commandDict.Add(Keys.Up, new MarioJumpCommand(mario));
            commandDict.Add(Keys.Q, new QuitGameCommand(mygame));


            releasedCommandDict.Add(Keys.Left, new ReleasedLeftMarioCommand(mario));
            releasedCommandDict.Add(Keys.Right, new ReleasedRightMarioCommand(mario));
            releasedCommandDict.Add(Keys.Down, new ReleasedCrouchMarioCommand(mario));
            releasedCommandDict.Add(Keys.Up, new ReleasedJumpMarioCommand(mario));
            

            /*
            controllerMappings.Add(Keys.P , HandlePauseOrResume);
            controllerMappings.Add(Keys.R, HandlePauseOrResume);
            controllerMappings.Add(Keys.Left, HandleLeft);
            controllerMappings.Add(Keys.Right, HandleRight);
            controllerMappings.Add(Keys.Up, HandleAscend);
            controllerMappings.Add(Keys.Down,HandleDown);
            controllerMappings.Add(Keys.Y, MakeSmall);
            controllerMappings.Add(Keys.U, MakeBig);
            controllerMappings.Add(Keys.I, MakeFire);
            controllerMappings.Add(Keys.O, MakeDead);
            controllerMappings.Add(Keys.B, BumpUp);
            controllerMappings.Add(Keys.X, ChangeToUsed);            
            controllerMappings.Add(Keys.Z, HandleJump);*/
            //controllerMappings.Add(Keys )
        }


        public void Update()
        {
            if (mario == null || commandDict.LongCount() == 0)
            {
                return;
            }

            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            if (Left(pressedKeys))
            {
                commandDict[Keys.Left].Execute();
            }
            else if (Right(pressedKeys))
            {
                commandDict[Keys.Right].Execute();
            }
            else if (Jump(pressedKeys))
            {
                commandDict[Keys.Up].Execute();
            }
            else if (Down(pressedKeys))
            {
                commandDict[Keys.Down].Execute();
            }
            else if (LeftJump(pressedKeys))
            {
                if (mario.IsInAir)
                {
                    commandDict[Keys.Left].Execute();
                }
                else
                {
                    commandDict[Keys.Up].Execute();
                }

            }
            else if (LeftDown(pressedKeys))
            {
                commandDict[Keys.Down].Execute();
            }
            else if (RightJump(pressedKeys))
            {
                if (mario.IsInAir)
                {
                    commandDict[Keys.Right].Execute();
                }
                else
                {
                    commandDict[Keys.Up].Execute();
                }
            }
            else if (RightDown(pressedKeys))
            {
                commandDict[Keys.Down].Execute();
            }
            else if (LeftRightJump(pressedKeys))
            {
                commandDict[Keys.Up].Execute();
            }


            if (preKeys != null)
            {
                foreach (Keys key in pressedKeys)
                {
                    if (preKeys.Contains(key) && Keyboard.GetState().IsKeyUp(key))
                    {
                        releasedCommandDict[key].Execute();
                    }                        
                }
            }

            preKeys = pressedKeys;
        }

        private bool Left(Keys[] pressedKeys)
        {
            return pressedKeys.Contains(Keys.Left) &&
                !pressedKeys.Contains(Keys.Up) &&
                !pressedKeys.Contains(Keys.Right) &&
                !pressedKeys.Contains(Keys.Down);
        }
        private bool Right(Keys[] pressedKeys)
        {
            return !pressedKeys.Contains(Keys.Left) &&
                !pressedKeys.Contains(Keys.Up) &&
                pressedKeys.Contains(Keys.Right) &&
                !pressedKeys.Contains(Keys.Down);
        }
        private bool Jump(Keys[] pressedKeys)
        {
            return !pressedKeys.Contains(Keys.Left) &&
                pressedKeys.Contains(Keys.Up) &&
                !pressedKeys.Contains(Keys.Right) &&
                !pressedKeys.Contains(Keys.Down);
        }
        private bool Down(Keys[] pressedKeys)
        {
            return !pressedKeys.Contains(Keys.Left) &&
                !pressedKeys.Contains(Keys.Up) &&
                !pressedKeys.Contains(Keys.Right) &&
                pressedKeys.Contains(Keys.Down);
        }

        private bool LeftJump(Keys[] pressedKeys)
        {
            return pressedKeys.Contains(Keys.Left) &&
                pressedKeys.Contains(Keys.Up) &&
                !pressedKeys.Contains(Keys.Right) &&
                !pressedKeys.Contains(Keys.Down);
        }
        private bool LeftDown(Keys[] pressedKeys)
        {
            return pressedKeys.Contains(Keys.Left) &&
                !pressedKeys.Contains(Keys.Up) &&
                !pressedKeys.Contains(Keys.Right) &&
                 pressedKeys.Contains(Keys.Down);
        }
        private bool RightJump(Keys[] pressedKeys)
        {
            return !pressedKeys.Contains(Keys.Left) &&
                pressedKeys.Contains(Keys.Up) &&
                pressedKeys.Contains(Keys.Right) &&
                !pressedKeys.Contains(Keys.Down);
        }
        private bool RightDown(Keys[] pressedKeys)
        {
            return !pressedKeys.Contains(Keys.Left) &&
                !pressedKeys.Contains(Keys.Up) &&
                pressedKeys.Contains(Keys.Right) &&
                pressedKeys.Contains(Keys.Down);
        }

        private bool LeftRightJump(Keys[] pressedKeys)
        {
            return pressedKeys.Contains(Keys.Left) &&
                pressedKeys.Contains(Keys.Up) &&
                pressedKeys.Contains(Keys.Right) &&
                !pressedKeys.Contains(Keys.Down);
        }
    }
}

