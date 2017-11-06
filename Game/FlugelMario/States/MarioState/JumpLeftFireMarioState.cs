using Microsoft.Xna.Framework;
using SuperMario.AbstractClasses;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;

namespace SuperMario.States.MarioStates
{
    public class JumpLeftFireMarioState : MarioState
    {
        public override bool IsStar { get; } = false;
        public JumpLeftFireMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateJumpLeftFireMarioSprite();
            this.MarioPosture = Posture.Jump;
            this.MarioDirection = Direction.Left;
            this.MarioShape = Shape.Fire;
            mario.Acceleration = new Vector2(0, mario.Acceleration.Y);
            mario.IsInAir = true;
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new JumpLeftBigMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new JumpLeftStarBigMarioState(Mario);
        }

        public override void RunLeft()
        {
            Mario.Location = new Vector2(Mario.Destination.X - 1, Mario.Destination.Y);
        }

        public override void RunRight()
        {
            Mario.State = new JumpRightFireMarioState(Mario);
        }

        public override void JumpOrStand()
        {
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
            Mario.State = new JumpLeftSmallMarioState(Mario);
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