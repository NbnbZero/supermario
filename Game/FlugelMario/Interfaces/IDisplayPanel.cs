using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMairo.Interfaces
{
    public interface IDisplayPanel
    {
        bool IsEnable { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
