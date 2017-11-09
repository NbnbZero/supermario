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
        public SuperMushroom superMushroom1{ get; private set; }
        public IBlock block { get; private set; }

        Dictionary<Type, Dictionary<CollisionDirection, ICommand>> commandDict;

        public CollisionHandlerSuperMushroom(SuperMushroom superMushroom)
        {
            superMushroom1 = superMushroom;
            commandDict = new Dictionary<Type, Dictionary<CollisionDirection, ICommand>>();
            commandDict.Add(typeof(IBlock), new Dictionary<CollisionDirection, ICommand>());
            commandDict[typeof(IBlock)].Add(CollisionDirection.Left, new SuperMushroomBlockCollisionLeft(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Right, new SuperMushroomBlockCollisionRight(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Top, new SuperMushroomBlockCollisionTop(this));
        }

        public void HandleBlockCollision(IBlock Block)
        {
            block = Block;
            CollisionDirection Direction = DetectCollisionDirection(superMushroom1.Destination, block.Destination);

            if (commandDict[typeof(IBlock)].ContainsKey(Direction))
                commandDict[typeof(IBlock)][Direction].Execute();

        }

    }
}
