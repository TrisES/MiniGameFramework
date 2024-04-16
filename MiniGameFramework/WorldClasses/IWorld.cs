namespace MiniGameFramework.WorldClasses
{
    public interface IWorld
    {
        int Height { get; set; }
        Tile[,] TilesGrid { get; set; }
        int Width { get; set; }

        void AddObject(IWorldObject obj, int x, int y);
        Tile GetTile(int x, int y);
        void RemoveObject(IWorldObject obj);
    }
}