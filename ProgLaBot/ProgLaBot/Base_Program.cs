using System;
using System.Drawing;
using System.Windows.Forms;

public class MainForm : Form
{
    private Panel containerPanel;

    public MainForm()
    {
        // フォームの初期設定
        this.Text = "ProgLaBot";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.White;
        this.FormBorderStyle = FormBorderStyle.FixedSingle; // サイズ変更を無効化
        this.MaximizeBox = false; // 最大化ボタンを無効化
        //this.FormBorderStyle = FormBorderStyle.None;  // タイトルバーを非表示
        //this.Icon = new Icon("path_to_icon.ico");

        this.Size = new Size(400, 400);

        // コンテナーパネルを作成し、子フォームを動的に切り替える
        containerPanel = new Panel
        {
            Dock = DockStyle.Fill
        };
        this.Controls.Add(containerPanel);

        // 初期状態ではLoginScreenを表示
        ShowHomeScreen();
    }

    // ログイン画面を表示
    public void ShowLoginScreen()
    {
        Console.WriteLine("Show_Login_Screen");
        //this.Controls.Clear();  // 現在のコントロールをクリア
        LoginScreen loginScreen = new LoginScreen(this);  // MainFormを渡す

        this.Controls.Add(containerPanel);  // コンテナーパネルを再追加
        loginScreen.Dock = DockStyle.Fill;  // ログイン画面をパネルに合わせる
        containerPanel.Controls.Add(loginScreen);
    }

    // ホーム画面を表示
    public void ShowHomeScreen()
    {
        Console.WriteLine("Show_Home_Screen");
        //this.Controls.Clear();  // 現在のコントロールをクリア
        HomeScreen homeScreen = new HomeScreen(this);  // MainFormを渡す

        this.Controls.Add(containerPanel);  // コンテナーパネルを再追加
        homeScreen.Dock = DockStyle.Fill;  // ホーム画面をパネルに合わせる
        containerPanel.Controls.Add(homeScreen);
    }
}


// エントリーポイント
class Core_Process
{
    public static void Main()
    {
        // 現在の参照パスをCUIに出力
        string currentDirectory = Environment.CurrentDirectory;
        Console.WriteLine($"Current Directory: {currentDirectory}");

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // LoginScreen クラスのインスタンスを作成してフォームを表示
        Application.Run(new MainForm());
    }
}
