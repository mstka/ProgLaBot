using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace MyApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // MauiApp を作成してビルドする
            var app = MauiProgram.CreateMauiApp();
            app.Run(args); // Run メソッドを削除して、IHost を使うように修正
        }
    }
}
