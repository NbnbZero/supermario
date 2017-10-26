using SuperMario.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Interfaces
{
    public abstract class Sprite
    {

        #region Variables

        private Rectangle _collisionRectangle;
        private Texture2D _collisionBoundary;
        private Rectangle _destination;
        private Vector2 _location;
        private Color _color;
        private int _height;
        private int _width;
        private Rectangle _sourceRectangle;
        private int _currentFrame;
        private int _totalFrames;
        private int _textureX;
        private int _textureY;
        private int _counter;
        private bool _bumped;

        private bool alive = false;
        private bool canCollide;

        #endregion

        #region Properties

        public Rectangle CollisionRectangle { get => _collisionRectangle; set => _collisionRectangle = value; }
        public Texture2D CollisionBoundary { get => _collisionBoundary; set => _collisionBoundary = value; }
        public Rectangle Destination { get => _destination; set => _destination = value; }
        public Vector2 Location { get => _location; set => _location = value; }
        public Color Color { get => _color; set => _color = value; }
        public int Height { get => _height; set => _height = value; }
        public int Width { get => _width; set => _width = value; }

        protected Texture2D Texture { get; set; }
        protected Rectangle SourceRectangle { get => _sourceRectangle; set => _sourceRectangle = value; }
        protected int CurrentFrame { get => _currentFrame; set => _currentFrame = value; }
        protected int TotalFrames { get => _totalFrames; set => _totalFrames = value; }
        protected int TextureX { get => _textureX; set => _textureX = value; }
        protected int TextureY { get => _textureY; set => _textureY = value; }
        protected int Counter { get => _counter; set => _counter = value; }
        public bool Alive { get => alive; set => alive = value; }
        public bool CanCollide { get => canCollide; set => canCollide = value; }

        #endregion

        // TODO: Only make it so there's 1 constructor
        #region Constructors

        protected Sprite(Texture2D texture)
        {
            Texture = texture;
            Counter = 0;
            CurrentFrame = 0;
            CanCollide = true;
        }

        protected Sprite(Texture2D texture, Vector2 location)
        {
            Texture = texture;
            Location = location;
            Counter = 0;
            CurrentFrame = 0;
            CanCollide = true;
        }

        #endregion

        #region Public Methods

       
        public virtual void Update() { }

        // TODO: Remove location as param
        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            SourceRectangle = new Rectangle((TextureX + CurrentFrame) * Width, TextureY * Height, Width, Height);
            Destination = MakeDestinationRectangle(Location);

            UpdateCollisionBoundary(Destination);

            if (spriteBatch != null)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                spriteBatch.Draw(CollisionBoundary, destinationRectangle: CollisionRectangle, layerDepth: 0.01f, color: Color);
                spriteBatch.Draw(Texture, position: Location, sourceRectangle: SourceRectangle, layerDepth: 0.1f);
#pragma warning restore CS0618 // Type or member is obsolete
            }

            if (_bumped)
            {
                _location.Y += 2;
                _bumped = false;
            }
        }

        public virtual Rectangle MakeDestinationRectangle(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, Width, Height);
        }

        public void BumpUp()
        {
            _location.Y -= 2;
            _bumped = true;
        }

        public virtual void RespondToCollision(CollisionDirection direction) { }

        #endregion

        #region Protected Methods

        protected void UpdateCollisionBoundary(Rectangle destinationRectangle)
        {
            var center = new Point(destinationRectangle.X, destinationRectangle.Y);
            CollisionRectangle = new Rectangle(center, new Point(Width, Height));
            CollisionBoundary = new Texture2D(Texture.GraphicsDevice, CollisionRectangle.Width, CollisionRectangle.Height);

            Color[] data = new Color[CollisionRectangle.Width * CollisionRectangle.Height];
            for (int i = 0; i < data.Length; ++i) data[i] = Color;
            CollisionBoundary.SetData(data);
        }

        protected void Animate()
        {
            Destination = MakeDestinationRectangle(Location);
            if (Counter % 10 == 0)
            {
                CurrentFrame++;
                CurrentFrame = CurrentFrame % TotalFrames;
                Counter = 0;
            }
            Counter++;
        }

        #endregion
    }
}
