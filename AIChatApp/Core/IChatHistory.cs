namespace AIChatApp.Core
{
    public interface IChatHistory
    {
        void AddUserMessage(string message);
        void AddBotMessage(string message);
        IEnumerable<ChatMessage> GetAllMessages();
    }
}
