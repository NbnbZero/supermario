using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using SuperMario.Enums;

namespace SuperMario
{
    public abstract class MarioState : IMarioState
    {

        public ISprite StateSprite { get; set; }

        public Posture MarioPosture { get; set; } = Posture.Stand;
        public Direction MarioDirection { get; set; } = Direction.Right;
        public Shape MarioShape { get; set; } = Shape.Small;
        public virtual bool IsStar { get; }
        public IMario Mario { get; set; }

        protected MarioState(IMario mario)
        {
            Mario = mario;
        }

        public virtual void ChangeFireMode(){}

        public virtual void ChangeSizeToBig(){}

        public virtual void ChangeSizeToSmall(){}

        public virtual void RunLeft(){}

        public virtual void RunRight(){}

        public virtual void SwimLeft() { }

        public virtual void SwimRight() { }

        public virtual void Crouch(){}

        public virtual void JumpOrStand(){}
        public virtual void ChangeStarMode(){}

        public virtual void Terminated(){}

        public virtual void Update()
        {

            if (this.Mario.IsInAir)
            {
                this.Mario.Acceleration = new Vector2(0, this.Mario.Acceleration.Y);
            }

            this.StateSprite.Update();
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            this.StateSprite.Draw(spriteBatch, location);
        }

        public void MarioShapeChange(Shape newShape)
        {
            switch (newShape)
            {
                case Shape.Big:
                    ChangeSizeToBig();
                    break;
                case Shape.Small:
                    ChangeSizeToSmall();
                    break;
                case Shape.Fire:
                    ChangeFireMode();
                    break;
                case Shape.StarBig:
                    ChangeStarMode();
                    break;
                case Shape.StarSmall:
                    ChangeStarMode();
                    break;
            }
        }
    }
}
