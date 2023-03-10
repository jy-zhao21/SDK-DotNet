using System.Net.WebSockets;
using System.Text.Json.Nodes;
using NovelCraft.Utilities.Logger;
using NovelCraft.Utilities.Messages;

namespace NovelCraft.Sdk;

internal class Client : IClient {
  public event EventHandler<IMessage>? AfterMessageReceiveEvent;


  private const int BufferSize = 1048576;


  /// <summary>
  /// Gets the latency between the client and the server.
  /// </summary>
  public decimal Latency { get; private set; }

  private ClientWebSocket _clientWebSocket;
  private DateTime _lastPingSent = DateTime.Now;
  private ILogger _logger = new Logger("SDK.Client");
  private byte[] _receiveBuffer = new byte[BufferSize];
  private Uri _uri;


  public Client(string host, int port) {
    _uri = new($"ws://{host}:{port}");
    _clientWebSocket = TryConnect();
    _logger.Info("Connected to server");

    Task.Run(() => {
      while (true) {
        ReceiveMessage();
      }
    });
  }


  public void Send(IMessage message) {
    _clientWebSocket.SendAsync(GetBuffer(message.Json.ToJsonString()), WebSocketMessageType.Text, true, CancellationToken.None);
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

  private void ReceiveMessage() {
    try {
      WebSocketReceiveResult result = _clientWebSocket.ReceiveAsync(new ArraySegment<byte>(_receiveBuffer), CancellationToken.None).Result;

      if (result.MessageType == WebSocketMessageType.Close) {
        throw new Exception("Server closed connection");
      }

    } catch (Exception e) {
      _logger.Error($"Failed to receive message: {e.Message}");
      _clientWebSocket = TryConnect();
      return;
    }

    // Counts the valid bytes in the buffer ('\0' is not valid)
    int count = 0;
    for (int i = 0; i < BufferSize; i++) {
      if (_receiveBuffer[i] == 0) {
        break;
      }

      count++;
    }

    try {
      IMessage message = Parser.Parse(JsonNode.Parse(
        System.Text.Encoding.UTF8.GetString(_receiveBuffer[..count]))!);

      AfterMessageReceiveEvent?.Invoke(this, message);
    } catch (Exception e) {
      _logger.Error($"Failed to parse message: {e.Message}");
    }
  }

  private ClientWebSocket TryConnect() {
    ClientWebSocket clientWebSocket = new();
    _logger.Info($"Trying to connect to server at {_uri}...");

    while (true) {
      try {
        clientWebSocket.ConnectAsync(_uri, CancellationToken.None).Wait();
        break;
      } catch (Exception e) {
        _logger.Error($"Failed to connect to server: {e.Message}");
        clientWebSocket = new ClientWebSocket();
      }

      _logger.Info("Retrying...");
    }

    return clientWebSocket;
  }
}