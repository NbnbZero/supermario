using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Commands
{
    public class ItemPipeTwoSides : ICommand
    {

        CollisionHandlerItem myhandler;
        public ItemPipeTwoSides(CollisionHandlerItem handler)
        {
            myhandler = handler;
        }

        public void Execute()
        {
            if (myhandler.item.Velocity.X != 0)
            {
                myhandler.item.ChangeDirection();
            }
        }

    }
}
