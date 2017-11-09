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
        Dictionary<Type, Dictionary<CollisionDirection, ICommand>> commandDict;

        public CollisionHandlerItem(IItem Item)
        {
            item = Item;
            commandDict = new Dictionary<Type, Dictionary<CollisionDirection, ICommand>>();
            commandDict.Add(typeof(IItem), new Dictionary<CollisionDirection, ICommand>());
            commandDict.Add(typeof(IBlock), new Dictionary<CollisionDirection, ICommand>());
            //commandDict[typeof(IBlock)].Add(CollisionDirection.Left, new ItemBlockTwoSide(this));
            //commandDict[typeof(IBlock)].Add(CollisionDirection.Right, new ItemBlockTwoSide(this));
            //commandDict[typeof(IBlock)].Add(CollisionDirection.Top, new ItemBlockTop(this));
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

    }
}
