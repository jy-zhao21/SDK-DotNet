using System.Text.Json.Serialization;

namespace NovelCraft.Utilities.Messages {



  internal record ClientPerformSwitchMainHandSlotMessage : MessageBase, IClientMessage {
    [JsonPropertyName("bound_to")]
    public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ServerBound;

    [JsonPropertyName("type")]
    public override IMessage.MessageKind Type => IMessage.MessageKind.PerformSwitchMainHandSlot;

    [JsonPropertyName("token")]
    public string Token { get; init; } = string.Empty;

    [JsonPropertyName("new_main_hand")]
    public int NewMainHand { get; init; }
  }
}