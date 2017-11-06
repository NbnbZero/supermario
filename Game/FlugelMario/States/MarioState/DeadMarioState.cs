using SuperMario.States.MarioStates;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using SuperMario.Enums;
using Microsoft.Xna.Framework;

namespace SuperMario.States.MarioStates
{
    public class DeadMarioState : MarioState
    {
        public override bool IsStar { get; } = false;
        public DeadMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateDeadMarioSprite();
            this.MarioPosture = Posture.Dead;
            this.MarioDirection = Direction.Dead;
            this.MarioShape = Shape.Dead;
            this.Mario.Velocity = new Vector2(0,0);
            this.Mario.Acceleration = new Vector2(0,0);
            MarioAttributes.MarioLife[0]--;
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
            if (MarioAttributes.MarioLife[0] == 0)
            {
                //...
            }
            else
            {
                //...
            }
        }
    }
}
