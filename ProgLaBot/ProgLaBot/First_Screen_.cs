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

public class LoginScreen : UserControl
{
    private MainForm mainForm;
    private TextBox usernameTextBox;
    private TextBox passwordTextBox;
    private Button loginButton;
    private Label usernameLabel;
    private Label passwordLabel;
    private PictureBox logoPictureBox;

    public LoginScreen(MainForm parentForm)
    {
        mainForm = parentForm;

        // 現在のコントロールをすべてクリア
        mainForm.Controls.Clear();

        // フォームサイズをログイン画面用に変更
        mainForm.Size = new Size(400, 600);


        // ロゴ画像の表示
        logoPictureBox = new PictureBox
        {
            Image = Image.FromFile("RExIM_LOGO.png"), // ロゴ画像のパス（適宜変更してください）
            Size = new Size(200, 140),
            Location = new Point(90, 0),
            SizeMode = PictureBoxSizeMode.StretchImage // 画像サイズをPictureBoxに合わせる
        };
        mainForm.Controls.Add(logoPictureBox);

        usernameLabel = new Label
        {
            Text = "Username:",
            Location = new Point(60, 150),
            AutoSize = true,
            Font = new Font("Arial", 10, FontStyle.Bold)
        };
        mainForm.Controls.Add(usernameLabel);

        usernameTextBox = new TextBox
        {
            Location = new Point(150, 145),
            Size = new Size(180, 30),
            Font = new Font("Arial", 10)
        };
        mainForm.Controls.Add(usernameTextBox);

        passwordLabel = new Label
        {
            Text = "Password:",
            Location = new Point(60, 200),
            AutoSize = true,
            Font = new Font("Arial", 10, FontStyle.Bold)
        };
        mainForm.Controls.Add(passwordLabel);

        passwordTextBox = new TextBox
        {
            Location = new Point(150, 195),
            Size = new Size(180, 30),
            Font = new Font("Arial", 10),
            PasswordChar = '*' // パスワードを隠す
        };
        mainForm.Controls.Add(passwordTextBox);

        loginButton = new Button
        {
            Text = "Login",
            Location = new Point(150, 250),
            Size = new Size(100, 40),
            Font = new Font("Arial", 10, FontStyle.Bold),
            BackColor = Color.LightBlue,
            FlatStyle = FlatStyle.Flat
        };
        loginButton.Click += LoginButton_Click; // クリックイベント

        // ボタンを丸角にする
        loginButton.FlatStyle = FlatStyle.Flat;  // フラットスタイルに設定
        loginButton.FlatAppearance.BorderSize = 0; // 境界線を非表示に
        loginButton.BackColor = Color.LightBlue; // 背景色を設定
        SetButtonRounded(loginButton);

        mainForm.Controls.Add(loginButton);
    }

    // 丸角ボタンを設定するメソッド
    private void SetButtonRounded(Button button)
    {
        int radius = 10;  // 丸角の半径
        System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
        path.AddArc(0, 0, radius, radius, 180, 90); // 左上
        path.AddArc(button.Width - radius - 1, 0, radius, radius, 270, 90); // 右上
        path.AddArc(button.Width - radius - 1, button.Height - radius - 1, radius, radius, 0, 90); // 右下
        path.AddArc(0, button.Height - radius - 1, radius, radius, 90, 90); // 左下
        path.CloseFigure();

        button.Region = new Region(path); // ボタンの領域を設定
    }

    private void LoginButton_Click(object sender, EventArgs e)
    {
        string username = usernameTextBox.Text;
        string password = passwordTextBox.Text;

        // ログイン成功条件
        if (username == "admin" && password == "password")
        {
            MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // ログイン成功した場合
            mainForm.ShowHomeScreen();  // ホーム画面に遷移
        }
        else
        {
            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
    }
}

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
            Font = new Font("Arial", 18),
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
