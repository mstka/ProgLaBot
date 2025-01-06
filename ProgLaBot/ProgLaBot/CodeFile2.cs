/*using System;
using System.Drawing;
using System.Windows.Forms;

class Form1 : Form
{
    private Button showButton;
    private Button hideButton;
    private Form2 form2;

    public Form1()
    {
        this.Text = "Form1";
        this.Size = new Size(800, 600);
        this.BackColor = Color.White;

        // Form2のインスタンスを作成
        form2 = new Form2();

        // Showボタン作成
        showButton = new Button
        {
            Text = "Show Form2",
            Location = new Point(120, 50),
            Size = new Size(200, 30)
        };
        showButton.Click += ShowButton_Click;
        this.Controls.Add(showButton);

        // Hideボタン作成
        hideButton = new Button
        {
            Text = "Hide Form1",
            Location = new Point(120, 100),
            Size = new Size(200, 30)
        };
        hideButton.Click += HideButton_Click;
        this.Controls.Add(hideButton);
    }

    // Showボタンのクリックイベント
    private void ShowButton_Click(object sender, EventArgs e)
    {
        form2.Show();  // Form2を表示
    }

    // Hideボタンのクリックイベント
    private void HideButton_Click(object sender, EventArgs e)
    {
        this.Hide();  // Form1を非表示
    }
}

class Form2 : Form
{
    private Button showButton;
    private Button hideButton;
    private Form1 form1;

    public Form2()
    {
        this.Text = "Form2";
        this.Size = new Size(800, 600);
        this.BackColor = Color.White;

        // Form1のインスタンスを作成
        form1 = new Form1();

        // Showボタン作成
        showButton = new Button
        {
            Text = "Show Form1",
            Location = new Point(120, 50),
            Size = new Size(200, 30)
        };
        showButton.Click += ShowButton_Click;
        this.Controls.Add(showButton);

        // Hideボタン作成
        hideButton = new Button
        {
            Text = "Hide Form2",
            Location = new Point(120, 100),
            Size = new Size(200, 30)
        };
        hideButton.Click += HideButton_Click;
        this.Controls.Add(hideButton);
    }

    // Showボタンのクリックイベント
    private void ShowButton_Click(object sender, EventArgs e)
    {
        form1.Show();  // Form1を表示
    }

    // Hideボタンのクリックイベント
    private void HideButton_Click(object sender, EventArgs e)
    {
        this.Hide();  // Form2を非表示
    }
}

class Core_Process
{
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // 最初にForm1を表示
        Application.Run(new Form1());
    }
}
*/