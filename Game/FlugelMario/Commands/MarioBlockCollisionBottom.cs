using SuperMario.Interfaces;
using SuperMario.Enums;
using SuperMario.GameObjects;
using Microsoft.Xna.Framework;
namespace SuperMario.Commands
{
    public class MarioBlockCollisionBottom:ICollisionCommand
    {
        public MarioBlockCollisionBottom()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            IBlock block = (IBlock)gameObject2;

            if (mario.State.MarioShape == Shape.Dead)
            {
                return;
            }
            if (gameObject2.GetType() == typeof(HiddenBlock) && mario.Velocity.Y >= GameData.StationaryVelocity)
            {
                return;
            }

            mario.Location = new Vector2(mario.Destination.X, block.Destination.Y + block.Destination.Height - GameData.SinglePixel);
        }
    }
}
