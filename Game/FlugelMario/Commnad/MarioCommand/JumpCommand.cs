using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlugelMario.Interfaces;


namespace FlugelMario.Commnand
{
    class JumpCommand
    {
        IMarioState myMario;
        public JumpCommand(IMarioState mario)
        {
            myMario = mario;
        }

        public void Execute()
        {
            myMario.Jump();
        }
    }
}
