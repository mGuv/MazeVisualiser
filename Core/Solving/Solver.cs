using System.Collections.Generic;

namespace Core.Solving
{
    /// <summary>
    /// Solver that utilised Dijkstra's algorithm to flood a map from a starting location.
    /// </summary>
    public class Solver : ISolver
    {
        /// <summary>
        /// The cost calculation to use for ordering the expand order
        /// </summary>
        private ICostCalculator costCalulator;

        /// <summary>
        /// Creates a new Solver with the given dependencies
        /// </summary>
        /// <param name="costCalculator">The cost calculator to use for any solves through this solver</param>
        public Solver(ICostCalculator costCalculator)
        {
            this.costCalulator = costCalculator;
        }

        /// <inheritdoc/>
        public Coordinate[] GetExpandOrder(Map map, Coordinate start, Coordinate goal)
        {
            // Set of available Nodes to expand, starts with the initial Coordinate in
            Heap openSet = new Heap();
            openSet.Insert(new Node(start, 0, 0, null));

            // Set of nodes already expanded
            HashSet<Coordinate> closedSet = new HashSet<Coordinate>();
            // Overall expanded order
            List<Coordinate> expandOrder = new List<Coordinate>();

            // Loop until we exhaust our search
            while (openSet.Count > 0)
            {
                // Get next cheapest node
                Node currentNode = openSet.Pop();

                // Check if the node has been previously expanded as we never expand a node twice
                if (closedSet.Contains(currentNode.Location))
                {
                    continue;
                }

                // Track the fact this node is being expanded
                expandOrder.Add(currentNode.Location);
                closedSet.Add(currentNode.Location);

                // Get any available connections and add them to the open set
                // Note: No need to check closed set here as we dedupe after Popping, this allows a node to be found
                // by multiple paths and only the cheapest will take effect.
                foreach (Coordinate location in map.Expand(currentNode.Location))
                {
                    // Create a new node from the given location. As this algorithm is dumb, it's cost to the next node
                    // is always 1 and the cost to the goal is always 0
                    openSet.Insert(
                        new Node(
                            location,
                            currentNode.PathCost + this.costCalulator.PathCost(currentNode.Location, location),
                            this.costCalulator.GoalEstimate(location, goal),
                            currentNode
                        )
                    );
                }
            }

            return expandOrder.ToArray();
        }
    }
}