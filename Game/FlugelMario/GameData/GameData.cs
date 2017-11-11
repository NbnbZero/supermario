using SuperMario.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public static class GameData
    {
        // just in case we forget these data
        public static AbstractGame Game { get; set; }
        public static GameObjectManager GameObjectManager { get; set; }

        public static int MarioJumpingSpeed = -8;
        public static float Gravity { get; } = 0.4f;
        public static float GoombaSpeed { get; } = .75f;
        public static float MarioCriticalSpeed { get; } = .75f;
        public static float MarioAccel { get; } = .25f;

        public static int collisionDisplacement { get; } = 3;

        public static int marioBouncingSpeed { get; } = -2;
    }
}
