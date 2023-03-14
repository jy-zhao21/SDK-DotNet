using System.Text.Json.Serialization;

namespace NovelCraft.Utilities.Messages {



  internal record ClientPerformDropItemMessage : MessageBase, IClientMessage {
    [JsonPropertyName("bound_to")]
    public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ServerBound;

    [JsonPropertyName("type")]
    public override IMessage.MessageKind Type => IMessage.MessageKind.PerformDropItem;

    [JsonPropertyName("token")]
    public string Token { get; init; } = string.Empty;

    public record ItemType {
      [JsonPropertyName("slot")]
      public int Slot { get; init; }

      [JsonPropertyName("count")]
      public int Count { get; init; }
    }

    [JsonPropertyName("drop_items")]
    public List<ItemType> DropItems { get; init; } = new();
  }
}