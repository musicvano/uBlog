using System;
using System.IO;

namespace uTool
{
    public class CommandLine
    {
        private string[] args;
        private int current = -1;

        public CommandLine(string[] args)
        {
            this.args = args;
        }

        /// <summary>
        /// Returns next token
        /// </summary>
        private string NextToken()
        {
            current++;
            return current < args.Length ? args[current] : null;
        }

        /// <summary>
        /// Shows help on the console
        /// </summary>
        private void ShowHelp()
        {
            string help =
                $"uTool v.{Program.Version}\n" +
                "Command-line interface for uBlog\n" +
                "Usage: uTool [options] [command] [arguments]\n" +
                "Options:\n" +
                "  -h|--help        Show help\n" +
                "  -v|--version     Show version\n\n" +
                "Commands:\n" +
                "  new <filename>   Creates new SQLite database for uBlog with demo data";
            Console.WriteLine(help);
        }

        /// <summary>
        /// Creates new database
        /// </summary>
        /// <param name="filePath">Database path, can be relative</param>
        private void InitDatabase(string filePath)
        {
            try
            {
                filePath = Path.GetFullPath(filePath);
                if (File.Exists(filePath))
                {
                    Console.WriteLine($"Error. Database file already exists: {filePath}");
                    Console.WriteLine("Failed");
                    return;
                }
                var dir = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(dir))
                {
                    Console.WriteLine($"Error. Path does't exist: {dir}");
                    Console.WriteLine("Failed");
                    return;
                }
                DatabaseInitializer.Create(filePath);
                DatabaseInitializer.Seed(filePath);
                Console.WriteLine($"Database have been created: {filePath}");
                Console.WriteLine("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error. {ex.Message}");
            }
        }

        /// <summary>
        /// Parsers and processes all command line args
        /// </summary>
        public void ParseArgs()
        {
            while (true)
            {
                string token = NextToken();
                if (token == null)
                {
                    break;
                }
                switch (token)
                {
                    case "-h":
                    case "--help":
                        ShowHelp();
                        break;
                    case "-v":
                    case "--version":
                        Console.WriteLine($"Version {Program.Version}");
                        break;
                    case "new":
                        var filePath = NextToken();
                        if (filePath == null)
                        {
                            Console.WriteLine("Error. Filename expected");
                            break;
                        }
                        InitDatabase(filePath);
                        break;
                    default:
                        Console.WriteLine($"Unknown command: {token}");
                        break;
                }
            }
        }
    }
}