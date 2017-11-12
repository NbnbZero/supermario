using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using SuperMario.States.MarioStates;
using SuperMario.Interfaces;
using SuperMario.Commands.ControllerCommand;
using SuperMairo.Interfaces;
using SuperMairo.States.GameState;
using SuperMairo.Commands;
using SuperMario.Sound;

namespace SuperMario.Game_Controllers
{
    public class KeyboardControls
    {
        private IMario mario;
        private Game1 mygame;
        private Dictionary<Keys, ICommand> commandDict = new Dictionary<Keys, ICommand>();
        private Dictionary<Keys, ICommand> releasedCommandDict = new Dictionary<Keys, ICommand>();
        private Keys[] preKeys = new Keys[0];

        public KeyboardControls(Game1 game, IMario Mario)
        {
            mygame = game;
            mario = Mario;
            RegisterCommand();
        }

        public void RegisterCommand()
        {
            commandDict.Add(Keys.Left, new LeftMarioCommand(mario));
            commandDict.Add(Keys.Right, new RightMarioCommand(mario));
            commandDict.Add(Keys.Down, new MarioCrouchCommand(mario));
            commandDict.Add(Keys.Up, new MarioJumpCommand(mario));

            commandDict.Add(Keys.Q, new QuitGameCommand(mygame));
            commandDict.Add(Keys.P, new PauseCommand(mygame));

            commandDict.Add(Keys.Y, new ChangeSmallState(mario));
            commandDict.Add(Keys.U, new ChangeBigState(mario));
            commandDict.Add(Keys.I, new ChangeFireState(mario));
            commandDict.Add(Keys.O, new ChangeDeadState(mario));




            releasedCommandDict.Add(Keys.Left, new ReleasedLeftMarioCommand(mario));
            releasedCommandDict.Add(Keys.Right, new ReleasedRightMarioCommand(mario));
            releasedCommandDict.Add(Keys.Down, new ReleasedCrouchMarioCommand(mario));
            releasedCommandDict.Add(Keys.Up, new ReleasedJumpMarioCommand(mario));
            
        }


        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            if ((Game1.State.Type == GameStates.Playing))
            {
                //cheat Keys
                foreach (Keys key in pressedKeys)
                {
                    switch (key)
                    {
                        case Keys.Q:
                            commandDict[key].Execute();
                            break;
                        case Keys.P:
                            commandDict[key].Execute();
                            break;
                        case Keys.Y:
                            commandDict[key].Execute();
                            break;
                        case Keys.U:
                            commandDict[key].Execute();
                            break;
                        case Keys.I:
                            commandDict[key].Execute();
                            break;
                        case Keys.O:
                            commandDict[key].Execute();
                            break;
                    }
                }

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
                    foreach (Keys key in preKeys)
                    {

                        if (preKeys.Contains(key) && Keyboard.GetState().IsKeyUp(key))
                        {
                            if (releasedCommandDict.ContainsKey(key))
                                releasedCommandDict[key].Execute();
                        }
                    }
                }
                preKeys = pressedKeys;
            }
            else if (Game1.State.Type == GameStates.Title)
            { 
                if ((pressedKeys.Contains(Keys.Enter) && preKeys != null && !preKeys.Contains(Keys.Enter)))
                {
                    Game1.State = new PlayingState(mygame);
                    SoundManager.Instance.PlayOverWorldSong();
                }
                else if ((pressedKeys.Contains(Keys.Q) && preKeys != null && !preKeys.Contains(Keys.Q)))
                {
                    commandDict[Keys.Q].Execute();
                }
            }
            else if (Game1.State.Type == GameStates.Pause)
            {
                if ((pressedKeys.Contains(Keys.P)))
                {
                    commandDict[Keys.P].Execute();
                }
            }

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

