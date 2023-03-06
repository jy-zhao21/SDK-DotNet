namespace NovelCraft.Sdk.Client;

/// <summary>
/// Represents common interfaces for all communication clients.
/// </summary>
public interface IClient {
  /// <summary>
  /// Occurs when a message is received from the server.
  /// </summary>
  public event EventHandler<NovelCraft.Sdk.Messages.IMessage>? MessageReceived;


  /// <summary>
  /// Connects to the server.
  /// </summary>
  public void Connect();

  /// <summary>
  /// Disconnects from the server.
  /// </summary>
  public void Disconnect();

  /// <summary>
  /// Sends a message to the server.
  /// </summary>
  /// <param name="message">The message to be sent.</param>
  public void Send(NovelCraft.Sdk.Messages.IMessage message);
}