using System.Text.Json.Serialization;

namespace NovelCraft.Sdk.Messages;


internal record ClientPerformMoveMessage : MessageBase, IClientMessage {
  [JsonPropertyName("bound_to")]
  public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ServerBound;

  [JsonPropertyName("type")]
  public override IMessage.MessageKind Type => IMessage.MessageKind.PerformMove;

  [JsonPropertyName("token")]
  public required string? Token { get; init; }

  //   [JsonPropertyName("direction")]
  //   public required Direction Direction { get; init; }
}