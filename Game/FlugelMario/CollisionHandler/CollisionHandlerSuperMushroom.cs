using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Enums;
using SuperMario.Commands;
using static SuperMario.CollisionDetector;
using SuperMario;

namespace SuperMario
{
    public class CollisionHandlerSuperMushroom
    {
        public SuperMushroom superMushroom1{ get; set; }
        public IBlock block { get; set; }

        Dictionary<Type, Dictionary<CollisionDirection, ICommand>> commandDict;

        public CollisionHandlerSuperMushroom(SuperMushroom superMushroom)
        {
            superMushroom1 = superMushroom;
            commandDict = new Dictionary<Type, Dictionary<CollisionDirection, ICommand>>();
            commandDict.Add(typeof(IBlock), new Dictionary<CollisionDirection, ICommand>());
            commandDict[typeof(IBlock)].Add(CollisionDirection.Left, new SuperMushroomBlockCollisionLeft(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Right, new SuperMushroomBlockCollisionLeft(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Top, new SuperMushroomBlockCollisionLeft(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Bottom, new SuperMushroomBlockCollisionLeft(this));
        }

    }
}
