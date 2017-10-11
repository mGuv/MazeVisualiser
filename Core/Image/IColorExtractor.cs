namespace Core.Image
{
    /// <summary>
    /// Interface responsible for being able to convert to a 2D array of Colours
    /// </summary>
    public interface IColorExtractor
    {
        /// <summary>
        /// Takes an Image and returns the 2D array of colours found in the file
        /// </summary>
        /// <param name="path">The full path to the image to get colours from</param>
        /// <returns>The 2D array of Colours in the file</returns>
        Color[,] FromImage(string path);
    }
}