using System.Text.Json.Serialization;

namespace NovelCraft.Sdk.Messages;


internal record ClientPerformSwapSlotsMessage : MessageBase, IClientMessage {
  [JsonPropertyName("bound_to")]
  public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ServerBound;

  [JsonPropertyName("type")]
  public override IMessage.MessageKind Type => IMessage.MessageKind.PerformSwapSlots;

  [JsonPropertyName("token")]
  public required string? Token { get; init; }

  [JsonPropertyName("slots_number")]
  public required int[] SlotsNumber { get; init; }
}