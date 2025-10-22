using AIChatApp.API;
using AIChatApp.Infrastructure;

namespace AIChatApp
{
    public partial class Form1 : Form
    {
        private TogetherAIChatService? _aiService;

        public Form1()
        {
            InitializeComponent();
            try
            {
                string apiKey = SettingsManager.GetApiKey();
                string model = SettingsManager.GetModel();
                _aiService = new TogetherAIChatService(apiKey, model);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "AI Chat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnSend_Click(object sender, EventArgs e)
        {
            await ProcessUserMessageAsync();
        }
        private async void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await ProcessUserMessageAsync();
            }
        }
        private async Task ProcessUserMessageAsync()
        {
            string userInput = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(userInput))
                return;
            AppendChat("Я", userInput);
            txtInput.Clear();
            txtInput.Enabled = false;
            btnSend.Enabled = false;
            lblStatus.Text = "Думаю..";
            string aiResponse = await GetAIResponse(userInput);
            AppendChat("Чат бот", aiResponse);
            txtInput.Enabled = true;
            btnSend.Enabled = true;
            lblStatus.Text = "Ответил";
        }

        private async Task<string> GetAIResponse(string input)
        {
            try
            {
                if (_aiService == null)
                    return "сервис null";
                return await _aiService.GetResponseAsync(input);
            }
            catch (Exception ex)
            {
                return $"{ex.Message}";
            }
        }
        private void AppendChat(string role, string message)
        {
            txtChat.SelectionStart = txtChat.TextLength;
            txtChat.SelectionFont = new System.Drawing.Font("Consolas", 10, System.Drawing.FontStyle.Bold);
            txtChat.SelectionColor = role == "Я" ? System.Drawing.Color.LightBlue : System.Drawing.Color.LightGreen;
            txtChat.AppendText($"{role}: ");
            txtChat.SelectionFont = new System.Drawing.Font("Consolas", 10);
            txtChat.SelectionColor = System.Drawing.Color.White;
            txtChat.AppendText($"{message}\n\n");
            txtChat.ScrollToCaret();
        }
    }
}
