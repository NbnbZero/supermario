using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario;
namespace SuperMario.Commands.ControllerCommand
{
    class ReleasedAcceMarioCommand: ICommand
    {
        private IMario mario;

        public ReleasedAcceMarioCommand(IMario Mario)
        {
            mario = Mario;
        }

        public void Execute()
        {
            mario.maxSpeed = GameUtility.MarioRegularSpeed;
        }
    }
}
