using SuperMario.AbstractClasses;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FlugelMario;

namespace SuperMario.Sprites.Mario
{
   public abstract class MarioRunningSprite : MarioSprite
    {
        private int _currentRunningFrame;
        private int _totalRunningFrame = MarioSpriteFactory.Instance.NormalMarioSpriteRunningSheetColumn;
        private int _runningFrameIncrement;
        private int _currentRunningDrawingFrame;
        private int _runningDrawingFrameDelay = 5;
        private int _baseFrame = 0;

        protected int CurrentRunningFrame { get => _currentRunningFrame; set => _currentRunningFrame = value; }
        protected int TotalRunningFrame { get => _totalRunningFrame; set => _totalRunningFrame = value; }
        protected int RunningFrameIncrement { get => _runningFrameIncrement; set => _runningFrameIncrement = value; }
        protected int CurrentRunningDrawingFrame { get => _currentRunningDrawingFrame; set => _currentRunningDrawingFrame = value; }


        protected MarioRunningSprite(Texture2D texture) : base(texture)
        {
            CurrentRunningDrawingFrame = _baseFrame;
        }

        public override void Update()
        {
            CurrentRunningDrawingFrame++;
            if (CurrentRunningDrawingFrame == _runningDrawingFrameDelay)
            {
                CurrentRunningDrawingFrame = _baseFrame;
                if (CurrentRunningFrame == _baseFrame || CurrentRunningFrame == TotalRunningFrame - 1)
                {
                    RunningFrameIncrement *= -1;
                }
                CurrentRunningFrame += RunningFrameIncrement;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            base.Draw(spriteBatch, location);
        }
    }
}
