using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using SuperMario.Enums;
using SuperMario.SCsystem;
using SuperMario.SpriteFactories;
using SuperMario.Sound;

namespace SuperMario.Animation
{
    public class TransitionAnimation : IAnimation
    {
        public AnimationState State { get; set; } = AnimationState.ToBegin;

        private IMario mario_;
        private int stage = 1;
        private const int stage1 = 1;
        private const int stage2 = 2;
        private const int stage3 = 3;


        public TransitionAnimation(IMario mario)
        {
            this.mario_ = mario;
            mario_.Acceleration = new Vector2(0, 0);
            mario_.Velocity = new Vector2(1, 0);
        }

        public void Update()
        {
            if (State != AnimationState.IsPlaying)
            {
                return;
            }

            switch (stage)
            {
                case stage1:
                    mario_.Velocity = new Vector2(1, 0);
                    break;
                default:
                    if (Game1.State.Type == GameStates.LevelComplete && this.mario_.IsLevel2)
                    {
                       //Game1.State.Proceed();
                    }
                    break;
            }
        }
    }
}
