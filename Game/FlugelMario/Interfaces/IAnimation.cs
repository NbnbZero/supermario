using SuperMario.Enums;
namespace SuperMario.Interfaces
{
      public interface IAnimation
      {
          void Update();
          AnimationState State { get; set; }
      }
}
