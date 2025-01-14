using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Sign_Up_Screen : UserControl
{
    private MainForm mainForm;
    private TextBox usernameTextBox;
    private TextBox passwordTextBox;
    private Button loginButton;
    private Label usernameLabel;
    private Label passwordLabel;
    private PictureBox logoPictureBox;
    private Button SignUp_Button;

    public Sign_Up_Screen(MainForm parentForm)
    {
        mainForm = parentForm;

        // 現在のコントロールをすべてクリア
        mainForm.Controls.Clear();

        // フォームサイズを変更
        mainForm.Size = new Size(400, 500);


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
            Text = "ユーザー名:",
            Location = new Point(60, 150),
            AutoSize = true,
            Font = new Font("Yu Gothic", 10, FontStyle.Bold)
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
            Text = "パスワード:",
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

        Label mailAddressLabel = new Label
        {
            Text = "メールアドレス:",
            Location = new Point(60, 250),
            AutoSize = true,
            Font = new Font("Arial", 10, FontStyle.Bold)
        };
        mainForm.Controls.Add(mailAddressLabel);

        TextBox mailAddress_TextBox = new TextBox
        {
            Location = new Point(160, 245),
            Size = new Size(180, 30),
            Font = new Font("Arial", 10)
        };
        mainForm.Controls.Add(mailAddress_TextBox);

        loginButton = new Button
        {
            Text = "新規登録",
            Location = new Point(70, 320),
            Size = new Size(250, 50),
            Font = new Font("Yu Gothic", 15, FontStyle.Bold),
            BackColor = Color.LightBlue,
            FlatStyle = FlatStyle.Flat
        };
        loginButton.Click += SignUp_Button_Click; // クリックイベント

        // ボタンを丸角にする
        loginButton.FlatStyle = FlatStyle.Flat;  // フラットスタイルに設定
        loginButton.FlatAppearance.BorderSize = 0; // 境界線を非表示に
        SetButtonRounded(loginButton);

        mainForm.Controls.Add(loginButton);



        SignUp_Button = new Button
        {
            Text = "ログイン画面へ",
            Location = new Point(135, 400),
            Size = new Size(120, 35),
            Font = new Font("Yu Gothic", 10, FontStyle.Regular), //FontStyle.Regular
            BackColor = Color.Wheat,
            FlatStyle = FlatStyle.Flat
        };
        SignUp_Button.Click += LoginButton_Click; // クリックイベント

        // ボタンを丸角にする
        SignUp_Button.FlatStyle = FlatStyle.Flat;  // フラットスタイルに設定
        SignUp_Button.FlatAppearance.BorderSize = 0; // 境界線を非表示に
        SetButtonRounded(SignUp_Button);

        mainForm.Controls.Add(SignUp_Button);


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
        mainForm.ShowLoginScreen();  // ホーム画面に遷移
    }

    private void SignUp_Button_Click(object sender, EventArgs e)
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