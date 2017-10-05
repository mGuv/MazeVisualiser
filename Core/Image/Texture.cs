namespace Core.Image
{
    public class Texture
    {
        public int Width => this.pixels.GetLength(0);
        public int Height => this.pixels.GetLength(1);
        private readonly Color[,] pixels;

        public Texture(Color[,] pixels)
        {
            this.pixels = pixels;
        }
        
        public Color GetPixel(int x, int y)
        {
            return this.pixels[x, y];
        }
    }
}