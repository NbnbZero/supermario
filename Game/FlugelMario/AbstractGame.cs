using Microsoft.Xna.Framework;
using SuperMairo.Interfaces;
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

        public static IGameState State { get; set; }
        public bool IsPause { get; set; } = false;
        public bool IsControllerEnable { get; set; } = true;
        public bool IsInAnimation { get; set; } = false;
    }
}
