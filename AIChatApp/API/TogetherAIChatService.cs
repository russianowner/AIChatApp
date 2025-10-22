using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AIChatApp.Core;

namespace AIChatApp.API
{
    public class TogetherAIChatService : IAIChatService
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;
        private readonly string _model;

        public TogetherAIChatService(string apiKey, string model = "meta-llama/Meta-Llama-3-70B-Instruct-Turbo")
        {
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _client = new HttpClient();
        }
        public async Task<string> GetResponseAsync(string prompt)
        {
            if (string.IsNullOrWhiteSpace(prompt))
                return "пустой запрос";
            var payload = new
            {
                model = _model,
                messages = new[]
                {
                    new { role = "user", content = prompt }
                },
                temperature = 0.7
            };
            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            var response = await _client.PostAsync("https://api.together.xyz/v1/chat/completions", content);
            var responseJson = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                return $"{response.StatusCode} - {responseJson}";
            try
            {
                var obj = JObject.Parse(responseJson);
                var text = obj["choices"]?[0]?["message"]?["content"]?.ToString();
                return string.IsNullOrWhiteSpace(text)
                    ? "нет ответа"
                    : text.Trim();
            }
            catch (Exception ex)
            {
                return $"{ex.Message}";
            }
        }
    }
}
