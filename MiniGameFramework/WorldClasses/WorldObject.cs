namespace MiniGameFramework.WorldClasses
{
    public abstract class WorldObject : IWorldObject
    {
        public string Name { get; set; }
        public Tile? CurrentTile { get; set; }

        public WorldObject(string name)
        {
            Name = name;
        }

        public abstract void Update();
    }
}