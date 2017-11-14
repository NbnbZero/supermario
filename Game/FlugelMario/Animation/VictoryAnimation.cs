using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using SuperMario.Enums;
using SuperMario.Heads_Up;
using SuperMario.SpriteFactories;
using SuperMario.Sound;

namespace SuperMario.Animation
{
    public class VictoryAnimation : IAnimation
    {
        public AnimationState State { get; set; } = AnimationState.ToBegin;

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
            flag_.Location= new Vector2(flag_.Location.X, mario_.Location.Y);
            mario_.Acceleration = new Vector2(0, 0);
            mario_.Velocity = new Vector2(0, 1);
            SoundManager.Instance.PlayFlagSong();
            flag_.Velocity = new Vector2(0, 1);
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
                    if (!mario_.IsInAir)
                    {
                        mario_.Velocity = new Vector2(0, 0);
                        mario_.Acceleration = new Vector2(0, GameData.Gravity);
                    }
                    if (flag_.Location.Y >= GameData.flagPoleBottomY)
                    {
                        flag_.Velocity = new Vector2(0, 0);
                        flag_.Location = new Vector2(flag_.Location.X, GameData.flagPoleBottomY);
                    }

                    if (!mario_.IsInAir&&flag_.Location.Y == GameData.flagPoleBottomY)
                    {
                        stage++;
                    }
                    break;
                case stage2:
                    mario_.State.RunRight();
                    if (mario_.Destination.X >= 215 * 16)
                    {
                        mario_.State.RunLeft();
                        mario_.State.StateSprite = ItemSpriteFactory.Instance.CreateDisappearedSprite();
                        stage++;
                    }
                    break;
                case stage3:
                    if (MarioInfo.Time == minTime)
                    {
                        stage++;
                    }
                    else
                    {
                        counter++;
                        if (counter == maxCount)
                        {
                            ScoringSystem.AddPointsForRestTime();
                            MarioInfo.Time--;
                            counter = minCount;
                        }
                    }
                    break;
                default:            
                    if (Game1.State.Type == GameStates.LevelComplete)
                    {
                       Game1.State.Proceed(); 
                    }
                    break;                 
            }
        }
    }
}
