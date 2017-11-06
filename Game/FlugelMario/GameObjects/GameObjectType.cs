using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlugelMario.GameObjects
{
    public class GameObjectType
    {
        public enum ObjectType
        {
            Mario, Goomba, Koopa, BrickBlock, Coin, FloorBlock,
            Flower, GreenMushroom, QuestionkBlock, RedMushroom,
            Star, UsedBlock, RockBlock, HiddenBlock
        };
    }
}
