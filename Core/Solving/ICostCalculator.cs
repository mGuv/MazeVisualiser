namespace Core.Solving
{
    /// <summary>
    /// Interface for describing something that can be used to calculate Path and Heuristic costs for path finding
    /// </summary>
    public interface ICostCalculator
    {
        /// <summary>
        /// The cost to travel between two given Coordinates
        /// </summary>
        /// <param name="from">The Coordinate to travel from</param>
        /// <param name="to">The Coordinate to travel to</param>
        /// <returns>The cost to travel between the Coordinates</returns>
        float PathCost(Coordinate from, Coordinate to);
        
        /// <summary>
        /// The estimate cost from the given Coordinate to the Goal
        /// </summary>
        /// <param name="from">The Coordinate to travel from</param>
        /// <param name="goal">The goal Coordinate to get to</param>
        /// <returns>The estimate cost to get to the goal</returns>
        float GoalEstimate(Coordinate from, Coordinate goal);
    }
}