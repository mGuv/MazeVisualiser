using ImageMagick;

namespace Core.Image.Magick
{
    /// <summary>
    /// Class responsible for getting Colours using ImageMagick
    /// </summary>
    public class ColourExtractor : IColorExtractor
    {
        /// <inheritdoc/>
        public Color[,] FromImage(string path)
        {
            MagickImage image = new MagickImage(path);
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