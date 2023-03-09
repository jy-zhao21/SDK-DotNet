using System.Net.WebSockets;
using NovelCraft.Utilities.Logger;

namespace NovelCraft.Sdk;

internal class Client : IClient {
  public event EventHandler<NovelCraft.Utilities.Messages.IMessage>? AfterMessageReceiveEvent;


  private ClientWebSocket _clientWebSocket = new();
  private ILogger _logger = new Logger("SDK.Client");


  public Client(string host, int port) {
    Uri uri = new($"ws://{host}:{port}");

    while (true) {
      try {
        _clientWebSocket.ConnectAsync(uri, CancellationToken.None).Wait();
        break;
      } catch (Exception e) {
        _logger.Error($"Failed to connect to server: {e.Message}");
        _clientWebSocket = new ClientWebSocket();
      }

      _logger.Info("Retrying...");
    }

    _logger.Info("Connected to server");
  }


  public void Send(NovelCraft.Utilities.Messages.IMessage message) {
    if (this._clientWebSocket.State == WebSocketState.Connecting) {
      this._clientWebSocket.SendAsync(this.GetBuffer(message.Json.ToJsonString()), WebSocketMessageType.Text, false, CancellationToken.None);
    }
  }

  /// <summary>Get buffer from a byte array</summary>
  /// <param name="arr">byte array</param>
  /// <returns> ArraySegment<byte> </returns>
  private ArraySegment<byte> GetBuffer(byte[] array) {
    return new ArraySegment<byte>(array);
  }

  /// <summary>Get buffer from a string</summary>
  /// <param name="str">string</param>
  /// <returns> ArraySegment<byte> </returns>
  private ArraySegment<byte> GetBuffer(string str) {
    return GetBuffer(System.Text.Encoding.UTF8.GetBytes(str));
  }
}