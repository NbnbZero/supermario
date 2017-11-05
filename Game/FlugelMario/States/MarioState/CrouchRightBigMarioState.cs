using SuperMario.States.MarioStates;
using SuperMario.AbstractClasses;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;

namespace SuperMario.States.MarioStates
{
    public class CrouchRightBigMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = true;
        public CrouchRightBigMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateCrouchRightBigMarioSprite();
            this.MarioPosture = Posture.Crouch;
            this.MarioDirection = Direction.Right;
            this.MarioShape = Shape.Big;
        }

        public override void ChangeFireMode()
        {
            Mario.State = new CrouchRightFireMarioState(Mario);
        }

        public override void RunLeft()
        {
            Mario.State = new CrouchLeftBigMarioState(Mario);
        }

        public override void RunRight()
        {
        }

        public override void JumpOrStand()
        {
            Mario.State = new IdleRightBigMarioState(Mario);
        }

        public override void Crouch()
        {
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new IdleRightSmallMarioState(Mario);
        }

        public override void Update()
        {
            if (Mario.IsInAir)
            {
                Mario.State = new IdleRightBigMarioState(Mario);
            }
            else
            {
                //making the critical speed to 0.75f
                if (Mario.Velocity.X >= 0.75f)
                {
                    Mario.Acceleration = new Vector2(-0.75f, Mario.Acceleration.Y);
                }
                else if (Mario.Velocity.X <= -0.75f)
                {
                    Mario.Acceleration = new Vector2(0.75f, Mario.Acceleration.Y);
                }
                else
                {
                    Mario.Acceleration = new Vector2(0, Mario.Acceleration.Y);
                    Mario.Velocity = new Vector2(0, Mario.Velocity.Y);
                }
            }
            base.Update();

        }
    }
}
