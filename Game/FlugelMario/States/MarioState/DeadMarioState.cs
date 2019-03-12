using SuperMario.States.MarioStates;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using SuperMario.Enums;
using Microsoft.Xna.Framework;
using SuperMario.Sound;

namespace SuperMario.States.MarioStates
{
    public class DeadMarioState : MarioState
    {
        public override bool IsStar { get; } = false;
        private int counter = 20;
        private float marioDeathAcceleration = .75f;
        private int marioDeathVelocity = -10;
        public DeadMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite();
            this.MarioPosture = Posture.Dead;
            this.MarioDirection = Direction.Dead;
            this.MarioShape = Shape.Dead;
            SoundManager.Instance.PlayMarioDyingSound();
            SoundManager.Instance.StopAllSound();
            this.Mario.Velocity = new Vector2(0,0);
            this.Mario.Acceleration = new Vector2(0,0);
            MarioInfo.MarioLife[0]--;
        }

        public override void RunLeft()
        {
        }

        public override void RunRight()
        {
        }

        public override void JumpOrStand()
        {
        }

        public override void Swim()
        {
        }

        public override void Crouch()
        {
        }

        public override void ChangeFireMode()
        {
            Mario.State = new IdleRightFireMarioState(Mario);
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new IdleRightBigMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new IdleRightSmallMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new IdleRightStarSmallMarioState(Mario);
        }

        public override void Update()
        {
            if (counter > 0)
            {
                counter--;
            }
            else if (counter == 0)
            {
                this.Mario.Velocity = new Vector2(0, marioDeathVelocity);
                this.Mario.Acceleration = new Vector2(0, marioDeathAcceleration);
                counter--;
            }
            
            if (this.Mario.Destination.Y > 1000)
            {
                MarioInfo.StopTimer();
                if (MarioInfo.MarioLife[0] == 0)
                {
                    Game1.State.GameOver();
                }
                else
                {
                    Game1.State.MarioDied();
                }
            }
        }
    }
}
