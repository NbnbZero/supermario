using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlugelMario.Interfaces;


namespace FlugelMario.Commnand
{
    class PauseCommand : ICommand
    {
        IMarioState myMario;
        public PauseCommand(IMarioState mario)
        {
            myMario = mario;
        }

        public void Execute()
        {
            myMario.Terminated();
        }

        public void Execute(InputState state, IMarioState marioState)
        {
            throw new NotImplementedException();
        }
    }
}
