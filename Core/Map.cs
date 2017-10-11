using System.Collections.Generic;

namespace Core
{
    /// <summary>
    /// Class that represents a traversable 2D area
    /// </summary>
    public class Map
    {
        /// <summary>
        /// The internal set of what exact Coordinates are traversable
        /// </summary>
        private HashSet<Coordinate> traversable;
        
        /// <summary>
        /// The set of Coordinate offsets that can be reached from any given Coordinate
        /// </summary>
        private Coordinate[] neighbours;
        
        /// <summary>
        /// Creates a new map with the given data
        /// </summary>
        /// <param name="traversable">The internal map of traversable coordinates</param>
        /// <param name="neighbours">The coordinate offsets that can be reached in this map</param>
        public Map(HashSet<Coordinate> traversable, Coordinate[] neighbours)
        {
            this.traversable = traversable;
            this.neighbours = neighbours;
        }

        /// <summary>
        /// Takes a given Coordinate and enumerates through all the traversable areas around it
        /// </summary>
        /// <param name="location">The coordinate to search around</param>
        /// <returns>The set of traversable coordinates</returns>
        public IEnumerable<Coordinate> Expand(Coordinate location)
        {
            foreach (Coordinate neighbour in this.neighbours)
            {
                Coordinate current = new Coordinate(location.X + neighbour.X, location.Y + neighbour.Y);
                if (this.traversable.Contains(current))
                {
                    yield return current;
                }
            }
        }
    }
}