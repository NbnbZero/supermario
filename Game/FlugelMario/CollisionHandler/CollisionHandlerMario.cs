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
    public class CollisionHandlerMario
    {
        public IMario mario { get; private set; }
        public IBlock block { get; private set; }

       private IGameObject Obj { get; set; }
        Dictionary<Type, Dictionary<CollisionDirection, ICommand>> commandDict;

        public CollisionHandlerMario(IMario Mario)
        {
            mario = Mario;
            commandDict = new Dictionary<Type, Dictionary<CollisionDirection, ICommand>>();
            commandDict.Add(typeof(IBlock), new Dictionary<CollisionDirection, ICommand>());
            commandDict[typeof(IBlock)].Add(CollisionDirection.Left, new BlockStopMarioRunningCommand(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Right, new BlockStopMarioRunningCommand(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Top, new BlockMarioTopCollisionCommand(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Bottom, new BlockMarioBottomCommand(this));

            
        }

        public void HandleCollision(IGameObject incomingObject)
        {
            /*if(incomingObject is IBlock)
            {
                HandleBlockCollision((IBlock)incomingObject);
            }*/
        }


        public void HandleBlockCollision(IBlock Block)
        {
            block = Block;
            CollisionDirection Direction = DetectCollisionDirection(mario.Destination,block.Destination);

            if (commandDict[typeof(IBlock)].ContainsKey(Direction))                
                commandDict[typeof(IBlock)][Direction].Execute();

        }
    }
}
