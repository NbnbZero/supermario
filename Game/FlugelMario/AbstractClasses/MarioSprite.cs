using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.AbstractClasses
{
    public abstract class MarioSprite : Sprite
    {
        public int MarioWidth { get; set; } = MarioSpriteFactory.Instance.NormalMarioWidth;
        public int MarioHeight { get; set; } = MarioSpriteFactory.Instance.NormalMarioHeight;

        public int BigMarioWidth { get; set; } = MarioSpriteFactory.Instance.BigMarioWidth;
        public int BigMarioHeight { get; set; } = MarioSpriteFactory.Instance.BigMarioHeight;

        // TODO: make it only 1 constructor
        #region Overloads

        protected MarioSprite(Texture2D texture) : base(texture)
        {
            // TODO: Maybe figure something better out.
            Height = MarioSpriteFactory.Instance.NormalMarioHeight;
            Width = MarioSpriteFactory.Instance.NormalMarioWidth;

            SourceRectangle = new Rectangle(0, 0, Width, Height);

            Color = Color.Yellow;
        }

        protected MarioSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {
            // TODO: Maybe figure something better out.
            Height = MarioSpriteFactory.Instance.NormalMarioHeight;
            Width = MarioSpriteFactory.Instance.NormalMarioWidth;

            SourceRectangle = new Rectangle(0, 0, Width, Height);

            Location = location;

            Color = Color.Yellow;
        }

        #endregion
        
        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            SourceRectangle = new Rectangle(SourceRectangle.X, SourceRectangle.Y + 1, Width, Height);
            Rectangle destinationRectangle = MakeDestinationRectangle(location);

            UpdateCollisionBoundary(destinationRectangle);
            
            if (spriteBatch != null)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                spriteBatch.Draw(CollisionBoundary, destinationRectangle: CollisionRectangle, layerDepth: 0.01f);
                spriteBatch.Draw(Texture, position: location, sourceRectangle: SourceRectangle, layerDepth: 0.1f, color: Color);
#pragma warning restore CS0618 // Type or member is obsolete
            }
        }
    }
}
