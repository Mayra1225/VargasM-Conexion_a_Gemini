using System.Net.Http.Headers;
using System.Security.Policy;
using Newtonsoft.Json;
using System.Text;
using VargasM_Conexión_a_Gemini.Interfaces;
using VargasM_Conexión_a_Gemini.Models;
using System.Net;

namespace VargasM_Conexión_a_Gemini.Repositories
{
    public class GroqRepository : IChatBotService
    {
        HttpClient _httpClient;
        private string apiKey = "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";

        public GroqRepository()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetChatbotResponse(string prompt)
        {
            var requestUri = "https://api.groq.com/openai/v1/chat/completions";

            GroqRequest request = new GroqRequest
            {
                model = "llama-3.3-70b-versatile",
                messages = new List<Message>
                {
                    new Message
                    {
                        role = "user",
                        content = prompt
                    }
                }
            };

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var response = await _httpClient.PostAsync(requestUri, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Groq API error: {response.StatusCode} - {error}");
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
