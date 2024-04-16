namespace MiniGameFramework.WorldClasses
{
    /// <summary>
    /// Represents a single tile in the game world.
    /// </summary>
    public class Tile : ITile
    {
        /// <summary>
        /// The X coordinate of the tile.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The Y coordinate of the tile.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// The contents of the tile. This can be a list of any objects that implement IWorldObject.
        /// </summary>
        public List<IWorldObject> Contents { get; set; } // TODO: burde gøre den privat og tilføje metoder til at tilføje og fjerne objekter (e.g. ala repository pattern)

        /// <summary>
        /// Creates a new tile with the specified coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Tile(int x, int y)
        {
            X = x;
            Y = y;
            Contents = new List<IWorldObject>();
        }

        /// <summary>
        /// Checks if the tile is empty.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Contents.Count == 0;
        }

        /// <inheritdoc/>
        public void AddObject(IWorldObject obj)
        {
            Contents.Add(obj);
            obj.CurrentTile = this;
        }

        /// <inheritdoc/>
        public bool RemoveObject(IWorldObject obj)
        {
            if (Contents.Contains(obj))
            {
                Contents.Remove(obj);
                obj.CurrentTile = null;
                return true;
            }
            return false;
        }
    }
}
