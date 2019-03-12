using Microsoft.Xna.Framework;
using SuperMario.GameObjects;
using SuperMario.Interfaces;

namespace SuperMario
{
    public class ItemBlockTop : ICommand
    {
        CollisionHandlerItem myHandler;
        public ItemBlockTop(CollisionHandlerItem handler)
        {
            myHandler = handler;   
        }

        public void Execute()
        {
            if (myHandler.block.GetType() == typeof(HiddenBlock))
            {
                return;
            }
            myHandler.item.Location = new Vector2(myHandler.item.Location.X, myHandler.block.Location.Y - myHandler.item.Destination.Height);
            if (myHandler.item.GetType()==typeof(Star))
            {
                myHandler.item.Velocity = new Vector2(myHandler.item.Velocity.X, -5);
            }
            else
            {
                myHandler.item.Velocity = new Vector2(myHandler.item.Velocity.X, 0);
            }
            
        }
    }
}