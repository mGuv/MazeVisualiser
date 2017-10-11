namespace Core
{
    /// <summary>
    /// Represents a position in 2D Space
    /// </summary>
    public struct Coordinate
    {
        /// <summary>
        /// The X coordinate of the position
        /// </summary>
        public int X;
        
        /// <summary>
        /// The Y coordinate of the position
        /// </summary>
        public int Y;

        /// <summary>
        /// Creates a new Coordinate with the given positions
        /// </summary>
        /// <param name="x">The position in the X axis</param>
        /// <param name="y">The position in the Y axis</param>
        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}