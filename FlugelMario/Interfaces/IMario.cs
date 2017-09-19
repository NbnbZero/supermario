using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlugelMario.Interfaces
{
    interface IMario
    {
        IMarioState State { get; set; }
        Vector2 Location { get; set; }
        void TakeDamage();
        void Update();
        void Draw(SpriteBatch spriteBatch);
        void CorrectLocation(bool bigState, bool crouchingState);
    }
}
