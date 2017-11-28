using Microsoft.Xna.Framework;
using SuperMario.AbstractClasses;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;

namespace SuperMario.States.MarioStates
{
    class SwimmingRightFireMarioState : MarioState
    {
        public override bool IsStar { get; } = false;
        public SwimmingRightFireMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateSwimmingRightFireMarioSprite();
            this.MarioPosture = Posture.Swimming;
            this.MarioDirection = Direction.Right;
            this.MarioShape = Shape.Fire;
            mario.IsInWater = true;
            Mario.Acceleration = new Vector2(0, Mario.Acceleration.Y + GameData.Float);
            if (mario.IsInAir == false && !mario.IsProtected)
            {
                //SoundManager.Instance.PlaySmallJumpSound();
            }
            mario.IsInAir = true;
        }

        public override void ChangeFireMode()
        {
            Mario.State = new SwimmingRightFireMarioState(Mario);
        }

        public override void RunLeft()
        {
            Mario.State = new SwimmingLeftFireMarioState(Mario);
        }

        public override void RunRight()
        {
            Mario.Location = new Vector2(Mario.Destination.X + 1, Mario.Destination.Y + GameData.Float);
        }

        public override void Swim()
        {
            Mario.Velocity = new Vector2(Mario.Velocity.X, -7);
            Mario.Acceleration = new Vector2(0, Mario.Acceleration.Y + GameData.Float);
        }

        public override void Crouch()
        {
            Mario.Velocity = new Vector2(Mario.Velocity.X, 7);
            Mario.Acceleration = new Vector2(0, Mario.Acceleration.Y + GameData.Float);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new SwimmingRightSmallMarioState(Mario);
        }

        public override void Update()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new IdleRightFireMarioState(Mario);
            }
            base.Update();
        }
    }
}
