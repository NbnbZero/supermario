using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.GameObjects;
using SuperMario.States.EnemyStates;

namespace SuperMario
{
    public class CheapCheap : IEnemy
    {
        public Rectangle Destination { get; set; }
        public Vector2 Location { get; set; }
        public IEnemyState State { get; set; }
        public bool Alive { get; set; } = true;
        public bool Moving { get; set; } = true;
        public GameObjectType.ObjectType Type { get; } = GameObjectType.ObjectType.CheapCheap;
        private Vector2 velocity;
        private Vector2 acceleration;
        private int counter = 0;
        public Vector2 Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }

        private bool hasBeenInView;
        public bool CanUpdate { get { return hasBeenInView; } }



        public CheapCheap(Vector2 location)
        {
            Location = location;
            State = new CheapCheapAliveState(this);
            Destination = State.StateSprite.MakeDestinationRectangle(Location);
            velocity = new Vector2(-0.5f, 0);
            acceleration = new Vector2(0, 0);
        }

        public void ChangeDirection()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            State.Draw(spriteBatch, Location);
        }

        public void Terminate(string direction)
        {

        }

        public void Update()
        {
            hasBeenInView = true;

            Location = new Vector2(Location.X + velocity.X, Location.Y);

            Destination = State.StateSprite.MakeDestinationRectangle(Location);
            State.Update();
        }
    }
}

