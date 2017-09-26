using FlugelMario.Enums;
using FlugelMario.Interfaces;
using FlugelMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FlugelMario.AbstractClasses.BlockState;

namespace FlugelMario.Sprites.Blocks
{
    class BrickBlockSprite:ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }
        public BlockType BlockType { get; set; }
        public InputState State { get; set; }

        private Rectangle sourceRectangle;
        private int BrickBlockWtidth = BlockSpriteFactory.Instance.BrickBlockWidth;
        private int BrickBlockHeight = BlockSpriteFactory.Instance.BrickBlockHeight;
        private int TextureX = (int)BlockSpriteFactory.Instance.BrickBlockAnimation1.X;
        private int TextureY = (int)BlockSpriteFactory.Instance.BrickBlockAnimation1.Y;
        private int currentFrame;
        private int TotalFrames = BlockSpriteFactory.Instance.BrickBlockAnimeTotalFrame;
        private int counter = 0;
        private static Vector2 location;
        private InputState state;

        public BrickBlockSprite(Texture2D texture)
        {
            currentFrame = 0;
            this.Texture = texture;
            location = Location;
            state = State;
            BlockType = BlockType.Brick;
        }

        public void Update()
        {

            Destination = MakeDestinationRectangle(location);
            if (counter % 20 == 0)
            {
                currentFrame++;
                currentFrame = currentFrame % TotalFrames;
                counter = 0;
            }
            counter++;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sourceRectangle = new Rectangle((TextureX + currentFrame) * BrickBlockWtidth, TextureY * BrickBlockHeight, BrickBlockWtidth, BrickBlockHeight);
            Destination = MakeDestinationRectangle(location);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, Destination, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, BrickBlockWtidth, BrickBlockHeight);
        }
    }
}
