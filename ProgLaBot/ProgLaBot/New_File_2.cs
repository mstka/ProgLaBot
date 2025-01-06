using System;
using System.Drawing;
using System.Windows.Forms;

// ログイン画面クラス
class LoginScreen : Form
{
    private TextBox usernameTextBox;
    private TextBox passwordTextBox;
    private Button loginButton;
    private Label usernameLabel;
    private Label passwordLabel;

    public LoginScreen()
    {
        // フォームの初期設定
        this.Text = "Application";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.White;
        this.FormBorderStyle = FormBorderStyle.FixedSingle; // サイズ変更を無効化
        this.MaximizeBox = false; // 最大化ボタンを無効化

        InitializeLoginScreen();
    }

    private void InitializeLoginScreen()
    {

        // 現在のコントロールをすべてクリア
        this.Controls.Clear();

        // フォームサイズをログイン画面用に変更
        this.Size = new Size(400, 300);

        // コントロールの初期化
        usernameLabel = new Label
        {
            Text = "Username:",
            Location = new Point(50, 50),
            AutoSize = true,
            Font = new Font("Arial", 10, FontStyle.Bold)
        };
        this.Controls.Add(usernameLabel);

        usernameTextBox = new TextBox
        {
            Location = new Point(150, 45),
            Size = new Size(180, 30),
            Font = new Font("Arial", 10)
        };
        this.Controls.Add(usernameTextBox);

        passwordLabel = new Label
        {
            Text = "Password:",
            Location = new Point(50, 100),
            AutoSize = true,
            Font = new Font("Arial", 10, FontStyle.Bold)
        };
        this.Controls.Add(passwordLabel);

        passwordTextBox = new TextBox
        {
            Location = new Point(150, 95),
            Size = new Size(180, 30),
            Font = new Font("Arial", 10),
            PasswordChar = '*' // パスワードを隠す
        };
        this.Controls.Add(passwordTextBox);

        loginButton = new Button
        {
            Text = "Login",
            Location = new Point(150, 150),
            Size = new Size(100, 40),
            Font = new Font("Arial", 10, FontStyle.Bold),
            BackColor = Color.LightBlue,
            FlatStyle = FlatStyle.Flat
        };
        loginButton.Click += LoginButton_Click; // クリックイベント
        this.Controls.Add(loginButton);
    }

    private void LoginButton_Click(object sender, EventArgs e)
    {
        string username = usernameTextBox.Text;
        string password = passwordTextBox.Text;

        // ログイン成功条件
        if (username == "admin" && password == "password")
        {
            MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            InitializeHomeScreen(); // HOME画面を初期化
        }
        else
        {
            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void InitializeHomeScreen()
    {
        // 現在のコントロールをすべてクリア
        this.Controls.Clear();

        // フォームサイズをHOME画面用に変更
        this.Size = new Size(600, 400);

        // HOME画面の要素を追加
        Label welcomeLabel = new Label
        {
            Text = "Welcome to the HOME Screen!",
            Location = new Point(100, 100),
            AutoSize = true,
            Font = new Font("Arial", 14, FontStyle.Bold),
            ForeColor = Color.DarkGreen
        };
        this.Controls.Add(welcomeLabel);

        Button logoutButton = new Button
        {
            Text = "Logout",
            Location = new Point(250, 200),
            Size = new Size(100, 40),
            Font = new Font("Arial", 10, FontStyle.Bold),
            BackColor = Color.Orange,
            FlatStyle = FlatStyle.Flat
        };
        logoutButton.Click += LogoutButton_Click;
        this.Controls.Add(logoutButton);
    }

    private void LogoutButton_Click(object sender, EventArgs e)
    {
        // 現在のコントロールをすべてクリア
        this.Controls.Clear();

        // ログイン画面を再初期化
        InitializeLoginScreen();
    }
}

// エントリーポイント
class Core_Process
{
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // LoginScreen クラスのインスタンスを作成してフォームを表示
        Application.Run(new LoginScreen());
    }
}
