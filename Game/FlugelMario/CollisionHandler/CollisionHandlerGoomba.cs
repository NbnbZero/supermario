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
    public class CollisionHandlerGoomba
    {
        public Goomba goomba1 { get; private set; }
        public Goomba goomba2 { get; private set; }
        public Koopa koopa1 { get; private set; }

        Dictionary<Type, Dictionary<CollisionDirection, ICommand>> commandDict;

        public CollisionHandlerGoomba(Goomba goomba)
        {
            goomba1 = goomba;
            commandDict = new Dictionary<Type, Dictionary<CollisionDirection, ICommand>>();
            commandDict.Add(typeof(Goomba), new Dictionary<CollisionDirection, ICommand>());
            commandDict[typeof(Goomba)].Add(CollisionDirection.Left, new GoombaGoombaCollisionLeft(this));
            commandDict[typeof(Goomba)].Add(CollisionDirection.Right, new GoombaGoombaCollisionRight(this));
            commandDict[typeof(Goomba)].Add(CollisionDirection.Top, new GoombaGoombaCollisionTop(this));
            commandDict[typeof(Goomba)].Add(CollisionDirection.Bottom, new GoombaGoombaCollisionBottom(this));
            commandDict[typeof(Koopa)].Add(CollisionDirection.Left, new GoombaKoopaCollisionLeft(this));
            commandDict[typeof(Koopa)].Add(CollisionDirection.Right, new GoombaKoopaCollisionRight(this));
            commandDict[typeof(Koopa)].Add(CollisionDirection.Top, new GoombaKoopaCollisionTop(this));
            commandDict[typeof(Koopa)].Add(CollisionDirection.Bottom, new GoombaKoopaCollisionBottom(this));
        }

        public void HandleGoombaCollision(Goomba goomba)
        {
            goomba2 = goomba;
            CollisionDirection Direction = DetectCollisionDirection(goomba1.Destination,goomba2.Destination);

            if (commandDict[typeof(Goomba)].ContainsKey(Direction))
            {
                commandDict[typeof(Goomba)][Direction].Execute();
            }
        }

        public void HandlerKoopaCollision(Koopa koopa)
        {
            koopa1 = koopa;
            CollisionDirection Direction = DetectCollisionDirection(goomba1.Destination, koopa1.Destination);

            if (commandDict[typeof(Koopa)].ContainsKey(Direction))
            {
                commandDict[typeof(Koopa)][Direction].Execute();
            }
        }

    }
}
