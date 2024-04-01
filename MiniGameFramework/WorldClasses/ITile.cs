namespace MiniGameFramework.WorldClasses
{
    public interface ITile
    {
        List<WorldObject> Contents { get; set; }
        int X { get; set; }
        int Y { get; set; }
    }
}