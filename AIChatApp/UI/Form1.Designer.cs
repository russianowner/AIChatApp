namespace AIChatApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox txtChat;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtChat = new RichTextBox();
            txtInput = new TextBox();
            btnSend = new Button();
            bottomPanel = new Panel();
            lblStatus = new Label();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // txtChat
            // 
            txtChat.BackColor = Color.FromArgb(40, 40, 40);
            txtChat.BorderStyle = BorderStyle.None;
            txtChat.Font = new Font("Consolas", 10F);
            txtChat.ForeColor = Color.White;
            txtChat.Location = new Point(12, 12);
            txtChat.Name = "txtChat";
            txtChat.ReadOnly = true;
            txtChat.Size = new Size(760, 380);
            txtChat.TabIndex = 0;
            txtChat.Text = "";
            // 
            // txtInput
            // 
            txtInput.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtInput.BackColor = Color.FromArgb(50, 50, 50);
            txtInput.BorderStyle = BorderStyle.FixedSingle;
            txtInput.Font = new Font("Consolas", 10F);
            txtInput.ForeColor = Color.White;
            txtInput.Location = new Point(12, 8);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(660, 23);
            txtInput.TabIndex = 1;
            txtInput.KeyDown += txtInput_KeyDown;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Right;
            btnSend.BackColor = Color.FromArgb(70, 130, 180);
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(685, 8);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(80, 25);
            btnSend.TabIndex = 2;
            btnSend.Text = "Отправить";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // bottomPanel
            // 
            bottomPanel.BackColor = Color.FromArgb(35, 35, 35);
            bottomPanel.Controls.Add(txtInput);
            bottomPanel.Controls.Add(btnSend);
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Location = new Point(0, 400);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Size = new Size(784, 45);
            bottomPanel.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 8F);
            lblStatus.ForeColor = Color.Silver;
            lblStatus.Location = new Point(12, 395);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(760, 12);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Напиши сообщение";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(784, 445);
            Controls.Add(lblStatus);
            Controls.Add(txtChat);
            Controls.Add(bottomPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimumSize = new Size(800, 480);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Together Чат";
            bottomPanel.ResumeLayout(false);
            bottomPanel.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
    }
}
