namespace VargasM_Conexión_a_Gemini.Models
{
    public class GroqRequest
    {
        public string model { get; set; }
        public List<Message> messages { get; set; }
    }

    public class Message
    {
        public string role { get; set; }
        public string content { get; set; }
    }
}
