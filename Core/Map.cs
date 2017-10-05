using System.Collections.Generic;

namespace Core
{
    public class Map
    {
        private HashSet<Coordinate> traversable;
        private Coordinate[] neighbours;
        
        public Map(HashSet<Coordinate> traversable, Coordinate[] neighbours)
        {
            this.traversable = traversable;
            this.neighbours = neighbours;
        }

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