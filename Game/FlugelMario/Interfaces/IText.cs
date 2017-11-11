using SuperMario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMairo.Interfaces
{
    public interface IText : ISprite
    {
        string text { get; set; }
    }
}
