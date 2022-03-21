using Newtonsoft.Json;
#nullable disable

namespace AllAboutGames.Core
{
    public class Global
    {
        public static AppSettings AppSettings { get; set; }

        public static void LoadSettings(WebApplicationBuilder builder)
        {
            var section = builder.Configuration.GetSection(nameof(AppSettings));
            AppSettings = section.Get<AppSettings>();
        }
    }
}
