using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FlugelMario.AbstractClasses.BlockState;

namespace FlugelMario.Interfaces
{
    public interface IBlockStateChanges
    {
        BlockTypeEnums BlockType { get; set; }
        IController KeyboadrController { get; set; }
        void Update();
    }
}
