namespace SuperMario.Interfaces
{
    public interface IItem : IGameObject
    {
        bool IsCollected { get; set; }
        void Collect();
    }
}