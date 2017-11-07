using Microsoft.Xna.Framework;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.States.MarioStates
{
    class JumpRightStarBigMarioState : MarioState
    {
        public override bool IsStar { get; } = true;
        public JumpRightStarBigMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateJumpRightStarBigMarioSprite();
            this.MarioPosture = Posture.Jump;
            this.MarioDirection = Direction.Right;
            this.MarioShape = Shape.StarBig;
            mario.Acceleration = new Vector2(0, mario.Acceleration.Y);
            mario.IsInAir = true;
        }

        public override void ChangeFireMode()
        {
            Mario.State = new JumpRightFireMarioState(Mario);
        }

        public override void RunLeft()
        {
            Mario.State = new JumpLeftStarBigMarioState(Mario);
        }

        public override void RunRight()
        {
            Mario.Location = new Vector2(Mario.Destination.X + 1, Mario.Destination.Y);
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

        public override void ChangeSizeToBig()
        {
            Mario.State = new JumpRightBigMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new JumpRightSmallMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new JumpRightStarSmallMarioState(Mario);
        }

        public override void Update()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new IdleRightStarBigMarioState(Mario);
            }
            base.Update();
        }
    }
}
