using System;

namespace TowerDefence.Input
{
    public interface IEntitySelectInputService : IInputService
    {
        event Action<int> OnEntitySelectButton;
    }
}
