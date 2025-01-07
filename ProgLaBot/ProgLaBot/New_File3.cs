/*using System;
using System.Drawing;
using System.Windows.Forms;

// ログイン画面クラス
class FirstScreen : Form
{
    private TextBox usernameTextBox;
    private TextBox passwordTextBox;
    private Button loginButton;
    private Label usernameLabel;
    private Label passwordLabel;
    private PictureBox logoPictureBox;

    public FirstScreen()
    {
        // フォームの初期設定
        this.Text = "ProgLaBot";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Color.White;
        this.FormBorderStyle = FormBorderStyle.FixedSingle; // サイズ変更を無効化
        this.MaximizeBox = false; // 最大化ボタンを無効化
        //this.FormBorderStyle = FormBorderStyle.None;  // タイトルバーを非表示
        //this.Icon = new Icon("path_to_icon.ico");

        InitializeLoginScreen();
    }

    private void InitializeLoginScreen()
    {

        // 現在のコントロールをすべてクリア
        this.Controls.Clear();

        // フォームサイズをログイン画面用に変更
        this.Size = new Size(400, 600);


        // ロゴ画像の表示
        logoPictureBox = new PictureBox
        {
            Image = Image.FromFile("RExIM_LOGO.png"), // ロゴ画像のパス（適宜変更してください）
            Size = new Size(200, 140),
            Location = new Point(90, 0),
            SizeMode = PictureBoxSizeMode.StretchImage // 画像サイズをPictureBoxに合わせる
        };
        this.Controls.Add(logoPictureBox);

        usernameLabel = new Label
        {
            Text = "Username:",
            Location = new Point(60, 150),
            AutoSize = true,
            Font = new Font("Arial", 10, FontStyle.Bold)
        };
        this.Controls.Add(usernameLabel);

        usernameTextBox = new TextBox
        {
            Location = new Point(150, 145),
            Size = new Size(180, 30),
            Font = new Font("Arial", 10)
        };
        this.Controls.Add(usernameTextBox);

        passwordLabel = new Label
        {
            Text = "Password:",
            Location = new Point(60, 200),
            AutoSize = true,
            Font = new Font("Arial", 10, FontStyle.Bold)
        };
        this.Controls.Add(passwordLabel);

        passwordTextBox = new TextBox
        {
            Location = new Point(150, 195),
            Size = new Size(180, 30),
            Font = new Font("Arial", 10),
            PasswordChar = '*' // パスワードを隠す
        };
        this.Controls.Add(passwordTextBox);

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

        this.Controls.Add(loginButton);
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
        // 現在の参照パスをCUIに出力
        string currentDirectory = Environment.CurrentDirectory;
        Console.WriteLine($"Current Directory: {currentDirectory}");

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // LoginScreen クラスのインスタンスを作成してフォームを表示
        Application.Run(new FirstScreen());
    }
}
*/