namespace MiniGameFramework.WorldClasses
{
    public class Tile : ITile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<WorldObject> Contents { get; set; }

        public Tile(int x, int y)
        {
            X = x;
            Y = y;
            Contents = new List<WorldObject>();
        }

        public bool IsEmpty()
        {
            return Contents.Count == 0;
        }
    }
}
