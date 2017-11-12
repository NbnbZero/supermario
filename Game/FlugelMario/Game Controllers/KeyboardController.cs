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
using Microsoft.Xna.Framework.Audio;

namespace SuperMario.Game_Controllers
{
    public class KeyboardControls
    {
        private IMario mario;
        private Game1 mygame;
        private Dictionary<Keys, ICommand> commandDict = new Dictionary<Keys, ICommand>();
        private Dictionary<Keys, ICommand> releasedCommandDict = new Dictionary<Keys, ICommand>();
        private Keys[] preKeys = new Keys[0];
        private bool Muted = true;

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

                if ((pressedKeys.Contains(Keys.Q) && preKeys != null && !preKeys.Contains(Keys.Q)))
                {
                    commandDict[Keys.Q].Execute();
                }
                else if ((pressedKeys.Contains(Keys.P) && preKeys != null))
                {
                    Game1.State.Pause();
                    SoundManager.Instance.muteAndUnmute(Muted);
                    Muted = !Muted;
                }
                else if ((pressedKeys.Contains(Keys.M) && preKeys != null))
                {
                    SoundManager.Instance.muteAndUnmute(Muted);
                    Muted = !Muted;
                }
                else if ((pressedKeys.Contains(Keys.Y) && preKeys != null))
                {
                    commandDict[Keys.Y].Execute();
                }
                else if ((pressedKeys.Contains(Keys.U) && preKeys != null))
                {
                    commandDict[Keys.U].Execute();
                }
                else if ((pressedKeys.Contains(Keys.I) && preKeys != null))
                {
                    commandDict[Keys.I].Execute();
                }
                else if ((pressedKeys.Contains(Keys.O) && preKeys != null))
                {
                    commandDict[Keys.O].Execute();
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
                    mygame.Reset();
                    Game1.State = new PlayingState(mygame);
                    SoundManager.Instance.PlayOverWorldSong();
                    MarioAttributes.StartTimer();
                }
                else if ((pressedKeys.Contains(Keys.Q) && preKeys != null && !preKeys.Contains(Keys.Q)))
                {
                    commandDict[Keys.Q].Execute();
                }
            }
            else if (Game1.State.Type == GameStates.LifeDisplay)
            {
                if ((pressedKeys.Contains(Keys.Y) && preKeys != null && !preKeys.Contains(Keys.Y)))
                {
                    mygame.Reset();
                    Game1.State.Proceed();
                    SoundManager.Instance.PlayOverWorldSong();
                }
                else if ((pressedKeys.Contains(Keys.N) && preKeys != null && !preKeys.Contains(Keys.N)))
                {
                    Game1.State.Proceed();
                    Game1.State.GameOver();
                }
            }
            else if (Game1.State.Type == GameStates.Pause)
            {
                if ((pressedKeys.Contains(Keys.P) && preKeys != null))
                {
                    Game1.State.Proceed();
                    SoundManager.Instance.muteAndUnmute(Muted);
                    Muted = !Muted;
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

