using Microsoft.Xna.Framework;
using SuperMario.Game_Controllers;
using SuperMario.Interfaces;

namespace SuperMario.Commands
{
    class SwimUpCommand:ICommand
    {
        private IMario mario;
        KeyboardControls key;
        public SwimUpCommand(IMario Mario)
        {
            mario = Mario;
        }

        public void Execute()
        {
            mario.Velocity = new Vector2(mario.Velocity.X, 3);
            key.AllowSwimUp = false;
        }
    }
}
