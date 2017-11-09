using Microsoft.Xna.Framework;
using SuperMario.Enums;
using SuperMario.GameObjects;
using SuperMario.Interfaces;

namespace SuperMario
{
    public class MarioBlockCollisionBottom : ICollisionCommand
    {
        public MarioBlockCollisionBottom()
        {

        }
        public void Execute(IGameObject gameObject1, IGameObject gameObject2)
        {
            IMario mario = (IMario)gameObject1;
            if(mario.State.MarioShape == Shape.Dead)
            {
                return;
            }
            if (gameObject2.GetType() == typeof(HiddenBlock) && mario.Velocity.Y >= 0)
            {
                return;
            }

            IBlock block = (IBlock)gameObject2;
            mario.Location = new Vector2(mario.Destination.X, block.Destination.Y + block.Destination.Height - 1);
            if(mario.Velocity.Y < 0)
            {
                mario.Velocity = new Vector2(mario.Velocity.X, 0);
                if(!((mario.State.MarioShape == Shape.Small ||
                    mario.State.MarioShape == Shape.StarSmall) &&
                    (block.GetType() == typeof(BrickBlock))))
                {
                    block.Trigger();
                }
                if((mario.State.MarioShape == Shape.Small ||
                    mario.State.MarioShape == Shape.StarSmall) &&
                    (block.GetType() == typeof(BrickBlock)))
                {
                    int verticalDisplacement = 5;
                    block.Location = new Vector2(block.Location.X, block.Location.Y - verticalDisplacement);
                }
            }
        }
    }
}
