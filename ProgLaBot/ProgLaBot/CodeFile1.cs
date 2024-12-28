using System;
using System.Drawing;
using System.Windows.Forms;

public class GraphicsWithGui : Form
{
    private Button button;
    private TextBox textBox;
    private Panel drawingPanel;

    public GraphicsWithGui()
    {
        // ウィンドウ設定
        this.Text = "Graphics and GUI Sample";
        this.Size = new Size(800, 600);

        // ボタン作成
        button = new Button
        {
            Text = "クリック",
            Location = new Point(10, 10),
            Size = new Size(100, 30)
        };
        button.Click += Button_Click;

        // テキストボックス作成
        textBox = new TextBox
        {
            Location = new Point(120, 10),
            Size = new Size(200, 30)
        };

        // 描画パネル作成
        drawingPanel = new Panel
        {
            Location = new Point(10, 50),
            Size = new Size(760, 500),
            BorderStyle = BorderStyle.FixedSingle
        };
        drawingPanel.Paint += DrawingPanel_Paint;

        // コントロールをフォームに追加
        this.Controls.Add(button);
        this.Controls.Add(textBox);
        this.Controls.Add(drawingPanel);
    }

    // ボタンクリック時のイベントハンドラ
    private void Button_Click(object sender, EventArgs e)
    {
        string inputText = textBox.Text;
        MessageBox.Show($"入力されたテキスト: {inputText}", "通知");
        drawingPanel.Invalidate(); // 再描画
    }

    // 描画パネルの描画イベント
    private void DrawingPanel_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        // 背景塗りつぶし
        g.Clear(Color.White);

        // シンプルな図形描画
        Pen pen = new Pen(Color.Blue, 2);
        Brush brush = new SolidBrush(Color.Red);

        g.DrawRectangle(pen, 50, 50, 200, 100); // 青い枠の四角形
        g.FillEllipse(brush, 300, 50, 100, 100); // 赤い塗りつぶしの円

        // テキスト描画
        Font font = new Font("Arial", 16);
        g.DrawString("リッチなグラフィックの例", font, Brushes.Black, new PointF(50, 200));
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new GraphicsWithGui());
    }
}
