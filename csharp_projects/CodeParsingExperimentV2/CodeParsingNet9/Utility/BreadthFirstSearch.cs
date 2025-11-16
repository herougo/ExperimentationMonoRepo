using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.Utility
{
    public interface IBfsManager<T>
    {
        List<T> GetChildren(T node);

        void ProcessNode(T node, List<T> pathFromRoot);
    }

    public static class BreadthFirstSearch
    {
        public static void Execute<T>(T rootNode, IBfsManager<T> manager)
        {
            var queue = new Queue<Tuple<T, List<T>>>();

            var visited = new HashSet<T>();

            var rootEntry = new Tuple<T, List<T>>(rootNode, new List<T>() { rootNode });
            queue.Enqueue(rootEntry);
            visited.Add(rootNode);

            while (queue.Count > 0)
            {
                var nodeEntry = queue.Dequeue();
                var node = nodeEntry.Item1;
                var pathFromRoot = nodeEntry.Item2;

                // If process returns false → stop BFS
                manager.ProcessNode(node, pathFromRoot);

                foreach (var child in manager.GetChildren(node))
                {
                    if (!visited.Add(child)) continue;

                    List<T> newPathFromRoot = Utils.Clone(pathFromRoot);
                    newPathFromRoot.Add(child);
                    var newEntry = new Tuple<T, List<T>>(child, newPathFromRoot);
                    queue.Enqueue(newEntry);
                }
            }
        }
    }
}
