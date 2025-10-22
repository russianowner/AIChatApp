using Newtonsoft.Json;
using AIChatApp.Core;

namespace AIChatApp.Infrastructure
{
    public class FileChatHistory : IChatHistory
    {
        private readonly string _filePath = "chat_history.json";
        private readonly List<ChatMessage> _messages = new();

        public void AddUserMessage(string message)
        {
            _messages.Add(new ChatMessage { Role = "user", Content = message });
            Save();
        }
        public void AddBotMessage(string message)
        {
            _messages.Add(new ChatMessage { Role = "assistant", Content = message });
            Save();
        }
        public IEnumerable<ChatMessage> GetAllMessages() => _messages;
        private void Save()
        {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(_messages, Formatting.Indented));
        }
    }
}
