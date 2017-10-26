using ImageMagick;

namespace Core.Image.Magick
{
    public class Visualiser
    {
        public string CreateGif(string sourceFile, Coordinate[] expandedOrder, int fps, float length)
        {
            int totalFrames = (int) System.Math.Ceiling(length * fps);
            int pixelsPerFrame = (int) System.Math.Ceiling((double)(expandedOrder.Length / totalFrames));

            
            Color[] colors = {
                new Color(255, 0, 0),
                new Color(255, 127, 0),
                new Color(255, 255, 0),
                new Color(127, 255, 0),
                new Color(0, 255, 0),
                new Color(0, 255, 127),
                new Color(0, 255, 255),
                new Color(0, 127, 255),
                new Color(0, 0, 255),
                new Color(127, 0, 255),
                new Color(255, 0, 255),
                new Color(255, 0, 127) 
            };
            

            Gradient gradient = new Gradient(colors);
            
            
            
            MagickImage source = new MagickImage(sourceFile);
            IPixelCollection pixels = source.GetPixels();
            
            source.Write("frame0.png");
            int pixelIndex = 0;
            for (int i = 1; i <= totalFrames; i++)
            {
                for (int p = 0; p < pixelsPerFrame; p++)
                {
                    if (pixelIndex >= expandedOrder.Length)
                    {
                        break;
                    }

                    Color color = gradient.Tween((float) pixelIndex / expandedOrder.Length);
                    byte[] pixel = {color.R, color.G, color.B};
                    pixels.SetPixel(expandedOrder[pixelIndex].X, expandedOrder[pixelIndex].Y, pixel);
                    pixelIndex++;
                }
                source.Write("frame" + i + ".png");
            }           

            int delay = (int) (100 / fps);
            
            using (MagickImageCollection collection = new MagickImageCollection())
            {
                for (int i = 0; i <= totalFrames; i++)
                {
                    collection.Add("frame" + i + ".png");
                    collection[i].AnimationDelay = delay;
                }
                
                // Optionally reduce colors
                QuantizeSettings settings = new QuantizeSettings();
                settings.Colors = 256;
                collection.Quantize(settings);

                // Optionally optimize the images (images should have the same size).
                collection.Optimize();

                // Save gif
                collection.Write("output.gif");
            }
            
            return "output.gif";
        }
    }
}