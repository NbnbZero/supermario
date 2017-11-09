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
        public IPipe pipe { get; private set; }

        private IGameObject Obj { get; set; }
        Dictionary<Type, Dictionary<CollisionDirection, ICommand>> commandDict;

        public CollisionHandlerMario(IMario Mario)
        {
            mario = Mario;
            commandDict = new Dictionary<Type, Dictionary<CollisionDirection, ICommand>>();

            commandDict.Add(typeof(IBlock), new Dictionary<CollisionDirection, ICommand>());
            commandDict.Add(typeof(IPipe), new Dictionary<CollisionDirection, ICommand>());

            commandDict[typeof(IBlock)].Add(CollisionDirection.Left, new MarioBlockTwoSide(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Right, new MarioBlockTwoSide(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Top, new MarioBlockTop(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Bottom, new MarioBlockBottom(this));

            commandDict[typeof(IPipe)].Add(CollisionDirection.Left, new MarioPipeTwoSide(this));
            commandDict[typeof(IPipe)].Add(CollisionDirection.Right, new MarioPipeTwoSide(this));
            commandDict[typeof(IPipe)].Add(CollisionDirection.Top, new MarioPipeTop(this));


        }

        public void HandlePipeCollision(IPipe Pipe)
        {
            pipe = Pipe;
            CollisionDirection Direction = DetectCollisionDirection(mario.Destination, pipe.Destination);
            if (commandDict[typeof(IPipe)].ContainsKey(Direction))
                commandDict[typeof(IPipe)][Direction].Execute();

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
