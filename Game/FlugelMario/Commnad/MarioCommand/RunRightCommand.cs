using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlugelMario.Interfaces;


namespace FlugelMario.Commnand
{
    class RunRightCommand 
    {
        IMarioState myMario;
        public RunRightCommand(IMarioState mario)
        {
            myMario = mario;
        }

        public void Execute()
        {
                myMario.RunRight();
        }
    }
}
