using System.Text.Json.Serialization;

namespace NovelCraft.Utilities.Messages {



  internal record ClientPerformSwapSlotsMessage : MessageBase, IClientMessage {
    [JsonPropertyName("bound_to")]
    public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ServerBound;

    [JsonPropertyName("type")]
    public override IMessage.MessageKind Type => IMessage.MessageKind.PerformSwapSlots;

    [JsonPropertyName("token")]
    public string Token { get; init; } = string.Empty;

    [JsonPropertyName("slot_a")]
    public int SlotA { get; init; }

    [JsonPropertyName("slot_b")]
    public int SlotB { get; init; }
  }
}