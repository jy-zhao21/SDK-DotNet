using System.Text.Json.Serialization;

namespace NovelCraft.Utilities.Messages {

  internal record ServerAfterEntityOrientationChangeMessage : MessageBase {
    public record ChangeType {
      [JsonPropertyName("unique_id")]
      public int UniqueId { get; init; }

      [JsonPropertyName("orientation")]
      public Orientation Orientation { get; init; } = new();
    }


    [JsonPropertyName("bound_to")]
    public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ClientBound;

    [JsonPropertyName("type")]
    public override IMessage.MessageKind Type => IMessage.MessageKind.AfterEntityOrientationChange;

    [JsonPropertyName("change_list")]
    public List<ChangeType> ChangeList { get; init; } = new();
  }
}