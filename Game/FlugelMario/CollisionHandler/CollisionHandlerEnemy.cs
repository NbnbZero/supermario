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
    public class CollisionHandlerEnemy: ICollisionHandler
    {
        public IEnemy enemy { get; private set; }
        public IEnemy another { get; private set; }
        public IBlock block { get; private set; }
        Dictionary<Type, Dictionary<CollisionDirection, ICommand>> commandDict;

        public CollisionHandlerEnemy(IEnemy Enemy)
        {
            enemy = Enemy;
            commandDict = new Dictionary<Type, Dictionary<CollisionDirection, ICommand>>();
            commandDict.Add(typeof(IEnemy), new Dictionary<CollisionDirection, ICommand>());
            commandDict.Add(typeof(IBlock), new Dictionary<CollisionDirection, ICommand>());
            commandDict[typeof(IEnemy)].Add(CollisionDirection.Left, new EnemyEnemyTwoSide(this));
            commandDict[typeof(IEnemy)].Add(CollisionDirection.Right, new EnemyEnemyTwoSide(this));
            commandDict[typeof(IEnemy)].Add(CollisionDirection.Top, new EnemyEnemyTop(this));

            commandDict[typeof(IBlock)].Add(CollisionDirection.Left, new EnemyBlockTwoSide(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Right, new EnemyBlockTwoSide(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Top, new EnemyBlockTop(this));
        }
        
        public void HandleEnemyCollision(IEnemy Another)
        {
            another = Another;
            CollisionDirection Direction = DetectCollisionDirection(enemy.Destination,another.Destination);

            if (commandDict[typeof(IEnemy)].ContainsKey(Direction))
            {
                commandDict[typeof(IEnemy)][Direction].Execute();
            }
        }

        public void HandleBlockCollision(IBlock Block)
        {
            block = Block;
            CollisionDirection Direction = DetectCollisionDirection(enemy.Destination, block.Destination);
            if (commandDict[typeof(IBlock)].ContainsKey(Direction))
            {
                commandDict[typeof(IBlock)][Direction].Execute();
            }
        }        

    }
}
