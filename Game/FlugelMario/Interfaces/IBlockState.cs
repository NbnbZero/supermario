using SuperMario.Enums;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Interfaces
{
    public interface IBlockState
    {
        ISprite StateSprite { get; set; }
        BlockType BlockType { get; set; }      
        Shape MarioShape { get; set; }
        void ChangeToUsedBlock();
        void ChangeToBrickBlock();
        void ChangeToHiddenBlock();
        void ChangeToQuestionBlock();
        void BlockBumpUp();
        void Update();
    }
}
