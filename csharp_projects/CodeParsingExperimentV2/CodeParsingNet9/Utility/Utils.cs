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

        public static string? TryParentFolder(string path)
        {
            return System.IO.Directory.GetParent(path)?.FullName;
        }

        public static string ParentFolder(string path)
        {
            string? result = System.IO.Directory.GetParent(path)?.FullName;
            if (result == null) throw new Exception("null parent");
            return result;
        }

        public static List<T> Clone<T>(List<T> list) {
            return new List<T>(list);
        }

        public static bool IsDescendant(string parentDirectoryPath, string filePath)
        {
            // Get the full, absolute paths for both the directory and the file.
            // This handles relative paths and resolves any ".." or "." components.
            string fullParentDirectoryPath = Path.GetFullPath(parentDirectoryPath);
            string fullFilePath = Path.GetFullPath(filePath);

            // Ensure the parent directory path ends with a directory separator for consistent comparison.
            if (!fullParentDirectoryPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                fullParentDirectoryPath += Path.DirectorySeparatorChar;
            }

            // Check if the file path starts with the parent directory path.
            // This indicates that the file is located within the directory or one of its subdirectories.
            return fullFilePath.StartsWith(fullParentDirectoryPath, StringComparison.OrdinalIgnoreCase);
        }

        public static string PascalCaseToCamelCase(string value)
        {
            // MyClass -> myClass
            string result = value.Substring(0, 1).ToLower() + value.Substring(1);
            return result;
        }
    }
}
