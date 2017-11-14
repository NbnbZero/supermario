using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static SuperMario.GameObjects.GameObjectType;
using SuperMario.StateMachine;
using SuperMario.SCsystem;
using SuperMario.Animation;

namespace SuperMario.GameObjects
{
    public class CoinBrickBlock: IBlock
    {
        private IBlockStateMachine state;
        public ObjectType Type { get; } = ObjectType.Block;
        private IAnimationInGame coinAnimation;
        private int coinNum = 5;
        public Vector2 Location { get; set; }
        private Vector2 initialLocation;
        private Vector2 fallingSpeed;
        private Vector2 fallingAcce;
        private Rectangle destinationRect;
        public Rectangle Destination
        {
            get
            {
                if (state.Used)
                    return state.MakeDestinationRectangle(Location);
                return destinationRect;
            }
            set
            {
                destinationRect = value;
            }
        }

        public CoinBrickBlock(Vector2 location)
        {
            state = new CoinBrickBlockStateMachine();
            Location = location;
            initialLocation = location;
            fallingSpeed = new Vector2(0, 0);
            fallingAcce = new Vector2(0, 0.5f);
            destinationRect = state.MakeDestinationRectangle(Location);
            coinAnimation = new CoinOutOfBlockAnimation(new Vector2(Location.X, Location.Y - Destination.Height));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch, this.Location);
        }

        public void Trigger()
        {
            if (coinNum > 0)
            {
                Location = new Vector2(Location.X, initialLocation.Y - 5);
                coinNum--;
                CoinSystem.Instance.AddCoin();
                ScoringSystem.AddPointsForCoin(this);
                coinAnimation.StartAnimation();
            }
            else
            {
                state.BeTriggered();
            }
        }

        public void Update()
        {
            if (Location.Y >= initialLocation.Y)
            {
                Location = initialLocation;
                fallingSpeed = new Vector2(0, 0);
            }
            else
            {
                Location = new Vector2(Location.X, Location.Y + fallingSpeed.Y);
                fallingSpeed = new Vector2(0, fallingSpeed.Y + fallingAcce.Y);
            }

            state.Update();
            destinationRect = state.MakeDestinationRectangle(Location);
        }
    }
}
