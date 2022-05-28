namespace AllAboutGames.Core
{
    public class AppSettings
    {
        public Serilog Serilog { get; set; }

        public JWT JWT { get; set; }
    }

    public class Serilog
    {
        public string ExceptionsPath { get; set; }

        public string LogsPath { get; set; }

        public string LogLevel { get; set; }
    }

    public class JWT
    {
        public string Secret { get; set; }
    }
}
