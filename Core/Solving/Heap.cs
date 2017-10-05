using System;

namespace Core.Solving
{
    /// <summary>
    /// Stack-style class that automatically orders elements as they are inserted from lowest to highest.
    /// </summary>
    /// <typeparam name="T">Type of element stored in the heap.</typeparam>
    public class Heap
    {
        /// <summary>
        /// Raw structure of the heap itself,
        /// </summary>
        private Node[] _heap = new Node[4];
        /// <summary>
        /// The number of elements currently in the Heap,
        /// </summary>
        public int Count
        {
            private set;
            get;
        }
        
        /// <summary>
        /// Resize the internal array to fit more elements.
        /// </summary>
        private void Resize()
        {
            // Just double the array length for ease
            Node[] resized = new Node[_heap.Length * 2];
            // Copy current heap in to new array
            Array.Copy(_heap, 0, resized, 0, _heap.Length);
            // Assign new array
            _heap = resized;
        }

        /// <summary>
        /// Check if the given node requires updating.
        /// </summary>
        /// <param name="childIndex">Index of node to check.</param>
        private void HeapUp(int childIndex)
        {
            if(childIndex > 0)
            {
                // Look up the heap
                int parentIndex = (childIndex - 1) / 2;

                // check if it needs swapping
                if(_heap[childIndex].TotalCost < _heap[parentIndex].TotalCost)
                {
                    // Swap
                    Node tempParent = _heap[parentIndex];
                    _heap[parentIndex] = _heap[childIndex];
                    _heap[childIndex] = tempParent;
                    // Propogate upwards
                    HeapUp(parentIndex);
                }
            }
        }

        /// <summary>
        /// Check if the given node requires it's position changed in a downwards direction.
        /// </summary>
        /// <param name="parentIndex">Index of node to check.</param>
        private void HeapDown(int parentIndex)
        {
            // Get the child nodes either side of this node
            int leftChildIndex = 2 * parentIndex + 1;
            int rightChildIndex = leftChildIndex + 1;
            int largestIndex = parentIndex;

            // Check if it needs reordering compared to the left
            if(leftChildIndex < Count && _heap[leftChildIndex].TotalCost < _heap[largestIndex].TotalCost)
            {
                largestIndex = leftChildIndex;
            }

            // Check if it needs reordering to the right
            if(rightChildIndex < Count && _heap[rightChildIndex].TotalCost < _heap[largestIndex].TotalCost)
            {
                largestIndex = rightChildIndex;
            }

            // Check if it needs reordering at all
            if(largestIndex != parentIndex)
            {
                // Reorder
                Node tempParent = _heap[parentIndex];
                _heap[parentIndex] = _heap[largestIndex];
                _heap[largestIndex] = tempParent;
                // Propogate node downwards
                HeapDown(largestIndex);
            }
        }

        /// <summary>
        /// Add an Element in to the heap that will be automatically ordered.
        /// </summary>
        /// <param name="element">The element to add to the heap.</param>
        public void Insert(Node element)
        {
            // If the heap is already full we need to resize it
            if (Count == _heap.Length)
            {
                Resize();
            }

            // Add the element at the end of the heap
            _heap[Count] = element;
            // Propogate the element upwards
            HeapUp(Count);
            Count++;
        }

        /// <summary>
        /// Get the element at the top of the heap.
        /// </summary>
        /// <returns>The 'lowest' element (based on comparer).</returns>
        public Node Pop()
        {
            // Get lowest element
            Node toReturn = _heap[0];
            Count--;
            // Swap the end node and first node
            _heap[0] = _heap[Count];
            // Find the end node's new position
            HeapDown(0);
            return toReturn;
        }

        /// <summary>
        /// Empty the current Heap so it can be reused.
        /// </summary>
        public void Clear()
        {
            // Clear indexs but keep size as if it grew once before, it will most likely be used again
            Array.Clear(_heap, 0, _heap.Length);
            // Reset count to zero
            Count = 0;
        }
    }
}