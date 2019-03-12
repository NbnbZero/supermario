using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using SuperMario.Enums;
namespace SuperMario.Commands
{
    class ItemPipeTop : ICommand
    {
        CollisionHandlerItem myhandler;
        public ItemPipeTop(CollisionHandlerItem handler)
        {
            myhandler = handler;
        }

        public void Execute()
        {

            /*myhandler.item.Location = new Vector2(myhandler.item.Location.X, myhandler.block.Location.Y - myhandler.item.Destination.Height);

            if (myhandler.item.GetType() == typeof(Star))
            {
                myhandler.item.Velocity = new Vector2(myhandler.item.Velocity.X, -5);
            }
            else
            {
                myhandler.item.Velocity = new Vector2(myhandler.item.Velocity.X, 0);
            }*/
        }
    }
}
