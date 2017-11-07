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
        public static float GoombaBounceVelocity { get; } = 3.5f;
        public static float MarioCriticalSpeed { get; } = .75f;
        public static float MarioAccel { get; } = 2.5f;

        public static int StationaryVelocity { get; } = 0;
         
        public static float BrickBlockFallingSpeed { get; } = 0.5f;
        public static float CoinGravity { get; } = 0.1f;
        public static float CoinInitialVelocity { get; } = -1.5f;

        public static int SinglePixel { get; } = 1;


    }
}
