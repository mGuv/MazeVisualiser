using System.Collections.Generic;
using ImageMagick;

namespace Core.Image.Magick
{
    public class ColourExtractor : IColorExtractor
    {
        public Color[,] FromFile(string filename)
        {
            MagickImage image = new MagickImage(filename);
            IPixelCollection pixels = image.GetPixels();

            Color[,] colors = new Color[image.Width,image.Height];

            foreach (Pixel pixel in pixels)
            {
                colors[pixel.X, pixel.Y] = new Color(pixel.GetChannel(0), pixel.GetChannel(1), pixel.GetChannel(2));
            }
            return colors;
        }
    }
}