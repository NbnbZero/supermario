using Microsoft.Xna.Framework;
using SuperMario.AbstractClasses;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;

namespace SuperMario.States.MarioStates
{
    class SwimmingLeftFireMarioState : MarioState
    {
        public override bool IsStar { get; } = false;
        public SwimmingLeftFireMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateSwimmingLeftFireMarioSprite();
            this.MarioPosture = Posture.Swimming;
            this.MarioDirection = Direction.Left;
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
            Mario.State = new SwimmingLeftFireMarioState(Mario);
        }

        public override void RunLeft()
        {
            Mario.Location = new Vector2(Mario.Destination.X - 1, Mario.Destination.Y + GameData.Float);
        }

        public override void RunRight()
        {
            Mario.State = new SwimmingRightFireMarioState(Mario);
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
            Mario.State = new SwimmingLeftSmallMarioState(Mario);
        }

        public override void Update()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new IdleLeftFireMarioState(Mario);
            }
            base.Update();
        }
    }
}
