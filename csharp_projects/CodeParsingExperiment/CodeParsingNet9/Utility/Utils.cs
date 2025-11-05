using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.Utility
{
    public static class Utils
    {
        public static List<string> SplitPathSegments(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                throw new ArgumentException("Path cannot be null or empty.", nameof(relativePath));

            // Normalize directory separators for consistency
            var normalized = relativePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);

            // Split by separator and remove empty entries (handles leading/trailing slashes)
            var segments = normalized.Split(
                new[] { Path.DirectorySeparatorChar },
                StringSplitOptions.RemoveEmptyEntries);

            return new List<string>(segments);
        }

        public static List<T> PopLast<T>(List<T> input) {
            return input.Count > 1
                ? input.Take(input.Count - 1).ToList()
                : new List<T>();
        }

        public static string Join(string separator, List<string> list)
        {
            return string.Join(separator, list);
        }

        public static string? ParentFolder(string path)
        {
            return System.IO.Directory.GetParent(path)?.FullName;
        }

        public static List<T> Clone<T>(List<T> list) {
            return new List<T>(list);
        }
    }
}
