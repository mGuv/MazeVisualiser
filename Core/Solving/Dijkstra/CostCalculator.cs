namespace Core.Solving.Dijkstra
{
    /// <summary>
    /// Cost calculations for pathfinding using Dijkstra's algorithm
    /// </summary>
    public class CostCalculator : ICostCalculator
    {
        /// <inheritdoc/>
        public float PathCost(Coordinate from, Coordinate to)
        {
            return from.SquareDistance(to);
        }

        /// <inheritdoc/>
        public float GoalEstimate(Coordinate from, Coordinate goal)
        {
            // Dijkstra is uninformed so the heuristic is 0
            return 0;
        }
    }
}