namespace Core.Image
{
    public class TextureFactory
    {
        private IColorExtractor colorExtractor;
        
        public TextureFactory(IColorExtractor colorExtractor)
        {
            this.colorExtractor = colorExtractor;
        }
        
        public Texture Create(string fileName)
        {
            Color[,] colors = this.colorExtractor.FromFile(fileName);
            return new Texture(colors);
        }
    }
}