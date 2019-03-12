using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static SuperMario.GameObjects.GameObjectType;
using SuperMario.StateMachine;
using SuperMario.Animation;
using SuperMario.Enums;
using SuperMario.GameObjects;
using SuperMario.Sound;
using SuperMario.SCsystem;

namespace SuperMario.GameObjects
{
    public class QuestionBlock : IBlock
    {
        private QuestionmarkBlockStateMachine stateMachine;
        private IAnimationInGame coinAnimation;
        public ObjectType Type { get; } = ObjectType.Block;
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }
        public bool Used { get { return this.stateMachine.Used; } }
        
        public ItemType hiddenItem { set; get; } = ItemType.Coin;

        public QuestionBlock(Vector2 location)
        {
            stateMachine = new QuestionmarkBlockStateMachine();
            Location = location;
            Destination = stateMachine.MakeDestinationRectangle(Location);
            coinAnimation = new CoinOutOfBlockAnimation(new Vector2(Location.X, Location.Y - Destination.Height));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            stateMachine.Draw(spriteBatch, this.Location);
        }

        public void Trigger()
        {
            if (Used)
            {
                return;
            }
            IGameObject newObject = null;
            switch (hiddenItem)
            {
                case ItemType.Flower:
                    newObject = new FireFlower(new Vector2(Location.X, Location.Y - 2));
                    SoundManager.Instance.PlayMushStarSound();
                    break;
                case ItemType.UpMushroom:
                    newObject = new UpMushroom(new Vector2(Location.X, Location.Y - 16));
                    SoundManager.Instance.PlayMushStarSound();
                    break;
                case ItemType.SuperMushroom:
                    newObject = new SuperMushroom(new Vector2(Location.X, Location.Y - 16));
                    SoundManager.Instance.PlayMushStarSound();
                    break;
                case ItemType.Star:
                    newObject = new Star(new Vector2(Location.X, Location.Y - 16));
                    SoundManager.Instance.PlayMushStarSound();
                    break;
                default:
                    coinAnimation.StartAnimation();
                    CoinSystem.Instance.AddCoin();
                    ScoringSystem.AddPointsForCoin(this);
                    break;
            }
            if (newObject != null)
            {
                GameObjectManager.itemList.Add(newObject);
            }

            stateMachine.BeTriggered();
        }

        public void Update()
        {
            Destination = stateMachine.MakeDestinationRectangle(Location);
            stateMachine.Update();
        }
    }
}
