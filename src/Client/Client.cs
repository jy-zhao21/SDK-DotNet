using System.Net.WebSockets;
namespace NovelCraft.Sdk.Client;

internal class Client : IClient {
  private ClientWebSocket _clientWebSocket = new();
  public event EventHandler<NovelCraft.Sdk.Messages.IMessage>? MessageReceived;
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


  public void Connect(Uri uri) {
    Task task = _clientWebSocket.ConnectAsync(uri, CancellationToken.None);
    task.Wait();
    // Wait for connection to complete
    while (!task.IsCompletedSuccessfully) {
      task = _clientWebSocket.ConnectAsync(uri, CancellationToken.None);
      task.Wait();
    }
  }


  public void Send(NovelCraft.Sdk.Messages.IMessage message) {
    if (this._clientWebSocket.State == WebSocketState.Connecting) {
      this._clientWebSocket.SendAsync(this.GetBuffer(message.Json.ToJsonString()), WebSocketMessageType.Text, false, CancellationToken.None);
    }
  }
}