using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlugelMario
{
    public enum InputState
    {
        Nothing,
        RunLeft,
        IdleLeft,
        IdleRight,
        RunRight,
        Jump,
        MakeSmall,
        MakeBig,
        MakeFire,
        MakeDead,
        Crouch,
        ChangeToUsed,
        BumpUp,
        ChangeToVisable
    }
}
