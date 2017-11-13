using Microsoft.Xna.Framework;
using SuperMairo.Interfaces;
using SuperMario.Enums;
using SuperMario.Interfaces;
using SuperMairo.HeadsUp;
using SuperMario.Heads_Up;
namespace SuperMario.Animation
{
    public class VictoryAnimation : IAnimation
    {
        public AnimationState State { get; set; } = AnimationState.NotStart;

        private IMario mario_;
        private IItem flag_;

        private int stage = 1;
        private int counter = 0;
        private int maxCount = 1;
        private const int stage1 = 1;
        private const int stage2 = 2;
        private const int stage3 = 3;
        private const int minTime = 0;
        private const int minCount = 0;


        public VictoryAnimation(IMario mario, IItem flag)
        {
            this.mario_ = mario;
            this.flag_ = flag;

            mario_.Acceleration = new Vector2(0, 0);
            mario_.Velocity = new Vector2(0, 0);
            //add sound
            flag_.Velocity = new Vector2(0, 0);
        }


        public void Update()
        {

        }
    }
}
