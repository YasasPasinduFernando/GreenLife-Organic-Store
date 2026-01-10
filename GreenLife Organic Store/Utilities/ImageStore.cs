using System;
using System.IO;

namespace GreenLife_Organic_Store.Utilities
{
    public static class ImageStore
    {
        private const string ImagesFolderName = "Images";

        public static string GetImagesDirectory()
        {
            var baseDir = AppContext.BaseDirectory; // works for single-file and development
            return Path.Combine(baseDir, ImagesFolderName);
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
        // If storedPath is relative like "Images/filename" it will be combined with the application base directory.
        public static string GetFullPath(string storedPath)
        {
            if (string.IsNullOrWhiteSpace(storedPath))
                return string.Empty;

            try
            {
                // If already absolute, return it
                if (Path.IsPathRooted(storedPath))
                    return storedPath;

                // Normalize separators and trim leading slashes
                var trimmed = storedPath.TrimStart('/', '\\');
                var full = Path.Combine(AppContext.BaseDirectory, trimmed.Replace('/', Path.DirectorySeparatorChar).Replace('\\', Path.DirectorySeparatorChar));
                return full;
            }
            catch
            {
                return storedPath;
            }
        }
    }
}
