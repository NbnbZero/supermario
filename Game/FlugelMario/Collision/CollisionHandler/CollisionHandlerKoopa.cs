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
    public class CollisionHandlerKoopa
    {
        public Goomba goomba1 { get; private set; }
        public Koopa koopa1 { get; private set; }
        public Koopa koopa2 { get; private set; }
        public IBlock block { get; private set; }

        Dictionary<Type, Dictionary<CollisionDirection, ICommand>> commandDict;

        public CollisionHandlerKoopa(Koopa koopa)
        {
            koopa1 = koopa;
            commandDict = new Dictionary<Type, Dictionary<CollisionDirection, ICommand>>();
            commandDict.Add(typeof(Koopa), new Dictionary<CollisionDirection, ICommand>());
            commandDict[typeof(Goomba)].Add(CollisionDirection.Left, new KoopaGoombaCollisionLeft(this));
            commandDict[typeof(Goomba)].Add(CollisionDirection.Right, new KoopaGoombaCollisionRight(this));
            commandDict[typeof(Goomba)].Add(CollisionDirection.Top, new KoopaGoombaCollisionTop(this));
            commandDict[typeof(Goomba)].Add(CollisionDirection.Bottom, new KoopaGoombaCollisionBottom(this));
            commandDict[typeof(Koopa)].Add(CollisionDirection.Left, new KoopaKoopaCollisionLeft(this));
            commandDict[typeof(Koopa)].Add(CollisionDirection.Right, new KoopaKoopaCollisionRight(this));
            commandDict[typeof(Koopa)].Add(CollisionDirection.Top, new KoopaKoopaCollisionTop(this));
            commandDict[typeof(Koopa)].Add(CollisionDirection.Bottom, new KoopaKoopaCollisionBottom(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Left, new KoopaBlockCollisionLeft(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Right, new KoopaBlockCollisionRight(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Top, new KoopaBlockCollisionTop(this));
            commandDict[typeof(IBlock)].Add(CollisionDirection.Bottom, new KoopaBlockCollisionBottom(this));
        }

        public void HandleGoombaCollision(Goomba goomba)
        {
            goomba1 = goomba;
            CollisionDirection Direction = DetectCollisionDirection(koopa1.Destination,goomba1.Destination);

            if (commandDict[typeof(Goomba)].ContainsKey(Direction))
            {
                commandDict[typeof(Goomba)][Direction].Execute();
            }
        }

        public void HandlerKoopaCollision(Koopa koopa)
        {
            koopa2 = koopa;
            CollisionDirection Direction = DetectCollisionDirection(koopa1.Destination, koopa2.Destination);

            if (commandDict[typeof(Koopa)].ContainsKey(Direction))
            {
                commandDict[typeof(Koopa)][Direction].Execute();
            }
        }

        public void HandlerBlockCollision(IBlock Block)
        {
            block=Block;
            CollisionDirection Direction = DetectCollisionDirection(koopa1.Destination, block.Destination);

            if (commandDict[typeof(IBlock)].ContainsKey(Direction))
            {
                commandDict[typeof(IBlock)][Direction].Execute();
            }
        }

    }
}
