using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public abstract class AbstractGame : Game
    {
        private GraphicsDeviceManager graphics;

        public GraphicsDeviceManager GraphicsManager
        {
            get
            {
                return graphics;
            }
            set
            {
                this.graphics = value;
            }
        }
    }
}
