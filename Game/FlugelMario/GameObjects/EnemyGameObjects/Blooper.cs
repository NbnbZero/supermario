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
    public class Blooper : IEnemy
    {
        public Rectangle Destination { get; set; }
        public Vector2 Location { get; set; }
        public IEnemyState State { get; set; }
        public bool Alive { get; set; } = true;
        public bool Moving { get; set; } = true;
        public GameObjectType.ObjectType Type { get; } = GameObjectType.ObjectType.Blooper;
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



        public Blooper(Vector2 location)
        {
            Location = location;
            State = new BlooperAliveState(this);
            Destination = State.StateSprite.MakeDestinationRectangle(Location);
            velocity = new Vector2(0, -0.5f);
            acceleration = new Vector2(0, 0);
        }

        public void ChangeDirection()
        {
            Velocity = new Vector2(Velocity.X, -Velocity.Y);
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

            if (counter >= 0 && counter < 150)
            {
                Location = new Vector2(Location.X, Location.Y - velocity.Y);
                counter++;
            }
            else if (counter >= 150 && counter < 300)
            {
                Location = new Vector2(Location.X, Location.Y + velocity.Y);
                counter++;
            }
            else
            {
                counter = 0;
            }
            
            Destination = State.StateSprite.MakeDestinationRectangle(Location);
            State.Update();
        }
    }
}
