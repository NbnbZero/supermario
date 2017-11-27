using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
namespace SuperMario
{
    class MarioFlagCollision:ICommand
    {
        CollisionHandlerItem myHandler;
        public MarioFlagCollision(CollisionHandlerItem handler)
        {
            myHandler = handler;
        }

        public void Execute()
        {
            
        }
    }
}
