using System.Text.Json.Nodes;

namespace NovelCraft.Sdk.Messages;

/// <summary>
/// Represents common interfaces for all messages.
/// </summary>
public interface IMessage {
  /// <summary>
  /// Represents the transmission direction of the message.
  /// </summary>
  public enum BoundToKind {
    /// <summary>
    /// The message is sent from the client to the server.
    /// </summary>
    ServerBound,

    /// <summary>
    /// The message is sent from the server to the client.
    /// </summary>
    ClientBound
  }

  /// <summary>
  /// Represents the type of the message.
  /// </summary>
  public enum MessageKind {
    /// <summary>
    /// The message is an error message.
    /// </summary>
    Error,

    /// <summary>
    /// The message is used to get the blocks and entities.
    /// </summary>
    GetBlocksAndEntities,

    /// <summary>
    /// The message is used to get the player information.
    /// </summary>
    GetPlayerInfo,

    /// <summary>
    /// The message is heartbeat message.
    /// </summary>
    Ping
  }


  /// <summary>
  /// Gets the JSON representation of the message.
  /// </summary>
  public JsonNode Json { get; }

  /// <summary>
  /// Gets the transmission direction of the message.
  /// </summary>
  public BoundToKind BoundTo { get; }

  /// <summary>
  /// Gets the type of the message.
  /// </summary>
  public MessageKind Type { get; }
}