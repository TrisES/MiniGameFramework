using System.Xml;

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
            InitializeTiles(width, height);
        }

        protected void InitializeTiles(int width, int height)
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

        /// <summary>
        /// Constructor that takes a xml config file path and creates a world based on the config file.
        /// </summary>
        /// <param name="configFilePath"></param>
        public World(string configFilePath) 
        {
            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException();
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(configFilePath);

            // Read Width
            int readWidth = 0;
            XmlNode? widthNode = doc.DocumentElement.SelectSingleNode("/World/Width");
            if (widthNode != null)
            {
                readWidth = int.Parse(widthNode.InnerText);
            }
            else
            {
                throw new XmlException("Width node not found in the config file.");
            }

            // Read Height
            int readHeight = 0;
            XmlNode? heightNode = doc.DocumentElement.SelectSingleNode("/World/Height");
            if (heightNode != null)
            {
                readHeight = int.Parse(heightNode.InnerText);
            }
            else
            {
                throw new XmlException("Height node not found in the config file.");
            }

            InitializeTiles(readWidth, readHeight);
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

        #region Update methods
        /// <summary>
        /// Updates the whole world. All objects in all tiles will be updated.
        /// </summary>
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

        /// <summary>
        /// Updates a part(an area) of the world. All objects in the tiles from startX to endX and startY to endY will be updated.
        /// </summary>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="endX"></param>
        /// <param name="endY"></param>
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

        /// <summary>
        /// Updates a part(single tile) of the world. All objects in the tile at x and y will be updated.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void UpdatePartOfWorld(int x, int y)
        {
            CheckBounds(x, y);

            foreach (WorldObject obj in TilesGrid[x, y].Contents)
            {
                obj.Update();
            }
        }
        #endregion
    }
}
