using System.Net.Http.Json;
using System.Text.Json;

namespace BookBrain.Services.Adapters
{
    public class GPT4AllAdapter : IAIAdapter
    {
        private readonly HttpClient _client = new();

        public async Task<string> GetBookSummaryAsync(string description)
        {
            _client.Timeout = TimeSpan.FromSeconds(300);
            var request = new
            {
                model = "q4_0-orca-mini-3b.gguf",
                messages = new[]
                {
                    new { role = "system", content = "Ти си асистент, който прави кратки резюмета на книги." },
                    new { role = "user", content = $"Резюмирай накратко следния текст на български: {description}" }
                },
                max_tokens = 200
            };

            var response = await _client.PostAsJsonAsync("http://localhost:4891/v1/chat/completions", request);

            if (!response.IsSuccessStatusCode)
                return "Грешка при комуникация с локалния AI модел.";

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);

            var content = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return content ?? "Няма резултат.";
        }
    }
}
