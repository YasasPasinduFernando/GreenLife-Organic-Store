using Microsoft.Data.Sqlite;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

namespace GreenLife_Organic_Store.Database
{
    // SQLite connection helper
    public class DatabaseConnection
    {
        private static readonly string DbFileName = "greenlife.db";

        private static string GetDatabaseFilePath()
        {
            // Database file stored in the application's executable directory under "Database".
            // If the runtime Database folder doesn't contain the DB, try to discover an existing
            // copy in parent folders (e.g. the project folder) and copy it into the runtime folder.
            var baseDir = AppContext.BaseDirectory;
            var dbDir = Path.Combine(baseDir, "Database");
            if (!Directory.Exists(dbDir)) Directory.CreateDirectory(dbDir);
            var runtimeDbPath = Path.Combine(dbDir, DbFileName);

            // If runtime DB already exists, prefer it only if it contains tables
            if (File.Exists(runtimeDbPath))
            {
                try
                {
                    var builder = new SqliteConnectionStringBuilder { DataSource = runtimeDbPath, Mode = SqliteOpenMode.ReadOnly };
                    using var checkConn = new SqliteConnection(builder.ToString());
                    checkConn.Open();
                    using var cmd = new SqliteCommand("SELECT count(*) FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%';", checkConn);
                    var cntObj = cmd.ExecuteScalar();
                    if (cntObj != null && int.TryParse(cntObj.ToString(), out int cnt) && cnt > 0)
                    {
                        return runtimeDbPath; // contains tables, use it
                    }
                    // otherwise fall through and attempt to copy a known DB into runtime location
                }
                catch
                {
                    // If we cannot read the runtime DB, attempt to replace it below
                }
            }

            // Search up the directory tree for a Database/greenlife.db (covers project dir)
            var dirInfo = new DirectoryInfo(baseDir);
            for (int i = 0; i < 8 && dirInfo != null; i++)
            {
                var candidate = Path.Combine(dirInfo.FullName, "Database", DbFileName);
                if (File.Exists(candidate))
                {
                    try
                    {
                        // Ensure we overwrite any empty runtime DB with the project DB
                        File.Copy(candidate, runtimeDbPath, overwrite: true);
                        Console.WriteLine($"Copied existing DB from '{candidate}' to runtime DB path '{runtimeDbPath}'.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to copy DB from '{candidate}' to '{runtimeDbPath}': {ex.Message}");
                    }

                    return runtimeDbPath;
                }

                dirInfo = dirInfo.Parent;
            }

            // As a last resort, check a common project-relative path (helps when running from IDE)
            try
            {
                var projectCandidate = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "GreenLife Organic Store", "Database", DbFileName));
                if (File.Exists(projectCandidate))
                {
                    try
                    {
                        File.Copy(projectCandidate, runtimeDbPath, overwrite: true);
                        Console.WriteLine($"Copied existing DB from '{projectCandidate}' to runtime DB path '{runtimeDbPath}'.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to copy DB from '{projectCandidate}' to '{runtimeDbPath}': {ex.Message}");
                    }

                    return runtimeDbPath;
                }
            }
            catch { /* ignore path resolution errors */ }

            // No existing DB found; return the runtime path (an empty DB will be created on first use)
            // As a fallback, if a MySQL dump is present in the project, try importing it into the runtime DB
            try
            {
                var searchDir = new DirectoryInfo(baseDir);
                for (int i = 0; i < 8 && searchDir != null; i++)
                {
                    var dump1 = Path.Combine(searchDir.FullName, "Database", "greenlife.sql");
                    var dump2 = Path.Combine(searchDir.FullName, "Database", "dump.sql");
                    var dump3 = Path.Combine(searchDir.FullName, "Database", "greenlife_dump.sql");
                    if (File.Exists(dump1)) { DumpImporter.ImportDumpIfPresent(dump1, runtimeDbPath); return runtimeDbPath; }
                    if (File.Exists(dump2)) { DumpImporter.ImportDumpIfPresent(dump2, runtimeDbPath); return runtimeDbPath; }
                    if (File.Exists(dump3)) { DumpImporter.ImportDumpIfPresent(dump3, runtimeDbPath); return runtimeDbPath; }
                    searchDir = searchDir.Parent;
                }

                // Check common project-relative path as well
                var projectDump = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "GreenLife Organic Store", "Database", "greenlife.sql"));
                if (File.Exists(projectDump)) { DumpImporter.ImportDumpIfPresent(projectDump, runtimeDbPath); return runtimeDbPath; }
            }
            catch { /* ignore import errors - will return runtime path */ }

            return runtimeDbPath;
        }

        private static string GetConnectionString()
        {
            var dbPath = GetDatabaseFilePath();
            return new SqliteConnectionStringBuilder { DataSource = dbPath }.ToString();
        }

        public static SqliteConnection GetConnection()
        {
            // Resolve DB path and create connection string here so we can run a quick diagnostic check
            var dbPath = GetDatabaseFilePath();
            var connStr = new SqliteConnectionStringBuilder { DataSource = dbPath }.ToString();
            var conn = new SqliteConnection(connStr);

            // Diagnostic: log runtime DB path and available tables to help troubleshoot "no such table" errors.
            try
            {
                if (File.Exists(dbPath))
                {
                    using var checkConn = new SqliteConnection(new SqliteConnectionStringBuilder { DataSource = dbPath, Mode = SqliteOpenMode.ReadOnly }.ToString());
                    checkConn.Open();
                    using var cmd = new SqliteCommand("SELECT name FROM sqlite_master WHERE type='table';", checkConn);
                    using var reader = cmd.ExecuteReader();
                    var tables = new List<string>();
                    while (reader.Read())
                    {
                        tables.Add(reader.GetString(0));
                    }
                    Debug.WriteLine($"[DatabaseConnection] Runtime DB path: {dbPath}");
                    Debug.WriteLine($"[DatabaseConnection] Tables: {string.Join(",", tables)}");
                    try
                    {
                        var logPath = Path.Combine(AppContext.BaseDirectory, "db-debug.log");
                        var msg = $"{DateTime.Now:O} - Runtime DB path: {dbPath}\nTables: {string.Join(",", tables)}\n";
                        if (!tables.Exists(t => string.Equals(t, "Users", StringComparison.OrdinalIgnoreCase)))
                        {
                            msg += "WARNING: 'Users' table not found in runtime DB.\n";
                            Debug.WriteLine("[DatabaseConnection] WARNING: 'Users' table not found in runtime DB.");
                        }
                        File.AppendAllText(logPath, msg + "\n");
                    }
                    catch { /* ignore logging failures */ }
                }
                else
                {
                    Debug.WriteLine($"[DatabaseConnection] Runtime DB file not found at: {dbPath}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[DatabaseConnection] DB diagnostic check failed: {ex.Message}");
            }

            return conn;
        }

        public static bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
