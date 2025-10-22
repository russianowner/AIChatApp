namespace AIChatApp.Core
{
    public class ChatController
    {
        private readonly IAIChatService _chatService;
        private readonly IChatHistory _history;

        public ChatController(IAIChatService chatService, IChatHistory history)
        {
            _chatService = chatService;
            _history = history;
        }
        public async Task<string> SendMessageAsync(string userInput)
        {
            _history.AddUserMessage(userInput);
            var response = await _chatService.GetResponseAsync(userInput);
            _history.AddBotMessage(response);
            return response;
        }
    }
}
