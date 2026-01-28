using System;
using System.IO;

namespace GreenLife_Organic_Store.Utilities
{
    public static class ImageStore
    {
        private const string ImagesFolderName = "Images";

    public static string GetImagesDirectory()
        {
            // Get the project root directory and return the Images folder path
            // When running from bin/Debug/net8.0-windows/:
            //   AppContext.BaseDirectory = .../GreenLife Organic Store/bin/Debug/net8.0-windows/
            // We want to get to: .../GreenLife Organic Store/Images/
            
            var projectRoot = GetProjectRoot();
            var imagesPath = Path.Combine(projectRoot, ImagesFolderName);
            return imagesPath;
        }

        /// <summary>
        /// Gets the project root directory by walking up from AppContext.BaseDirectory
        /// until it finds a folder that contains a .csproj file or the expected project structure
        /// </summary>
        private static string GetProjectRoot()
        {
            var baseDir = AppContext.BaseDirectory;
            var currentDir = new DirectoryInfo(baseDir);

            // Walk up the directory tree looking for the project root
            // Look for: a folder containing "GreenLife Organic Store.csproj" file
            while (currentDir != null)
            {
                // Check if this directory contains a .csproj file
                var csprojFiles = currentDir.GetFiles("*.csproj", SearchOption.TopDirectoryOnly);
                if (csprojFiles.Length > 0)
                {
                    return currentDir.FullName;
                }

                // Also check if the folder name matches the project name
                if (currentDir.Name.Equals("GreenLife Organic Store", StringComparison.OrdinalIgnoreCase))
                {
                    return currentDir.FullName;
                }

                currentDir = currentDir.Parent;
            }

            // Fallback: if we can't find the project root, return the base directory
            // This shouldn't happen in normal circumstances
            return baseDir;
        }

        public static void EnsureImagesDirectoryExists()
        {
            var dir = GetImagesDirectory();
            try
            {
                Directory.CreateDirectory(dir);
            }
            catch
            {
                // non-fatal, callers should handle failures when writing files
            }
        }

        // Saves the source file into the Images directory and returns a normalized relative path like "Images/filename.ext"
        public static string SaveImageFile(string sourceFilePath)
        {
            if (string.IsNullOrWhiteSpace(sourceFilePath) || !File.Exists(sourceFilePath))
                throw new FileNotFoundException("Source image not found", sourceFilePath);

            EnsureImagesDirectoryExists();
            var fileName = Path.GetFileName(sourceFilePath);
            var destDir = GetImagesDirectory();
            var destPath = Path.Combine(destDir, fileName);

            if (File.Exists(destPath))
            {
                var unique = Guid.NewGuid().ToString().Split('-')[0];
                var name = Path.GetFileNameWithoutExtension(fileName);
                var ext = Path.GetExtension(fileName);
                destPath = Path.Combine(destDir, name + "_" + unique + ext);
                fileName = Path.GetFileName(destPath);
            }

            File.Copy(sourceFilePath, destPath);

            // return normalized DB-friendly relative path using forward slash
            return ImagesFolderName + "/" + fileName;
        }

        // Returns an absolute path for a stored path. If storedPath is absolute it is returned as-is.
        // If storedPath is relative like "Images/filename" or "images/filename" it will be combined with the Images directory.
        public static string GetFullPath(string storedPath)
        {
            if (string.IsNullOrWhiteSpace(storedPath))
                return string.Empty;

            try
            {
                // If already absolute, return it
                if (Path.IsPathRooted(storedPath))
                    return storedPath;

                // Normalize separators
                var normalized = storedPath.Replace('/', Path.DirectorySeparatorChar).Replace('\\', Path.DirectorySeparatorChar);
                
                // If path starts with "images" or "Images" (case-insensitive), use GetImagesDirectory()
                var parts = normalized.Split(new[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 0 && parts[0].Equals("images", StringComparison.OrdinalIgnoreCase))
                {
                    // Extract the filename (everything after "images/")
                    var filename = string.Join(Path.DirectorySeparatorChar.ToString(), parts.Skip(1));
                    var full = Path.Combine(GetImagesDirectory(), filename);
                    return full;
                }
                
                // Otherwise, combine with Images directory directly
                var fullPath = Path.Combine(GetImagesDirectory(), normalized);
                return fullPath;
            }
            catch
            {
                return storedPath;
            }
        }
    }
}
