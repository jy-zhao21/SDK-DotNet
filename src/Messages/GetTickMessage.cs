using System.Text.Json.Serialization;

namespace NovelCraft.Sdk.Messages;


internal record ClientGetTickMessage : MessageBase, IClientMessage {
  [JsonPropertyName("bound_to")]
  public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ServerBound;

  [JsonPropertyName("type")]
  public override IMessage.MessageKind Type => IMessage.MessageKind.GetTick;

  [JsonPropertyName("token")]
  public required string? Token { get; init; }
}


internal record ServerGetTickMessage : MessageBase {
  [JsonPropertyName("bound_to")]
  public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ClientBound;

  [JsonPropertyName("type")]
  public override IMessage.MessageKind Type => IMessage.MessageKind.GetTick;

  [JsonPropertyName("tick")]
  public required int Tick { get; init; }
}