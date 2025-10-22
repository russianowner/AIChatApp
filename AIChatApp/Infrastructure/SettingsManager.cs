using Newtonsoft.Json.Linq;

namespace AIChatApp.Infrastructure
{
    public static class SettingsManager
    {
        public static string GetApiKey()
        {
            if (!File.Exists("appsettings.json"))
                throw new FileNotFoundException("нету джейсона");
            var json = File.ReadAllText("appsettings.json");
            var jObj = JObject.Parse(json);
            return jObj["TogetherAI"]?["ApiKey"]?.ToString() ?? "";
        }
        public static string GetModel()
        {
            if (!File.Exists("appsettings.json"))
                return "meta-llama/Meta-Llama-3-70B-Instruct-Turbo";
            var json = File.ReadAllText("appsettings.json");
            var jObj = JObject.Parse(json);
            return jObj["TogetherAI"]?["Model"]?.ToString() ?? "meta-llama/Meta-Llama-3-70B-Instruct-Turbo";
        }
    }
}
