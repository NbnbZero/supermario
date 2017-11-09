using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario;
using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuperMario.GameObjects.GameObjectType;

namespace FlugelMario.GameObjects.PipeGameObjects
{
    class LPipeTopLeft : IPipe
    {
        private ISprite sprite;
        public ObjectType Type { get; } = ObjectType.Pipe;
        public Vector2 Location { get; set; }
        public Rectangle Destination { get; set; }

        public LPipeTopLeft(Vector2 location)
        {
            sprite = PipeSpriteFactory.Instance.CreateLPipeTopLeftSprite();
            Location = location;
            Destination = sprite.MakeDestinationRectangle(Location);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.Location);
        }

        public void Warp(IMario mario)
        {
        }

        public void Update()
        {
            Destination = sprite.MakeDestinationRectangle(Location);
            sprite.Update();
        }
    }
}
