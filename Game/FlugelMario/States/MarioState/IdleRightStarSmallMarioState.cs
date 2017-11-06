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
    class IdleRightStarSmallMarioState : MarioState
    {
        public override bool IsStar { get; } = true;
        public IdleRightStarSmallMarioState(IMario mario) : base(mario)
        {
        StateSprite = MarioSpriteFactory.Instance.CreateIdleRightStarSmallMarioSprite();
        this.MarioPosture = Posture.Stand;
        this.MarioDirection = Direction.Right;
        this.MarioShape = Shape.StarSmall;

    }

    public override void ChangeToLeft()
    {
        Mario.State = new IdleLeftStarSmallMarioState(Mario);
    }

    public override void ChangeToRight()
    {
        if (!Mario.IsInAir)
        {
            Mario.State = new RunningRightStarSmallMarioState(Mario);
        }
    }

    public override void Crouch()
    {
    }

    public override void ChangeSizeToBig()
    {
        Mario.State = new IdleRightBigMarioState(Mario);
    }

    public override void ChangeFireMode()
    {
        Mario.State = new IdleRightFireMarioState(Mario);
    }
    public override void JumpOrStand()
    {
        if (!Mario.IsInAir)
        {
            Mario.State = new JumpRightStarSmallMarioState(Mario);
            Mario.Velocity = new Vector2(Mario.Velocity.X, GameData.MarioJumpingSpeed);
        }
    }

    public override void Terminated()
    {
        Mario.State = new DeadMarioState(Mario);
    }

    public override void ChangeSizeToSmall()
    {
        Mario.State = new IdleRightSmallMarioState(Mario);
    }

    public override void ChangeStarMode()
    {
        Mario.State = new IdleRightStarBigMarioState(Mario);
    }

    public override void Update()
    {
        base.Update();
        if (Mario.IsInAir) return;
        if (Mario.Velocity.X >= GameData.MarioCriticalSpeed)
        {
            Mario.Acceleration = new Vector2(-GameData.MarioCriticalSpeed, Mario.Acceleration.Y);
        }
        else if (Mario.Velocity.X <= -GameData.MarioCriticalSpeed)
        {
            Mario.Acceleration = new Vector2(GameData.MarioCriticalSpeed, Mario.Acceleration.Y);
        }
        else
        {
            Mario.Acceleration = new Vector2(0, Mario.Acceleration.Y);
            Mario.Velocity = new Vector2(0, Mario.Velocity.Y);
        }
    }
}
}
