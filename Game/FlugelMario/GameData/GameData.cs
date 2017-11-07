using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public static class GameData
    {
        public static int MarioJumpingSpeed = -8;
        public static float Gravity { get; } = .48f;
        public static float GoombaSpeed { get; } = .75f;
        public static float MarioCriticalSpeed { get; } = .75f;
        public static float MarioAccel { get; } = 2.5f;

    }
}
