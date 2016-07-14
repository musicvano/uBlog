namespace uTool
{
    public class Program
    {
        public const string Version = "0.1";

        public static void Main(string[] args)
        {
            var commadLine = new CommandLine(args);
            commadLine.ParseArgs();
        }
    }
}