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
    class JumpLeftStarSmallMarioState : MarioState
    {
        public override bool IsStar { get; } = true;

        public JumpLeftStarSmallMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateJumpLeftStarSmallMarioSprite();
            this.MarioPosture = Posture.Jump;
            this.MarioDirection = Direction.Left;
            this.MarioShape = Shape.StarSmall;
            mario.Acceleration = new Vector2(0, mario.Acceleration.Y);
            mario.IsInAir = true;
        }

        public override void ChangeToLeft()
        {
            Mario.Location = new Vector2(Mario.Destination.X - 1, Mario.Destination.Y);
        }

        public override void ChangeToRight()
        {
            Mario.State = new JumpRightStarSmallMarioState(Mario);
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

        public override void ChangeFireMode()
        {
            Mario.State = new JumpLeftFireMarioState(Mario);
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new JumpLeftBigMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new JumpLeftSmallMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new JumpLeftStarBigMarioState(Mario);
        }

        public override void Update()
        {
            if (!Mario.IsInAir)
            {
                Mario.State = new IdleLeftStarSmallMarioState(Mario);
            }
            base.Update();
        }
    }
}
