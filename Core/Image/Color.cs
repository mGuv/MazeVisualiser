namespace Core.Image
{
    /// <summary>
    /// Class to represent a basic RGB Byte based colour, with three channels. The values ranging from 0 (no presence)
    /// to 255 (full presence). I.e. Black is (0, 0, 0) and White is (255, 255, 255)
    /// </summary>
    public struct Color
    {
        /// <summary>
        /// Value of the amount of Red in the Colour
        /// </summary>
        public byte R;
        
        /// <summary>
        /// Value of the amount of Green in the Colour
        /// </summary>
        public byte G;
        
        /// <summary>
        /// Value of the amount of Blue in the Colour
        /// </summary>
        public byte B;

        /// <summary>
        /// Create a new Colour with the given values
        /// </summary>
        /// <param name="r">The value of the amount of Red</param>
        /// <param name="g">The value of the amount of Green</param>
        /// <param name="b">The value of the amount of Blue</param>
        public Color(byte r, byte g, byte b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }
    }
}