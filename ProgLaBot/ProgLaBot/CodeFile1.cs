/*using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

class Screen_Operation : Form
{
    private Panel drawingPanel;
    private List<TextBox> TBox_list = new List<TextBox>();
    private int circleX = 100; // 円のX座標
    private int circleY = 100; // 円のY座標
    private const int circleDiameter = 50; // 円の直径

    private Timer moveTimer; // 移動用タイマー
    private bool moveUp, moveDown, moveLeft, moveRight; // 移動フラグ

    public Screen_Operation()
    {
        this.Text = "ProgLaBot";
        this.Size = new Size(800, 600);
        this.BackColor = Color.White; // 背景色を白色に設定

        // Panel作成
        drawingPanel = new DoubleBufferedPanel
        {
            Location = new Point(0, 0),
            Size = new Size(800, 600),
            BorderStyle = BorderStyle.FixedSingle
        };
        drawingPanel.Paint += DrawingPanel_Paint; // Paintイベントにハンドラを追加
        this.Controls.Add(drawingPanel);

        this.KeyDown += Screen_Operation_KeyDown; // キーボード押下イベント
        this.KeyUp += Screen_Operation_KeyUp; // キーボード解放イベント
        this.KeyPreview = true; // キー入力をフォーム全体でキャッチする

        // タイマーの初期化
        moveTimer = new Timer
        {
            Interval = 1 // 20ミリ秒ごとに移動処理
        };
        moveTimer.Tick += MoveTimer_Tick;
        moveTimer.Start();
    }

    private void DrawingPanel_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        Brush brush = new SolidBrush(Color.Red);

        // 円を描画
        g.FillEllipse(brush, circleX, circleY, circleDiameter, circleDiameter);
    }

    private void Screen_Operation_KeyDown(object sender, KeyEventArgs e)
    {
        // 矢印キーで移動フラグを設定
        if (e.KeyCode == Keys.Up) moveUp = true;
        if (e.KeyCode == Keys.Down) moveDown = true;
        if (e.KeyCode == Keys.Left) moveLeft = true;
        if (e.KeyCode == Keys.Right) moveRight = true;
    }

    private void Screen_Operation_KeyUp(object sender, KeyEventArgs e)
    {
        // 矢印キーの移動フラグを解除
        if (e.KeyCode == Keys.Up) moveUp = false;
        if (e.KeyCode == Keys.Down) moveDown = false;
        if (e.KeyCode == Keys.Left) moveLeft = false;
        if (e.KeyCode == Keys.Right) moveRight = false;
    }

    private void MoveTimer_Tick(object sender, EventArgs e)
    {
        const int moveAmount = 5; // 移動量

        // 移動フラグに基づいて円の座標を更新
        if (moveUp) circleY -= moveAmount;
        if (moveDown) circleY += moveAmount;
        if (moveLeft) circleX -= moveAmount;
        if (moveRight) circleX += moveAmount;

        // 再描画を要求
        drawingPanel.Invalidate();
    }

    public void Add_TBox()
    {
        // TextBox作成
        TextBox newTextBox = new TextBox
        {
            Location = new Point(120, 10), // drawingPanel内での位置
            Size = new Size(200, 30),
            Font = new Font("Arial", 12, FontStyle.Bold),
            ForeColor = Color.Blue,
            Multiline = true,  // 複数行の入力を許可
            WordWrap = true,   // 自動改行を有効化
            Text = "Welcome!",
            ScrollBars = ScrollBars.Vertical
        };

        // drawingPanelにTextBoxを追加
        drawingPanel.Controls.Add(newTextBox);
    }
}

// ダブルバッファリングを有効にしたPanelクラス
class DoubleBufferedPanel : Panel
{
    public DoubleBufferedPanel()
    {
        this.DoubleBuffered = true; // ダブルバッファリングを有効化
    }
}

class Core_Process
{
    public static void Main()
    {
        Application.EnableVisualStyles();  // Visual Stylesを有効に
        Application.SetCompatibleTextRenderingDefault(false); // テキスト描画の設定

        // Screen_Operation クラスのインスタンスを作成してフォームを表示
        Screen_Operation First_Screen = new Screen_Operation();
        First_Screen.Add_TBox(); // TextBoxを追加
        Application.Run(First_Screen); // Screen_Operationインスタンスを渡してフォームを表示
    }
}
*/