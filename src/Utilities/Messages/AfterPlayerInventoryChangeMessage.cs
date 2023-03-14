using System.Text.Json.Serialization;

namespace NovelCraft.Utilities.Messages {

  internal record ServerAfterPlayerInventoryChangeMessage : MessageBase {
    public record ChangeType {
      [JsonPropertyName("player_unique_id")]
      public int PlayerUniqueId { get; init; }

      [JsonPropertyName("change_list")]
      public List<InventoryChangeType> ChangeList { get; init; } = new();

      public record InventoryChangeType {
        [JsonPropertyName("slot")]
        public int Slot { get; init; }

        [JsonPropertyName("count")]
        public int Count { get; init; }

        [JsonPropertyName("item_type_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ItemTypeId { get; init; }
      }
    }


    [JsonPropertyName("bound_to")]
    public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ClientBound;

    [JsonPropertyName("type")]
    public override IMessage.MessageKind Type => IMessage.MessageKind.AfterPlayerInventoryChange;

    [JsonPropertyName("change_list")]
    public List<ChangeType> ChangeList { get; init; } = new();
  }
}