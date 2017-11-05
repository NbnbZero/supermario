using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using SuperMario.States.MarioStates;
using SuperMario.Interfaces;
using SuperMario.Commands.ControllerCommand;
namespace SuperMario.Game_Controllers
{
    class KeyboardControls : Controller
    {
        private IMario mario;
        private Dictionary<Keys, Action<InputState>> controllerMappings;
        private Dictionary<Keys, ICommand> commandDict;
        private Dictionary<Keys, ICommand> releasedCommandDict;
        private Keys[] preKeys;

        public KeyboardControls(MarioState state, Game1 game) : base (state, game)
        {
            Game = game;
            controllerMappings = new Dictionary<Keys, Action<InputState>>();
            RegisterCommand();
            preKeys = new Keys[0];
        }

        public void RegisterCommand()
        {
            commandDict.Add(Keys.B, new MarioAccelerateCommand(mario));
            commandDict.Add(Keys.Left, new LeftMarioCommand(mario));
            commandDict.Add(Keys.Right, new RightMarioCommand(mario));
            commandDict.Add(Keys.Down, new MarioCrouchCommand(mario));
            commandDict.Add(Keys.Up, new MarioJumpCommand(mario));

            releasedCommandDict.Add(Keys.B, new ReleasedAcceMarioCommand(mario));
            releasedCommandDict.Add(Keys.Left, new ReleasedLeftMarioCommand(mario));
            releasedCommandDict.Add(Keys.Right, new ReleasedRightMarioCommand(mario));
            releasedCommandDict.Add(Keys.Down, new ReleasedCrouchMarioCommand(mario));
            releasedCommandDict.Add(Keys.Up, new ReleasedJumpMarioCommand(mario));
            controllerMappings.Add(Keys.Q, HandleQuit);
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

            /*if ((GameUtilities.Game.State.Type == Interfaces.GameStates.Playing ||
                GameUtilities.Game.State.Type == Interfaces.GameStates.Competitive) &&
                IsFunctionKeysEnable)*/
            
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
                    commandDict[Keys.A].Execute();
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
                        commandDict[Keys.A].Execute();
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
                        commandDict[Keys.A].Execute();
                    }
                }
                else if (RightDown(pressedKeys))
                {
                    commandDict[Keys.Down].Execute();
                }
                else if (LeftRightJump(pressedKeys))
                {
                    commandDict[Keys.A].Execute();
                }


                if (pressedKeys.Contains(Keys.B) && preKeys != null && !preKeys.Contains(Keys.B))
                {
                    commandDict[Keys.B].Execute();
                }

                if (preKeys != null)
                {
                    foreach (Keys key in pressedKeys)
                    {
                        releasedCommandDict[key].Execute();
                    }
                }

            preKeys = pressedKeys;
            /*else if (GameUtilities.Game.State.Type == Interfaces.GameStates.Title)
            {
                if (pressedKeys.Contains(commandDict[KeyboardKeys.A]) && preKeys != null && !preKeys.Contains(commandDict[KeyboardKeys.A]))
                {
                    commandDict[commandDict[KeyboardKeys.A]].Execute();
                }

                if (pressedKeys.Contains(commandDict[KeyboardKeys.Down]) && preKeys != null && !preKeys.Contains(commandDict[KeyboardKeys.Down]))
                {
                    commandDict[commandDict[KeyboardKeys.Down]].Execute();
                }
            }*/

            /*if (pressedKeys.Contains(commandDict[KeyboardKeys.Start]) && preKeys != null && !preKeys.Contains(commandDict[KeyboardKeys.Start]))
            {
                commandDict[commandDict[KeyboardKeys.Start]].Execute();
            }*/


        }
        private bool Left(Keys[] pressedKeys)
        {
            return pressedKeys.Contains(Keys.Left) &&
                !pressedKeys.Contains(Keys.A) &&
                !pressedKeys.Contains(Keys.Right) &&
                !pressedKeys.Contains(Keys.Down);
        }
        private bool Right(Keys[] pressedKeys)
        {
            return !pressedKeys.Contains(Keys.Left) &&
                !pressedKeys.Contains(Keys.A) &&
                pressedKeys.Contains(Keys.Right) &&
                !pressedKeys.Contains(Keys.Down);
        }
        private bool Jump(Keys[] pressedKeys)
        {
            return !pressedKeys.Contains(Keys.Left) &&
                pressedKeys.Contains(Keys.A) &&
                !pressedKeys.Contains(Keys.Right) &&
                !pressedKeys.Contains(Keys.Down);
        }
        private bool Down(Keys[] pressedKeys)
        {
            return !pressedKeys.Contains(Keys.Left) &&
                !pressedKeys.Contains(Keys.A) &&
                !pressedKeys.Contains(Keys.Right) &&
                pressedKeys.Contains(Keys.Down);
        }

        private bool LeftJump(Keys[] pressedKeys)
        {
            return pressedKeys.Contains(Keys.Left) &&
                pressedKeys.Contains(Keys.A) &&
                !pressedKeys.Contains(Keys.Right) &&
                !pressedKeys.Contains(Keys.Down);
        }
        private bool LeftDown(Keys[] pressedKeys)
        {
            return pressedKeys.Contains(Keys.Left) &&
                !pressedKeys.Contains(Keys.A) &&
                !pressedKeys.Contains(Keys.Right) &&
                 pressedKeys.Contains(Keys.Down);
        }
        private bool RightJump(Keys[] pressedKeys)
        {
            return !pressedKeys.Contains(Keys.Left) &&
                pressedKeys.Contains(Keys.A) &&
                pressedKeys.Contains(Keys.Right) &&
                !pressedKeys.Contains(Keys.Down);
        }
        private bool RightDown(Keys[] pressedKeys)
        {
            return !pressedKeys.Contains(Keys.Left) &&
                !pressedKeys.Contains(Keys.A) &&
                pressedKeys.Contains(Keys.Right) &&
                pressedKeys.Contains(Keys.Down);
        }

        private bool LeftRightJump(Keys[] pressedKeys)
        {
            return pressedKeys.Contains(Keys.Left) &&
                pressedKeys.Contains(Keys.A) &&
                pressedKeys.Contains(Keys.Right) &&
                !pressedKeys.Contains(Keys.Down);
        }
    }


    /*public void Update()
    {
        if (mario == null || commandDict.LongCount() == 0)
        {
            return;
        }


        if (!Game.Paused)
        {
            Keys[] keysPressed = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in keysPressed.Except(previousKeys))
            {
                if (controllerMappings.ContainsKey(key))
                {
                    controllerMappings[key](State);
                }
            }

            previousKeys = keysPressed;

        } else
        {
            if (Keyboard.GetState().GetPressedKeys().Contains(Keys.R))
            {
                HandlePauseOrResume(State);
            }
        }
    }*/
}

