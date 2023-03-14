using System.Text.Json.Serialization;

namespace NovelCraft.Utilities.Messages {

  internal record ServerAfterEntityCreateMessage : MessageBase {
    public record CreationType {
      [JsonPropertyName("entity_type_id")]
      public int EntityTypeId { get; init; }

      [JsonPropertyName("unique_id")]
      public int UniqueId { get; init; }

      [JsonPropertyName("position")]
      public Position<decimal> Position { get; init; } = new();

      [JsonPropertyName("orientation")]
      public Orientation Orientation { get; init; } = new();

      [JsonPropertyName("item_type_id")]
      public int? ItemTypeId { get; init; } = null;

      [JsonPropertyName("health")]
      public decimal? Health { get; init; } = null;
    }


    [JsonPropertyName("bound_to")]
    public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ClientBound;

    [JsonPropertyName("type")]
    public override IMessage.MessageKind Type => IMessage.MessageKind.AfterEntityCreate;

    [JsonPropertyName("creation_list")]
    public List<CreationType> CreationList { get; init; } = new();
  }
}