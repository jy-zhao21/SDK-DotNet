using System.Text.Json.Serialization;

namespace NovelCraft.Utilities.Messages {



  internal record ClientPerformCraftMessage : MessageBase, IClientMessage {
    [JsonPropertyName("bound_to")]
    public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ServerBound;

    [JsonPropertyName("type")]
    public override IMessage.MessageKind Type => IMessage.MessageKind.PerformCraft;

    [JsonPropertyName("token")]
    public string Token { get; init; } = string.Empty;

    [JsonPropertyName("item_id_sequence")]
    public List<int?> ItemIdSequence { get; init; } = new();
  }
}