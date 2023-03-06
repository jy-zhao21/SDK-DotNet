namespace NovelCraft.Sdk.Messages;

/// <summary>
/// Represents common interfaces for all messages sent from the client to the server.
/// </summary>
public interface IClientMessage : IMessage {
  /// <summary>
  /// Gets the token of the client.
  /// </summary>
  public string Token { get; init; }
}