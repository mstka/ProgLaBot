using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

public class TcpClientApp
{
    private string serverIP = "127.0.0.1"; // サーバーのIPアドレス
    private int port = 50301;
    public TcpClientApp()
    {
    }
    public string Send_method(string message)
    {
        try
        {
            using (TcpClient client = new TcpClient(serverIP, port))
            {
                Console.WriteLine("サーバーに接続しました。");

                using (NetworkStream stream = client.GetStream())
                {
                    // サーバーにメッセージを送信
                    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                    stream.Write(messageBytes, 0, messageBytes.Length);
                    Console.WriteLine("送信: " + message);

                    // サーバーからの返信を受信
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string responseMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("受信: " + responseMessage);

                    return responseMessage;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("エラー: " + ex.Message);
            return "ERROR";
        }
    }
}


