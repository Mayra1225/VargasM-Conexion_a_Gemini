namespace VargasM_Conexión_a_Gemini.Interfaces
{
    public interface IChatBotService
    {
        public Task<string> GetChatbotResponse(string prompt);
    }
}
