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
        public readonly int X;
        
        /// <summary>
        /// The Y coordinate of the position
        /// </summary>
        public readonly int Y;

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

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.X + (this.Y << 16);
        }

        /// <summary>
        /// Checks if the given Coordinate matches this Coordinate
        /// </summary>
        /// <param name="other">The Coordinate to compare against</param>
        /// <returns>True if they are the same, false otherwise</returns>
        public bool Equals(Coordinate other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Coordinate coordinate)
            {
                return this.Equals(coordinate);
            }

            return false;
        }

        /// <summary>
        /// Gets the Squared Distance to another coordinate
        /// </summary>
        /// <param name="to">The other Coordinate to get the Distance to</param>
        /// <returns>The Square Distance between coordinates</returns>
        public int SquareDistance(Coordinate to)
        {
            int xDiff = to.X - this.X;
            int yDiff = to.Y - this.Y;

            return (xDiff * xDiff) + (yDiff * yDiff);
        }
    }
}