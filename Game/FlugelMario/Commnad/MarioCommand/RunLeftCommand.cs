using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlugelMario.Interfaces;


namespace FlugelMario.Commnand
{
    class RunLeftCommand
    {
        IMarioState myMario;
        public RunLeftCommand(IMarioState mario)
        {
            myMario = mario;
        }

        public void Execute()
        {
            myMario.RunLeft();
        }
    }
}
