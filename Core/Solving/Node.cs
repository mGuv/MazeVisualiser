namespace Core.Solving
{
    public class Node
    {
        public readonly Coordinate Location;
        public readonly int TotalCost;
        public readonly int PathCost;
        public readonly int HeuristicCost;
        public readonly Node PreviousNode;

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