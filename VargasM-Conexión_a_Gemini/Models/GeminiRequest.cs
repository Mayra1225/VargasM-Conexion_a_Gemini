using System.Text.Json.Serialization;

namespace VargasM_Conexión_a_Gemini.Models
{
    public class GeminiRequest
    {
        [JsonPropertyName("contents")]
        public List<Content> contents { get; set; }
    }

    public class Content
    {
        [JsonPropertyName("parts")]
        public List<Part> parts { get; set; }
    }

    public class Part
    {
        [JsonPropertyName("text")]
        public string text { get; set; }
    }

}
