using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using ImGuiNET;
using System;

class Program
{
    static void Main(string[] args)
    {
        // ウィンドウの作成
        using (var gameWindow = new GameWindow(800, 600, GraphicsMode.Default, "ImGui + OpenTK Game"))
        {
            gameWindow.Load += (sender, e) =>
            {
                // 初期化コード（OpenGLやImGuiの初期化など）
                GL.ClearColor(Color4.CornflowerBlue);
            };

            gameWindow.RenderFrame += (sender, e) =>
            {
                // 画面の描画
                GL.Clear(ClearBufferMask.ColorBufferBit);

                // ImGuiのUI描画
                DrawImGui();

                gameWindow.SwapBuffers();
            };

            gameWindow.Run(60.0); // 60FPSでゲームを実行
        }
    }

    private static void DrawImGui()
    {
        ImGui.NewFrame();

        // ImGuiでUIを描画
        ImGui.Text("Hello, ImGui!");
        if (ImGui.Button("Click me"))
        {
            Console.WriteLine("Button clicked!");
        }

        ImGui.Render();
    }
}
