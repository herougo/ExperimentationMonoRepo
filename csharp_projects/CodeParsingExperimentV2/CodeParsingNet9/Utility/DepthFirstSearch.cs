using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.Utility
{
    public interface IDfsManager<T>
    {
        List<T> GetChildren(T node);

        void ProcessNode(T node, List<T> pathFromRoot);

        void ProcessNodeBeforeVisitCheck(T node, List<T> pathFromRoot, bool visited);
    }

    public static class DepthFirstSearch
    {
        public static void Execute<T>(T root, IDfsManager<T> manager)
        {
            if (root == null) return;

            var visited = new HashSet<T>();

            var stack = new Stack<(T node, List<T> path)>();
            stack.Push((root, new List<T> { root }));

            while (stack.Count > 0)
            {
                var (node, path) = stack.Pop();

                manager.ProcessNodeBeforeVisitCheck(node, path, visited.Contains(node));

                if (visited.Contains(node))
                    continue;

                visited.Add(node);

                manager.ProcessNode(node, path);

                var children = manager.GetChildren(node);
                if (children != null)
                {
                    for (int i = children.Count - 1; i >= 0; i--)
                    {
                        var child = children[i];

                        var newPath = new List<T>(path) { child };

                        stack.Push((child, newPath));
                    }
                }
            }
        }
    }
}
