using Microsoft.Xna.Framework;
using SuperMario.AbstractClasses;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;

namespace SuperMario.States.MarioStates
{
    public class CrouchLeftFireMarioState : MarioState
    {
        private const bool isBig = true;
        private const bool isCrouching = true;
        public CrouchLeftFireMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateCrouchLeftFireMarioSprite();
            this.MarioPosture = Posture.Crouch;
            this.MarioDirection = Direction.Left;
            this.MarioShape = Shape.Fire;
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new CrouchLeftBigMarioState(Mario);
        }

        public override void RunLeft()
        {
        }

        public override void RunRight()
        {
            Mario.State = new CrouchRightFireMarioState(Mario);
        }

        public override void JumpOrStand()
        {
            Mario.State = new IdleLeftFireMarioState(Mario);
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
            Mario.State = new IdleLeftSmallMarioState(Mario);
        }

        public override void Update()
        {
            if (Mario.IsInAir)
            {
                Mario.State = new IdleLeftFireMarioState(Mario);
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
