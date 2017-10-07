using System;
using System.Collections.Generic;
using Core.Image;
using Core.Image.Magick;
using Core.Solving;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = args[0];
            
            HashSet<Color> blackList = new HashSet<Color>();
            blackList.Add(new Color(0, 0, 0));
            
            Coordinate[] neighbours = new Coordinate[4]
            {
                new Coordinate(0, 1),
                new Coordinate(1, 0),
                new Coordinate(0, -1),
                new Coordinate(-1, 0)
            };
            
            MapFactory factory = new MapFactory(new TextureFactory(new ColourExtractor()), blackList, neighbours);
            
            Solver solver = new Solver();
            Coordinate[] output = solver.Expand(factory.Create(inputFile), new Coordinate(0, 0));

            Visualiser visualiser = new Visualiser();
            string outputGif = visualiser.CreateGif(inputFile, output, 10, 10);
            Console.WriteLine("yo there's a gif at: " + outputGif);
        }
    }
}
