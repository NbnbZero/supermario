using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuperMario.GameObjects.GameObjectType;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.GameObjects
{
    public class BigPipe : IPipe
    {
        private ISprite sprite;
        public ObjectType Type { get; } = ObjectType.Pipe;
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }
        private bool canWarp = false;
        private Vector2 teleLocation;

        public BigPipe(Vector2 location)
        {
            sprite = PipeSpriteFactory.Instance.CreateBigPipeSprite();
            Location = location;
            Destination = sprite.MakeDestinationRectangle(Location);
        }

        public BigPipe(Vector2 location, Vector2 teleLocation)
        {
            sprite = PipeSpriteFactory.Instance.CreateBigPipeSprite();
            Location = location;
            Destination = sprite.MakeDestinationRectangle(Location);
            this.teleLocation = teleLocation;
            canWarp = true;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.Location);
        }

        public void Warp(IMario mario)
        {
            if (canWarp)
            {
                Camera.SetCamera(new Vector2(teleLocation.X - 16 * 3, -420));
                mario.Location = teleLocation;
            }
        }

        public void Update()
        {
            Destination = sprite.MakeDestinationRectangle(Location);
            sprite.Update();
        }
    }
}
