using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;

public class TcpServer
{
    private const int Port = 5000; // 使用するポート
    private const string IpAddress = "127.0.0.1"; // サーバーIP（ローカルホスト）

    // 受信したJSONデータを格納するための構造体
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    private static void Main()
    {
        // フォームの設定
        Form form = new Form();
        form.Text = "座標表示";
        form.Size = new Size(800, 600);

        // タイマーを使って描画を更新
        Timer timer = new Timer();
        timer.Interval = 16; // 約60FPS
        timer.Tick += (sender, e) => form.Invalidate();
        timer.Start();

        // TCPサーバーを開始
        TcpListener listener = new TcpListener(IPAddress.Parse(IpAddress), Port);
        listener.Start();

        // 座標リスト
        var coordinates = new List<Coordinate>();

        // サーバースレッド
        var serverThread = new System.Threading.Thread(() =>
        {
            while (true)
            {
                var client = listener.AcceptTcpClient();
                var stream = client.GetStream();

                byte[] buffer = new byte[1024];
                int bytesRead;

                // データ受信ループ
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string json = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // JSONデータをCoordinateオブジェクトにデシリアライズ
                    try
                    {
                        var coord = JsonConvert.DeserializeObject<Coordinate>(json);
                        coordinates.Add(coord);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("エラー: " + ex.Message);
                    }
                }

                client.Close();
            }
        });

        // サーバースレッド開始
        serverThread.IsBackground = true;
        serverThread.Start();

        // 描画処理
        form.Paint += (sender, e) =>
        {
            foreach (var coord in coordinates)
            {
                e.Graphics.FillEllipse(Brushes.Red, coord.X - 10, coord.Y - 10, 20, 20); // 半径10の円を描画
            }
        };

        // フォームを表示
        Application.Run(form);
    }
}
