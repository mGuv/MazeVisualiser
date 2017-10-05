using System.Collections.Generic;

namespace Core.Image
{
    public class MapFactory
    {
        private readonly TextureFactory textureFactory;
        private readonly HashSet<Color> blackList;
        private readonly Coordinate[] neighbours;

        public MapFactory(TextureFactory textureFactory, HashSet<Color> blackList, Coordinate[] neighbours)
        {
            this.textureFactory = textureFactory;
            this.blackList = blackList;
            this.neighbours = neighbours;
        }
        
        public Map Create(string fileName)
        {
            Texture texture = this.textureFactory.Create(fileName);
            HashSet<Coordinate> traversable = this.createTraversable(texture);
            
            return new Map(traversable, this.neighbours);

        }

        private HashSet<Coordinate> createTraversable(Texture texture)
        {
            HashSet<Coordinate> traversable = new HashSet<Coordinate>();
            
            for (int x = 0; x < texture.Width; x++)
            {
                for (int y = 0; y < texture.Height; y++)
                {
                    if (this.blackList.Contains(texture.GetPixel(x, y)))
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