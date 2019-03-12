using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Enums;
using SuperMario.Commands;
using static SuperMario.CollisionDetector;
namespace SuperMario
{
    public class CollisionHandlerItem: ICollisionHandler
    {
        public IItem item { get; private set; }
        public IBlock block { get; private set; }
        public IPipe pipe { get; private set; }
        Dictionary<Type, Dictionary<CollisionDirection, ICommand>> commandDict;

        public CollisionHandlerItem(IItem Item)
        {
            item = Item;
            commandDict = new Dictionary<Type, Dictionary<CollisionDirection, ICommand>>();
            commandDict.Add(typeof(IItem), new Dictionary<CollisionDirection, ICommand>());
            commandDict.Add(typeof(IBlock), new Dictionary<CollisionDirection, ICommand>());
            commandDict.Add(typeof(IPipe), new Dictionary<CollisionDirection, ICommand>());

            commandDict[typeof(IBlock)].Add(CollisionDirection.Left, new ItemBlockTwoSide(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Right, new ItemBlockTwoSide(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Top, new ItemBlockTop(this));


            commandDict[typeof(IPipe)].Add(CollisionDirection.Left, new ItemPipeTwoSides(this));
            commandDict[typeof(IPipe)].Add(CollisionDirection.Right, new ItemPipeTwoSides(this));
            commandDict[typeof(IPipe)].Add(CollisionDirection.Top, new ItemPipeTop(this));
        }
        
        public void HandleBlockCollision(IBlock Block)
        {
            block = Block;
            CollisionDirection Direction = DetectCollisionDirection(item.Destination, block.Destination);
            if (commandDict[typeof(IBlock)].ContainsKey(Direction))
            {
                commandDict[typeof(IBlock)][Direction].Execute();
            }
        }

        public void HandlePipeCollision(IPipe Pipe)
        {
            pipe = Pipe;
            CollisionDirection Direction = DetectCollisionDirection(item.Destination, Pipe.Destination);
            if (commandDict[typeof(IPipe)].ContainsKey(Direction))
            {
                commandDict[typeof(IPipe)][Direction].Execute();
            }
        }

    }
}
