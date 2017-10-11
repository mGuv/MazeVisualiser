using System.Collections.Generic;

namespace Core.Image
{
    public class MapFactory
    {
        private readonly IColorExtractor colorExtractor;
        private readonly HashSet<Color> blackList;
        private readonly Coordinate[] neighbours;

        public MapFactory(IColorExtractor colorExtractor, HashSet<Color> blackList, Coordinate[] neighbours)
        {
            this.colorExtractor = colorExtractor;
            this.blackList = blackList;
            this.neighbours = neighbours;
        }
        
        public Map Create(string fileName)
        {
            Color[,] colors = this.colorExtractor.FromImage(fileName);
            HashSet<Coordinate> traversable = this.createTraversable(colors);
            
            return new Map(traversable, this.neighbours);

        }

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