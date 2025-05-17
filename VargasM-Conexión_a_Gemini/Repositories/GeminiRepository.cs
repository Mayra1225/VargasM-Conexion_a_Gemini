using VargasM_Conexión_a_Gemini.Interfaces;
using VargasM_Conexión_a_Gemini.Models;

namespace VargasM_Conexión_a_Gemini.Repositories
{
    public class GeminiRepository : IChatBotService
    {
        HttpClient _httpClient;
        private string apiKey = "AIzaSyD9-hd-7wqrOKRGeDJGEOf8Q5BMOVe6dO4";

        public GeminiRepository()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetChatbotResponse(string prompt)
        {
            string url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key="+apiKey;
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, url);

            GeminiRequest request = new GeminiRequest
            {
                contents = new List<Content>
                {
                    new Content
                    {
                        parts = new List<Part>
                        {
                            new Part
                            {
                                text = prompt
                            }
                        }
                    }
                }
            };

            message.Content = JsonContent.Create<GeminiRequest>(request);
            var response = await _httpClient.SendAsync(message);
            string answer = await response.Content.ReadAsStringAsync();

            return answer; 
        }
    }
}
