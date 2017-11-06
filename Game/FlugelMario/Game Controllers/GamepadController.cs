using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using SuperMario.Interfaces;
using SuperMario.Commands.ControllerCommand;
using System.Linq;

namespace SuperMario.Game_Controllers
{
    class GamePadControls
    {
        private Dictionary<Buttons, ICommand> commandDict = new Dictionary<Buttons, ICommand>();
        private Dictionary<Buttons, ICommand> releasedCommandDict = new Dictionary<Buttons, ICommand>();
        private Buttons[] preKeys = new Buttons[0];
        private IMario mario;
        private Game1 mygame;
        public GamePadControls()
        {
        }

        public void RegisterCommand()
        {
            commandDict.Add(Buttons.DPadLeft, new LeftMarioCommand(mario));
            commandDict.Add(Buttons.DPadRight, new RightMarioCommand(mario));
            commandDict.Add(Buttons.DPadDown, new MarioCrouchCommand(mario));
            commandDict.Add(Buttons.DPadUp, new MarioJumpCommand(mario));
            commandDict.Add(Buttons.Back, new QuitGameCommand(mygame));


            releasedCommandDict.Add(Buttons.DPadLeft, new ReleasedLeftMarioCommand(mario));
            releasedCommandDict.Add(Buttons.DPadRight, new ReleasedRightMarioCommand(mario));
            releasedCommandDict.Add(Buttons.DPadDown, new ReleasedCrouchMarioCommand(mario));
            releasedCommandDict.Add(Buttons.DPadUp, new ReleasedJumpMarioCommand(mario));
        }

        public void Update()
        {
            if (mario == null || commandDict.LongCount() == 0)
            {
                return;
            }

            List<Buttons> tempList = new List<Buttons>();

            if (GamePad.GetState(0).DPad.Left == ButtonState.Pressed)
            {
                tempList.Add(Buttons.DPadLeft);
            }
            if (GamePad.GetState(0).DPad.Right == ButtonState.Pressed)
            {
                tempList.Add(Buttons.DPadRight);
            }
            if (GamePad.GetState(0).DPad.Up == ButtonState.Pressed)
            {
                tempList.Add(Buttons.DPadUp);
            }
            if (GamePad.GetState(0).DPad.Down == ButtonState.Pressed)
            {
                tempList.Add(Buttons.DPadDown);
            }

            Buttons[] pressedKeys = new Buttons[tempList.LongCount()];
            for (int i = 0; i < pressedKeys.LongCount(); i++)
            {
                pressedKeys[i] = tempList[i];
            }

            if (Left(pressedKeys))
            {
                commandDict[Buttons.DPadLeft].Execute();
            }
            else if (Right(pressedKeys))
            {
                commandDict[Buttons.DPadRight].Execute();
            }
            else if (Jump(pressedKeys))
            {
                commandDict[Buttons.DPadUp].Execute();
            }
            else if (Down(pressedKeys))
            {
                commandDict[Buttons.DPadDown].Execute();
            }
            else if (LeftJump(pressedKeys))
            {
                if (mario.IsInAir)
                {
                    commandDict[Buttons.DPadLeft].Execute();
                }
                else
                {
                    commandDict[Buttons.DPadUp].Execute();
                }

            }
            else if (LeftDown(pressedKeys))
            {
                commandDict[Buttons.DPadDown].Execute();
            }
            else if (RightJump(pressedKeys))
            {
                if (mario.IsInAir)
                {
                    commandDict[Buttons.DPadRight].Execute();
                }
                else
                {
                    commandDict[Buttons.DPadUp].Execute();
                }
            }
            else if (RightDown(pressedKeys))
            {
                commandDict[Buttons.DPadDown].Execute();
            }
            else if (LeftRightJump(pressedKeys))
            {
                commandDict[Buttons.DPadUp].Execute();
            }


            if (preKeys != null)
            {
                foreach (Buttons key in pressedKeys)
                {
                    if (preKeys.Contains(key) && GamePad.GetState(0).IsButtonUp(key))
                    {
                        releasedCommandDict[key].Execute();
                    }
                }
            }

            preKeys = pressedKeys;
        }

        private bool Left(Buttons[] pressedKeys)
        {
            return pressedKeys.Contains(Buttons.DPadLeft) &&
                !pressedKeys.Contains(Buttons.DPadRight) &&
                !pressedKeys.Contains(Buttons.DPadUp) &&
                !pressedKeys.Contains(Buttons.DPadDown);
        }
        private bool Right(Buttons[] pressedKeys)
        {
            return !pressedKeys.Contains(Buttons.DPadLeft) &&
                !pressedKeys.Contains(Buttons.DPadUp) &&
                pressedKeys.Contains(Buttons.DPadRight) &&
                !pressedKeys.Contains(Buttons.DPadDown);
        }
        private bool Jump(Buttons[] pressedKeys)
        {
            return !pressedKeys.Contains(Buttons.DPadLeft) &&
                 !pressedKeys.Contains(Buttons.DPadRight) &&
                 pressedKeys.Contains(Buttons.DPadUp) &&
                 !pressedKeys.Contains(Buttons.DPadDown);
        }
        private bool Down(Buttons[] pressedKeys)
        {
            return !pressedKeys.Contains(Buttons.DPadLeft) &&
                !pressedKeys.Contains(Buttons.DPadRight) &&
                !pressedKeys.Contains(Buttons.DPadUp) &&
                pressedKeys.Contains(Buttons.DPadDown);
        }

        private bool LeftJump(Buttons[] pressedKeys)
        {
            return pressedKeys.Contains(Buttons.DPadLeft) &&
                !pressedKeys.Contains(Buttons.DPadRight) &&
                pressedKeys.Contains(Buttons.DPadUp) &&
                !pressedKeys.Contains(Buttons.DPadDown);
        }
        private bool LeftDown(Buttons[] pressedKeys)
        {
            return pressedKeys.Contains(Buttons.DPadLeft) &&
                !pressedKeys.Contains(Buttons.DPadRight) &&
                !pressedKeys.Contains(Buttons.DPadUp) &&
                pressedKeys.Contains(Buttons.DPadDown);
        }
        private bool RightJump(Buttons[] pressedKeys)
        {
            return !pressedKeys.Contains(Buttons.DPadLeft) &&
                pressedKeys.Contains(Buttons.DPadRight) &&
                pressedKeys.Contains(Buttons.DPadUp) &&
                !pressedKeys.Contains(Buttons.DPadDown);
        }
        private bool RightDown(Buttons[] pressedKeys)
        {
            return !pressedKeys.Contains(Buttons.DPadLeft) &&
                 pressedKeys.Contains(Buttons.DPadRight) &&
                 !pressedKeys.Contains(Buttons.DPadUp) &&
                 pressedKeys.Contains(Buttons.DPadDown);
        }

        private bool LeftRightJump(Buttons[] pressedKeys)
        {
            return pressedKeys.Contains(Buttons.DPadLeft) &&
                pressedKeys.Contains(Buttons.DPadRight) &&
                pressedKeys.Contains(Buttons.DPadUp) &&
                !pressedKeys.Contains(Buttons.DPadDown);
        }

    }
}