using System.Net.WebSockets;
using NovelCraft.Sdk.Utilities.Logger;

namespace NovelCraft.Sdk;

internal class Client : IClient {
  public event EventHandler<NovelCraft.Sdk.Messages.IMessage>? AfterMessageReceiveEvent;


  private ClientWebSocket _clientWebSocket = new();
  private ILogger _logger = new Logger("SDK.Client");


  public Client(string host, int port) {

    Uri uri = new($"ws://{host}:{port}");

    Task task = _clientWebSocket.ConnectAsync(uri, CancellationToken.None);
    task.Wait();
    // Wait for connection to complete
    while (!task.IsCompletedSuccessfully) {
      _logger.Error("Connection failed");
      task = _clientWebSocket.ConnectAsync(uri, CancellationToken.None);
      task.Wait();
    }
  }


  public void Send(NovelCraft.Sdk.Messages.IMessage message) {
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