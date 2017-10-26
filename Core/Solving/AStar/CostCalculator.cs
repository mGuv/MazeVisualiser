using System.ComponentModel;

namespace Core.Solving.AStar
{
    /// <summary>
    /// Cost calculations for pathfinding using A*
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
            // Basic A* can just use the distance between the two
            return from.SquareDistance(goal);
        }
    }
}