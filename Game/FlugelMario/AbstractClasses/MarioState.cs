using FlugelMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlugelMario.AbstractClasses
{
    public abstract class MarioState : IMarioState
    {
        public enum MarioPostureEnums { Stand, Crouch, Jump, Running, Dead }
        public enum MarioDirectionEnums { Left, Right, Dead }
        public enum MarioShapeEnums { Small, Big, Fire, Dead }

        public ISprite StateSprite { get; set; }

        public MarioPostureEnums MarioPosture { get; set; } = MarioPostureEnums.Stand;
        public MarioDirectionEnums MarioDirection { get; set; } = MarioDirectionEnums.Right;
        public MarioShapeEnums MarioShape { get; set; } = MarioShapeEnums.Small;

        public IMario Mario { get; set; }

        protected MarioState(IMario mario)
        {
            Mario = mario;
        }

        public virtual void ChangeFireMode() { }

        public virtual void ChangeSizeToBig() { }

        public virtual void ChangeSizeToSmall() { }

        public virtual void ChangeToLeft() { }

        public virtual void ChangeToRight() { }

        public virtual void Crouch() { }

        public virtual void JumpOrStand() { }

        public virtual void Terminated() { }

        public virtual void Update()
        {
            this.StateSprite.Update();
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            this.StateSprite.Draw(spriteBatch, location);
        }
    }
}
