﻿using Microsoft.Xna.Framework;
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
    class RunningLeftStarBigMarioState : MarioState
    {
        public override bool IsStar { get; } = true;

        public RunningLeftStarBigMarioState(IMario mario) : base(mario)
        {
            StateSprite = MarioSpriteFactory.Instance.CreateRunningLeftStarBigMarioSprite();
            this.MarioPosture = Posture.Running;
            this.MarioDirection = Direction.Left;
            this.MarioShape = Shape.StarBig;
            Mario.Acceleration = new Vector2(-GameData.MarioAccel, Mario.Acceleration.Y);
        }

        public override void ChangeFireMode()
        {
            Mario.State = new RunningLeftFireMarioState(Mario);
        }

        public override void RunLeft()
        {
        }

        public override void RunRight()
        {
            Mario.State = new IdleLeftStarBigMarioState(Mario);
        }

        public override void JumpOrStand()
        {
            Mario.State = new JumpLeftStarBigMarioState(Mario);
            Mario.Velocity = new Vector2(Mario.Velocity.X, GameData.MarioJumpingSpeed);
            Mario.Acceleration = new Vector2(0, Mario.Acceleration.Y);
        }

        public override void Crouch()
        {
            Mario.State = new CrouchLeftStarMarioState(Mario);
        }

        public override void Terminated()
        {
            Mario.State = new DeadMarioState(Mario);
        }

        public override void ChangeSizeToBig()
        {
            Mario.State = new RunningLeftBigMarioState(Mario);
        }

        public override void ChangeSizeToSmall()
        {
            Mario.State = new RunningLeftSmallMarioState(Mario);
        }

        public override void ChangeStarMode()
        {
            Mario.State = new RunningLeftStarSmallMarioState(Mario);
        }

        public override void Update()
        {
            if (Mario.IsInAir && Mario.State.MarioPosture != Posture.Jump)
            {
                Mario.State = new IdleLeftStarBigMarioState(Mario);
            }
            base.Update();

        }
    }
}
