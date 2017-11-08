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

    }

}
