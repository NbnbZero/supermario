using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static SuperMario.GameObjects.GameObjectType;
using SuperMario.StateMachine;
using SuperMario.Sound;

namespace SuperMario.GameObjects
{
    public class HiddenBlock : IBlock
    {
        private HiddenBlockStateMachine stateMachine;
        public ObjectType Type { get; } = ObjectType.Block;
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }
        public bool Used
        {
            get { return this.stateMachine.Used; }
        }

        public HiddenBlock(Vector2 location)
        {
            stateMachine = new HiddenBlockStateMachine();
            Location = location;
            Destination = stateMachine.MakeDestinationRectangle(Location);
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
            UpMushroom newObject = new UpMushroom(new Vector2(Location.X, Location.Y - 2));
            SoundManager.Instance.PlayMushStarSound();
            //Need to Add to List
            stateMachine.BeTriggered();
        }

        public void Update()
        {
            stateMachine.Update();
            Destination = stateMachine.MakeDestinationRectangle(Location);
        }
    }
}
