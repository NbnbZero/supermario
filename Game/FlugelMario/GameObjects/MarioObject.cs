using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuperMario.GameObjects.GameObjectType;
using SuperMario.States.MarioStates;
namespace SuperMario.GameObjects
{
    public class MarioObject : IMario
    {
        public ObjectType Type { get; } = ObjectType.Mario;
        public IMarioState State { get; set; }
        private bool isAir = false;
        public bool IsInAir
        {
            get { return isAir; }
            set
            {
                isAir = value;
            }
        }
        public Shape PreStarShape { set; get; }
        private Vector2 location;
        private bool isProtect = false;
        public bool IsProtected
        {
            get { return isProtect; }
            set
            {
                isProtect = value;
            }
        }

        public Vector2 Location
        {
            get { return location; }
            set
            {
                int horizontalDisplacement = (MarioSpriteFactory.Instance.NormalMarioWidth - this.Destination.Width) / 2;
                int verticalDisplacement = (MarioSpriteFactory.Instance.NormalMarioHeight - this.Destination.Height);
                location.X = value.X - horizontalDisplacement;
                location.Y = value.Y - verticalDisplacement;
            }
        }

        public Vector2 Velocity { set; get; }
        public float maxSpeed { set; get; }
        public Vector2 Acceleration { set; get; }
        private const int smallMarioVertDis = 3;
        private const int smallMarioHeriDis = 3;
        private const int bigMarioVertDis = 5;
        private const int bigMarioHeriDis = 2;
        private const int maxYSpeed = 10;
        
        public MarioObject(Vector2 location)
        {
            State = new IdleRightSmallMarioState(this);
            Location = location;
            State.MarioPosture = Posture.Stand;
            State.MarioShape = Shape.Small;
            State.MarioDirection = Direction.Right;
            Velocity = new Vector2(0, 0);
            Acceleration = new Vector2(0, 0);
            IsProtected = false;
            maxSpeed = 4;
        }

        public Rectangle Destination
        {
            set { Destination = value; }
            get
            {
                int verticalDisplacement;
                int horizontalDisplacement;
                if (State.MarioPosture == Posture.Crouch ||
                    State.MarioShape == Shape.Small ||
                    State.MarioShape == Shape.StarSmall)
                {
                    verticalDisplacement = MarioSpriteFactory.Instance.HalfNormalMarioHeight + smallMarioVertDis;
                    horizontalDisplacement = smallMarioHeriDis;
                }
                else
                {
                    verticalDisplacement = bigMarioVertDis;
                    horizontalDisplacement = bigMarioHeriDis;
                }
                return new Rectangle((int)this.location.X + horizontalDisplacement, (int)this.location.Y + verticalDisplacement, MarioSpriteFactory.Instance.NormalMarioWidth - 2 * horizontalDisplacement, MarioSpriteFactory.Instance.NormalMarioHeight - verticalDisplacement);
            }
        }
        

        public void Update()
        {
            //horizontal velocity control
            float newVelocityX = this.Velocity.X;
            if ((this.Velocity.X < maxSpeed && this.Velocity.X > -maxSpeed) ||
                (this.Velocity.X <= -maxSpeed && this.Acceleration.X >0) ||
                (this.Velocity.X >= maxSpeed && this.Acceleration.X < 0))
            {
                newVelocityX += this.Acceleration.X;
            }

            //vertical velocity control
            float newVelocityY = this.Velocity.Y;
            if (this.Velocity.Y < maxYSpeed)
            {
                newVelocityY += this.Acceleration.Y;
            }
            this.Velocity = new Vector2(newVelocityX, newVelocityY);
            float newLocationX = this.Destination.X + this.Velocity.X;
            float newLocationY = this.Destination.Y + this.Velocity.Y;
            this.Location = new Vector2(newLocationX, newLocationY);
            State.Update();


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch, this.Location);
        }
    }
}
