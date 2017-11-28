using SuperMario.Interfaces;
using SuperMario.Game_Controllers;
namespace SuperMario.Commands
{
    class ReleaseSwimUpCommand:ICommand
    {
        private IMario mario;
        KeyboardControls key;
        public ReleaseSwimUpCommand()
        {
        }

        public void Execute()
        {
            key.AllowSwimUp = true;
        }
    }
}
