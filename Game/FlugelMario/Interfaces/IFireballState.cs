using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.States;

namespace SuperMario.Interfaces
{
    public interface IFireballState
    {
        void Explode();
        void Update();
        void shoot(Vector2 Location, Vector2 direction);
        void draw(SpriteBatch batch);        
    }
}
