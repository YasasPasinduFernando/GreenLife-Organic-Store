using System;
using System.IO;

namespace GreenLife_Organic_Store.Utilities
{
    public static class ImageStore
    {
        private const string ImagesFolderName = "Images";

    public static string GetImagesDirectory()
        {
            var projectRoot = GetProjectRoot();
            var imagesPath = Path.Combine(projectRoot, ImagesFolderName);
            return imagesPath;
        }

        // Goes up from bin folder to find project root
        private static string GetProjectRoot()
        {
            var baseDir = AppContext.BaseDirectory;
            var currentDir = new DirectoryInfo(baseDir);

            while (currentDir != null)
            {
                var csprojFiles = currentDir.GetFiles("*.csproj", SearchOption.TopDirectoryOnly);
                if (csprojFiles.Length > 0)
                {
                    return currentDir.FullName;
                }

                if (currentDir.Name.Equals("GreenLife Organic Store", StringComparison.OrdinalIgnoreCase))
                {
                    return currentDir.FullName;
                }

                currentDir = currentDir.Parent;
            }

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
            }
        }

        // Copies image to Images folder and returns relative path
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

            return ImagesFolderName + "/" + fileName;
        }

        // Converts relative path like "Images/file.jpg" to full path
        public static string GetFullPath(string storedPath)
        {
            if (string.IsNullOrWhiteSpace(storedPath))
                return string.Empty;

            try
            {
                if (Path.IsPathRooted(storedPath))
                    return storedPath;

                var normalized = storedPath.Replace('/', Path.DirectorySeparatorChar).Replace('\\', Path.DirectorySeparatorChar);
                
                var parts = normalized.Split(new[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 0 && parts[0].Equals("images", StringComparison.OrdinalIgnoreCase))
                {
                    var filename = string.Join(Path.DirectorySeparatorChar.ToString(), parts.Skip(1));
                    var full = Path.Combine(GetImagesDirectory(), filename);
                    return full;
                }
                
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
