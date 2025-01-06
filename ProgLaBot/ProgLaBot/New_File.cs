/*using System;
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
        // フォームの設定
        this.Text = "Login Screen";
        this.Size = new Size(400, 300);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.White;

        // ユーザー名ラベル
        usernameLabel = new Label
        {
            Text = "Username:",
            Location = new Point(50, 50),
            AutoSize = true,
            Font = new Font("Arial", 10, FontStyle.Bold)
        };
        this.Controls.Add(usernameLabel);

        // ユーザー名入力ボックス
        usernameTextBox = new TextBox
        {
            Location = new Point(150, 45),
            Size = new Size(180, 30),
            Font = new Font("Arial", 10)
        };
        this.Controls.Add(usernameTextBox);

        // パスワードラベル
        passwordLabel = new Label
        {
            Text = "Password:",
            Location = new Point(50, 100),
            AutoSize = true,
            Font = new Font("Arial", 10, FontStyle.Bold)
        };
        this.Controls.Add(passwordLabel);

        // パスワード入力ボックス
        passwordTextBox = new TextBox
        {
            Location = new Point(150, 95),
            Size = new Size(180, 30),
            Font = new Font("Arial", 10),
            PasswordChar = '*' // パスワードを隠す
        };
        this.Controls.Add(passwordTextBox);

        // ログインボタン
        loginButton = new Button
        {
            Text = "Login",
            Location = new Point(150, 150),
            Size = new Size(100, 40),
            Font = new Font("Arial", 10, FontStyle.Bold),
            BackColor = Color.LightBlue,
            FlatStyle = FlatStyle.Flat // ボタンをリッチにする
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
            this.Hide(); // 現在のフォームを隠す
            HomeScreen homeScreen = new HomeScreen();
            homeScreen.ShowDialog(); // HOME画面を表示
            this.Close(); // ログイン画面を終了
        }
        else
        {
            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

// HOME画面クラス
class HomeScreen : Form
{
    public HomeScreen()
    {
        // フォームの設定
        this.Text = "Home Screen";
        this.Size = new Size(600, 400);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.LightGray;

        // ラベルを追加
        Label welcomeLabel = new Label
        {
            Text = "Welcome to the HOME Screen!",
            Location = new Point(150, 150),
            AutoSize = true,
            Font = new Font("Arial", 14, FontStyle.Bold),
            ForeColor = Color.DarkGreen
        };
        this.Controls.Add(welcomeLabel);
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
*/