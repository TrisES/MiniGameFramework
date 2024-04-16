using MiniGameFramework.MarkerInterfaces;

namespace MiniGameFramework.WorldClasses
{
    public interface IWorldObject : IHasName
    {
        Tile? CurrentTile { get; set; }

        //void Update();
    }
}