using System.Text.Json.Serialization;

namespace NovelCraft.Sdk.Messages;


internal record ClientPerformUseMessage : MessageBase, IClientMessage {
  [JsonPropertyName("bound_to")]
  public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ServerBound;

  [JsonPropertyName("type")]
  public override IMessage.MessageKind Type => IMessage.MessageKind.PerformUse;

  [JsonPropertyName("token")]
  public required string? Token { get; init; }

  //   [JsonPropertyName("use_kind")]
  //   public required UseKind UseKind { get; init; }
}