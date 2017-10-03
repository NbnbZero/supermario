using SuperMario.AbstractClasses;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Enums;
using SuperMario.Sprites.Mario;
using Microsoft.Xna.Framework.Input;

namespace SuperMario.States.MarioStates
{
    public class MarioState : IMarioState
    {
        public ISprite StateSprite { get; set; }
        public Posture MarioPosture { get; set; }
        public Direction MarioDirection { get; set; }
        public Shape MarioShape { get; set; }

        public MarioState()
        {
            StateSprite = MarioSpriteFactory.Instance.CreateIdleRightSmallMarioSprite();
            MarioPosture = Posture.Stand;
            MarioDirection = Direction.Right;
        }

        public void RunLeft()
        {
            if (MarioShape == Shape.Small)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateRunningLeftSmallMarioSprite();
            }
            else if (MarioShape == Shape.Big)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateRunningLeftBigMarioSprite();
            }
            else if (MarioShape == Shape.Fire)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateRunningLeftFireMarioSprite();
            }
            else if (MarioShape == Shape.Dead)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite();
            }


            MarioDirection = Direction.Left;
        }

        public void RunRight()
        {
            if (MarioShape == Shape.Small)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateRunningRightSmallMarioSprite();
            }
            else if (MarioShape == Shape.Big)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateRunningRightBigMarioSprite();
            }
            else if (MarioShape == Shape.Fire)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateRunningRightFireMarioSprite();
            }
            else if (MarioShape == Shape.Dead)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite();
            } 


            MarioDirection = Direction.Right;
        }

        public void BeIdle()
        {
            if (MarioShape == Shape.Small)
            {
                if (MarioDirection == Direction.Right)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleRightSmallMarioSprite();
                }
                else
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftSmallMarioSprite();
                }
            }
            else if (MarioShape == Shape.Big)
            {
                if (MarioDirection == Direction.Right)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleRightBigMarioSprite();
                }
                else
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftBigMarioSprite();
                }
            }
            else if (MarioShape == Shape.Fire)
            {
                if (MarioDirection == Direction.Right)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleRightFireMarioSprite();
                }
                else
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftFireMarioSprite();
                }
            }
            else if (MarioShape == Shape.Dead)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite();
            }

        }

        public void BeIdle(InputState state)
        {
            if (state == InputState.IdleLeft)
            {
                if (MarioShape == Shape.Small)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftSmallMarioSprite();
                }
                else if (MarioShape == Shape.Big)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftBigMarioSprite();
                }
                else if (MarioShape == Shape.Fire)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftFireMarioSprite();
                }
                else if (MarioShape == Shape.Dead)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite();
                }
                MarioDirection = Direction.Left;
            }
            else
            {
                if (MarioShape == Shape.Small)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleRightSmallMarioSprite();
                }
                else if (MarioShape == Shape.Big)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleRightBigMarioSprite();
                }
                else if (MarioShape == Shape.Fire)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateIdleRightFireMarioSprite();
                }
                else if (MarioShape == Shape.Dead)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite();
                }
                MarioDirection = Direction.Right;
            }
        }

        public void Crouch()
        {
            if (MarioDirection == Direction.Right && MarioShape == Shape.Big)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateCrouchRightBigMarioSprite();
            }
            else if(MarioDirection == Direction.Left && MarioShape == Shape.Big)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateCrouchLeftBigMarioSprite();
            }
            else if (MarioDirection == Direction.Right && MarioShape == Shape.Fire)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateCrouchRightFireMarioSprite();
            }
            else if (MarioDirection == Direction.Left && MarioShape == Shape.Fire)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateCrouchLeftFireMarioSprite();
            }
        }

        public void Jump()
        {
            if (MarioDirection == Direction.Right)
            {            
                if (MarioShape == Shape.Small)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateJumpRightSmallMarioSprite();
                }
                else if (MarioShape == Shape.Big)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateJumpRightBigMarioSprite();
                }
                else if (MarioShape == Shape.Fire)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateJumpRightFireMarioSprite();
                }
                else if (MarioShape == Shape.Dead)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite();
                }
            }
            else
            {
                if (MarioShape == Shape.Small)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateJumpLeftSmallMarioSprite();
                }
                else if (MarioShape == Shape.Big)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateJumpLeftBigMarioSprite();
                }
                else if (MarioShape == Shape.Fire)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateJumpLeftFireMarioSprite();
                }
                else if (MarioShape == Shape.Dead)
                {
                    StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite();
                }
            }
        }

        public void ChangeFireMode()
        {
            MarioShape = Shape.Fire;
            if (MarioDirection == Direction.Right)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateIdleRightFireMarioSprite();
            } else
            {
                StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftFireMarioSprite();
            }
        }

        public void ChangeSizeToBig()
        {
            MarioShape = Shape.Big;
            if (MarioDirection == Direction.Right)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateIdleRightBigMarioSprite();
            }
            else
            {
                StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftBigMarioSprite();
            }
        }

        public void Terminated()
        {
            MarioShape = Shape.Dead;
            StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite();
        }

        public void ChangeSizeToSmall()
        {
            MarioShape = Shape.Small;
            if (MarioDirection == Direction.Right)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateIdleRightSmallMarioSprite();
            }
            else
            {
                StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftSmallMarioSprite();
            }
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            throw new System.NotImplementedException();
        }

        public void JumpOrStand()
        {
            throw new System.NotImplementedException();
        }
    }
}
