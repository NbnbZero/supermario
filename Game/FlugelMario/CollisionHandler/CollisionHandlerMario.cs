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
    public class CollisionHandlerMario: ICollisionHandler
    {
        public IMario mario { get; private set; }
        public IBlock block { get; private set; }
        public IPipe pipe { get; private set; }
        public IEnemy enemy { get; private set; }
        public IItem item { get; private set; }
        Dictionary<Type, Dictionary<CollisionDirection, ICommand>> commandDict;

        public CollisionHandlerMario(IMario Mario)
        {
            mario = Mario;
            commandDict = new Dictionary<Type, Dictionary<CollisionDirection, ICommand>>();

            commandDict.Add(typeof(IBlock), new Dictionary<CollisionDirection, ICommand>());
            commandDict.Add(typeof(IPipe), new Dictionary<CollisionDirection, ICommand>());
            commandDict.Add(typeof(IEnemy), new Dictionary<CollisionDirection, ICommand>());
            commandDict.Add(typeof(IItem), new Dictionary<CollisionDirection, ICommand>());

            commandDict[typeof(IBlock)].Add(CollisionDirection.Left, new MarioBlockTwoSide(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Right, new MarioBlockTwoSide(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Top, new MarioBlockTop(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Bottom, new MarioBlockBottom(this));

            commandDict[typeof(IEnemy)].Add(CollisionDirection.Left, new MarioEnemyTwoSideBottom(this));
            commandDict[typeof(IEnemy)].Add(CollisionDirection.Right, new MarioEnemyTwoSideBottom(this));
            commandDict[typeof(IEnemy)].Add(CollisionDirection.Top, new MarioEnemyTop(this));
            commandDict[typeof(IEnemy)].Add(CollisionDirection.Bottom, new MarioEnemyTwoSideBottom(this));

            commandDict[typeof(IPipe)].Add(CollisionDirection.Left, new MarioPipeTwoSide(this));
            commandDict[typeof(IPipe)].Add(CollisionDirection.Right, new MarioPipeTwoSide(this));
            commandDict[typeof(IPipe)].Add(CollisionDirection.Top, new MarioPipeTop(this));

            commandDict[typeof(IItem)].Add(CollisionDirection.Left, new MarioItemCollision(this));
            commandDict[typeof(IItem)].Add(CollisionDirection.Right, new MarioItemCollision(this));
            commandDict[typeof(IItem)].Add(CollisionDirection.Top, new MarioItemCollision(this));
            commandDict[typeof(IItem)].Add(CollisionDirection.Bottom, new MarioItemCollision(this));
        }
        
        public void HandleEnemyCollision(IEnemy Enemy)
        {
            enemy = Enemy;
            CollisionDirection Direction = DetectCollisionDirection(mario.Destination, enemy.Destination);
            if (commandDict[typeof(IEnemy)].ContainsKey(Direction))
                commandDict[typeof(IEnemy)][Direction].Execute();

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

        public void HandleItemCollision(IItem Item)
        {
            item=Item;
            CollisionDirection Direction = DetectCollisionDirection(mario.Destination, item.Destination);

            if (commandDict[typeof(IItem)].ContainsKey(Direction))
                commandDict[typeof(IItem)][Direction].Execute();
        }
    }
}
