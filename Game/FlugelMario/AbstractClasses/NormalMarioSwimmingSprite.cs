using SuperMario.AbstractClasses;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario;

namespace SuperMario.Sprites.Mario
{
   public abstract class NormalMarioSwimmingSprite : MarioSprite
    {
        private int _currentSwimmingFrame;
        private int _totalSwimmingFrame = MarioSpriteFactory.Instance.NormalMarioSpriteSwimmingSheetColumn;
        private int _swimmingFrameIncrement;
        private int _currentSwimmingDrawingFrame;
        private int _swimmingDrawingFrameDelay = 5;
        private int _baseFrame = 0;

        protected int CurrentSwimmingFrame { get => _currentSwimmingFrame; set => _currentSwimmingFrame = value; }
        protected int TotalSwimmingFrame { get => _totalSwimmingFrame; set => _totalSwimmingFrame = value; }
        protected int SwimmingFrameIncrement { get => _swimmingFrameIncrement; set => _swimmingFrameIncrement = value; }
        protected int CurrentSwimmingDrawingFrame { get => _currentSwimmingDrawingFrame; set => _currentSwimmingDrawingFrame = value; }


        protected NormalMarioSwimmingSprite(Texture2D texture) : base(texture)
        {
            CurrentSwimmingDrawingFrame = _baseFrame;
        }

        public override void Update()
        {
            CurrentSwimmingDrawingFrame++;
            if (CurrentSwimmingDrawingFrame == _swimmingDrawingFrameDelay)
            {
                CurrentSwimmingDrawingFrame = _baseFrame;
                if (CurrentSwimmingFrame == _baseFrame || CurrentSwimmingFrame == TotalSwimmingFrame - 1)
                {
                    SwimmingFrameIncrement *= -1;
                }
                CurrentSwimmingFrame += SwimmingFrameIncrement;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            base.Draw(spriteBatch, location);
        }
    }
}
