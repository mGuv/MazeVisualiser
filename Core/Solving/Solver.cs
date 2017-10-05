using System.Collections.Generic;

namespace Core.Solving
{
    public class Solver
    {
        public Coordinate[] Expand(Map map, Coordinate start)
        {
            Heap openSet = new Heap();
            HashSet<Coordinate> closedSet = new HashSet<Coordinate>();
             // Container for path
            List<Coordinate> expandOrder = new List<Coordinate>();
            // Insert our starting node
            openSet.Insert(new Node(start, 0, 0, null));
            // Loop until we exhaust our search or break out early
            while(openSet.Count > 0)
            {
                // Get next cheapest node
                Node currentNode = openSet.Pop();
                
                // Check if the node has been previously expanded
                if(closedSet.Contains(currentNode.Location))
                {
                    // It has, skip to next node
                    continue;
                }
                expandOrder.Add(currentNode.Location);
                // Add the node to the expanded list
                closedSet.Add(currentNode.Location);
                // Get connected nodes
                foreach(Coordinate location in map.Expand(currentNode.Location))
                {
                    // create new path nodes with cost along path so far and current node as their parent
                    openSet.Insert(new Node(location, currentNode.PathCost + 1, 0, currentNode));
                }
            }

            return expandOrder.ToArray();
        }
    }
}