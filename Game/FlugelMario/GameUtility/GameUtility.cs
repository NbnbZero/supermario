using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public static class GameUtility
    {
        public static int MarioJumpingSpeed = -8;
        public static float gravity = 0.5f;
        public static int MarioSprintSpeed = 4;
        public static float MarioRegularSpeed = 2.5f;
        public static float Gravity { get; } = .48f;
        public static float GoombaSpeed { get; } = .75f;
        public static float GoombaBounceVelocity { get; } = 3.5f;



    }
}
