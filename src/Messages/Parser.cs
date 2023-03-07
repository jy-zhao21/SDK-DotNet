using System.Text.Json;
using System.Text.Json.Nodes;

namespace NovelCraft.Sdk.Messages;

/// <summary>
/// Parses messages from JSON.
/// </summary>
public static class Parser {
  /// <summary>
  /// Parses a message from JSON.
  /// </summary>
  public static IMessage Parse(JsonNode json) {
    IMessage.BoundToKind boundTo = (IMessage.BoundToKind)(int)json["bound_to"]!;
    IMessage.MessageKind kind = (IMessage.MessageKind)(int)json["type"]!;

    return (boundTo, kind) switch {
      (IMessage.BoundToKind.ClientBound, IMessage.MessageKind.Error) => JsonSerializer.Deserialize<ErrorMessage>(json!.ToJsonString())!,
      (IMessage.BoundToKind.ServerBound, IMessage.MessageKind.GetBlocksAndEntities) => JsonSerializer.Deserialize<ClientGetBlocksAndEntitiesMessage>(json!.ToJsonString())!,
      (IMessage.BoundToKind.ClientBound, IMessage.MessageKind.GetBlocksAndEntities) => JsonSerializer.Deserialize<ServerGetBlocksAndEntitiesMessage>(json!.ToJsonString())!,
      _ => throw new NotImplementedException()
    };
  }
}