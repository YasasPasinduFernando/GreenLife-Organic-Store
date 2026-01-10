using System;
using System.IO;
using Microsoft.Data.Sqlite;
using GreenLife_Organic_Store.Utilities;

namespace GreenLife_Organic_Store.Database.Migrations
{
    /// <summary>
    /// Migration helper to convert absolute/legacy image paths stored in the Products.ImagePath
    /// column into normalized relative paths under the application's Images folder using ImageStore.
    ///
    /// Usage: Call ConvertImagePaths.Run() from a temporary console runner or invoke from an admin tool.
    /// </summary>
    public static class ConvertImagePaths
    {
        public static void Run(bool copyFiles = true)
        {
            Console.WriteLine("Starting ImagePath conversion migration...");
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();

            using var selectCmd = new SqliteCommand("SELECT ID, ImagePath FROM Products", conn);
            using var reader = selectCmd.ExecuteReader();
            var items = new System.Collections.Generic.List<(int Id, string? ImagePath)>();
            while (reader.Read())
            {
                var id = Convert.ToInt32(reader["ID"]);
                var img = reader["ImagePath"] != DBNull.Value ? reader["ImagePath"].ToString() : null;
                items.Add((id, img));
            }

            reader.Close();

            foreach (var item in items)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(item.ImagePath))
                        continue;

                    var stored = item.ImagePath.Trim();

                    // Already normalized
                    if (stored.StartsWith("Images/", StringComparison.OrdinalIgnoreCase))
                        continue;

                    // If it's a relative path without Images/ prefix, just normalize to Images/<filename>
                    var filename = Path.GetFileName(stored);
                    if (string.IsNullOrWhiteSpace(filename))
                        continue;

                    string? newRelative = null;

                    // If the source exists as an absolute path, copy it into Images
                    if (Path.IsPathRooted(stored) && File.Exists(stored))
                    {
                        if (copyFiles)
                        {
                            newRelative = ImageStore.SaveImageFile(stored);
                        }
                    }
                    else
                    {
                        // Try to resolve stored path relative to app base directory (handles legacy bin\\Debug\\... entries)
                        var candidate = Path.Combine(AppContext.BaseDirectory, stored.TrimStart('/', '\\').Replace('/', Path.DirectorySeparatorChar).Replace('\\', Path.DirectorySeparatorChar));
                        if (File.Exists(candidate))
                        {
                            if (copyFiles)
                                newRelative = ImageStore.SaveImageFile(candidate);
                        }
                        else
                        {
                            // As a last resort, create a normalized Images/<filename> entry without copying if file not found.
                            newRelative = "Images/" + filename;
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(newRelative))
                    {
                        using var update = new SqliteCommand("UPDATE Products SET ImagePath = @ImagePath WHERE ID = @ID", conn);
                        update.Parameters.AddWithValue("@ImagePath", newRelative);
                        update.Parameters.AddWithValue("@ID", item.Id);
                        var affected = update.ExecuteNonQuery();
                        Console.WriteLine($"Updated product {item.Id}: {stored} -> {newRelative} ({affected} rows)");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to process product {item.Id}: {ex.Message}");
                }
            }

            Console.WriteLine("ImagePath conversion migration completed.");
        }
    }
}
