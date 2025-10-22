namespace AIChatApp.Core
{
    public interface IAIChatService
    {
        Task<string> GetResponseAsync(string prompt);
    }
}
