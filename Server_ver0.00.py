import socket
import threading

# 最大同時接続数
MAX_CONNECTIONS = 10

# クライアントごとの通信を処理する関数
def handle_client(client_socket, client_address):
    try:
        while True:
            data = client_socket.recv(1024)  # データを受信 (最大1024バイト)
            if not data:
                break  # 接続が切れた場合はループを抜ける

            client_socket.sendall(data)  # データをそのまま送り返す（おうむ返し）
    except Exception as e:
        print(f"[ERROR] {client_address}: {e}")
    finally:
        client_socket.close()
        print(f"[INFO] Connection closed: {client_address}")

# メインサーバー関数
def main(IP_addr, port):

    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)  # ソケット再利用を有効化

    server_socket.bind((IP_addr, port))
    server_socket.listen(MAX_CONNECTIONS)

    # 接続を管理するスレッドリスト
    threads = []

    try:
        while True:
            client_socket, client_address = server_socket.accept()
            # 新しい接続ごとにスレッドを作成
            threads.append(threading.Thread(target=handle_client, args=(client_socket, client_address)))
            threads[-1].start()

            # 古いスレッドの整理（終了したスレッドを削除）
            threads = [t for t in threads if t.is_alive()]
    except KeyboardInterrupt:
        print("\n[INFO] Server shutting down...")
    finally:
        server_socket.close()
        for t in threads:
            t.join()

if __name__ == "__main__":
    main('127.0.0.1', 60000)
