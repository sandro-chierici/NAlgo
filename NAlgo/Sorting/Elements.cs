using System;
using System.Collections.Generic;
using System.Linq;

namespace NAlgo.Sorting
{
    public static class Elements
    {
        /// <summary>
        /// Extract Top K Elements from an array
        /// Time complexity O(n + k) with k = number of top k elements needed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="buffer"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static T[] Top<T>(ReadOnlySpan<T> buffer, int k) 
            where T: notnull, IComparable
        {
            var maxValues = new LinkedList<T>();

            var len = Math.Min(k, buffer.Length);
            if (len <= 0)
                return maxValues.ToArray();            

            // init Linked list

            var minNode = new LinkedListNode<T>(buffer[0]);
            maxValues.AddFirst(minNode);

            // add rest of initial values
            // keeping values ordered from Max to Min (Last Value in linked list)
            for (var i = 1; i < len; i++)
            {
                var newNode = new LinkedListNode<T>(buffer[i]);
                var currentNode = maxValues.First;
                var found = false;
                for (var item = 0; item < maxValues.Count; item++)
                {
                    if (currentNode.Value.CompareTo(buffer[i]) < 0)
                    {
                        maxValues.AddBefore(currentNode, newNode);
                        found = true;
                        break;
                    }
                }
                // lesser than everything
                if (!found)
                    maxValues.AddAfter(maxValues.Last, newNode);
            }

            // loop until the end and check
            for (var i = len; i < buffer.Length; i++)
            {
                //
                // Optimization: if value is lesser than min refuse it directly
                // avoiding useless iterations
                //
                if (buffer[i].CompareTo(maxValues.Last.Value) < 0)
                    continue;

                // 
                // start comparing from max value until found right position
                //
                var node = maxValues.First;                                
                for (var count = 0; count < len; count++)
                {
                    if (node.Value.CompareTo(buffer[i]) < 0)
                    {
                        // remove currentmin and add new value 
                        // at position found
                        maxValues.RemoveLast();

                        // insert on the left of node found because 
                        // value is greater
                        maxValues.AddBefore(node, new LinkedListNode<T>(buffer[i]));

                        // job done
                        break;
                    }

                    // continue to next node
                    node = node.Next;
                }
            }

            return maxValues.ToArray();
        }
    }
}
