using System.Drawing;
using System.Windows.Forms;
using System;

public class HomeScreen : UserControl
{
    private MainForm mainForm;

    public HomeScreen(MainForm parentForm)
    {
        mainForm = parentForm;

        // 現在のコントロールをすべてクリア
        mainForm.Controls.Clear();

        // フォーム設定
        mainForm.Size = new Size(400, 500);

        // ホーム画面のUI設定
        Label welcomeLabel = new Label
        {
            Text = "Welcome to the Home Screen!",
            Font = new Font("Yu Gothic", 18),
            Location = new Point(50, 100),
            Size = new Size(300, 40)
        };

        Button logoutButton = new Button
        {
            Text = "Logout",
            Font = new Font("Arial", 12),
            Location = new Point(150, 200),
            Size = new Size(100, 40)
        };
        logoutButton.Click += LogoutButton_Click;

        mainForm.Controls.Add(welcomeLabel);
        mainForm.Controls.Add(logoutButton);
    }

    private void LogoutButton_Click(object sender, EventArgs e)
    {
        // ログアウトしてログイン画面に戻る
        mainForm.ShowLoginScreen();  // ログイン画面に遷移
    }
}