using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Commands
{
    public class EnemyPipeLeftRight : ICommand
    {

        CollisionHandlerEnemy myhandler;
        public EnemyPipeLeftRight(CollisionHandlerEnemy handler)
        {
            myhandler = handler;
        }

        public void Execute()
        {
            if (myhandler.enemy.Velocity.X != 0)
            {
                myhandler.enemy.ChangeDirection();
            }
        }

    }
}
