using Microsoft.Xna.Framework;
using SuperMario.AbstractClasses;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;

namespace SuperMario.States.MarioStates
{
    class SwimmingLeftSmallMarioState : MarioState
    {
        public override bool IsStar { get; } = false;
        public SwimmingLeftSmallMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateSwimmingLeftSmallMarioSprite();
            this.MarioPosture = Posture.Swimming;
            this.MarioDirection = Direction.Left;
            this.MarioShape = Shape.Small;
            mario.IsInWater = true;
            Mario.Velocity = new Vector2(Mario.Velocity.X, GameData.marioInWaterJump);
            Mario.Acceleration = new Vector2(0, GameData.Gravity + GameData.Float);
            if (mario.IsInAir == false && !mario.IsProtected)
            {
                //SoundManager.Instance.PlaySmallJumpSound();
            }
            mario.IsInAir = true;
        }

        public override void ChangeFireMode()
        {
            Mario.State = new SwimmingLeftFireMarioState(Mario);
        }

        public override void RunLeft()
        {
            Mario.Acceleration = new Vector2(-GameData.marioInWaterAcc, Mario.Acceleration.Y);
            Mario.Location = new Vector2(Mario.Destination.X - 1, Mario.Destination.Y);
        }

        public override void RunRight()
        {
            Mario.State = new SwimmingRightSmallMarioState(Mario);
        }

        public override void Swim()
        {
            Mario.Velocity = new Vector2(0, GameData.marioInWaterJump);
            Mario.Acceleration = new Vector2(Mario.Acceleration.X, GameData.Float + GameData.Gravity);
        }

        public override void Crouch()
        {
            Mario.Velocity = new Vector2(Mario.Velocity.X, 0);
            Mario.Acceleration = new Vector2(0, Mario.Acceleration.Y);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new SwimmingLeftSmallMarioState(Mario);
        }

        public override void Update()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new IdleLeftSmallMarioState(Mario);
            }
            base.Update();
        }
    }
}
