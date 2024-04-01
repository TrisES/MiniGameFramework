namespace MiniGameFramework.WorldClasses
{
    public interface IWorldObject
    {
        Tile? CurrentTile { get; set; }
        string Name { get; set; }

        void Update();
    }
}