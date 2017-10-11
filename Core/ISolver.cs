namespace Core
{
    /// <summary>
    /// Interface responsible for being able to Solve a map and return the order in which Nodes were expanded
    /// </summary>
    public interface ISolver
    {
        /// <summary>
        /// Expands through the Map from a given start location towards the goal but does not stop when it reaches the 
        /// goal.
        /// </summary>
        /// <param name="map">The Map to solve</param>
        /// <param name="start">The starting coordinate on the Map</param>
        /// <param name="goal">The ending coordinate to find in the Map</param>
        /// <returns>The order of which the Map was expanded</returns>
        Coordinate[] GetExpandOrder(Map map, Coordinate start, Coordinate goal);
    }
}