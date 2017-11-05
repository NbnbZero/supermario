using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
namespace SuperMario.Commands.ControllerCommand
{
    class RightMarioCommand:ICommand
    {
        private IMario Mario;

        public RightMarioCommand(IMario mario)
        {
            Mario = mario;
        }

        public void Execute()
        {
            Mario.State.ChangeToRight();
        }
    }
}
