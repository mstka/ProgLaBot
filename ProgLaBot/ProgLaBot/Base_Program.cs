using System;
using System.Drawing;
using System.Windows.Forms;
using System.Management;
using System.Security.Cryptography;
using System.Text;

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
        ShowLoginScreen();
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

    public void ShowSignUpScreen()
    {
        Console.WriteLine("Show_Home_Screen");
        //this.Controls.Clear();  // 現在のコントロールをクリア
        Sign_Up_Screen homeScreen = new Sign_Up_Screen(this);  // MainFormを渡す

        this.Controls.Add(containerPanel);  // コンテナーパネルを再追加
        homeScreen.Dock = DockStyle.Fill;  // ホーム画面をパネルに合わせる
        containerPanel.Controls.Add(homeScreen);
    }
}


// エントリーポイント
class Core_Process
{

    /// <summary>
    /// マザーボードのUUIDを取得する関数
    /// </summary>
    /// <returns>UUID文字列</returns>
    static string GetMotherboardUUID()
    {
        try
        {
            string query = "SELECT UUID FROM Win32_ComputerSystemProduct";
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    return obj["UUID"]?.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in GetMotherboardUUID: " + ex.Message);
        }
        return null;
    }

    /// <summary>
    /// 入力文字列からSHA256ハッシュ値を生成する関数
    /// </summary>
    /// <param name="input">ハッシュ化する文字列</param>
    /// <returns>ハッシュ値の16進数表記</returns>
    static string GetHash(string input)
    {
        try
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                // バイト配列を16進数文字列に変換
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in GetHash: " + ex.Message);
            return null;
        }
    }


    public static void Main()
    {

       // Console.WriteLine($"Current Directory: {GetMotherboardUUID()}");
       //Console.WriteLine(GetHash(GetMotherboardUUID()));

        // 現在の参照パスをCUIに出力
        string currentDirectory = Environment.CurrentDirectory;
        Console.WriteLine($"Current Directory: {currentDirectory}");

        //通信用オブジェクトを生成
        //TcpClientApp TCA = new TcpClientApp();

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // LoginScreen クラスのインスタンスを作成してフォームを表示
        Application.Run(new MainForm());
    }
}
