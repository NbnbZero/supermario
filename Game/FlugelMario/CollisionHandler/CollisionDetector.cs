using SuperMario.Interfaces;
using SuperMario.Enums;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class CollisionDetector
    {
        public static CollisionDirection DetectCollisionDirection(Rectangle firstObject, Rectangle secondObject)
        {
            Rectangle overlap = Rectangle.Intersect(firstObject, secondObject);
            if (!overlap.IsEmpty)
            {
                if (overlap.Height > overlap.Width && firstObject.X < secondObject.X)
                {
                    return CollisionDirection.Left;
                }
                if (overlap.Height > overlap.Width && firstObject.X > secondObject.X)
                {
                    return CollisionDirection.Right;
                }
                if (overlap.Width > overlap.Height && firstObject.Y < secondObject.Y)
                {
                    return CollisionDirection.Top;
                }
                if (overlap.Width > overlap.Height && firstObject.Y > secondObject.Y)
                {
                    return CollisionDirection.Bottom;
                }
            }
            return CollisionDirection.NoCollision;
        }
        private static CollisionDirection DetermineBorderOrNoCollisionSide(Rectangle obj1Dest, Rectangle obj2Dest)
        {
            CollisionDirection side = CollisionDirection.NoCollision;
            if (obj1Dest.Y + obj1Dest.Height == obj2Dest.Y && HasHorizontalIntersection(obj1Dest, obj2Dest))
            {
                side = CollisionDirection.Top;
            }
            else if (obj1Dest.Y == obj2Dest.Y + obj2Dest.Height && HasHorizontalIntersection(obj1Dest, obj2Dest))
            {
                side = CollisionDirection.Bottom;
            }
            else if (obj1Dest.X + obj1Dest.Width == obj2Dest.X && HasVerticalIntersection(obj1Dest, obj2Dest))
            {
                side = CollisionDirection.Left;
            }
            else if (obj1Dest.X == obj2Dest.X + obj2Dest.Width && HasVerticalIntersection(obj1Dest, obj2Dest))
            {
                side = CollisionDirection.Right;
            }
            return side;
        }
        private static bool HasHorizontalIntersection(Rectangle rect1, Rectangle rect2)
        {
            return rect1.X > rect2.X - rect1.Width + GameData.collisionDisplacement && rect1.X < rect2.X + rect2.Width - GameData.collisionDisplacement;
        }

        private static bool HasVerticalIntersection(Rectangle rect1, Rectangle rect2)
        {
            return rect1.Y > rect2.Y - rect1.Height + GameData.collisionDisplacement && rect1.Y < rect2.Y + rect2.Height - GameData.collisionDisplacement;
        }





    }

}
