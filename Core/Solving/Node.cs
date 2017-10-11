namespace Core.Solving
{
    /// <summary>
    /// Represents a Node in the search tree
    /// </summary>
    public class Node
    {
        /// <summary>
        /// The Coordinate location of the Node
        /// </summary>
        public readonly Coordinate Location;

        /// <summary>
        /// The total cost of expanding this node
        /// </summary>
        public readonly int TotalCost;

        /// <summary>
        /// The cost to reach this node from the start
        /// </summary>
        public readonly int PathCost;

        /// <summary>
        /// The estimated cost to reach the goal from this Node
        /// </summary>
        public readonly int HeuristicCost;

        /// <summary>
        /// The node that was expanded to reach this Node
        /// </summary>
        public readonly Node PreviousNode;

        /// <summary>
        /// Creates a new Node with the given information
        /// </summary>
        /// <param name="location">The location of the Node</param>
        /// <param name="pathCost">The cost along the path to reach this Node</param>
        /// <param name="heuristicCost">The estimated cost to the goal from this Node</param>
        /// <param name="previousNode">The Node that was expanded to reach this Node</param>
        public Node(Coordinate location, int pathCost, int heuristicCost, Node previousNode)
        {
            this.Location = location;
            this.PathCost = pathCost;
            this.HeuristicCost = heuristicCost;
            this.TotalCost = this.PathCost + this.HeuristicCost;
            this.PreviousNode = previousNode;
        }
    }
}