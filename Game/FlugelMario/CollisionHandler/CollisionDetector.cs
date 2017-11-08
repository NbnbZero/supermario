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

       
        public static void AdjustObjectPosition(IGameObject firstObject, Rectangle anotherRectangle)
        {
            Rectangle marioDest = firstObject.Destination;
            CollisionDirection side = DetectCollisionDirection(marioDest, anotherRectangle);
            Vector2 adjustment = new Vector2();
            Rectangle overlap = Rectangle.Intersect(marioDest, anotherRectangle);
            switch (side)
            {
                case CollisionDirection.Left: adjustment.X = -overlap.Width; break;
                case CollisionDirection.Right: adjustment.X = overlap.Width; break;
                case CollisionDirection.Top: adjustment.Y = -overlap.Height; break;
                case CollisionDirection.Bottom: adjustment.Y = overlap.Height; break;

            }
        }


    }

}
