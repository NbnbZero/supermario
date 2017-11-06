using SuperMario.Enums;
namespace FlugelMario.Interfaces
{
      public interface IAnimation
      {
          void Update();
          AnimationState State { get; set; }
      }
}
