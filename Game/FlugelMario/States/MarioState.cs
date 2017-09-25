using FlugelMario.AbstractClasses;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FlugelMario.Enums;
using FlugelMario.Sprites.Mario;

namespace FlugelMario.States.MarioStates
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
            MarioShape = Shape.Small;
        }

        public void RunLeft()
        {
            if (MarioShape == Shape.Small)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateRunningLeftSmallMarioSprite();
            }

            MarioDirection = Direction.Left;
        }

        public void RunRight()
        {
            if (MarioShape == Shape.Small)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateRunningRightSmallMarioSprite();
            }

            MarioDirection = Direction.Right;
        }

        public void BeIdle()
        {
            if (MarioDirection == Direction.Right)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateIdleRightSmallMarioSprite();
            } else
            {
                StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftSmallMarioSprite();
            }
        }

        public void BeIdle(InputState state)
        {
            if (state == InputState.IdleLeft)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateIdleLeftSmallMarioSprite();
            }
            else
            {
                StateSprite = MarioSpriteFactory.Instance.CreateIdleRightSmallMarioSprite();
            }
        }

        public void Crouch()
        {
            if (MarioDirection == Direction.Right)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateCrouchRightBigMarioSprite();
            }
            else
            {
                StateSprite = MarioSpriteFactory.Instance.CreateCrouchLeftBigMarioSprite();
            }
        }

        private void ChangeToLeft()
        {
            MarioDirection = Direction.Left;
            StateSprite = MarioSpriteFactory.Instance.CreateRunningLeftSmallMarioSprite();
        }

        private void ChangeToRight()
        {
            MarioDirection = Direction.Right;
            StateSprite = MarioSpriteFactory.Instance.CreateRunningRightSmallMarioSprite();
        }

        public void Jump()
        {
            if (MarioDirection == Direction.Right)
            {
                StateSprite = MarioSpriteFactory.Instance.CreateJumpRightSmallMarioSprite();
            }
            else
            {
                StateSprite = MarioSpriteFactory.Instance.CreateJumpLeftSmallMarioSprite();
            }
        }

        public void ChangeFireMode()
        {
            MarioShape = Shape.Fire;
        }

        public void ChangeSizeToBig()
        {
            MarioShape = Shape.Big;
        }

        public void Terminated()
        {
            MarioShape = Shape.Dead;
        }

        public void ChangeSizeToSmall()
        {
            throw new System.NotImplementedException();
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
