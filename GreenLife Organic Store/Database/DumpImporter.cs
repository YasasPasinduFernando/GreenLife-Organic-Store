using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace GreenLife_Organic_Store.Database
{
    /// <summary>
    /// Simple MySQL dump importer for development: converts a provided MySQL dump SQL
    /// into SQLite-compatible statements and imports into a target SQLite file.
    /// </summary>
    public static class DumpImporter
    {
        public static void ImportDumpIfPresent(string dumpPath, string targetSqliteFile)
        {
            if (string.IsNullOrWhiteSpace(dumpPath) || !File.Exists(dumpPath)) return;

            try
            {
                // Read dump file
                var sql = File.ReadAllText(dumpPath);
                Console.WriteLine($"[DumpImporter] Read {dumpPath}, {sql.Length} characters");

                // Remove MySQL comments and directives
                sql = RemoveComments(sql);

                // Extract and process CREATE TABLE and INSERT statements separately
                var statements = ExtractStatements(sql);
                var createStatements = new List<string>();
                var insertStatements = new List<string>();

                foreach (var stmt in statements)
                {
                    var trimmed = stmt.Trim();
                    if (trimmed.StartsWith("CREATE TABLE", StringComparison.OrdinalIgnoreCase))
                    {
                        var converted = ConvertCreateTable(stmt);
                        if (!string.IsNullOrWhiteSpace(converted))
                        {
                            createStatements.Add(converted);
                            Console.WriteLine($"[DumpImporter] Parsed: {converted.Substring(0, Math.Min(60, converted.Length))}...");
                        }
                    }
                    else if (trimmed.StartsWith("INSERT INTO", StringComparison.OrdinalIgnoreCase))
                    {
                        insertStatements.Add(stmt);
                    }
                }

                Console.WriteLine($"[DumpImporter] Found {createStatements.Count} CREATE TABLE and {insertStatements.Count} INSERT statements");

                if (createStatements.Count == 0)
                {
                    Console.WriteLine($"[DumpImporter] No CREATE TABLE statements found");
                    return;
                }

                // Ensure target directory exists
                var dir = Path.GetDirectoryName(targetSqliteFile);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                // Delete existing database
                if (File.Exists(targetSqliteFile))
                    File.Delete(targetSqliteFile);

                // Create database and execute statements
                using var conn = new SqliteConnection($"Data Source={targetSqliteFile}");
                conn.Open();

                using var tran = conn.BeginTransaction();
                try
                {
                    // Create tables
                    foreach (var stmt in createStatements)
                    {
                        try
                        {
                            Console.WriteLine($"[DumpImporter] Executing CREATE TABLE...");
                            using var cmd = new SqliteCommand(stmt, conn, tran);
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[DumpImporter] Error creating table: {ex.Message}\nStatement:\n{stmt}");
                            throw;
                        }
                    }

                    // Insert data
                    int insertCount = 0;
                    foreach (var stmt in insertStatements)
                    {
                        try
                        {
                            using var cmd = new SqliteCommand(stmt, conn, tran);
                            cmd.ExecuteNonQuery();
                            insertCount++;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[DumpImporter] Warning inserting data: {ex.Message}");
                            // Continue on insert errors
                        }
                    }

                    tran.Commit();
                    Console.WriteLine($"[DumpImporter] Database imported successfully! {createStatements.Count} tables, {insertCount} inserts");
                }
                catch (Exception ex)
                {
                    try { tran.Rollback(); } catch { }
                    Console.WriteLine($"[DumpImporter] Transaction failed: {ex.Message}");
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DumpImporter] Import failed: {ex.Message}");
            }
        }

        private static string RemoveComments(string sql)
        {
            // Remove MySQL directives like /*!40101 SET ... */
            sql = Regex.Replace(sql, @"/\*!.*?\*/", "", RegexOptions.Singleline);
            // Remove regular comments /* ... */
            sql = Regex.Replace(sql, @"/\*.*?\*/", "", RegexOptions.Singleline);
            // Remove -- comments
            sql = Regex.Replace(sql, @"--[^\n]*\n", "\n");
            // Remove # comments
            sql = Regex.Replace(sql, @"#[^\n]*\n", "\n");
            return sql;
        }

        private static List<string> ExtractStatements(string sql)
        {
            var statements = new List<string>();
            var current = "";
            var inString = false;
            var stringChar = '\0';
            var i = 0;

            while (i < sql.Length)
            {
                var ch = sql[i];

                // Handle string literals
                if ((ch == '\'' || ch == '"') && (i == 0 || sql[i - 1] != '\\'))
                {
                    if (!inString)
                    {
                        inString = true;
                        stringChar = ch;
                    }
                    else if (ch == stringChar)
                    {
                        inString = false;
                    }
                }

                current += ch;

                // Check for statement terminator
                if (ch == ';' && !inString)
                {
                    var stmt = current.Trim();
                    if (!string.IsNullOrWhiteSpace(stmt) && !stmt.StartsWith("/*!") && !stmt.StartsWith("--") && !stmt.StartsWith("#"))
                    {
                        // Skip LOCK, UNLOCK, USE, CREATE DATABASE statements
                        if (!stmt.StartsWith("LOCK", StringComparison.OrdinalIgnoreCase) &&
                            !stmt.StartsWith("UNLOCK", StringComparison.OrdinalIgnoreCase) &&
                            !stmt.StartsWith("USE", StringComparison.OrdinalIgnoreCase) &&
                            !stmt.StartsWith("CREATE DATABASE", StringComparison.OrdinalIgnoreCase) &&
                            !stmt.StartsWith("ALTER TABLE", StringComparison.OrdinalIgnoreCase) &&
                            !stmt.StartsWith("DROP TABLE", StringComparison.OrdinalIgnoreCase))
                        {
                            statements.Add(stmt);
                        }
                    }
                    current = "";
                }

                i++;
            }

            return statements;
        }

        private static string ConvertCreateTable(string stmt)
        {
            try
            {
                // Remove backticks
                stmt = stmt.Replace("`", "");

                // Extract table name - more flexible pattern
                var tableMatch = Regex.Match(stmt, @"CREATE\s+TABLE\s+(\w+)\s*\(", RegexOptions.IgnoreCase);
                if (!tableMatch.Success)
                {
                    Console.WriteLine("[DumpImporter] Could not extract table name");
                    return null;
                }

                var tableName = tableMatch.Groups[1].Value.Trim();
                
                // Extract everything between CREATE TABLE tablename ( and the last )
                var startIdx = stmt.IndexOf('(');
                var endIdx = stmt.LastIndexOf(')');
                
                if (startIdx < 0 || endIdx < 0 || endIdx <= startIdx)
                {
                    Console.WriteLine("[DumpImporter] Could not find parentheses in CREATE TABLE");
                    return null;
                }

                var content = stmt.Substring(startIdx + 1, endIdx - startIdx - 1);
                var columns = ParseColumns(content);

                if (columns.Count == 0)
                {
                    Console.WriteLine("[DumpImporter] No columns parsed");
                    return null;
                }

                return $"CREATE TABLE {tableName} (\n  {string.Join(",\n  ", columns)}\n);";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DumpImporter] Error converting CREATE TABLE: {ex.Message}");
                return null;
            }
        }

        private static List<string> ParseColumns(string content)
        {
            var columns = new List<string>();
            var lines = content.Split('\n');
            var currentCol = "";

            foreach (var line in lines)
            {
                var trimmedLine = line.Trim();
                
                if (string.IsNullOrWhiteSpace(trimmedLine))
                    continue;

                // Append to current column until we hit a comma
                if (currentCol.Length > 0)
                    currentCol += " ";
                currentCol += trimmedLine;

                // Check if this line ends a column definition
                if (trimmedLine.EndsWith(","))
                {
                    // Remove the trailing comma
                    currentCol = currentCol.Substring(0, currentCol.Length - 1).Trim();

                    // Process the column
                    var processed = ProcessColumnDefinition(currentCol);
                    if (!string.IsNullOrWhiteSpace(processed))
                        columns.Add(processed);

                    currentCol = "";
                }
                else if (IsConstraintOrKey(trimmedLine))
                {
                    // This is a constraint/key line - skip it entirely
                    // Remove trailing comma if present
                    if (currentCol.EndsWith(","))
                        currentCol = currentCol.Substring(0, currentCol.Length - 1).Trim();

                    if (!IsColumnDefinition(currentCol))
                    {
                        currentCol = "";
                    }
                }
            }

            // Don't forget the last column if it exists
            if (!string.IsNullOrWhiteSpace(currentCol))
            {
                var processed = ProcessColumnDefinition(currentCol);
                if (!string.IsNullOrWhiteSpace(processed))
                    columns.Add(processed);
            }

            return columns;
        }

        private static bool IsConstraintOrKey(string line)
        {
            var upperLine = line.ToUpper();
            return upperLine.StartsWith("CONSTRAINT") ||
                   upperLine.StartsWith("FOREIGN KEY") ||
                   upperLine.StartsWith("KEY ") ||
                   upperLine.StartsWith("UNIQUE") ||
                   upperLine.StartsWith("PRIMARY KEY");
        }

        private static bool IsColumnDefinition(string line)
        {
            // A column definition starts with a word (column name)
            return Regex.IsMatch(line, @"^\w+\s");
        }

        private static string ProcessColumnDefinition(string col)
        {
            if (string.IsNullOrWhiteSpace(col))
                return null;

            col = col.Trim().TrimEnd(',');

            // Skip constraint lines
            if (IsConstraintOrKey(col))
                return null;

            // Skip if it's just a closing paren
            if (col.Equals(")"))
                return null;

            // Convert MySQL types to SQLite
            col = ConvertTypes(col);

            // Handle AUTO_INCREMENT
            if (Regex.IsMatch(col, @"AUTO_INCREMENT", RegexOptions.IgnoreCase))
            {
                col = Regex.Replace(col, @"\s+AUTO_INCREMENT", "", RegexOptions.IgnoreCase);
                if (Regex.IsMatch(col, @"PRIMARY\s+KEY", RegexOptions.IgnoreCase))
                {
                    col = Regex.Replace(col, @"PRIMARY\s+KEY", "PRIMARY KEY AUTOINCREMENT", RegexOptions.IgnoreCase);
                }
            }

            // Remove ON UPDATE CURRENT_TIMESTAMP
            col = Regex.Replace(col, @"\s+ON\s+UPDATE\s+CURRENT_TIMESTAMP", "", RegexOptions.IgnoreCase);

            // Remove COLLATE clauses
            col = Regex.Replace(col, @"\s+COLLATE\s+\w+", "", RegexOptions.IgnoreCase);

            col = col.Trim();

            return string.IsNullOrWhiteSpace(col) ? null : col;
        }

        private static string ConvertTypes(string definition)
        {
            // Convert MySQL types to SQLite
            definition = Regex.Replace(definition, @"\bint\b", "INTEGER", RegexOptions.IgnoreCase);
            definition = Regex.Replace(definition, @"\btinyint(\([^\)]*\))?", "INTEGER", RegexOptions.IgnoreCase);
            definition = Regex.Replace(definition, @"\bsmallint(\([^\)]*\))?", "INTEGER", RegexOptions.IgnoreCase);
            definition = Regex.Replace(definition, @"\bbigint(\([^\)]*\))?", "INTEGER", RegexOptions.IgnoreCase);
            definition = Regex.Replace(definition, @"\bfloat(\([^\)]*\))?", "REAL", RegexOptions.IgnoreCase);
            definition = Regex.Replace(definition, @"\bdouble(\([^\)]*\))?", "REAL", RegexOptions.IgnoreCase);
            definition = Regex.Replace(definition, @"\bdecimal(\([^\)]*\))?", "REAL", RegexOptions.IgnoreCase);
            definition = Regex.Replace(definition, @"\blongtext\b", "TEXT", RegexOptions.IgnoreCase);
            definition = Regex.Replace(definition, @"\btext\b", "TEXT", RegexOptions.IgnoreCase);
            definition = Regex.Replace(definition, @"\bvarchar(\([^\)]*\))?", "TEXT", RegexOptions.IgnoreCase);
            definition = Regex.Replace(definition, @"\bchar(\([^\)]*\))?", "TEXT", RegexOptions.IgnoreCase);
            definition = Regex.Replace(definition, @"\benum(\([^\)]*\))?", "TEXT", RegexOptions.IgnoreCase);
            definition = Regex.Replace(definition, @"\bset(\([^\)]*\))?", "TEXT", RegexOptions.IgnoreCase);
            definition = Regex.Replace(definition, @"\bdatetime\b", "TEXT", RegexOptions.IgnoreCase);
            definition = Regex.Replace(definition, @"\bdate\b", "TEXT", RegexOptions.IgnoreCase);
            definition = Regex.Replace(definition, @"\btime\b", "TEXT", RegexOptions.IgnoreCase);
            definition = Regex.Replace(definition, @"\btimestamp\b", "TEXT", RegexOptions.IgnoreCase);

            return definition;
        }
    }
}
