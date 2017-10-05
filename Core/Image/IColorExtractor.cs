namespace Core.Image
{
    public interface IColorExtractor
    {
        Color[,] FromFile(string filename);
    }
}