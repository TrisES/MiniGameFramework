namespace MiniGameFramework.WorldClasses
{
    public interface ITile
    {
        List<IWorldObject> Contents { get; set; }
        int X { get; set; }
        int Y { get; set; }

        /// <summary>
        /// Adds a world object to the tile, and sets the object's CurrentTile property to this tile.
        /// </summary>
        /// <param name="obj"></param>
        void AddObject(IWorldObject obj);

        /// <summary>
        /// Removes a world object from the tile, and sets the object's CurrentTile property to null.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if it was removed; Otherwise, False</returns>
        bool RemoveObject(IWorldObject obj);
    }
}