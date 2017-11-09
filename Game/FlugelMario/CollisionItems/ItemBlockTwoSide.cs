using Microsoft.Xna.Framework;
using SuperMario.Interfaces;

namespace SuperMario
{
    class ItemBlockTwoSide : ICommand
    {
        CollisionHandlerItem myHandler;
        public ItemBlockTwoSide(CollisionHandlerItem handler)
        {
            myHandler = handler;
        }

        public void Execute()
        {
            if (myHandler.item.Velocity.X != 0)
            {
                myHandler.item.ChangeDirection();
            }
        }
    }
}