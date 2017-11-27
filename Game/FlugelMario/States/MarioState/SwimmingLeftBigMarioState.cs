using Microsoft.Xna.Framework;
using SuperMario.AbstractClasses;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;

namespace SuperMario.States.MarioStates
{
    class SwimmingLeftBigMarioState : MarioState
    {
        public override bool IsStar { get; } = false;
        public SwimmingLeftBigMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateSwimmingLeftBigMarioSprite();
            this.MarioPosture = Posture.Swimming;
            this.MarioDirection = Direction.Left;
            this.MarioShape = Shape.Big;
            Mario.Acceleration = new Vector2(-0.25f, Mario.Acceleration.Y + GameData.Float);
            if (mario.IsInWater == false && !mario.IsProtected)
            {
                //SoundManager.Instance.PlaySmallJumpSound();
            }
            mario.IsInWater = true;
        }

        public override void ChangeFireMode()
        {
            Mario.State = new SwimmingLeftMarioState(Mario);
        }

        public override void RunLeft()
        {
        }

        public override void RunRight()
        {
            Mario.State = new IdleInWaterLeftBigMarioState(Mario);
        }

        public override void JumpOrStand()
        {
            Mario.State = new IdleInWaterLeftBigMarioState(Mario);
            Mario.Velocity = new Vector2(Mario.Velocity.X, -7);
            Mario.Acceleration = new Vector2(0, Mario.Acceleration.Y + GameData.Float);
        }

        public override void Crouch()
        {
            Mario.State = new IdleInWaterLeftBigMarioState(Mario);
            Mario.Velocity = new Vector2(Mario.Velocity.X, 7);
            Mario.Acceleration = new Vector2(0, Mario.Acceleration.Y + GameData.Float);
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
            if (!Mario.IsInWater)
            {
                Mario.State = new IdleLeftBigMarioState(Mario);
            }
            base.Update();
        }
    }
}
