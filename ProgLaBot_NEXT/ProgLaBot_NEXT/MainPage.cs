using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace MyApp
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            // StackLayoutを作成
            var stackLayout = new StackLayout
            {
                Padding = new Thickness(10),
                Children =
                {
                    new Label
                    {
                        Text = "Hello, .NET MAUI!",
                        FontSize = 24,
                        HorizontalOptions = LayoutOptions.Center
                    },
                    new Button
                    {
                        Text = "Click Me",
                        Command = new Command(() => DisplayAlert("Clicked", "Button was clicked", "OK"))
                    }
                }
            };

            // ページのContentにStackLayoutを設定
            Content = stackLayout;
        }
    }
}