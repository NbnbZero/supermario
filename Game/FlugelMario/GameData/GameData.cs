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

        public static int MarioJumpingSpeed = -7;
        public static float Gravity { get; } = .5f;
        public static float GoombaSpeed { get; } = .75f;
        public static float MarioCriticalSpeed { get; } = .75f;
        public static float MarioAccel { get; } = .25f;

    }
}
