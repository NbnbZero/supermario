using Microsoft.Xna.Framework;
using SuperMario.AbstractClasses;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;

namespace SuperMario.States.MarioStates
{
    public class CrouchRightFireMarioState : MarioState
    {
        public override bool IsStar { get; } = false;
        public CrouchRightFireMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateCrouchRightFireMarioSprite();
            this.MarioPosture = Posture.Crouch;
            this.MarioDirection = Direction.Right;
            this.MarioShape = Shape.Fire;
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new CrouchRightBigMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new CrouchRightStarMarioState(Mario);
        }

        public override void RunLeft()
        {
            Mario.State = new CrouchLeftFireMarioState(Mario);
        }

        public override void RunRight()
        {
        }

        public override void JumpOrStand()
        {
            Mario.State = new IdleRightFireMarioState(Mario);
        }
        public override void Swim()
        {
            Mario.State = new IdleRightFireMarioState(Mario);
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
            if (Mario.IsInAir && !Mario.IsInWater)
            {
                Mario.State = new IdleLeftBigMarioState(Mario); //switch to idle state and return
            }
            else if (Mario.IsInAir && Mario.IsInWater)
            {
                Mario.State = new SwimmingLeftBigMarioState(Mario);
            }
            else if (Mario.IsInWater)
            {
                //making the critical speed to 0.75f
                if (Mario.Velocity.X >= 0.75f)
                {
                    Mario.Acceleration = new Vector2(-0.75f, Mario.Acceleration.Y );
                }
                else if (Mario.Velocity.X <= -0.75f)
                {
                    Mario.Acceleration = new Vector2(0.75f, Mario.Acceleration.Y );
                }
                else
                {
                    Mario.Acceleration = new Vector2(0, Mario.Acceleration.Y );
                    Mario.Velocity = new Vector2(0, Mario.Velocity.Y );
                }
            }
            else if (!Mario.IsInWater)
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
