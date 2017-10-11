using System.Collections.Generic;

namespace Core.Image
{
    /// <summary>
    /// Class responsible for creating Usable Maps
    /// </summary>
    public class MapFactory
    {
        /// <summary>
        /// The Colur Extractor to get Colours from Images
        /// </summary>
        private readonly IColorExtractor colorExtractor;
        
        /// <summary>
        /// The set of Colours that are deemed impassable
        /// </summary>
        private readonly HashSet<Color> blackList;
        
        /// <summary>
        /// The neighbouring Coordinates the map may move between from a given Coordinate
        /// </summary>
        private readonly Coordinate[] neighbours;

        /// <summary>
        /// Creates a new Map Factory with the given Dependencies
        /// </summary>
        /// <param name="colorExtractor">The Extractor to get Colours from</param>
        /// <param name="blackList">The set of colours that cannot be traversed</param>
        /// <param name="neighbours">The coordinate offsets that can be reached from a given coordinate</param>
        public MapFactory(IColorExtractor colorExtractor, HashSet<Color> blackList, Coordinate[] neighbours)
        {
            this.colorExtractor = colorExtractor;
            this.blackList = blackList;
            this.neighbours = neighbours;
        }
        
        /// <summary>
        /// Creates a new Map of the given File
        /// </summary>
        /// <param name="fileName">The path to the file to create a map for</param>
        /// <returns>The created Map</returns>
        public Map Create(string fileName)
        {
            Color[,] colors = this.colorExtractor.FromImage(fileName);
            HashSet<Coordinate> traversable = this.createTraversable(colors);
            
            return new Map(traversable, this.neighbours);

        }

        /// <summary>
        /// Creates a set of passable coordinates from a 2D array of colours
        /// </summary>
        /// <param name="colors">The full set of Colours to scan</param>
        /// <returns>A set of passable coordinates</returns>
        private HashSet<Coordinate> createTraversable(Color[,] colors)
        {
            HashSet<Coordinate> traversable = new HashSet<Coordinate>();
            
            for (int x = 0; x < colors.GetLength(0); x++)
            {
                for (int y = 0; y < colors.GetLength(1); y++)
                {
                    if (this.blackList.Contains(colors[x, y]))
                    {
                        continue;
                    }

                    traversable.Add(new Coordinate(x, y));
                }
            }

            return traversable;
        }
    }
}