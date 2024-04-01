namespace MiniGameFramework.WorldClasses
{
    public class World : IWorld
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Tile[,] TilesGrid { get; set; }

        public World() { }
        public World(int width, int height)
        {
            Width = width;
            Height = height;
            TilesGrid = new Tile[Width, Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    TilesGrid[x, y] = new Tile(x, y);
                }
            }
        }
        private void CheckBounds(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public Tile GetTile(int x, int y)
        {
            CheckBounds(x, y);
            return TilesGrid[x, y];
        }

        public void AddObject(WorldObject obj, int x, int y)
        {
            CheckBounds(x, y);
            obj.CurrentTile = TilesGrid[x, y];
            TilesGrid[x, y].Contents.Add(obj);
        }

        public void RemoveObject(WorldObject obj)
        {
            obj.CurrentTile?.Contents.Remove(obj);
            obj.CurrentTile = null;
        }

        public void RemoveObject(WorldObject obj, int x, int y)
        {
            CheckBounds(x, y);
            obj.CurrentTile?.Contents.Remove(obj);
            obj.CurrentTile = TilesGrid[x, y];
            TilesGrid[x, y].Contents.Add(obj);
        }

        public void UpdateWorld()
        {
            foreach (Tile tile in TilesGrid)
            {
                foreach (WorldObject obj in tile.Contents)
                {
                    obj.Update();
                }
            }
        }

        public void UpdatePartOfWorld(int startX, int startY, int endX, int endY)
        {
            CheckBounds(startX, startY);
            CheckBounds(endX, endY);

            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    foreach (WorldObject obj in TilesGrid[x, y].Contents)
                    {
                        obj.Update();
                    }
                }
            }
        }

        public void UpdatePartOfWorld(int x, int y)
        {
            CheckBounds(x, y);

            foreach (WorldObject obj in TilesGrid[x, y].Contents)
            {
                obj.Update();
            }
        }
    }
}
