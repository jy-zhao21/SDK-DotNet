using System.Text.Json.Serialization;

namespace NovelCraft.Sdk.Messages;


internal record ClientPerformCraftMessage : MessageBase, IClientMessage {
  [JsonPropertyName("bound_to")]
  public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ServerBound;

  [JsonPropertyName("type")]
  public override IMessage.MessageKind Type => IMessage.MessageKind.PerformCraft;

  [JsonPropertyName("token")]
  public required string? Token { get; init; }

  //   [JsonPropertyName("craft_sequence")]
  //   public required CraftSequence CraftSequence { get; init; }
}