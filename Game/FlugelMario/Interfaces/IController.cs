using Microsoft.Xna.Framework.Input;
using SuperMario.States.MarioStates;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.Sprites.Blocks;
using SuperMario.SpriteFactories;

namespace SuperMario
{
    public abstract class Controller
    {
        private Game1 game;
        
        private InputState _state;
        private MarioState marioState1;

        protected MarioState MarioState => marioState1;

        protected void SetMarioState(MarioState value)
        {
            marioState1 = value;
        }

        public Game1 Game { get => game; set => game = value; }
        protected InputState State { get => _state; set => _state = value; }

        protected Controller(MarioState state, Game1 game)
        {
            SetMarioState(state);
            Game = game;
        }

        public virtual InputState Update(KeyboardState keyboard)
        {
            return State;
        }

        public virtual InputState Update(GamePadState gamepad)
        {
            return State;
        }

        #region Direction Logic

        protected void HandleQuit(InputState state)
        {
            Game.Exit();
        }

        protected void HandlePauseOrResume(InputState state)
        {
            Game.Paused = !Game.Paused;
        }

        protected void HandleLeft(InputState state)
        {
            if (state == InputState.RunRight)
            {
                this.State = InputState.IdleRight;
                MarioState.BeIdle();
            }
            else if (state == InputState.IdleRight)
            {
                this.State = InputState.IdleLeft;
                MarioState.MarioDirection = Enums.Direction.Left;
                MarioState.BeIdle();
            }
            else
            {
                if (state != InputState.RunLeft)
                {
                    this.State = InputState.RunLeft;
                    MarioState.RunLeft();
                }
            }
        }

        protected void HandleRight(InputState state)
        {
            if (state == InputState.RunLeft)
            {
                this.State = InputState.IdleLeft;
                MarioState.BeIdle();
            }
            else if (state == InputState.IdleLeft)
            {
                this.State = InputState.IdleRight;
                MarioState.MarioDirection = Enums.Direction.Right;
                MarioState.BeIdle();
            }
            else
            {
                if (state != InputState.RunRight)
                {
                    this.State = InputState.RunRight;
                    MarioState.RunRight();
                }
            }
        }

        protected void HandleJump(InputState state)
        {
            if (state == InputState.Descend)
            {
                if (MarioState.MarioDirection == Direction.Left)
                {
                    this.State = InputState.IdleLeft;
                    MarioState.BeIdle();
                }
                else
                {
                    this.State = InputState.IdleRight;
                    MarioState.BeIdle();
                }
            }
            else
            {
                if (state != InputState.Ascend)
                {
                    this.State = InputState.Ascend;
                    MarioState.Jump();
                }
            }
        }

        protected void HandleDown(InputState state)
        {
            if (state == InputState.Ascend)
            {
                if (MarioState.MarioDirection == Direction.Left)
                {
                    this.State = InputState.IdleLeft;
                    MarioState.BeIdle();
                } else
                {
                    this.State = InputState.IdleRight;
                    MarioState.BeIdle();
                }
            } else
            {
                if (state != InputState.Descend)
                {
                    this.State = InputState.Descend;
                    MarioState.Descend();
                }
            }
        }


        #region Size Modifiers

        protected void MakeSmall(InputState state)
        {
            Transition.ChangeMario(InputState.MakeSmall, MarioState);
        }

        protected void MakeBig(InputState state)
        {
            Transition.ChangeMario(InputState.MakeBig, MarioState);
        }

        protected void MakeFire(InputState state)
        {
            Transition.ChangeMario(InputState.MakeFire, MarioState);
        }

        protected void MakeDead(InputState state)
        {
            Transition.ChangeMario(InputState.MakeDead, MarioState);
        }

        protected void BumpUp(InputState state)
        {
            foreach(Sprite sprite in Game.Sprites)
            {
                if (sprite.GetType() == typeof(BrickBlockSprite))
                    sprite.BumpUp();
            }
        }

        protected void ChangeToUsed(InputState state)
        {
            for(int i = 0; i < Game.Sprites.Count; i++)
            {
                if (Game.Sprites[i].GetType() == typeof(QuestionBlockSprite))
                    Game.Sprites[i] = BlockSpriteFactory.Instance.CreateUsedBlock(Game.Sprites[i].Location);
            }
        }

        #endregion

        protected void BeIdle()
        {
            MarioState.BeIdle();
        }

        #endregion
    }
}
