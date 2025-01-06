using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Maui_PJ;

public partial class MainPage : ContentPage
{
    int count = 0;
    double currentX = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        // スコアを更新
        scoreLabel.Text = $"スコア: {count}";

        // キャラクターの移動（アニメーション）
        currentX += 50; // 移動量を調整
        if (currentX > this.Width - botImage.Width)
        {
            // 画面を超えないようにリセット
            currentX = 0;
        }

        // 画像をアニメーションで移動
        await botImage.TranslateTo(currentX, botImage.Y, 250, Easing.CubicInOut);

        // ボタンのテキストを更新
        if (count == 1)
            CounterBtn.Text = $"クリック {count} 回";
        else
            CounterBtn.Text = $"クリック {count} 回";

        //SemanticScreenReader.Announce(CounterBtn.Text);
    }
}
