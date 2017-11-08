using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
namespace SuperMario.Commands.ControllerCommand
{
    class LeftMarioCommand:ICommand
    {
        private IMario Mario;

        public LeftMarioCommand(IMario mario)
        {
            Mario = mario;
        }

        public void Execute()
        {
            Mario.State.RunLeft();
        }
    }
}
