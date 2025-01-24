using System.Drawing;
using System.Windows.Forms;
using System;
using System.Threading;
using System.Drawing.Text;

public class Main_Simulation : UserControl
{
    private MainForm mainForm;
    private bool lp_flag = true;

    public Main_Simulation(MainForm parentForm)
    {
        //TcpClientApp TCA = new TcpClientApp();

        mainForm = parentForm;

        // 現在のコントロールをすべてクリア
        mainForm.Controls.Clear();

        // フォーム設定
        mainForm.Size = new Size(400, 500);

        // Paint イベントにハンドラを追加
        mainForm.Paint += Simulation_Paint;


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

        while (lp_flag)
        {
            mainForm.Invalidate();
            Thread.Sleep(10); // CPU負荷を軽減するための休み
        }
    }


    private void LogoutButton_Click(object sender, EventArgs e)
    {
        mainForm.Paint -= Simulation_Paint;
        // ログアウトしてログイン画面に戻る
        mainForm.ShowLoginScreen();  // ログイン画面に遷移
    }

    // Paint イベントのハンドラ
    private void Simulation_Paint(object sender, PaintEventArgs e)
    {
        int circleX = 5;
        int circleY = 5;
        int circleDiameter = 5;
        Graphics graphics = e.Graphics;

        // 赤い丸を描画
        Brush redBrush = new SolidBrush(Color.Red);
        graphics.FillEllipse(redBrush, circleX, circleY, circleDiameter, circleDiameter);
    }
}