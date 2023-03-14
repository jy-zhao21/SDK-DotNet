using System.Text.Json.Serialization;

namespace NovelCraft.Utilities.Messages {

  internal record ServerAfterEntityPositionChangeMessage : MessageBase {
    public record ChangeType {
      [JsonPropertyName("unique_id")]
      public int UniqueId { get; init; }

      [JsonPropertyName("position")]
      public Position<decimal> Position { get; init; } = new();
    }


    [JsonPropertyName("bound_to")]
    public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ClientBound;

    [JsonPropertyName("type")]
    public override IMessage.MessageKind Type => IMessage.MessageKind.AfterEntityPositionChange;

    [JsonPropertyName("change_list")]
    public List<ChangeType> ChangeList { get; init; } = new();
  }
}